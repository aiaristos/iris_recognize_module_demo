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
            label2 = new Label();
            startBuildIrisBtn = new Button();
            buildIrisLabel = new Label();
            stopBuildIrisBtn = new Button();
            systemMsg = new TextBox();
            systemMsgLabel = new Label();
            cameraPanel = new Panel();
            filePathLabel = new Label();
            textBox1 = new TextBox();
            openProgramBtn = new Button();
            openCameraBtn = new Button();
            closeCameraBtn = new Button();
            label3 = new Label();
            seasonIdLabel = new Label();
            seasonIdTextBox = new TextBox();
            loftIdTextBox = new TextBox();
            label1 = new Label();
            feetNumberTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            stopCompareIrisBtn = new Button();
            label6 = new Label();
            startCompareIrisBtn = new Button();
            compareResult = new TextBox();
            label7 = new Label();
            label8 = new Label();
            leftBuildNum = new NumericUpDown();
            rightBuildNum = new NumericUpDown();
            compareFocusOnLeftBtn = new Button();
            compareFocusOnRightBtn = new Button();
            openCameraParamComboBox = new ComboBox();
            flipLeftCameraBtn = new Button();
            flipRightCameraBtn = new Button();
            reloadEnvSettingBtn = new Button();
            useOldMethod = new Button();
            ((System.ComponentModel.ISupportInitialize)leftBuildNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rightBuildNum).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(46, 355);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(645, 2);
            label2.TabIndex = 17;
            // 
            // startBuildIrisBtn
            // 
            startBuildIrisBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            startBuildIrisBtn.Location = new Point(162, 296);
            startBuildIrisBtn.Margin = new Padding(2);
            startBuildIrisBtn.Name = "startBuildIrisBtn";
            startBuildIrisBtn.Size = new Size(153, 37);
            startBuildIrisBtn.TabIndex = 18;
            startBuildIrisBtn.Text = "開始";
            startBuildIrisBtn.UseVisualStyleBackColor = true;
            startBuildIrisBtn.Click += startBuildIrisBtn_Click;
            // 
            // buildIrisLabel
            // 
            buildIrisLabel.AutoSize = true;
            buildIrisLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            buildIrisLabel.Location = new Point(47, 304);
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
            stopBuildIrisBtn.Location = new Point(354, 296);
            stopBuildIrisBtn.Margin = new Padding(2);
            stopBuildIrisBtn.Name = "stopBuildIrisBtn";
            stopBuildIrisBtn.Size = new Size(153, 37);
            stopBuildIrisBtn.TabIndex = 20;
            stopBuildIrisBtn.Text = "中斷";
            stopBuildIrisBtn.UseVisualStyleBackColor = true;
            stopBuildIrisBtn.Click += stopBuildIrisBtn_Click;
            // 
            // systemMsg
            // 
            systemMsg.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            systemMsg.Location = new Point(145, 485);
            systemMsg.Margin = new Padding(2);
            systemMsg.Multiline = true;
            systemMsg.Name = "systemMsg";
            systemMsg.ScrollBars = ScrollBars.Vertical;
            systemMsg.Size = new Size(547, 169);
            systemMsg.TabIndex = 21;
            // 
            // systemMsgLabel
            // 
            systemMsgLabel.AutoSize = true;
            systemMsgLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            systemMsgLabel.Location = new Point(46, 559);
            systemMsgLabel.Margin = new Padding(2, 0, 2, 0);
            systemMsgLabel.Name = "systemMsgLabel";
            systemMsgLabel.Size = new Size(89, 20);
            systemMsgLabel.TabIndex = 22;
            systemMsgLabel.Text = "系統訊息：";
            // 
            // cameraPanel
            // 
            cameraPanel.Location = new Point(729, 88);
            cameraPanel.Name = "cameraPanel";
            cameraPanel.Size = new Size(953, 564);
            cameraPanel.TabIndex = 25;
            // 
            // filePathLabel
            // 
            filePathLabel.AutoSize = true;
            filePathLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            filePathLabel.Location = new Point(389, 40);
            filePathLabel.Margin = new Padding(2, 0, 2, 0);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(77, 20);
            filePathLabel.TabIndex = 26;
            filePathLabel.Text = "程式路徑:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(483, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(726, 24);
            textBox1.TabIndex = 27;
            textBox1.Text = "C:\\Users\\User\\source\\repos\\lingDonIrisModule\\x64\\Release\\iris_recognize_module.exe";
            // 
            // openProgramBtn
            // 
            openProgramBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            openProgramBtn.Location = new Point(46, 32);
            openProgramBtn.Margin = new Padding(2);
            openProgramBtn.Name = "openProgramBtn";
            openProgramBtn.Size = new Size(153, 37);
            openProgramBtn.TabIndex = 28;
            openProgramBtn.Text = "開啟程式";
            openProgramBtn.UseVisualStyleBackColor = true;
            openProgramBtn.Click += openProgramBtn_Click;
            // 
            // openCameraBtn
            // 
            openCameraBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            openCameraBtn.Location = new Point(44, 113);
            openCameraBtn.Margin = new Padding(2);
            openCameraBtn.Name = "openCameraBtn";
            openCameraBtn.Size = new Size(153, 37);
            openCameraBtn.TabIndex = 29;
            openCameraBtn.Text = "開啟鏡頭";
            openCameraBtn.UseVisualStyleBackColor = true;
            openCameraBtn.Click += openCameraBtn_Click;
            // 
            // closeCameraBtn
            // 
            closeCameraBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            closeCameraBtn.Location = new Point(340, 113);
            closeCameraBtn.Margin = new Padding(2);
            closeCameraBtn.Name = "closeCameraBtn";
            closeCameraBtn.Size = new Size(153, 37);
            closeCameraBtn.TabIndex = 30;
            closeCameraBtn.Text = "關閉鏡頭";
            closeCameraBtn.UseVisualStyleBackColor = true;
            closeCameraBtn.Click += closeCameraBtn_Click;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(47, 189);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(645, 2);
            label3.TabIndex = 31;
            // 
            // seasonIdLabel
            // 
            seasonIdLabel.AutoSize = true;
            seasonIdLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            seasonIdLabel.Location = new Point(50, 221);
            seasonIdLabel.Margin = new Padding(2, 0, 2, 0);
            seasonIdLabel.Name = "seasonIdLabel";
            seasonIdLabel.Size = new Size(89, 20);
            seasonIdLabel.TabIndex = 32;
            seasonIdLabel.Text = "賽季編號：";
            // 
            // seasonIdTextBox
            // 
            seasonIdTextBox.Location = new Point(141, 219);
            seasonIdTextBox.Name = "seasonIdTextBox";
            seasonIdTextBox.Size = new Size(120, 24);
            seasonIdTextBox.TabIndex = 33;
            seasonIdTextBox.Text = "Test";
            // 
            // loftIdTextBox
            // 
            loftIdTextBox.Location = new Point(340, 220);
            loftIdTextBox.Name = "loftIdTextBox";
            loftIdTextBox.Size = new Size(120, 24);
            loftIdTextBox.TabIndex = 35;
            loftIdTextBox.Text = "001";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(278, 221);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 34;
            label1.Text = "舍號：";
            // 
            // feetNumberTextBox
            // 
            feetNumberTextBox.Location = new Point(541, 220);
            feetNumberTextBox.Name = "feetNumberTextBox";
            feetNumberTextBox.Size = new Size(120, 24);
            feetNumberTextBox.TabIndex = 37;
            feetNumberTextBox.Text = "0001";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label4.Location = new Point(479, 221);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 36;
            label4.Text = "環號：";
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(46, 261);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(645, 2);
            label5.TabIndex = 38;
            // 
            // stopCompareIrisBtn
            // 
            stopCompareIrisBtn.Enabled = false;
            stopCompareIrisBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            stopCompareIrisBtn.Location = new Point(353, 371);
            stopCompareIrisBtn.Margin = new Padding(2);
            stopCompareIrisBtn.Name = "stopCompareIrisBtn";
            stopCompareIrisBtn.Size = new Size(153, 37);
            stopCompareIrisBtn.TabIndex = 41;
            stopCompareIrisBtn.Text = "中斷";
            stopCompareIrisBtn.UseVisualStyleBackColor = true;
            stopCompareIrisBtn.Click += stopCompareIrisBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label6.Location = new Point(38, 413);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 40;
            label6.Text = "虹膜比對：";
            // 
            // startCompareIrisBtn
            // 
            startCompareIrisBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            startCompareIrisBtn.Location = new Point(162, 371);
            startCompareIrisBtn.Margin = new Padding(2);
            startCompareIrisBtn.Name = "startCompareIrisBtn";
            startCompareIrisBtn.Size = new Size(153, 37);
            startCompareIrisBtn.TabIndex = 39;
            startCompareIrisBtn.Text = "開始";
            startCompareIrisBtn.UseVisualStyleBackColor = true;
            startCompareIrisBtn.Click += startCompareIrisBtn_Click;
            // 
            // compareResult
            // 
            compareResult.BackColor = SystemColors.MenuBar;
            compareResult.BorderStyle = BorderStyle.None;
            compareResult.Font = new Font("Maple UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            compareResult.ForeColor = SystemColors.Window;
            compareResult.Location = new Point(541, 372);
            compareResult.Name = "compareResult";
            compareResult.Size = new Size(139, 36);
            compareResult.TabIndex = 42;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label7.Location = new Point(535, 285);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(89, 20);
            label7.TabIndex = 43;
            label7.Text = "左側數量：";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label8.Location = new Point(535, 321);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(89, 20);
            label8.TabIndex = 45;
            label8.Text = "右側數量：";
            // 
            // leftBuildNum
            // 
            leftBuildNum.Location = new Point(629, 285);
            leftBuildNum.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            leftBuildNum.Name = "leftBuildNum";
            leftBuildNum.Size = new Size(63, 24);
            leftBuildNum.TabIndex = 46;
            leftBuildNum.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // rightBuildNum
            // 
            rightBuildNum.Location = new Point(629, 322);
            rightBuildNum.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            rightBuildNum.Name = "rightBuildNum";
            rightBuildNum.Size = new Size(63, 24);
            rightBuildNum.TabIndex = 47;
            rightBuildNum.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // compareFocusOnLeftBtn
            // 
            compareFocusOnLeftBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            compareFocusOnLeftBtn.Location = new Point(162, 431);
            compareFocusOnLeftBtn.Margin = new Padding(2);
            compareFocusOnLeftBtn.Name = "compareFocusOnLeftBtn";
            compareFocusOnLeftBtn.Size = new Size(153, 37);
            compareFocusOnLeftBtn.TabIndex = 48;
            compareFocusOnLeftBtn.Text = "只使用左側";
            compareFocusOnLeftBtn.UseVisualStyleBackColor = true;
            compareFocusOnLeftBtn.Click += compareFocusOnLeftBtn_Click;
            // 
            // compareFocusOnRightBtn
            // 
            compareFocusOnRightBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            compareFocusOnRightBtn.Location = new Point(353, 431);
            compareFocusOnRightBtn.Margin = new Padding(2);
            compareFocusOnRightBtn.Name = "compareFocusOnRightBtn";
            compareFocusOnRightBtn.Size = new Size(153, 37);
            compareFocusOnRightBtn.TabIndex = 49;
            compareFocusOnRightBtn.Text = "只使用右側";
            compareFocusOnRightBtn.UseVisualStyleBackColor = true;
            compareFocusOnRightBtn.Click += compareFocusOnRightBtn_Click;
            // 
            // openCameraParamComboBox
            // 
            openCameraParamComboBox.FormattingEnabled = true;
            openCameraParamComboBox.Items.AddRange(new object[] { "disable", "left", "right" });
            openCameraParamComboBox.Location = new Point(202, 121);
            openCameraParamComboBox.Name = "openCameraParamComboBox";
            openCameraParamComboBox.Size = new Size(116, 25);
            openCameraParamComboBox.TabIndex = 51;
            // 
            // flipLeftCameraBtn
            // 
            flipLeftCameraBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            flipLeftCameraBtn.Location = new Point(535, 76);
            flipLeftCameraBtn.Margin = new Padding(2);
            flipLeftCameraBtn.Name = "flipLeftCameraBtn";
            flipLeftCameraBtn.Size = new Size(153, 37);
            flipLeftCameraBtn.TabIndex = 52;
            flipLeftCameraBtn.Text = "左側翻轉";
            flipLeftCameraBtn.UseVisualStyleBackColor = true;
            flipLeftCameraBtn.Click += flipLeftCameraBtn_Click;
            // 
            // flipRightCameraBtn
            // 
            flipRightCameraBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            flipRightCameraBtn.Location = new Point(535, 134);
            flipRightCameraBtn.Margin = new Padding(2);
            flipRightCameraBtn.Name = "flipRightCameraBtn";
            flipRightCameraBtn.Size = new Size(153, 37);
            flipRightCameraBtn.TabIndex = 53;
            flipRightCameraBtn.Text = "右側翻轉";
            flipRightCameraBtn.UseVisualStyleBackColor = true;
            flipRightCameraBtn.Click += flipRightCameraBtn_Click;
            // 
            // reloadEnvSettingBtn
            // 
            reloadEnvSettingBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            reloadEnvSettingBtn.Location = new Point(212, 32);
            reloadEnvSettingBtn.Margin = new Padding(2);
            reloadEnvSettingBtn.Name = "reloadEnvSettingBtn";
            reloadEnvSettingBtn.Size = new Size(153, 37);
            reloadEnvSettingBtn.TabIndex = 54;
            reloadEnvSettingBtn.Text = "重新載入ENV";
            reloadEnvSettingBtn.UseVisualStyleBackColor = true;
            reloadEnvSettingBtn.Click += reloadEnvSettingBtn_Click;
            // 
            // useOldMethod
            // 
            useOldMethod.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            useOldMethod.Location = new Point(541, 431);
            useOldMethod.Margin = new Padding(2);
            useOldMethod.Name = "useOldMethod";
            useOldMethod.Size = new Size(153, 37);
            useOldMethod.TabIndex = 55;
            useOldMethod.Text = "使用舊方法分析";
            useOldMethod.UseVisualStyleBackColor = true;
            useOldMethod.Click += useOldMethod_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1694, 676);
            Controls.Add(useOldMethod);
            Controls.Add(reloadEnvSettingBtn);
            Controls.Add(flipRightCameraBtn);
            Controls.Add(flipLeftCameraBtn);
            Controls.Add(openCameraParamComboBox);
            Controls.Add(compareFocusOnRightBtn);
            Controls.Add(compareFocusOnLeftBtn);
            Controls.Add(rightBuildNum);
            Controls.Add(leftBuildNum);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(compareResult);
            Controls.Add(stopCompareIrisBtn);
            Controls.Add(label6);
            Controls.Add(startCompareIrisBtn);
            Controls.Add(label5);
            Controls.Add(feetNumberTextBox);
            Controls.Add(label4);
            Controls.Add(loftIdTextBox);
            Controls.Add(label1);
            Controls.Add(seasonIdTextBox);
            Controls.Add(seasonIdLabel);
            Controls.Add(label3);
            Controls.Add(closeCameraBtn);
            Controls.Add(openCameraBtn);
            Controls.Add(openProgramBtn);
            Controls.Add(textBox1);
            Controls.Add(filePathLabel);
            Controls.Add(cameraPanel);
            Controls.Add(systemMsgLabel);
            Controls.Add(systemMsg);
            Controls.Add(stopBuildIrisBtn);
            Controls.Add(buildIrisLabel);
            Controls.Add(startBuildIrisBtn);
            Controls.Add(label2);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_Closing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)leftBuildNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)rightBuildNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Button startBuildIrisBtn;
        private Label buildIrisLabel;
        private Button stopBuildIrisBtn;
        private TextBox systemMsg;
        private Label systemMsgLabel;
        private Panel cameraPanel;
        private Label filePathLabel;
        private TextBox textBox1;
        private Button openProgramBtn;
        private Button openCameraBtn;
        private Button closeCameraBtn;
        private Label label3;
        private Label seasonIdLabel;
        private TextBox seasonIdTextBox;
        private TextBox loftIdTextBox;
        private Label label1;
        private TextBox feetNumberTextBox;
        private Label label4;
        private Label label5;
        private Button stopCompareIrisBtn;
        private Label label6;
        private Button startCompareIrisBtn;
        private TextBox compareResult;
        private Label label7;
        private Label label8;
        private NumericUpDown leftBuildNum;
        private NumericUpDown rightBuildNum;
        private Button compareFocusOnLeftBtn;
        private Button compareFocusOnRightBtn;
        private ComboBox openCameraParamComboBox;
        private Button flipLeftCameraBtn;
        private Button flipRightCameraBtn;
        private Button reloadEnvSettingBtn;
        private Button useOldMethod;
    }
}
