﻿namespace CursCompiler.Forms
{
    partial class ErrorReportForm
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
            this.richTxtListOfErrors = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTxtListOfErrors
            // 
            this.richTxtListOfErrors.Location = new System.Drawing.Point(1, 0);
            this.richTxtListOfErrors.Name = "richTxtListOfErrors";
            this.richTxtListOfErrors.Size = new System.Drawing.Size(671, 283);
            this.richTxtListOfErrors.TabIndex = 0;
            this.richTxtListOfErrors.Text = "";
            // 
            // ErrorReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 283);
            this.Controls.Add(this.richTxtListOfErrors);
            this.Name = "ErrorReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error!";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTxtListOfErrors;
    }
}