using System;
using System.Drawing.Printing;
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

            //string lines = TextEditor.CommentRemover("(*", "*)", allines);
            //lines = TextEditor.SpaceCorrector(lines);
            //foreach (var line in lines)
            //{
            //    richTxtEdit.Text += line;
            //}
            //todo move logic to another file


        }

        //This code deleting text in richTextBox
        private void btnDeleteTextFromTextEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(@"Ви дійсно хочете видалити текст?", @"Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            //todo Paste here prioryty matrix initializator
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            //------------Lexical analiz--------------
            string Lex_Prog = String.Empty;
            gridLexems.Rows.Clear();
            //додаємо заголовок таблиці
            gridLexems.Columns.Add("wordCount", "№ Слова");
            gridLexems.Columns.Add("lexem", "Лексема");
            gridLexems.Columns.Add("description", "Опис");
            gridLexems.Columns.Add("rowNumber", "№ рядка");
            gridLexems.Columns.Add("charNumber", "№ символа");
            foreach (var temp in richTxtEdit.Lines)
            {
                if (temp != String.Empty)
                {
                    Lex_Prog += temp + "\r\n";
                }
            }

            Lex_Prog = TextEditor.CommentRemover("(*", "*)", Lex_Prog);
            string[] LexLines = Lex_Prog.Split(new Char[] {'\r'});
            Lex_Prog = String.Empty;
            for (int i = 0; i < LexLines.Length - 1; i++)
            {
                Lex_Prog += TextEditor.SpaceCorrector(LexLines[i]);
            }
            int wordCount = 0; //word counter
            int unknownLexemsCount = 0; //counter for unknown lexems
            int sting = 0, sts = 0; //зміщення в тексті при пошуку лексем
            int row = 0, symbol = 0;
            string tempStringConstant = String.Empty; //для збірки рядкових констант
            bool tsc = false;
            int quotesCount = 0;
            int errorCounter = 0;
            bool LexAnalizPerformed = false;

            //проводимо перевірку по словах 
            string[] LexWords = Lex_Prog.Split(new char[] {' '});
            foreach (var temp in LexWords)
            {
                if ((temp == "\""))
                    quotesCount++;
                if ((temp == "\"") && (tsc == false) && (quotesCount%2 == 1))
                    tsc = true;
                if (temp != String.Empty && tsc == false)
                {
                    wordCount++;
                    //записуємо координати лексеми
                    row = richTxtEdit.GetLineFromCharIndex(richTxtEdit.Text.IndexOf(temp, sting));
                    symbol = richTxtEdit.Lines[row].IndexOf(temp, sts);
                    if (richTxtEdit.Lines[row].LastIndexOf(temp) != richTxtEdit.Lines[row].IndexOf(temp))
                    {
                        sts = richTxtEdit.Lines[row].IndexOf(temp, sts);
                    }
                    else
                    {
                        sts = 0;
                    }
                    row++;
                    symbol++;
                    sting = richTxtEdit.Text.IndexOf(temp, sting);

                    //перевіряємо до якого класу належить лексема
                    //KeyWord
                    LexAnalyzer.TreeNode word = LexListMaker.BTKeyWords.FindNode(temp);
                    if (word != null)
                    {
                        gridLexems.Rows.Add(wordCount.ToString(), temp, "Ключове слово", row.ToString(),
                            symbol.ToString());
                    }
                    else
                    {
                        //Операція
                        word = LexListMaker.BTOperators.FindNode(temp);
                        if (word != null)
                        {
                            gridLexems.Rows.Add(wordCount.ToString(), temp, Lex.Operators[(int) word.Value].Type,
                                row.ToString(), symbol.ToString());
                        }
                        else
                        {
                            char[] templet = temp.ToCharArray();
                            int numbersOfDigits = 0, numbersOfLawSymbols = 0;
                            for (int i = 0; i < templet.Length; i++)
                            {
                                if (char.IsDigit(templet[i]))
                                    numbersOfDigits++;
                                if (char.IsLetterOrDigit(templet[i]) || templet[i] == '-')
                                    numbersOfLawSymbols++;
                            }
                            //Constant
                            if (temp.Length == numbersOfDigits && !temp.Contains('9') && !temp.Contains('8'))
                            {
                                gridLexems.Rows.Add(wordCount.ToString(), temp, "8-ва константа", row.ToString(),
                                    symbol.ToString());
                            }
                                //Variable
                            else if ((char.IsLetter(templet[0])) && temp.Length == numbersOfLawSymbols)
                            {
                                gridLexems.Rows.Add(wordCount.ToString(), temp, "Змінна", row.ToString(),
                                    symbol.ToString());
                            }
                            else
                            {
                                gridLexems.Rows.Add(wordCount.ToString(), temp, "Невідома лексема", row.ToString(),
                                    symbol.ToString());
                                unknownLexemsCount++;
                                errorCounter++;
                                //todo Add error struct ErrAdd(errorCount, r, s, temp,"");

                            }
                        }

                    }
                    sting = richTxtEdit.Text.IndexOf(temp, sting);
                }
                else if (tsc == true)
                {
                    tempStringConstant += temp + " ";
                    if (temp == "\"" && tempStringConstant.Length > 2 && quotesCount%2 == 0)
                    {
                        wordCount++;
                        gridLexems.Rows.Add(wordCount.ToString(), tempStringConstant, "Константа(рядкова)",
                            row.ToString(), symbol.ToString());
                        tsc = false;
                        tempStringConstant = String.Empty;
                    }
                }

            }
            LexAnalizPerformed = true;
            //лексичний аналіз завершено;
        }
    }
}
