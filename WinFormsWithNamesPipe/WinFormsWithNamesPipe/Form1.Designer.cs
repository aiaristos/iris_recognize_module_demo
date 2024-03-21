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
            focusOnLeftBtn = new Button();
            focusOnRightBtn = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(46, 304);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(645, 2);
            label2.TabIndex = 17;
            // 
            // startBuildIrisBtn
            // 
            startBuildIrisBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            startBuildIrisBtn.Location = new Point(162, 231);
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
            buildIrisLabel.Location = new Point(50, 239);
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
            stopBuildIrisBtn.Location = new Point(363, 231);
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
            systemMsg.Location = new Point(144, 426);
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
            systemMsgLabel.Location = new Point(47, 505);
            systemMsgLabel.Margin = new Padding(2, 0, 2, 0);
            systemMsgLabel.Name = "systemMsgLabel";
            systemMsgLabel.Size = new Size(89, 20);
            systemMsgLabel.TabIndex = 22;
            systemMsgLabel.Text = "系統訊息：";
            // 
            // cameraPanel
            // 
            cameraPanel.Location = new Point(729, 46);
            cameraPanel.Name = "cameraPanel";
            cameraPanel.Size = new Size(705, 564);
            cameraPanel.TabIndex = 25;
            // 
            // filePathLabel
            // 
            filePathLabel.AutoSize = true;
            filePathLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            filePathLabel.Location = new Point(50, 40);
            filePathLabel.Margin = new Padding(2, 0, 2, 0);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(77, 20);
            filePathLabel.TabIndex = 26;
            filePathLabel.Text = "程式路徑:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(144, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(547, 24);
            textBox1.TabIndex = 27;
            textBox1.Text = "D:\\project\\ling_don_iris_project\\ling_don_iris_module\\dist\\iris_recognize_module\\iris_recognize_module.exe";
            // 
            // openProgramBtn
            // 
            openProgramBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            openProgramBtn.Location = new Point(50, 78);
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
            openCameraBtn.Location = new Point(248, 78);
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
            closeCameraBtn.Location = new Point(445, 78);
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
            label3.Location = new Point(47, 133);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(645, 2);
            label3.TabIndex = 31;
            // 
            // seasonIdLabel
            // 
            seasonIdLabel.AutoSize = true;
            seasonIdLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            seasonIdLabel.Location = new Point(50, 155);
            seasonIdLabel.Margin = new Padding(2, 0, 2, 0);
            seasonIdLabel.Name = "seasonIdLabel";
            seasonIdLabel.Size = new Size(89, 20);
            seasonIdLabel.TabIndex = 32;
            seasonIdLabel.Text = "賽季編號：";
            // 
            // seasonIdTextBox
            // 
            seasonIdTextBox.Location = new Point(141, 153);
            seasonIdTextBox.Name = "seasonIdTextBox";
            seasonIdTextBox.Size = new Size(120, 24);
            seasonIdTextBox.TabIndex = 33;
            seasonIdTextBox.Text = "Test";
            // 
            // loftIdTextBox
            // 
            loftIdTextBox.Location = new Point(340, 154);
            loftIdTextBox.Name = "loftIdTextBox";
            loftIdTextBox.Size = new Size(120, 24);
            loftIdTextBox.TabIndex = 35;
            loftIdTextBox.Text = "001";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(278, 155);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 34;
            label1.Text = "舍號：";
            // 
            // feetNumberTextBox
            // 
            feetNumberTextBox.Location = new Point(541, 154);
            feetNumberTextBox.Name = "feetNumberTextBox";
            feetNumberTextBox.Size = new Size(120, 24);
            feetNumberTextBox.TabIndex = 37;
            feetNumberTextBox.Text = "0001";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label4.Location = new Point(479, 155);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 36;
            label4.Text = "環號：";
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(47, 196);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(645, 2);
            label5.TabIndex = 38;
            // 
            // stopCompareIrisBtn
            // 
            stopCompareIrisBtn.Enabled = false;
            stopCompareIrisBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            stopCompareIrisBtn.Location = new Point(363, 342);
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
            label6.Location = new Point(50, 350);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 40;
            label6.Text = "虹膜比對：";
            // 
            // startCompareIrisBtn
            // 
            startCompareIrisBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            startCompareIrisBtn.Location = new Point(162, 342);
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
            compareResult.Location = new Point(552, 342);
            compareResult.Name = "compareResult";
            compareResult.Size = new Size(139, 36);
            compareResult.TabIndex = 42;
            // 
            // focusOnLeftBtn
            // 
            focusOnLeftBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            focusOnLeftBtn.Location = new Point(539, 213);
            focusOnLeftBtn.Margin = new Padding(2);
            focusOnLeftBtn.Name = "focusOnLeftBtn";
            focusOnLeftBtn.Size = new Size(153, 37);
            focusOnLeftBtn.TabIndex = 43;
            focusOnLeftBtn.Text = "只拍左側";
            focusOnLeftBtn.UseVisualStyleBackColor = true;
            focusOnLeftBtn.Click += focusOnLeftBtn_Click;
            // 
            // focusOnRightBtn
            // 
            focusOnRightBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            focusOnRightBtn.Location = new Point(539, 254);
            focusOnRightBtn.Margin = new Padding(2);
            focusOnRightBtn.Name = "focusOnRightBtn";
            focusOnRightBtn.Size = new Size(153, 37);
            focusOnRightBtn.TabIndex = 44;
            focusOnRightBtn.Text = "只拍右側";
            focusOnRightBtn.UseVisualStyleBackColor = true;
            focusOnRightBtn.Click += focusOnRightBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1447, 628);
            Controls.Add(focusOnRightBtn);
            Controls.Add(focusOnLeftBtn);
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
        private Button focusOnLeftBtn;
        private Button focusOnRightBtn;
    }
}
