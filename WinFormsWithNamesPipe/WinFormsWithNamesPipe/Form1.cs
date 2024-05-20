using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using WinFormsWithNamesPipe.service;

namespace WinFormsWithNamesPipe
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        private Process pythonProcess;
        private bool needRetry;

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
            public required string Action { get; set; }
            public required string Message { get; set; }
        }

        private NamedPipeClientStream pipeClient;

        public Form1()
        {
            // 初始化表單元件
            InitializeComponent();

            // 初始化NamedPipe Server
            NamedPipeServer.OnMessageReceived += UpdateSystemMsgUI;
            NamedPipeServer.onCompareResultStatusReceived += UpdateCompareResultUI;
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

        private void Form1_Closing(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;

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
                            Action = "closeProgram",
                            Data = new { }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 等待Python應用程式回傳訊息
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "closeProgram")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        // 確保進程存在且尚未退出
                        if (pythonProcess != null && !pythonProcess.HasExited)
                        {
                            // 嘗試正常結束進程
                            pythonProcess.CloseMainWindow();
                            pythonProcess.Close();
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        private void startBuildIrisBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                                season_id = seasonIdTextBox.Text,
                                loft_id = loftIdTextBox.Text,
                                feet_number = feetNumberTextBox.Text,
                                folder_path = @"C:\iris_data",
                                left_build_num = leftBuildNum.Value,
                                right_build_num = rightBuildNum.Value
                            }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 接收來自Python的資料
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "startBuildIris")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // 模擬開始建檔，調整按鈕狀態
                            // disabled button
                            startBuildIrisBtn.Enabled = false;
                            startCompareIrisBtn.Enabled = false;
                            stopCompareIrisBtn.Enabled = false;

                            // enabled button
                            stopBuildIrisBtn.Enabled = true;

                            // 更新UI
                            systemMsg.Text = "開始建檔";
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        private void stopBuildIrisBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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

                        while (recivedResult.Action != "stopBuildIris")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // 模擬中斷建檔，調整按鈕狀態
                            // disabled button
                            stopBuildIrisBtn.Enabled = false;
                            stopCompareIrisBtn.Enabled = false;

                            // enabled button
                            startBuildIrisBtn.Enabled = true;
                            startCompareIrisBtn.Enabled = true;

                            // 更新UI
                            systemMsg.Text = "中斷建檔";
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        // 更新系統訊息
        private void UpdateSystemMsgUI(string message, string action)
        {
            // 確保跨執行序的操作安全
            if (InvokeRequired)
            {
                Invoke(new Action<string, string>(UpdateSystemMsgUI), message, action);
            }
            else
            {
                // 更新UI
                systemMsg.Text = message;

                // 如果傳入的action = build_iris_error or compare_iris_error
                // 則不須後續調整按鈕狀態
                if (action == "build_iris_error" || action == "compare_iris_error")
                {
                    return;
                }

                // 模擬建檔比對完成，調整按鈕狀態
                // disabled button
                stopBuildIrisBtn.Enabled = false;
                stopCompareIrisBtn.Enabled = false;

                // enabled button
                startBuildIrisBtn.Enabled = true;
                startCompareIrisBtn.Enabled = true;
            }
        }

        // 更新顯示比對結果
        private void UpdateCompareResultUI(int statusCode)
        {
            // 確保跨執行序的操作安全
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCompareResultUI), statusCode);
            }
            else
            {
                // 更新UI
                // 如果statusCode = 0 代表成功, 將compareResult背景色設為綠色
                // 如果status = 其他數值 代表失敗, 將compareResult背景色設為紅色
                compareResult.BackColor = statusCode == 0 ? Color.Green : Color.Red;
            }
        }

        // 開啟python程式
        private void openProgramBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                                Data = new
                                {
                                    single_camera_mode = openCameraParamComboBox.SelectedItem.ToString()
                                }
                            };
                            string message = JsonSerializer.Serialize(operation);

                            // 執行指令
                            sw.WriteLine(message);

                            // 等待Python應用程式回傳訊息
                            string result = sr.ReadLine();
                            RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                            while (recivedResult.Action != "openCamera")
                            {
                                // 接收來自Python的資料
                                result = sr.ReadLine();
                                recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                            }

                            if (recivedResult.Status == "error")
                            {
                                MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        private void openCameraBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                        // action: openCamera
                        Operation operation = new Operation
                        {
                            Action = "openCamera",
                            Data = new
                            {
                                single_camera_mode = openCameraParamComboBox.SelectedItem.ToString()
                            }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 等待Python應用程式回傳訊息
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "openCamera")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        private void closeCameraBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                        // action: closeCamera
                        Operation operation = new Operation
                        {
                            Action = "closeCamera",
                            Data = new { }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 等待Python應用程式回傳訊息
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "closeCamera")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        // 開始虹膜比對
        private void startCompareIrisBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                            Action = "startCompareIris",
                            Data = new
                            {
                                season_id = seasonIdTextBox.Text,
                                loft_id = loftIdTextBox.Text,
                                feet_number = feetNumberTextBox.Text,
                                folder_path = @"C:\iris_data",
                                threshold = 0.35
                            }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 接收來自Python的資料
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "startCompareIris")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // 模擬開始比對，調整按鈕狀態
                            // disabled button
                            startBuildIrisBtn.Enabled = false;
                            stopBuildIrisBtn.Enabled = false;
                            startCompareIrisBtn.Enabled = false;

                            // enabled button
                            stopCompareIrisBtn.Enabled = true;

                            // 更新UI
                            systemMsg.Text = "開始比對";

                            // 重置比對結果背景色
                            compareResult.BackColor = SystemColors.MenuBar;
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        // 停止虹膜比對
        private void stopCompareIrisBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                            Action = "stopCompareIris",
                            Data = new { }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 接收來自Python的資料
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "stopCompareIris")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // 模擬中斷比對，調整按鈕狀態
                            // disabled button
                            stopBuildIrisBtn.Enabled = false;
                            stopCompareIrisBtn.Enabled = false;

                            // enabled button
                            startBuildIrisBtn.Enabled = true;
                            startCompareIrisBtn.Enabled = true;

                            // 更新UI
                            systemMsg.Text = "中斷比對";
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        private void compareFocusOnLeftBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                        // action: setFocusCamera
                        Operation operation = new Operation
                        {
                            Action = "setCompareFocusCamera",
                            Data = new
                            {
                                camera_src = "left"
                            }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 等待Python應用程式回傳訊息
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "setCompareFocusCamera")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        private void compareFocusOnRightBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                        // action: setFocusCamera
                        Operation operation = new Operation
                        {
                            Action = "setCompareFocusCamera",
                            Data = new
                            {
                                camera_src = "right"
                            }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 等待Python應用程式回傳訊息
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "setCompareFocusCamera")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 將openCameraParamComboBox 預設值設為 "disable"
            openCameraParamComboBox.SelectedIndex = 0;
        }

        private void flipLeftCameraBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                        // action: setFocusCamera
                        Operation operation = new Operation
                        {
                            Action = "flipCamera",
                            Data = new
                            {
                                camera_src = "left"
                            }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 等待Python應用程式回傳訊息
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "flipCamera")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        private void flipRightCameraBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                        // action: flipCamera
                        Operation operation = new Operation
                        {
                            Action = "flipCamera",
                            Data = new
                            {
                                camera_src = "right"
                            }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 等待Python應用程式回傳訊息
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "flipCamera")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }

        private void reloadEnvSettingBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                        // action: reloadEnvSettings
                        Operation operation = new Operation
                        {
                            Action = "reloadEnvSettings",
                            Data = new {}
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // 等待Python應用程式回傳訊息
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "reloadEnvSettings")
                        {
                            // 接收來自Python的資料
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (IOException ex)
                {
                    needRetry = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!needRetry)
                {
                    break;
                }
            }
        }
    }
}
