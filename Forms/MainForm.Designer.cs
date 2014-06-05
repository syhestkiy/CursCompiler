namespace CursCompiler.Forms
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
            this.lblRowNumber = new System.Windows.Forms.Label();
            this.btnCompile = new System.Windows.Forms.Button();
            this.btnDeleteTextFromTextEdit = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.richTxtEntryProgram = new System.Windows.Forms.RichTextBox();
            this.tabLexems = new System.Windows.Forms.TabPage();
            this.gridLexems = new System.Windows.Forms.DataGridView();
            this.tabListOfIdintifers = new System.Windows.Forms.TabPage();
            this.gridIdintifers = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextSyntax = new System.Windows.Forms.RichTextBox();
            this.tabTriads = new System.Windows.Forms.TabPage();
            this.gridTriads = new System.Windows.Forms.DataGridView();
            this.tabGeneretedCode = new System.Windows.Forms.TabPage();
            this.btnExit = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnHelp = new System.Windows.Forms.Button();
            this.listOfTabs.SuspendLayout();
            this.tabTxtEditOrOpenExistingFile.SuspendLayout();
            this.tabLexems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLexems)).BeginInit();
            this.tabListOfIdintifers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIdintifers)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabTriads.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTriads)).BeginInit();
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
            this.listOfTabs.Controls.Add(this.tabListOfIdintifers);
            this.listOfTabs.Controls.Add(this.tabPage1);
            this.listOfTabs.Controls.Add(this.tabTriads);
            this.listOfTabs.Controls.Add(this.tabGeneretedCode);
            this.listOfTabs.Location = new System.Drawing.Point(0, 0);
            this.listOfTabs.Name = "listOfTabs";
            this.listOfTabs.SelectedIndex = 0;
            this.listOfTabs.Size = new System.Drawing.Size(731, 327);
            this.listOfTabs.TabIndex = 0;
            // 
            // tabTxtEditOrOpenExistingFile
            // 
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.btnHelp);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.lblRowNumber);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.btnCompile);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.btnDeleteTextFromTextEdit);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.btnOpen);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.btnSaveAs);
            this.tabTxtEditOrOpenExistingFile.Controls.Add(this.richTxtEntryProgram);
            this.tabTxtEditOrOpenExistingFile.Location = new System.Drawing.Point(4, 22);
            this.tabTxtEditOrOpenExistingFile.Name = "tabTxtEditOrOpenExistingFile";
            this.tabTxtEditOrOpenExistingFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabTxtEditOrOpenExistingFile.Size = new System.Drawing.Size(723, 301);
            this.tabTxtEditOrOpenExistingFile.TabIndex = 0;
            this.tabTxtEditOrOpenExistingFile.Text = "Editor";
            this.tabTxtEditOrOpenExistingFile.UseVisualStyleBackColor = true;
            // 
            // lblRowNumber
            // 
            this.lblRowNumber.AutoSize = true;
            this.lblRowNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRowNumber.Location = new System.Drawing.Point(3, 3);
            this.lblRowNumber.Name = "lblRowNumber";
            this.lblRowNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRowNumber.Size = new System.Drawing.Size(13, 26);
            this.lblRowNumber.TabIndex = 5;
            this.lblRowNumber.Text = "1\r\n2";
            this.lblRowNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            this.btnCompile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
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
            this.btnDeleteTextFromTextEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
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
            this.btnOpen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
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
            this.btnSaveAs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // richTxtEntryProgram
            // 
            this.richTxtEntryProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTxtEntryProgram.Location = new System.Drawing.Point(40, 0);
            this.richTxtEntryProgram.Name = "richTxtEntryProgram";
            this.richTxtEntryProgram.Size = new System.Drawing.Size(594, 301);
            this.richTxtEntryProgram.TabIndex = 0;
            this.richTxtEntryProgram.Text = "";
            this.richTxtEntryProgram.VScroll += new System.EventHandler(this.richTxtEntryProgram_VScroll);
            this.richTxtEntryProgram.FontChanged += new System.EventHandler(this.richTxtEntryProgram_FontChanged);
            this.richTxtEntryProgram.TextChanged += new System.EventHandler(this.richTxtEntryProgram_TextChanged);
            this.richTxtEntryProgram.Resize += new System.EventHandler(this.richTxtEntryProgram_Resize);
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
            // gridLexems
            // 
            this.gridLexems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLexems.Location = new System.Drawing.Point(0, 0);
            this.gridLexems.Name = "gridLexems";
            this.gridLexems.Size = new System.Drawing.Size(723, 301);
            this.gridLexems.TabIndex = 0;
            // 
            // tabListOfIdintifers
            // 
            this.tabListOfIdintifers.Controls.Add(this.gridIdintifers);
            this.tabListOfIdintifers.Location = new System.Drawing.Point(4, 22);
            this.tabListOfIdintifers.Name = "tabListOfIdintifers";
            this.tabListOfIdintifers.Padding = new System.Windows.Forms.Padding(3);
            this.tabListOfIdintifers.Size = new System.Drawing.Size(723, 301);
            this.tabListOfIdintifers.TabIndex = 2;
            this.tabListOfIdintifers.Text = "Idintifers";
            this.tabListOfIdintifers.UseVisualStyleBackColor = true;
            // 
            // gridIdintifers
            // 
            this.gridIdintifers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridIdintifers.Location = new System.Drawing.Point(0, 0);
            this.gridIdintifers.Name = "gridIdintifers";
            this.gridIdintifers.Size = new System.Drawing.Size(723, 301);
            this.gridIdintifers.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextSyntax);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(723, 301);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Syntax";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextSyntax
            // 
            this.richTextSyntax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextSyntax.Location = new System.Drawing.Point(0, 0);
            this.richTextSyntax.Name = "richTextSyntax";
            this.richTextSyntax.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextSyntax.Size = new System.Drawing.Size(723, 305);
            this.richTextSyntax.TabIndex = 2;
            this.richTextSyntax.Text = "";
            // 
            // tabTriads
            // 
            this.tabTriads.Controls.Add(this.gridTriads);
            this.tabTriads.Location = new System.Drawing.Point(4, 22);
            this.tabTriads.Name = "tabTriads";
            this.tabTriads.Padding = new System.Windows.Forms.Padding(3);
            this.tabTriads.Size = new System.Drawing.Size(723, 301);
            this.tabTriads.TabIndex = 4;
            this.tabTriads.Text = "Triads";
            this.tabTriads.UseVisualStyleBackColor = true;
            // 
            // gridTriads
            // 
            this.gridTriads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTriads.Location = new System.Drawing.Point(0, 0);
            this.gridTriads.Name = "gridTriads";
            this.gridTriads.Size = new System.Drawing.Size(727, 305);
            this.gridTriads.TabIndex = 0;
            // 
            // tabGeneretedCode
            // 
            this.tabGeneretedCode.Location = new System.Drawing.Point(4, 22);
            this.tabGeneretedCode.Name = "tabGeneretedCode";
            this.tabGeneretedCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneretedCode.Size = new System.Drawing.Size(723, 301);
            this.tabGeneretedCode.TabIndex = 5;
            this.tabGeneretedCode.Text = "Genereted code";
            this.tabGeneretedCode.UseVisualStyleBackColor = true;
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
            this.btnExit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Location = new System.Drawing.Point(640, 183);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 357);
            this.Controls.Add(this.listOfTabs);
            this.Controls.Add(this.btnExit);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Курсова робота з СПЗ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.listOfTabs.ResumeLayout(false);
            this.tabTxtEditOrOpenExistingFile.ResumeLayout(false);
            this.tabTxtEditOrOpenExistingFile.PerformLayout();
            this.tabLexems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLexems)).EndInit();
            this.tabListOfIdintifers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridIdintifers)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabTriads.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTriads)).EndInit();
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
        private System.Windows.Forms.RichTextBox richTxtEntryProgram;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridView gridLexems;
        private System.Windows.Forms.TabPage tabListOfIdintifers;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gridIdintifers;
        private System.Windows.Forms.RichTextBox richTextSyntax;
        private System.Windows.Forms.TabPage tabTriads;
        private System.Windows.Forms.DataGridView gridTriads;
        private System.Windows.Forms.TabPage tabGeneretedCode;
        private System.Windows.Forms.Label lblRowNumber;
        private System.Windows.Forms.Button btnHelp;
    }
}

