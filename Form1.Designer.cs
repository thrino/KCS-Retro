namespace KCS_Retro
{
    partial class mainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            progressBar = new ToolStripProgressBar();
            fileList = new ListView();
            recordFilenames = new CheckBox();
            removeFileBtn = new Button();
            addFileBtn = new Button();
            recordToFileBtn = new Button();
            recordToOutputBtn = new Button();
            recordInOneFile = new CheckBox();
            toolStrip1 = new ToolStrip();
            toolStripButton8 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton5 = new ToolStripButton();
            toolStripButton6 = new ToolStripButton();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(32, 32);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, progressBar });
            statusStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip1.Location = new Point(0, 1050);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(2, 0, 26, 0);
            statusStrip1.Size = new Size(1512, 42);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(734, 32);
            toolStripStatusLabel1.Text = "KCS-Retro v1.0 for Windows - Copyright (c) 2025 Alexander Blohmé";
            // 
            // progressBar
            // 
            progressBar.Alignment = ToolStripItemAlignment.Right;
            progressBar.AutoToolTip = true;
            progressBar.Margin = new Padding(1, 3, 0, 3);
            progressBar.Name = "progressBar";
            progressBar.Overflow = ToolStripItemOverflow.Never;
            progressBar.RightToLeftLayout = true;
            progressBar.Size = new Size(557, 36);
            // 
            // fileList
            // 
            fileList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileList.BorderStyle = BorderStyle.FixedSingle;
            fileList.Location = new Point(22, 105);
            fileList.Margin = new Padding(6);
            fileList.Name = "fileList";
            fileList.Size = new Size(1469, 828);
            fileList.TabIndex = 20;
            fileList.UseCompatibleStateImageBehavior = false;
            // 
            // recordFilenames
            // 
            recordFilenames.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            recordFilenames.AutoSize = true;
            recordFilenames.Location = new Point(414, 954);
            recordFilenames.Margin = new Padding(6);
            recordFilenames.Name = "recordFilenames";
            recordFilenames.Size = new Size(369, 36);
            recordFilenames.TabIndex = 19;
            recordFilenames.Text = "Record filenames to first block";
            recordFilenames.UseVisualStyleBackColor = true;
            // 
            // removeFileBtn
            // 
            removeFileBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            removeFileBtn.Location = new Point(202, 951);
            removeFileBtn.Margin = new Padding(6);
            removeFileBtn.Name = "removeFileBtn";
            removeFileBtn.Size = new Size(169, 79);
            removeFileBtn.TabIndex = 18;
            removeFileBtn.Text = "&Remove File";
            removeFileBtn.UseVisualStyleBackColor = true;
            removeFileBtn.Click += button6_Click;
            // 
            // addFileBtn
            // 
            addFileBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            addFileBtn.Location = new Point(22, 951);
            addFileBtn.Margin = new Padding(6);
            addFileBtn.Name = "addFileBtn";
            addFileBtn.Size = new Size(169, 79);
            addFileBtn.TabIndex = 17;
            addFileBtn.Text = "&Add File";
            addFileBtn.UseVisualStyleBackColor = true;
            addFileBtn.Click += button5_Click_1;
            // 
            // recordToFileBtn
            // 
            recordToFileBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            recordToFileBtn.Location = new Point(1150, 949);
            recordToFileBtn.Margin = new Padding(6);
            recordToFileBtn.Name = "recordToFileBtn";
            recordToFileBtn.Size = new Size(344, 81);
            recordToFileBtn.TabIndex = 16;
            recordToFileBtn.Text = "Record to wav file";
            recordToFileBtn.UseVisualStyleBackColor = true;
            recordToFileBtn.Click += recordToFileBtn_Click;
            // 
            // recordToOutputBtn
            // 
            recordToOutputBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            recordToOutputBtn.Location = new Point(795, 949);
            recordToOutputBtn.Margin = new Padding(6);
            recordToOutputBtn.Name = "recordToOutputBtn";
            recordToOutputBtn.Size = new Size(344, 81);
            recordToOutputBtn.TabIndex = 15;
            recordToOutputBtn.Text = "Record to output";
            recordToOutputBtn.UseVisualStyleBackColor = true;
            // 
            // recordInOneFile
            // 
            recordInOneFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            recordInOneFile.AutoSize = true;
            recordInOneFile.Checked = true;
            recordInOneFile.CheckState = CheckState.Checked;
            recordInOneFile.Location = new Point(418, 995);
            recordInOneFile.Margin = new Padding(6);
            recordInOneFile.Name = "recordInOneFile";
            recordInOneFile.Size = new Size(289, 36);
            recordInOneFile.TabIndex = 21;
            recordInOneFile.Text = "Record all files to 1 file";
            recordInOneFile.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(50, 50);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton8, toolStripButton7, toolStripSeparator3, toolStripButton2, toolStripButton3, toolStripSeparator1, toolStripButton1, toolStripButton4, toolStripSeparator2, toolStripButton5, toolStripButton6 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 4, 0);
            toolStrip1.Size = new Size(1512, 60);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 22;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton8
            // 
            toolStripButton8.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton8.Image = (Image)resources.GetObject("toolStripButton8.Image");
            toolStripButton8.ImageTransparentColor = Color.Magenta;
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new Size(54, 54);
            toolStripButton8.Text = "Add files to record";
            toolStripButton8.Click += button5_Click_1;
            // 
            // toolStripButton7
            // 
            toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(54, 54);
            toolStripButton7.Text = "Remove selected files from list";
            toolStripButton7.Click += button6_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 60);
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(54, 54);
            toolStripButton2.Text = "Load from an input source";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(54, 54);
            toolStripButton3.Text = "Record to an output device";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 60);
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(54, 54);
            toolStripButton1.Text = "Load from audio file";
            toolStripButton1.Click += fromWAVFileToolStripMenuItem_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(54, 54);
            toolStripButton4.Text = "Record to audio file";
            toolStripButton4.Click += recordToFileBtn_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 60);
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(54, 54);
            toolStripButton5.Text = "Settings";
            toolStripButton5.Click += settingsToolStripMenuItem_Click;
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(54, 54);
            toolStripButton6.Text = "Quit";
            toolStripButton6.Click += toolStripButton6_Click;
            // 
            // mainFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1512, 1092);
            Controls.Add(toolStrip1);
            Controls.Add(recordInOneFile);
            Controls.Add(fileList);
            Controls.Add(recordFilenames);
            Controls.Add(removeFileBtn);
            Controls.Add(addFileBtn);
            Controls.Add(recordToFileBtn);
            Controls.Add(recordToOutputBtn);
            Controls.Add(statusStrip1);
            Margin = new Padding(6);
            Name = "mainFrm";
            Text = "KCS-Retro";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ListView fileList;
        private CheckBox recordFilenames;
        private Button removeFileBtn;
        private Button addFileBtn;
        private Button recordToFileBtn;
        private Button recordToOutputBtn;
        private CheckBox recordInOneFile;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton4;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripProgressBar progressBar;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripButton8;
        private ToolStripSeparator toolStripSeparator3;
    }
}
