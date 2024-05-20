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
            public required string Action { get; set; }
            public required string Message { get; set; }
        }

        private NamedPipeClientStream pipeClient;

        public Form1()
        {
            // ��l�ƪ�椸��
            InitializeComponent();

            // ��l��NamedPipe Server
            NamedPipeServer.OnMessageReceived += UpdateSystemMsgUI;
            NamedPipeServer.onCompareResultStatusReceived += UpdateCompareResultUI;
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

        private void Form1_Closing(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;

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
                            Action = "closeProgram",
                            Data = new { }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // ����Python���ε{���^�ǰT��
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "closeProgram")
                        {
                            // �����Ӧ�Python�����
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        // �T�O�i�{�s�b�B�|���h�X
                        if (pythonProcess != null && !pythonProcess.HasExited)
                        {
                            // ���ե��`�����i�{
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

                        // �����Ӧ�Python�����
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "startBuildIris")
                        {
                            // �����Ӧ�Python�����
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // �����}�l���ɡA�վ���s���A
                            // disabled button
                            startBuildIrisBtn.Enabled = false;
                            startCompareIrisBtn.Enabled = false;
                            stopCompareIrisBtn.Enabled = false;

                            // enabled button
                            stopBuildIrisBtn.Enabled = true;

                            // ��sUI
                            systemMsg.Text = "�}�l����";
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

                        while (recivedResult.Action != "stopBuildIris")
                        {
                            // �����Ӧ�Python�����
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // �������_���ɡA�վ���s���A
                            // disabled button
                            stopBuildIrisBtn.Enabled = false;
                            stopCompareIrisBtn.Enabled = false;

                            // enabled button
                            startBuildIrisBtn.Enabled = true;
                            startCompareIrisBtn.Enabled = true;

                            // ��sUI
                            systemMsg.Text = "���_����";
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

        // ��s�t�ΰT��
        private void UpdateSystemMsgUI(string message, string action)
        {
            // �T�O�����Ǫ��ާ@�w��
            if (InvokeRequired)
            {
                Invoke(new Action<string, string>(UpdateSystemMsgUI), message, action);
            }
            else
            {
                // ��sUI
                systemMsg.Text = message;

                // �p�G�ǤJ��action = build_iris_error or compare_iris_error
                // �h��������վ���s���A
                if (action == "build_iris_error" || action == "compare_iris_error")
                {
                    return;
                }

                // �������ɤ�粒���A�վ���s���A
                // disabled button
                stopBuildIrisBtn.Enabled = false;
                stopCompareIrisBtn.Enabled = false;

                // enabled button
                startBuildIrisBtn.Enabled = true;
                startCompareIrisBtn.Enabled = true;
            }
        }

        // ��s��ܤ�ﵲ�G
        private void UpdateCompareResultUI(int statusCode)
        {
            // �T�O�����Ǫ��ާ@�w��
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateCompareResultUI), statusCode);
            }
            else
            {
                // ��sUI
                // �p�GstatusCode = 0 �N���\, �NcompareResult�I����]�����
                // �p�Gstatus = ��L�ƭ� �N����, �NcompareResult�I����]������
                compareResult.BackColor = statusCode == 0 ? Color.Green : Color.Red;
            }
        }

        // �}��python�{��
        private void openProgramBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                                Data = new
                                {
                                    single_camera_mode = openCameraParamComboBox.SelectedItem.ToString()
                                }
                            };
                            string message = JsonSerializer.Serialize(operation);

                            // ������O
                            sw.WriteLine(message);

                            // ����Python���ε{���^�ǰT��
                            string result = sr.ReadLine();
                            RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                            while (recivedResult.Action != "openCamera")
                            {
                                // �����Ӧ�Python�����
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

                        // ����Python���ε{���^�ǰT��
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "openCamera")
                        {
                            // �����Ӧ�Python�����
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
                        // action: closeCamera
                        Operation operation = new Operation
                        {
                            Action = "closeCamera",
                            Data = new { }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // ����Python���ε{���^�ǰT��
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "closeCamera")
                        {
                            // �����Ӧ�Python�����
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

        // �}�l�i�����
        private void startCompareIrisBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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

                        // �����Ӧ�Python�����
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "startCompareIris")
                        {
                            // �����Ӧ�Python�����
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // �����}�l���A�վ���s���A
                            // disabled button
                            startBuildIrisBtn.Enabled = false;
                            stopBuildIrisBtn.Enabled = false;
                            startCompareIrisBtn.Enabled = false;

                            // enabled button
                            stopCompareIrisBtn.Enabled = true;

                            // ��sUI
                            systemMsg.Text = "�}�l���";

                            // ���m��ﵲ�G�I����
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

        // ����i�����
        private void stopCompareIrisBtn_Click(object sender, EventArgs e)
        {
            while (true)
            {
                needRetry = false;
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
                            Action = "stopCompareIris",
                            Data = new { }
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // �����Ӧ�Python�����
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "stopCompareIris")
                        {
                            // �����Ӧ�Python�����
                            result = sr.ReadLine();
                            recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);
                        }

                        if (recivedResult.Status == "error")
                        {
                            MessageBox.Show(recivedResult.Message, recivedResult.Status, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // �������_���A�վ���s���A
                            // disabled button
                            stopBuildIrisBtn.Enabled = false;
                            stopCompareIrisBtn.Enabled = false;

                            // enabled button
                            startBuildIrisBtn.Enabled = true;
                            startCompareIrisBtn.Enabled = true;

                            // ��sUI
                            systemMsg.Text = "���_���";
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

                        // ����Python���ε{���^�ǰT��
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "setCompareFocusCamera")
                        {
                            // �����Ӧ�Python�����
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

                        // ����Python���ε{���^�ǰT��
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "setCompareFocusCamera")
                        {
                            // �����Ӧ�Python�����
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
            // �NopenCameraParamComboBox �w�]�ȳ]�� "disable"
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

                        // ����Python���ε{���^�ǰT��
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "flipCamera")
                        {
                            // �����Ӧ�Python�����
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

                        // ����Python���ε{���^�ǰT��
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "flipCamera")
                        {
                            // �����Ӧ�Python�����
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
                        // action: reloadEnvSettings
                        Operation operation = new Operation
                        {
                            Action = "reloadEnvSettings",
                            Data = new {}
                        };
                        string message = JsonSerializer.Serialize(operation);

                        sw.WriteLine(message);

                        // ����Python���ε{���^�ǰT��
                        string result = sr.ReadLine();
                        RecivedResult recivedResult = JsonSerializer.Deserialize<RecivedResult>(result);

                        while (recivedResult.Action != "reloadEnvSettings")
                        {
                            // �����Ӧ�Python�����
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
