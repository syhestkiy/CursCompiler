namespace CursCompiler.Forms
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.tabsHelpForm = new System.Windows.Forms.TabControl();
            this.tabGeneralInfo = new System.Windows.Forms.TabPage();
            this.richTxtGeneralInfo = new System.Windows.Forms.RichTextBox();
            this.tabSyntax = new System.Windows.Forms.TabPage();
            this.richTxtHelpSyntax = new System.Windows.Forms.RichTextBox();
            this.tabsHelpForm.SuspendLayout();
            this.tabGeneralInfo.SuspendLayout();
            this.tabSyntax.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabsHelpForm
            // 
            this.tabsHelpForm.Controls.Add(this.tabGeneralInfo);
            this.tabsHelpForm.Controls.Add(this.tabSyntax);
            this.tabsHelpForm.Location = new System.Drawing.Point(0, 0);
            this.tabsHelpForm.Name = "tabsHelpForm";
            this.tabsHelpForm.SelectedIndex = 0;
            this.tabsHelpForm.Size = new System.Drawing.Size(408, 312);
            this.tabsHelpForm.TabIndex = 0;
            // 
            // tabGeneralInfo
            // 
            this.tabGeneralInfo.Controls.Add(this.richTxtGeneralInfo);
            this.tabGeneralInfo.Location = new System.Drawing.Point(4, 22);
            this.tabGeneralInfo.Name = "tabGeneralInfo";
            this.tabGeneralInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralInfo.Size = new System.Drawing.Size(400, 286);
            this.tabGeneralInfo.TabIndex = 0;
            this.tabGeneralInfo.Text = "General";
            this.tabGeneralInfo.UseVisualStyleBackColor = true;
            // 
            // richTxtGeneralInfo
            // 
            this.richTxtGeneralInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtGeneralInfo.Location = new System.Drawing.Point(0, 0);
            this.richTxtGeneralInfo.Name = "richTxtGeneralInfo";
            this.richTxtGeneralInfo.ReadOnly = true;
            this.richTxtGeneralInfo.Size = new System.Drawing.Size(402, 279);
            this.richTxtGeneralInfo.TabIndex = 0;
            this.richTxtGeneralInfo.Text = resources.GetString("richTxtGeneralInfo.Text");
            // 
            // tabSyntax
            // 
            this.tabSyntax.Controls.Add(this.richTxtHelpSyntax);
            this.tabSyntax.Location = new System.Drawing.Point(4, 22);
            this.tabSyntax.Name = "tabSyntax";
            this.tabSyntax.Padding = new System.Windows.Forms.Padding(3);
            this.tabSyntax.Size = new System.Drawing.Size(400, 286);
            this.tabSyntax.TabIndex = 1;
            this.tabSyntax.Text = "Syntax";
            this.tabSyntax.UseVisualStyleBackColor = true;
            // 
            // richTxtHelpSyntax
            // 
            this.richTxtHelpSyntax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtHelpSyntax.Location = new System.Drawing.Point(0, 0);
            this.richTxtHelpSyntax.Name = "richTxtHelpSyntax";
            this.richTxtHelpSyntax.ReadOnly = true;
            this.richTxtHelpSyntax.Size = new System.Drawing.Size(400, 286);
            this.richTxtHelpSyntax.TabIndex = 0;
            this.richTxtHelpSyntax.Text = resources.GetString("richTxtHelpSyntax.Text");
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 315);
            this.Controls.Add(this.tabsHelpForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HelpForm";
            this.tabsHelpForm.ResumeLayout(false);
            this.tabGeneralInfo.ResumeLayout(false);
            this.tabSyntax.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsHelpForm;
        private System.Windows.Forms.TabPage tabGeneralInfo;
        private System.Windows.Forms.RichTextBox richTxtGeneralInfo;
        private System.Windows.Forms.TabPage tabSyntax;
        private System.Windows.Forms.RichTextBox richTxtHelpSyntax;
    }
}