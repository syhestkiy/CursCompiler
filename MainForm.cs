using System;
using System.IO;
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            openFileDialog.ShowDialog();
            txtOpenFilePath.Text = openFileDialog.FileName;
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            FileStream fs = File.Open(txtOpenFilePath.Text, FileMode.Open, FileAccess.Read, FileShare.None);
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

            richTxtEntryFile.Text = allines;

            string lines=TextEditor.CommentRemover("(*","*)",allines);
            lines = TextEditor.SpaceCorrector(lines);
            foreach (var line in lines)
            {
                richTxtEntryFile.Text += line;
            }
        }
    }
}
