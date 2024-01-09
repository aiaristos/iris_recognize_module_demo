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
            ((System.ComponentModel.ISupportInitialize)positionXValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)positionYValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)frameHeightValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)frameWidthValue).BeginInit();
            SuspendLayout();
            // 
            // setPositionBtn
            // 
            setPositionBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            setPositionBtn.Location = new Point(404, 35);
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
            positionXLabel.Location = new Point(44, 44);
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
            positionYLabel.Location = new Point(219, 44);
            positionYLabel.Margin = new Padding(2, 0, 2, 0);
            positionYLabel.Name = "positionYLabel";
            positionYLabel.Size = new Size(23, 20);
            positionYLabel.TabIndex = 8;
            positionYLabel.Text = "Y:";
            // 
            // positionXValue
            // 
            positionXValue.Location = new Point(107, 43);
            positionXValue.Margin = new Padding(2);
            positionXValue.Maximum = new decimal(new int[] { 1920, 0, 0, 0 });
            positionXValue.Name = "positionXValue";
            positionXValue.Size = new Size(86, 23);
            positionXValue.TabIndex = 9;
            // 
            // positionYValue
            // 
            positionYValue.Location = new Point(296, 44);
            positionYValue.Margin = new Padding(2);
            positionYValue.Maximum = new decimal(new int[] { 1080, 0, 0, 0 });
            positionYValue.Name = "positionYValue";
            positionYValue.Size = new Size(86, 23);
            positionYValue.TabIndex = 10;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(34, 80);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(564, 2);
            label1.TabIndex = 11;
            // 
            // frameHeightValue
            // 
            frameHeightValue.Location = new Point(296, 118);
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
            frameWidthValue.Location = new Point(107, 118);
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
            frameHeightLabel.Location = new Point(219, 118);
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
            frameWidthLabel.Location = new Point(42, 118);
            frameWidthLabel.Margin = new Padding(2, 0, 2, 0);
            frameWidthLabel.Name = "frameWidthLabel";
            frameWidthLabel.Size = new Size(60, 20);
            frameWidthLabel.TabIndex = 13;
            frameWidthLabel.Text = "Width:";
            // 
            // setFrameSizeBtn
            // 
            setFrameSizeBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            setFrameSizeBtn.Location = new Point(404, 109);
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
            label2.Location = new Point(30, 159);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(564, 2);
            label2.TabIndex = 17;
            // 
            // startBuildIrisBtn
            // 
            startBuildIrisBtn.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            startBuildIrisBtn.Location = new Point(151, 187);
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
            buildIrisLabel.Location = new Point(42, 194);
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
            stopBuildIrisBtn.Location = new Point(327, 187);
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
            systemMsg.Location = new Point(135, 273);
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
            systemMsgLabel.Location = new Point(44, 329);
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
            startBuildIrisWithWaitingDescription.Location = new Point(44, 235);
            startBuildIrisWithWaitingDescription.Margin = new Padding(2, 0, 2, 0);
            startBuildIrisWithWaitingDescription.Name = "startBuildIrisWithWaitingDescription";
            startBuildIrisWithWaitingDescription.Size = new Size(233, 18);
            startBuildIrisWithWaitingDescription.TabIndex = 24;
            startBuildIrisWithWaitingDescription.Text = "*開始建檔，共建3張，每張模擬兩秒";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 436);
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
            Activated += Form1_Activated;
            Deactivate += Form1_Deactivate;
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
    }
}
