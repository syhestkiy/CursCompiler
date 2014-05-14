namespace CursCompiler
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richTxtEntryFile = new System.Windows.Forms.RichTextBox();
            this.txtOpenFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(625, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "upload";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTxtEntryFile
            // 
            this.richTxtEntryFile.Location = new System.Drawing.Point(13, 75);
            this.richTxtEntryFile.Name = "richTxtEntryFile";
            this.richTxtEntryFile.Size = new System.Drawing.Size(687, 252);
            this.richTxtEntryFile.TabIndex = 2;
            this.richTxtEntryFile.Text = "";
            // 
            // txtOpenFilePath
            // 
            this.txtOpenFilePath.Location = new System.Drawing.Point(24, 48);
            this.txtOpenFilePath.Name = "txtOpenFilePath";
            this.txtOpenFilePath.Size = new System.Drawing.Size(514, 20);
            this.txtOpenFilePath.TabIndex = 3;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 357);
            this.Controls.Add(this.txtOpenFilePath);
            this.Controls.Add(this.richTxtEntryFile);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Курсова робота з СПЗ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTxtEntryFile;
        private System.Windows.Forms.TextBox txtOpenFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

