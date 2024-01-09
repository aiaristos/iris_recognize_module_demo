using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using WinFormsWithNamesPipe.service;

namespace WinFormsWithNamesPipe
{
    public partial class Form1 : Form
    {
        // �w�q�n�ǰe��Python����Ʈ榡
        public class Operation
        {
            public required string Action { get; set; }
            public required object Data { get; set; }
        }

        // �w�q�n�����Ӧ�Python����Ʈ榡
        public class RecivedResult
        {
            public required string Status { get; set; }
            public required string Message { get; set; }
        }

        private NamedPipeClientStream pipeClient;

        public Form1()
        {
            // ��l�ƪ�椸��
            InitializeComponent();

            // ��l��NamedPipe Server
            NamedPipeServer.OnMessageReceived += UpdateSystemMsgUI;
            NamedPipeServer.StartServer();

            // ��l��NamedPipe Client
            InitializePipeClient();
        }

        // ��l�ƭn�Ω󷾳q��NamedPipe
        private void InitializePipeClient()
        {
            pipeClient = new NamedPipeClientStream(".", "PythonPipe", PipeDirection.InOut);
            pipeClient.Connect(5000); // Timeout after 5000ms
        }

        // �]�w������m
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
                    decimal positionX = positionXValue.Value; // ���o�Τ��J��X�y��
                    decimal positionY = positionYValue.Value; // ���o�Τ��J��Y�y��

                    // �N��Ʋզ�json�榡
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

        // �]�w�����j�p
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
                    decimal frameWidth = frameWidthValue.Value; // ���o�Τ��J��X�y��
                    decimal frameHeight = frameHeightValue.Value; // ���o�Τ��J��Y�y��

                    // �N��Ʋզ�json�榡
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

        // ����camera �O�_���H������
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

                    // �N��Ʋզ�json�榡
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

        // ����camera �O�_���H�������
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            // �P�_�����O�_�̤p��
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

                        // �N��Ʋզ�json�榡
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

                    // �N��Ʋզ�json�榡
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

                    // �N��Ʋզ�json�榡
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

                    // �����Ӧ�Python�����
                    string result = sr.ReadLine();
                    RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                    if (recivedResult.Status == "Error")
                    {
                        MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // �����}�l���ɡA�վ���s���A
                        // disabled button
                        startBuildIrisBtn.Enabled = false;

                        // enabled button
                        stopBuildIrisBtn.Enabled = true;

                        // ��sUI
                        systemMsg.Text = "�}�l����";
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

                    // �N��Ʋզ�json�榡
                    Operation operation = new Operation
                    {
                        Action = "stopBuildIris",
                        Data = new { }
                    };
                    string message = JsonSerializer.Serialize(operation);

                    sw.WriteLine(message);

                    // �����Ӧ�Python�����
                    string result = sr.ReadLine();
                    RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                    if (recivedResult.Status == "Error")
                    {
                        MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // �������_���ɡA�վ���s���A
                        // disabled button
                        stopBuildIrisBtn.Enabled = false;

                        // enabled button
                        startBuildIrisBtn.Enabled = true;

                        // ��sUI
                        systemMsg.Text = "���_����";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ��s�t�ΰT��
        private void UpdateSystemMsgUI(string message)
        {
            // �T�O�����Ǫ��ާ@�w��
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateSystemMsgUI), message);
            }
            else
            {
                // ��sUI
                systemMsg.Text = message;

                // �������ɧ����A�վ���s���A
                // disabled button
                stopBuildIrisBtn.Enabled = false;

                // enabled button
                startBuildIrisBtn.Enabled = true;
            }
        }
    }
}
