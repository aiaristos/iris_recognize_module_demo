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

        // �ˬdNamedPipe�O�_�s�u
        private bool CheckPipeClientConnection()
        {
            // ��l��NamedPipe Client
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

        // �]�w������m
        private void setPositionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPipeClientConnection())
                {
                    // �p�G�S���s���A������������k
                    // ��ܿ��~�T��
                    MessageBox.Show("NamedPipe �s�u����", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
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
                if (!CheckPipeClientConnection())
                {
                    // �p�G�S���s���A������������k
                    // ��ܿ��~�T��
                    MessageBox.Show("NamedPipe �s�u����", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
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

        private void Form1_Closing(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPipeClientConnection())
                {
                    // �p�G�S���s���A�������z�Lapi����Python���ε{��
                    // �����i������
                    // �T�O�i�{�s�b�B�|���h�X
                    if (pythonProcess != null && !pythonProcess.HasExited)
                    {
                        // ���ե��`�����i�{
                        pythonProcess.CloseMainWindow();
                        pythonProcess.Close();
                    }

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    sw.AutoFlush = true;

                    // �N��Ʋզ�json�榡
                    Operation operation = new Operation
                    {
                        Action = "closePrograme",
                        Data = new { }
                    };
                    string message = JsonSerializer.Serialize(operation);

                    sw.WriteLine(message);

                    // ����Python���ε{���^�ǰT��
                    sr.ReadLine();

                    // �T�O�i�{�s�b�B�|���h�X
                    if (pythonProcess != null && !pythonProcess.HasExited)
                    {
                        // ���ե��`�����i�{
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
                    // �p�G�S���s���A������������k
                    // ��ܿ��~�T��
                    MessageBox.Show("NamedPipe �s�u����", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
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
                if (!CheckPipeClientConnection())
                {
                    // �p�G�S���s���A������������k
                    // ��ܿ��~�T��
                    MessageBox.Show("NamedPipe �s�u����", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
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

        // �}��python�{��
        private void openProgramBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // �Ұ� Python ���ε{���� exe
                pythonProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = textBox1.Text,
                        UseShellExecute = false
                    }
                };
                pythonProcess.Start();

                // ���� Python ���ε{��GUI�إ�
                pythonProcess.WaitForInputIdle();

                // �N Python ���ε{�����f�O�J�� WinForms ��
                SetParent(pythonProcess.MainWindowHandle, cameraPanel.Handle);

                // ���ʨ�̥��W��
                // ���X cameraPanel �����e
                int width = cameraPanel.Width;
                int height = cameraPanel.Height;

                MoveWindow(pythonProcess.MainWindowHandle, 0, 0, width, height, true);

                try
                {
                    if (!CheckPipeClientConnection())
                    {
                        // �p�G�S���s���A������������k
                        // ��ܿ��~�T��
                        MessageBox.Show("NamedPipe �s�u����", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, bufferSize: -1, leaveOpen: true))
                    using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                    {
                        sw.AutoFlush = true;

                        // �N��Ʋզ�json�榡
                        Operation operation = new Operation
                        {
                            Action = "openCamera",
                            Data = new { }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        // ������O
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
                    // �p�G�S���s���A������������k
                    // ��ܿ��~�T��
                    MessageBox.Show("NamedPipe �s�u����", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    // �N��Ʋզ�json�榡
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
                    // �p�G�S���s���A������������k
                    // ��ܿ��~�T��
                    MessageBox.Show("NamedPipe �s�u����", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                using (StreamWriter sw = new StreamWriter(pipeClient, Encoding.UTF8, -1, leaveOpen: true))
                using (StreamReader sr = new StreamReader(pipeClient, Encoding.UTF8, true, -1, leaveOpen: true))
                {
                    // �N��Ʋզ�json�榡
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
