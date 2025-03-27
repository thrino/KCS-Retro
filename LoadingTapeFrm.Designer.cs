namespace KCS_Retro
{
    partial class LoadingTapeFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tapeLoadingStatus = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tapeRunningForLabel = new Label();
            totalBytesRecvdLabel = new Label();
            filesFoundLabel = new Label();
            cancelDoneBtn = new Button();
            SuspendLayout();
            // 
            // tapeLoadingStatus
            // 
            tapeLoadingStatus.AutoSize = true;
            tapeLoadingStatus.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tapeLoadingStatus.Location = new Point(67, 24);
            tapeLoadingStatus.Name = "tapeLoadingStatus";
            tapeLoadingStatus.Size = new Size(303, 37);
            tapeLoadingStatus.TabIndex = 0;
            tapeLoadingStatus.Text = "PRESS PLAY ON 'TAPE'";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 123);
            label2.Name = "label2";
            label2.Size = new Size(68, 15);
            label2.TabIndex = 1;
            label2.Text = "Files found:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 138);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 2;
            label3.Text = "Total bytes received:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 108);
            label4.Name = "label4";
            label4.Size = new Size(98, 15);
            label4.TabIndex = 3;
            label4.Text = "Tape running for:";
            // 
            // tapeRunningForLabel
            // 
            tapeRunningForLabel.AutoSize = true;
            tapeRunningForLabel.Location = new Point(132, 108);
            tapeRunningForLabel.Name = "tapeRunningForLabel";
            tapeRunningForLabel.Size = new Size(16, 15);
            tapeRunningForLabel.TabIndex = 6;
            tapeRunningForLabel.Text = "...";
            // 
            // totalBytesRecvdLabel
            // 
            totalBytesRecvdLabel.AutoSize = true;
            totalBytesRecvdLabel.Location = new Point(132, 138);
            totalBytesRecvdLabel.Name = "totalBytesRecvdLabel";
            totalBytesRecvdLabel.Size = new Size(114, 15);
            totalBytesRecvdLabel.TabIndex = 5;
            totalBytesRecvdLabel.Text = "Total bytes received:";
            // 
            // filesFoundLabel
            // 
            filesFoundLabel.AutoSize = true;
            filesFoundLabel.Location = new Point(132, 123);
            filesFoundLabel.Name = "filesFoundLabel";
            filesFoundLabel.Size = new Size(13, 15);
            filesFoundLabel.TabIndex = 4;
            filesFoundLabel.Text = "0";
            // 
            // cancelDoneBtn
            // 
            cancelDoneBtn.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelDoneBtn.Location = new Point(327, 141);
            cancelDoneBtn.Name = "cancelDoneBtn";
            cancelDoneBtn.Size = new Size(117, 45);
            cancelDoneBtn.TabIndex = 7;
            cancelDoneBtn.Text = "Cancel";
            cancelDoneBtn.UseVisualStyleBackColor = true;
            // 
            // LoadingTapeFrm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(456, 198);
            Controls.Add(cancelDoneBtn);
            Controls.Add(tapeRunningForLabel);
            Controls.Add(totalBytesRecvdLabel);
            Controls.Add(filesFoundLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(tapeLoadingStatus);
            Name = "LoadingTapeFrm";
            Text = "Loading tape";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tapeLoadingStatus;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label tapeRunningForLabel;
        private Label totalBytesRecvdLabel;
        private Label filesFoundLabel;
        private Button cancelDoneBtn;
    }
}