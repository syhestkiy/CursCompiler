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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listOfTabs = new System.Windows.Forms.TabControl();
            this.tabTxtEditOrOpenExistingFile = new System.Windows.Forms.TabPage();
            this.tabLexems = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.richTxtEdit = new System.Windows.Forms.RichTextBox();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDeleteTextFromTextEdit = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.gridLexems = new System.Windows.Forms.DataGridView();
            this.listOfTabs.SuspendLayout();
            this.tabTxtEditOrOpenExistingFile.SuspendLayout();
            this.tabLexems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLexems)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // listOfTabs
            // 
            this.listOfTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfTabs.Controls.Add(this.tabTxtEditOrOpenExistingFile);
            this.listOfTabs.Controls.Add(this.tabLexems);
            this.listOfTabs.Location = new System.Drawing.Point(0, 0);
            this.listOfTabs.Name = "listOfTabs";
            this.listOfTabs.SelectedIndex = 0;
            this.listOfTabs.Size = new System.Drawing.Size(731, 327);
            this.listOfTabs.TabIndex = 0;
            // 
            // tabTxtEditOrOpenExistingFile
            // 
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.btnCompile);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.btnDeleteTextFromTextEdit);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.btnOpen);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.btnSaveAs);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.richTxtEdit);
            this.tabTxtEditOrOpenExistingFile.Location = new System.Drawing.Point(4, 22);
            this.tabTxtEditOrOpenExistingFile.Name = "tabTxtEditOrOpenExistingFile";
            this.tabTxtEditOrOpenExistingFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabTxtEditOrOpenExistingFile.Size = new System.Drawing.Size(723, 301);
            this.tabTxtEditOrOpenExistingFile.TabIndex = 0;
            this.tabTxtEditOrOpenExistingFile.Text = "Editor";
            this.tabTxtEditOrOpenExistingFile.UseVisualStyleBackColor = true;
            // 
            // tabLexems
            // 
            this.tabLexems.Controls.Add(this.gridLexems);
            this.tabLexems.Location = new System.Drawing.Point(4, 22);
            this.tabLexems.Name = "tabLexems";
            this.tabLexems.Padding = new System.Windows.Forms.Padding(3);
            this.tabLexems.Size = new System.Drawing.Size(723, 301);
            this.tabLexems.TabIndex = 1;
            this.tabLexems.Text = "Lexems";
            this.tabLexems.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(644, 329);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // richTxtEdit
            // 
            this.richTxtEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtEdit.Location = new System.Drawing.Point(8, 7);
            this.richTxtEdit.Name = "richTxtEdit";
            this.richTxtEdit.Size = new System.Drawing.Size(626, 288);
            this.richTxtEdit.TabIndex = 0;
            this.richTxtEdit.Text = "";
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAs.Location = new System.Drawing.Point(640, 7);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 1;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(640, 36);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDeleteTextFromTextEdit
            // 
            this.btnDeleteTextFromTextEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTextFromTextEdit.Location = new System.Drawing.Point(640, 65);
            this.btnDeleteTextFromTextEdit.Name = "btnDeleteTextFromTextEdit";
            this.btnDeleteTextFromTextEdit.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTextFromTextEdit.TabIndex = 3;
            this.btnDeleteTextFromTextEdit.Text = "Delete text";
            this.btnDeleteTextFromTextEdit.UseVisualStyleBackColor = true;
            this.btnDeleteTextFromTextEdit.Click += new System.EventHandler(this.btnDeleteTextFromTextEdit_Click);
            // 
            // btnCompile
            // 
            this.btnCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompile.Location = new System.Drawing.Point(640, 94);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(75, 34);
            this.btnCompile.TabIndex = 4;
            this.btnCompile.Text = "Compile";
            this.btnCompile.UseVisualStyleBackColor = true;
            // 
            // gridLexems
            // 
            this.gridLexems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLexems.Location = new System.Drawing.Point(8, 8);
            this.gridLexems.Name = "gridLexems";
            this.gridLexems.Size = new System.Drawing.Size(707, 287);
            this.gridLexems.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 357);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.listOfTabs);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Курсова робота з СПЗ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.listOfTabs.ResumeLayout(false);
            this.tabTxtEditOrOpenExistingFile.ResumeLayout(false);
            this.tabLexems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLexems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabControl listOfTabs;
        private System.Windows.Forms.TabPage tabTxtEditOrOpenExistingFile;
        private System.Windows.Forms.TabPage tabLexems;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.Button btnDeleteTextFromTextEdit;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.RichTextBox richTxtEdit;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridView gridLexems;
    }
}

