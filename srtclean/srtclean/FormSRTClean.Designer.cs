namespace srtclean
{
    partial class FormSRTClean
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
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.openFileDialogSRT = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenSRT = new System.Windows.Forms.Button();
            this.textBoxSRT = new System.Windows.Forms.TextBox();
            this.textBoxEDL = new System.Windows.Forms.TextBox();
            this.buttonEDL = new System.Windows.Forms.Button();
            this.openFileDialogEDL = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(12, 91);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOutput.Size = new System.Drawing.Size(760, 536);
            this.textBoxOutput.TabIndex = 0;
            // 
            // openFileDialogSRT
            // 
            this.openFileDialogSRT.FileName = "openFileDialogSRT";
            this.openFileDialogSRT.Filter = "srt files|*.srt|All Files|*.*";
            this.openFileDialogSRT.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogSRT_FileOk);
            // 
            // buttonOpenSRT
            // 
            this.buttonOpenSRT.Location = new System.Drawing.Point(697, 12);
            this.buttonOpenSRT.Name = "buttonOpenSRT";
            this.buttonOpenSRT.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenSRT.TabIndex = 1;
            this.buttonOpenSRT.Text = "SRT";
            this.buttonOpenSRT.UseVisualStyleBackColor = true;
            this.buttonOpenSRT.Click += new System.EventHandler(this.buttonOpenSRT_Click);
            // 
            // textBoxSRT
            // 
            this.textBoxSRT.Enabled = false;
            this.textBoxSRT.Location = new System.Drawing.Point(12, 12);
            this.textBoxSRT.Name = "textBoxSRT";
            this.textBoxSRT.Size = new System.Drawing.Size(679, 22);
            this.textBoxSRT.TabIndex = 2;
            // 
            // textBoxEDL
            // 
            this.textBoxEDL.Enabled = false;
            this.textBoxEDL.Location = new System.Drawing.Point(12, 41);
            this.textBoxEDL.Name = "textBoxEDL";
            this.textBoxEDL.Size = new System.Drawing.Size(679, 22);
            this.textBoxEDL.TabIndex = 4;
            // 
            // buttonEDL
            // 
            this.buttonEDL.Location = new System.Drawing.Point(697, 41);
            this.buttonEDL.Name = "buttonEDL";
            this.buttonEDL.Size = new System.Drawing.Size(75, 23);
            this.buttonEDL.TabIndex = 3;
            this.buttonEDL.Text = "EDL";
            this.buttonEDL.UseVisualStyleBackColor = true;
            this.buttonEDL.Click += new System.EventHandler(this.buttonEDL_Click);
            // 
            // openFileDialogEDL
            // 
            this.openFileDialogEDL.FileName = "openFileDialogEDL";
            this.openFileDialogEDL.Filter = "edl files|*.edl|All Files|*.*";
            this.openFileDialogEDL.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogEDL_FileOk);
            // 
            // FormSRTClean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 639);
            this.Controls.Add(this.textBoxEDL);
            this.Controls.Add(this.buttonEDL);
            this.Controls.Add(this.textBoxSRT);
            this.Controls.Add(this.buttonOpenSRT);
            this.Controls.Add(this.textBoxOutput);
            this.Name = "FormSRTClean";
            this.Text = "SRTClean";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.OpenFileDialog openFileDialogSRT;
        private System.Windows.Forms.Button buttonOpenSRT;
        private System.Windows.Forms.TextBox textBoxSRT;
        private System.Windows.Forms.TextBox textBoxEDL;
        private System.Windows.Forms.Button buttonEDL;
        private System.Windows.Forms.OpenFileDialog openFileDialogEDL;
    }
}

