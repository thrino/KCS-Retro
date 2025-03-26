namespace KCS_Retro
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
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadDataToolStripMenuItem = new ToolStripMenuItem();
            fromAudioDeviceToolStripMenuItem = new ToolStripMenuItem();
            fromWAVFileToolStripMenuItem = new ToolStripMenuItem();
            addFileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            quitKCSToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutKCSRetroToolStripMenuItem = new ToolStripMenuItem();
            debugButtonToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            progressBar = new ToolStripProgressBar();
            fileList = new ListView();
            checkBox1 = new CheckBox();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(811, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadDataToolStripMenuItem, addFileToolStripMenuItem, toolStripMenuItem1, quitKCSToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // loadDataToolStripMenuItem
            // 
            loadDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fromAudioDeviceToolStripMenuItem, fromWAVFileToolStripMenuItem });
            loadDataToolStripMenuItem.Name = "loadDataToolStripMenuItem";
            loadDataToolStripMenuItem.Size = new Size(127, 22);
            loadDataToolStripMenuItem.Text = "&Load Data";
            // 
            // fromAudioDeviceToolStripMenuItem
            // 
            fromAudioDeviceToolStripMenuItem.Name = "fromAudioDeviceToolStripMenuItem";
            fromAudioDeviceToolStripMenuItem.Size = new Size(175, 22);
            fromAudioDeviceToolStripMenuItem.Text = "&From Audio Device";
            // 
            // fromWAVFileToolStripMenuItem
            // 
            fromWAVFileToolStripMenuItem.Name = "fromWAVFileToolStripMenuItem";
            fromWAVFileToolStripMenuItem.Size = new Size(175, 22);
            fromWAVFileToolStripMenuItem.Text = "F&rom WAV File";
            fromWAVFileToolStripMenuItem.Click += fromWAVFileToolStripMenuItem_Click;
            // 
            // addFileToolStripMenuItem
            // 
            addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            addFileToolStripMenuItem.Size = new Size(127, 22);
            addFileToolStripMenuItem.Text = "&Add File";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(124, 6);
            // 
            // quitKCSToolStripMenuItem
            // 
            quitKCSToolStripMenuItem.Name = "quitKCSToolStripMenuItem";
            quitKCSToolStripMenuItem.Size = new Size(127, 22);
            quitKCSToolStripMenuItem.Text = "&Quit KCS";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "&Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutKCSRetroToolStripMenuItem, debugButtonToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutKCSRetroToolStripMenuItem
            // 
            aboutKCSRetroToolStripMenuItem.Name = "aboutKCSRetroToolStripMenuItem";
            aboutKCSRetroToolStripMenuItem.Size = new Size(180, 22);
            aboutKCSRetroToolStripMenuItem.Text = "&About KCS-Retro";
            aboutKCSRetroToolStripMenuItem.Click += aboutKCSRetroToolStripMenuItem_Click;
            // 
            // debugButtonToolStripMenuItem
            // 
            debugButtonToolStripMenuItem.Name = "debugButtonToolStripMenuItem";
            debugButtonToolStripMenuItem.Size = new Size(180, 22);
            debugButtonToolStripMenuItem.Text = "&Debug Button";
            debugButtonToolStripMenuItem.Click += debugButtonToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, progressBar });
            statusStrip1.Location = new Point(0, 451);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(811, 22);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(154, 17);
            toolStripStatusLabel1.Text = "KCS-Retro v1.0 for Windows";
            // 
            // progressBar
            // 
            progressBar.Alignment = ToolStripItemAlignment.Right;
            progressBar.Name = "progressBar";
            progressBar.RightToLeft = RightToLeft.Yes;
            progressBar.Size = new Size(100, 16);
            // 
            // fileList
            // 
            fileList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileList.Location = new Point(0, 27);
            fileList.Name = "fileList";
            fileList.Size = new Size(811, 352);
            fileList.TabIndex = 20;
            fileList.UseCompatibleStateImageBehavior = false;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(234, 398);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(185, 19);
            checkBox1.TabIndex = 19;
            checkBox1.Text = "Record filenames at first block";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button6.Location = new Point(109, 388);
            button6.Name = "button6";
            button6.Size = new Size(91, 37);
            button6.TabIndex = 18;
            button6.Text = "&Remove File";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button5.Location = new Point(12, 388);
            button5.Name = "button5";
            button5.Size = new Size(91, 37);
            button5.TabIndex = 17;
            button5.Text = "&Add File";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(616, 387);
            button4.Name = "button4";
            button4.Size = new Size(185, 38);
            button4.TabIndex = 16;
            button4.Text = "Record to wav file";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_2;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(425, 387);
            button3.Name = "button3";
            button3.Size = new Size(185, 38);
            button3.TabIndex = 15;
            button3.Text = "Record to output";
            button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(811, 473);
            Controls.Add(fileList);
            Controls.Add(checkBox1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "KCS-Retro";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar progressBar;
        private ToolStripMenuItem addFileToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem quitKCSToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem loadDataToolStripMenuItem;
        private ToolStripMenuItem fromAudioDeviceToolStripMenuItem;
        private ToolStripMenuItem fromWAVFileToolStripMenuItem;
        private ListView fileList;
        private CheckBox checkBox1;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private ToolStripMenuItem aboutKCSRetroToolStripMenuItem;
        private ToolStripMenuItem debugButtonToolStripMenuItem;
    }
}
