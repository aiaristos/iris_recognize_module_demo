using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using WinFormsWithNamesPipe.service;
using static WinFormsWithNamesPipe.Form1;

namespace WinFormsWithNamesPipe
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        private Process pythonProcess;

        // 定義要傳送給Python的資料格式
        public class Operation
        {
            public required string Action { get; set; }
            public required object Data { get; set; }
        }

        // 定義要接收來自Python的資料格式
        public class RecivedResult
        {
            public required string Status { get; set; }
            public required string Message { get; set; }
        }

        private NamedPipeClientStream pipeClient;

        public Form1()
        {
            // 初始化表單元件
            InitializeComponent();

            // 初始化NamedPipe Server
            NamedPipeServer.OnMessageReceived += UpdateSystemMsgUI;
            NamedPipeServer.StartServer();

            // 初始化NamedPipe Client
            InitializePipeClient();
        }

        // 初始化要用於溝通的NamedPipe
        private void InitializePipeClient()
        {
            try
            {
                pipeClient = new NamedPipeClientStream(".", "PythonPipe", PipeDirection.InOut);
                pipeClient.Connect(1000); // Timeout after 1000ms
            }
            catch (Exception)
            {
                pipeClient.Dispose();
            }
        }

        // 檢查NamedPipe是否連線
        private bool CheckPipeClientConnection()
        {
            // 初始化NamedPipe Client
            if (pipeClient == null)
            {
                InitializePipeClient();
            }
            else if (!pipeClient.IsConnected)
            {
                InitializePipeClient();
            }

            try
            {
                return pipeClient.IsConnected;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // 設定視窗位置
        private void setPositionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPipeClientConnection())
                {
                    // 如果沒有連接，直接結束此方法
                    // 顯示錯誤訊息
                    MessageBox.Show("NamedPipe 連線失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    sw.AutoFlush = true;
                    decimal positionX = positionXValue.Value; // 取得用戶輸入的X座標
                    decimal positionY = positionYValue.Value; // 取得用戶輸入的Y座標

                    // 將資料組成json格式
                    // action: setPosition
                    // data: { x: 100, y: 200 }
                    Operation operation = new Operation
                    {
                        Action = "setPosition",
                        Data = new { x = positionX, y = positionY }
                    };
                    string message = JsonSerializer.Serialize(operation);

                    sw.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 設定視窗大小
        private void setFrameSizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPipeClientConnection())
                {
                    // 如果沒有連接，直接結束此方法
                    // 顯示錯誤訊息
                    MessageBox.Show("NamedPipe 連線失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    sw.AutoFlush = true;
                    decimal frameWidth = frameWidthValue.Value; // 取得用戶輸入的X座標
                    decimal frameHeight = frameHeightValue.Value; // 取得用戶輸入的Y座標

                    // 將資料組成json格式
                    // action: setPosition
                    // data: { x: 100, y: 200 }
                    Operation operation = new Operation
                    {
                        Action = "setFrameSize",
                        Data = new { width = frameWidth, height = frameHeight }
                    };
                    string message = JsonSerializer.Serialize(operation);

                    sw.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPipeClientConnection())
                {
                    // 如果沒有連接，直接放棄透過api關閉Python應用程式
                    // 直接進行關閉
                    // 確保進程存在且尚未退出
                    if (pythonProcess != null && !pythonProcess.HasExited)
                    {
                        // 嘗試正常結束進程
                        pythonProcess.CloseMainWindow();
                        pythonProcess.Close();
                    }

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    sw.AutoFlush = true;

                    // 將資料組成json格式
                    Operation operation = new Operation
                    {
                        Action = "closePrograme",
                        Data = new { }
                    };
                    string message = JsonSerializer.Serialize(operation);

                    sw.WriteLine(message);

                    // 等待Python應用程式回傳訊息
                    sr.ReadLine();

                    // 確保進程存在且尚未退出
                    if (pythonProcess != null && !pythonProcess.HasExited)
                    {
                        // 嘗試正常結束進程
                        pythonProcess.CloseMainWindow();
                        pythonProcess.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startBuildIrisBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPipeClientConnection())
                {
                    // 如果沒有連接，直接結束此方法
                    // 顯示錯誤訊息
                    MessageBox.Show("NamedPipe 連線失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    sw.AutoFlush = true;

                    // 將資料組成json格式
                    Operation operation = new Operation
                    {
                        Action = "startBuildIris",
                        Data = new
                        {
                            season_id = "test_season",
                            loft_id = "002",
                            feet_number = "12345",
                            folder_path = @"C:\iris_data"
                        }
                    };
                    string message = JsonSerializer.Serialize(operation);

                    sw.WriteLine(message);

                    // 接收來自Python的資料
                    string result = sr.ReadLine();
                    RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                    if (recivedResult.Status == "Error")
                    {
                        MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // 模擬開始建檔，調整按鈕狀態
                        // disabled button
                        startBuildIrisBtn.Enabled = false;

                        // enabled button
                        stopBuildIrisBtn.Enabled = true;

                        // 更新UI
                        systemMsg.Text = "開始建檔";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void stopBuildIrisBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPipeClientConnection())
                {
                    // 如果沒有連接，直接結束此方法
                    // 顯示錯誤訊息
                    MessageBox.Show("NamedPipe 連線失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    sw.AutoFlush = true;

                    // 將資料組成json格式
                    Operation operation = new Operation
                    {
                        Action = "stopBuildIris",
                        Data = new { }
                    };
                    string message = JsonSerializer.Serialize(operation);

                    sw.WriteLine(message);

                    // 接收來自Python的資料
                    string result = sr.ReadLine();
                    RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                    if (recivedResult.Status == "Error")
                    {
                        MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // 模擬中斷建檔，調整按鈕狀態
                        // disabled button
                        stopBuildIrisBtn.Enabled = false;

                        // enabled button
                        startBuildIrisBtn.Enabled = true;

                        // 更新UI
                        systemMsg.Text = "中斷建檔";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 更新系統訊息
        private void UpdateSystemMsgUI(string message)
        {
            // 確保跨執行序的操作安全
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateSystemMsgUI), message);
            }
            else
            {
                // 更新UI
                systemMsg.Text = message;

                // 模擬建檔完成，調整按鈕狀態
                // disabled button
                stopBuildIrisBtn.Enabled = false;

                // enabled button
                startBuildIrisBtn.Enabled = true;
            }
        }

        // 開啟python程式
        private void openProgramBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 啟動 Python 應用程式的 exe
                pythonProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = textBox1.Text,
                        UseShellExecute = false
                    }
                };
                pythonProcess.Start();

                // 等待 Python 應用程式GUI建立
                pythonProcess.WaitForInputIdle();

                // 將 Python 應用程式窗口嵌入到 WinForms 中
                SetParent(pythonProcess.MainWindowHandle, cameraPanel.Handle);

                // 移動到最左上角
                // 取出 cameraPanel 的長寬
                int width = cameraPanel.Width;
                int height = cameraPanel.Height;

                MoveWindow(pythonProcess.MainWindowHandle, 0, 0, width, height, true);

                try
                {
                    if (!CheckPipeClientConnection())
                    {
                        // 如果沒有連接，直接結束此方法
                        // 顯示錯誤訊息
                        MessageBox.Show("NamedPipe 連線失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, bufferSize: -1, leaveOpen: true))
                    using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                    {
                        sw.AutoFlush = true;

                        // 將資料組成json格式
                        Operation operation = new Operation
                        {
                            Action = "openCamera",
                            Data = new { }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        // 執行指令
                        sw.WriteLine(message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openCameraBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPipeClientConnection())
                {
                    // 如果沒有連接，直接結束此方法
                    // 顯示錯誤訊息
                    MessageBox.Show("NamedPipe 連線失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    // 將資料組成json格式
                    // action: openCamera
                    Operation operation = new Operation
                    {
                        Action = "openCamera",
                        Data = new { }
                    };
                    string message = JsonSerializer.Serialize(operation);

                    sw.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeCameraBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPipeClientConnection())
                {
                    // 如果沒有連接，直接結束此方法
                    // 顯示錯誤訊息
                    MessageBox.Show("NamedPipe 連線失敗", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    // 將資料組成json格式
                    // action: closeCamera
                    Operation operation = new Operation
                    {
                        Action = "closeCamera",
                        Data = new { }
                    };
                    string message = JsonSerializer.Serialize(operation);

                    sw.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
