namespace WinFormsWithNamesPipe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            setPositionBtn = new Button();
            positionXLabel = new Label();
            positionYLabel = new Label();
            positionXValue = new NumericUpDown();
            positionYValue = new NumericUpDown();
            label1 = new Label();
            frameHeightValue = new NumericUpDown();
            frameWidthValue = new NumericUpDown();
            frameHeightLabel = new Label();
            frameWidthLabel = new Label();
            setFrameSizeBtn = new Button();
            label2 = new Label();
            startBuildIrisBtn = new Button();
            buildIrisLabel = new Label();
            stopBuildIrisBtn = new Button();
            systemMsg = new TextBox();
            systemMsgLabel = new Label();
            startBuildIrisWithWaitingDescription = new Label();
            cameraPanel = new Panel();
            filePathLabel = new Label();
            textBox1 = new TextBox();
            openProgramBtn = new Button();
            openCameraBtn = new Button();
            closeCameraBtn = new Button();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)positionXValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)positionYValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)frameHeightValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)frameWidthValue).BeginInit();
            SuspendLayout();
            // 
            // setPositionBtn
            // 
            setPositionBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            setPositionBtn.Location = new Point(411, 145);
            setPositionBtn.Margin = new Padding(2);
            setPositionBtn.Name = "setPositionBtn";
            setPositionBtn.Size = new Size(134, 33);
            setPositionBtn.TabIndex = 4;
            setPositionBtn.Text = "Set Position";
            setPositionBtn.UseVisualStyleBackColor = true;
            setPositionBtn.Click += setPositionBtn_Click;
            // 
            // positionXLabel
            // 
            positionXLabel.AutoSize = true;
            positionXLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            positionXLabel.Location = new Point(51, 154);
            positionXLabel.Margin = new Padding(2, 0, 2, 0);
            positionXLabel.Name = "positionXLabel";
            positionXLabel.Size = new Size(24, 20);
            positionXLabel.TabIndex = 7;
            positionXLabel.Text = "X:";
            // 
            // positionYLabel
            // 
            positionYLabel.AutoSize = true;
            positionYLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            positionYLabel.Location = new Point(226, 154);
            positionYLabel.Margin = new Padding(2, 0, 2, 0);
            positionYLabel.Name = "positionYLabel";
            positionYLabel.Size = new Size(23, 20);
            positionYLabel.TabIndex = 8;
            positionYLabel.Text = "Y:";
            // 
            // positionXValue
            // 
            positionXValue.Location = new Point(114, 153);
            positionXValue.Margin = new Padding(2);
            positionXValue.Maximum = new decimal(new int[] { 1920, 0, 0, 0 });
            positionXValue.Name = "positionXValue";
            positionXValue.Size = new Size(86, 23);
            positionXValue.TabIndex = 9;
            // 
            // positionYValue
            // 
            positionYValue.Location = new Point(303, 154);
            positionYValue.Margin = new Padding(2);
            positionYValue.Maximum = new decimal(new int[] { 1080, 0, 0, 0 });
            positionYValue.Name = "positionYValue";
            positionYValue.Size = new Size(86, 23);
            positionYValue.TabIndex = 10;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(41, 190);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(564, 2);
            label1.TabIndex = 11;
            // 
            // frameHeightValue
            // 
            frameHeightValue.Location = new Point(303, 253);
            frameHeightValue.Margin = new Padding(2);
            frameHeightValue.Maximum = new decimal(new int[] { 1080, 0, 0, 0 });
            frameHeightValue.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            frameHeightValue.Name = "frameHeightValue";
            frameHeightValue.Size = new Size(86, 23);
            frameHeightValue.TabIndex = 16;
            frameHeightValue.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // frameWidthValue
            // 
            frameWidthValue.Location = new Point(114, 253);
            frameWidthValue.Margin = new Padding(2);
            frameWidthValue.Maximum = new decimal(new int[] { 1920, 0, 0, 0 });
            frameWidthValue.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            frameWidthValue.Name = "frameWidthValue";
            frameWidthValue.Size = new Size(86, 23);
            frameWidthValue.TabIndex = 15;
            frameWidthValue.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // frameHeightLabel
            // 
            frameHeightLabel.AutoSize = true;
            frameHeightLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            frameHeightLabel.Location = new Point(226, 253);
            frameHeightLabel.Margin = new Padding(2, 0, 2, 0);
            frameHeightLabel.Name = "frameHeightLabel";
            frameHeightLabel.Size = new Size(65, 20);
            frameHeightLabel.TabIndex = 14;
            frameHeightLabel.Text = "Height:";
            // 
            // frameWidthLabel
            // 
            frameWidthLabel.AutoSize = true;
            frameWidthLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            frameWidthLabel.Location = new Point(49, 253);
            frameWidthLabel.Margin = new Padding(2, 0, 2, 0);
            frameWidthLabel.Name = "frameWidthLabel";
            frameWidthLabel.Size = new Size(60, 20);
            frameWidthLabel.TabIndex = 13;
            frameWidthLabel.Text = "Width:";
            // 
            // setFrameSizeBtn
            // 
            setFrameSizeBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            setFrameSizeBtn.Location = new Point(411, 244);
            setFrameSizeBtn.Margin = new Padding(2);
            setFrameSizeBtn.Name = "setFrameSizeBtn";
            setFrameSizeBtn.Size = new Size(134, 33);
            setFrameSizeBtn.TabIndex = 12;
            setFrameSizeBtn.Text = "Set Frame Size";
            setFrameSizeBtn.UseVisualStyleBackColor = true;
            setFrameSizeBtn.Click += setFrameSizeBtn_Click;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(37, 292);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(564, 2);
            label2.TabIndex = 17;
            // 
            // startBuildIrisBtn
            // 
            startBuildIrisBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            startBuildIrisBtn.Location = new Point(158, 320);
            startBuildIrisBtn.Margin = new Padding(2);
            startBuildIrisBtn.Name = "startBuildIrisBtn";
            startBuildIrisBtn.Size = new Size(134, 33);
            startBuildIrisBtn.TabIndex = 18;
            startBuildIrisBtn.Text = "開始";
            startBuildIrisBtn.UseVisualStyleBackColor = true;
            startBuildIrisBtn.Click += startBuildIrisBtn_Click;
            // 
            // buildIrisLabel
            // 
            buildIrisLabel.AutoSize = true;
            buildIrisLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            buildIrisLabel.Location = new Point(49, 327);
            buildIrisLabel.Margin = new Padding(2, 0, 2, 0);
            buildIrisLabel.Name = "buildIrisLabel";
            buildIrisLabel.Size = new Size(89, 20);
            buildIrisLabel.TabIndex = 19;
            buildIrisLabel.Text = "虹膜建檔：";
            // 
            // stopBuildIrisBtn
            // 
            stopBuildIrisBtn.Enabled = false;
            stopBuildIrisBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            stopBuildIrisBtn.Location = new Point(334, 320);
            stopBuildIrisBtn.Margin = new Padding(2);
            stopBuildIrisBtn.Name = "stopBuildIrisBtn";
            stopBuildIrisBtn.Size = new Size(134, 33);
            stopBuildIrisBtn.TabIndex = 20;
            stopBuildIrisBtn.Text = "中斷";
            stopBuildIrisBtn.UseVisualStyleBackColor = true;
            stopBuildIrisBtn.Click += stopBuildIrisBtn_Click;
            // 
            // systemMsg
            // 
            systemMsg.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            systemMsg.Location = new Point(142, 406);
            systemMsg.Margin = new Padding(2);
            systemMsg.Multiline = true;
            systemMsg.Name = "systemMsg";
            systemMsg.ScrollBars = ScrollBars.Vertical;
            systemMsg.Size = new Size(459, 133);
            systemMsg.TabIndex = 21;
            // 
            // systemMsgLabel
            // 
            systemMsgLabel.AutoSize = true;
            systemMsgLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            systemMsgLabel.Location = new Point(51, 462);
            systemMsgLabel.Margin = new Padding(2, 0, 2, 0);
            systemMsgLabel.Name = "systemMsgLabel";
            systemMsgLabel.Size = new Size(89, 20);
            systemMsgLabel.TabIndex = 22;
            systemMsgLabel.Text = "系統訊息：";
            // 
            // startBuildIrisWithWaitingDescription
            // 
            startBuildIrisWithWaitingDescription.AutoSize = true;
            startBuildIrisWithWaitingDescription.Font = new Font("Microsoft JhengHei UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 136);
            startBuildIrisWithWaitingDescription.ForeColor = Color.Red;
            startBuildIrisWithWaitingDescription.Location = new Point(51, 368);
            startBuildIrisWithWaitingDescription.Margin = new Padding(2, 0, 2, 0);
            startBuildIrisWithWaitingDescription.Name = "startBuildIrisWithWaitingDescription";
            startBuildIrisWithWaitingDescription.Size = new Size(233, 18);
            startBuildIrisWithWaitingDescription.TabIndex = 24;
            startBuildIrisWithWaitingDescription.Text = "*開始建檔，共建3張，每張模擬兩秒";
            // 
            // cameraPanel
            // 
            cameraPanel.Location = new Point(638, 41);
            cameraPanel.Name = "cameraPanel";
            cameraPanel.Size = new Size(498, 498);
            cameraPanel.TabIndex = 25;
            // 
            // filePathLabel
            // 
            filePathLabel.AutoSize = true;
            filePathLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            filePathLabel.Location = new Point(44, 35);
            filePathLabel.Margin = new Padding(2, 0, 2, 0);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(77, 20);
            filePathLabel.TabIndex = 26;
            filePathLabel.Text = "程式路徑:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(126, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(479, 23);
            textBox1.TabIndex = 27;
            textBox1.Text = "D:\\project\\ling_don_iris_module\\dist\\iris_recognize_module_no_console\\iris_recognize_module.exe";
            // 
            // openProgramBtn
            // 
            openProgramBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            openProgramBtn.Location = new Point(44, 69);
            openProgramBtn.Margin = new Padding(2);
            openProgramBtn.Name = "openProgramBtn";
            openProgramBtn.Size = new Size(134, 33);
            openProgramBtn.TabIndex = 28;
            openProgramBtn.Text = "開啟程式";
            openProgramBtn.UseVisualStyleBackColor = true;
            openProgramBtn.Click += openProgramBtn_Click;
            // 
            // openCameraBtn
            // 
            openCameraBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            openCameraBtn.Location = new Point(217, 69);
            openCameraBtn.Margin = new Padding(2);
            openCameraBtn.Name = "openCameraBtn";
            openCameraBtn.Size = new Size(134, 33);
            openCameraBtn.TabIndex = 29;
            openCameraBtn.Text = "開啟鏡頭";
            openCameraBtn.UseVisualStyleBackColor = true;
            openCameraBtn.Click += openCameraBtn_Click;
            // 
            // closeCameraBtn
            // 
            closeCameraBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            closeCameraBtn.Location = new Point(389, 69);
            closeCameraBtn.Margin = new Padding(2);
            closeCameraBtn.Name = "closeCameraBtn";
            closeCameraBtn.Size = new Size(134, 33);
            closeCameraBtn.TabIndex = 30;
            closeCameraBtn.Text = "關閉鏡頭";
            closeCameraBtn.UseVisualStyleBackColor = true;
            closeCameraBtn.Click += closeCameraBtn_Click;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(41, 117);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(564, 2);
            label3.TabIndex = 31;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(49, 224);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(516, 18);
            label4.TabIndex = 32;
            label4.Text = "*目前在內嵌狀態下設定長寬視窗座標會跑掉，請再使用Set Positon 設定一次座標";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 554);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(closeCameraBtn);
            Controls.Add(openCameraBtn);
            Controls.Add(openProgramBtn);
            Controls.Add(textBox1);
            Controls.Add(filePathLabel);
            Controls.Add(cameraPanel);
            Controls.Add(startBuildIrisWithWaitingDescription);
            Controls.Add(systemMsgLabel);
            Controls.Add(systemMsg);
            Controls.Add(stopBuildIrisBtn);
            Controls.Add(buildIrisLabel);
            Controls.Add(startBuildIrisBtn);
            Controls.Add(label2);
            Controls.Add(frameHeightValue);
            Controls.Add(frameWidthValue);
            Controls.Add(frameHeightLabel);
            Controls.Add(frameWidthLabel);
            Controls.Add(setFrameSizeBtn);
            Controls.Add(label1);
            Controls.Add(positionYValue);
            Controls.Add(positionXValue);
            Controls.Add(positionYLabel);
            Controls.Add(positionXLabel);
            Controls.Add(setPositionBtn);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_Closing;
            ((System.ComponentModel.ISupportInitialize)positionXValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)positionYValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)frameHeightValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)frameWidthValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button setPositionBtn;
        private Label positionXLabel;
        private Label positionYLabel;
        private NumericUpDown positionXValue;
        private NumericUpDown positionYValue;
        private Label label1;
        private NumericUpDown frameHeightValue;
        private NumericUpDown frameWidthValue;
        private Label frameHeightLabel;
        private Label frameWidthLabel;
        private Button setFrameSizeBtn;
        private Label label2;
        private Button startBuildIrisBtn;
        private Label buildIrisLabel;
        private Button stopBuildIrisBtn;
        private TextBox systemMsg;
        private Label systemMsgLabel;
        private Label startBuildIrisWithWaitingDescription;
        private Panel cameraPanel;
        private Label filePathLabel;
        private TextBox textBox1;
        private Button openProgramBtn;
        private Button openCameraBtn;
        private Button closeCameraBtn;
        private Label label3;
        private Label label4;
    }
}
