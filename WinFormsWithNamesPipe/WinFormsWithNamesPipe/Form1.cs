using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using WinFormsWithNamesPipe.service;

namespace WinFormsWithNamesPipe
{
    public partial class Form1 : Form
    {
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
            pipeClient = new NamedPipeClientStream(".", "PythonPipe", PipeDirection.InOut);
            pipeClient.Connect(5000); // Timeout after 5000ms
        }

        // 設定視窗位置
        private void setPositionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pipeClient.IsConnected)
                {
                    InitializePipeClient();
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
                if (!pipeClient.IsConnected)
                {
                    InitializePipeClient();
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

        // 控制camera 是否跟隨表單顯示
        private void Form1_Activated(object sender, EventArgs e)
        {
            try
            {
                if (!pipeClient.IsConnected)
                {
                    InitializePipeClient();
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    sw.AutoFlush = true;

                    // 將資料組成json格式
                    Operation operation = new Operation
                    {
                        Action = "setActivated",
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

        // 控制camera 是否跟隨表單隱藏
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            // 判斷視窗是否最小化
            if (WindowState == FormWindowState.Minimized)
            {
                try
                {
                    if (!pipeClient.IsConnected)
                    {
                        InitializePipeClient();
                    }

                    using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                    using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                    {
                        sw.AutoFlush = true;

                        // 將資料組成json格式
                        Operation operation = new Operation
                        {
                            Action = "setMinimized",
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

        private void Form1_Closing(object sender, EventArgs e)
        {
            try
            {
                if (!pipeClient.IsConnected)
                {
                    InitializePipeClient();
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    sw.AutoFlush = true;

                    // 將資料組成json格式
                    Operation operation = new Operation
                    {
                        Action = "setMinimized",
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

        private void startBuildIrisBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pipeClient.IsConnected)
                {
                    InitializePipeClient();
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
                if (!pipeClient.IsConnected)
                {
                    InitializePipeClient();
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
    }
}
