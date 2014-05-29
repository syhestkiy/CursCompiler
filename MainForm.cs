using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CursCompiler.LexAnalyzer;

namespace CursCompiler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //This code opens text file with program and add it to richTextBox
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            FileStream fs = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(fs))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            string allines = sb.ToString().ToLower();

            richTxtEdit.Text = allines;

            string lines = TextEditor.CommentRemover("(*", "*)", allines);
            lines = TextEditor.SpaceCorrector(lines);
            foreach (var line in lines)
            {
                richTxtEdit.Text += line;
            }
        }

        //This code deleting text in richTextBox
        private void btnDeleteTextFromTextEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Ви дійсно хочете видалити текст?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                richTxtEdit.Text = String.Empty;
            }

        }

        /*         Save text from richTextBox to text file         */
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "DefaultOutputName.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string line;
                StreamWriter writer = new StreamWriter(save.OpenFile());
                for (int i = 0; i < richTxtEdit.Lines.Count(); i++)
                {
                    line = richTxtEdit.Lines[i];
                    writer.WriteLine(line);
                }
                writer.Dispose();
                writer.Close();
            }


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            LexListMaker.InitializeBinaryTrees();
        }
    }
}
