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

            richTxtEntryProgram.Text = allines;

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
                richTxtEntryProgram.Text = String.Empty;
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
                for (int i = 0; i < richTxtEntryProgram.Lines.Count(); i++)
                {
                    line = richTxtEntryProgram.Lines[i];
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
            gridLexems.Columns.Clear();
            //додаємо заголовок таблиці
            gridLexems.Columns.Add("wordCount", "№ Слова");
            gridLexems.Columns.Add("lex", "Лексема");
            gridLexems.Columns.Add("description", "Опис");
            gridLexems.Columns.Add("rowNumber", "№ рядка");
            gridLexems.Columns.Add("charNumber", "№ символа");
            foreach (var temp in richTxtEntryProgram.Lines)
            {
                if (temp != String.Empty)
                {
                    Lex_Prog += temp + "\r\n";
                }
            }

            Lex_Prog = TextEditor.CommentRemover("(*", "*)", Lex_Prog);
            string[] LexLines = Lex_Prog.Split(new Char[] { '\r' });
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
            string[] LexWords = Lex_Prog.Split(new char[] { ' ' });
            foreach (var temp in LexWords)
            {
                if ((temp == "\""))
                    quotesCount++;
                if ((temp == "\"") && (tsc == false) && (quotesCount % 2 == 1))
                    tsc = true;
                if (temp != String.Empty && tsc == false)
                {
                    wordCount++;
                    //записуємо координати лексеми
                    row = richTxtEntryProgram.GetLineFromCharIndex(richTxtEntryProgram.Text.IndexOf(temp, sting));
                    symbol = richTxtEntryProgram.Lines[row].IndexOf(temp, sts);
                    if (richTxtEntryProgram.Lines[row].LastIndexOf(temp) != richTxtEntryProgram.Lines[row].IndexOf(temp))
                    {
                        sts = richTxtEntryProgram.Lines[row].IndexOf(temp, sts);
                    }
                    else
                    {
                        sts = 0;
                    }
                    row++;
                    symbol++;
                    sting = richTxtEntryProgram.Text.IndexOf(temp, sting);

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
                            gridLexems.Rows.Add(wordCount.ToString(), temp, Lex.Operators[(int)word.Value].Type,
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
                    sting = richTxtEntryProgram.Text.IndexOf(temp, sting);
                }
                else if (tsc == true)
                {
                    tempStringConstant += temp + " ";
                    if (temp == "\"" && tempStringConstant.Length > 2 && quotesCount % 2 == 0)
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

            //----------Синтаксичний аналіз---------------
            int syntaxErrorCount = 0;
            string syntText = "S ";
            for (int i = 0; i < gridLexems.RowCount-1; i++)
            {
                switch (gridLexems["description", i].Value.ToString())
                {
                    default:
                    case "Ключове слово":
                        syntText += gridLexems["lex", i].Value.ToString() + " ";
                        break;
                    case "Змінна":
                    case "Константа(8-ва)":
                    case "Костанта(рядкова)":
                        syntText += "E ";
                        break;
                    case "Знак закінчення рядка":
                        try
                        {
                            if (gridLexems["lex", i + 1].Value.ToString() == "}" || i == gridLexems.RowCount - 2)
                                syntText += "F ";
                            else
                                syntText += "F S "; //розбиваємо на символ початку та кінця рядка
                        }
                        catch
                        {
                            syntText += "F ";
                        }
                        break;
                    case "Знак відкриття блоку":
                        syntText += "{ S ";
                        break;
                    case "Знак закриття блоку":
                        if (gridLexems["lex", i + 1].Value.ToString() == "}")
                            syntText += "} F ";
                        else
                            syntText += "} F S ";
                        break;
                }
            }
            syntText = syntText.Replace("prog ", String.Empty);
            syntText = syntText.Replace("end.", String.Empty);
            //Згормаємо все те що в лапках (бо це рядкова константа)
            //Якщо кількість лапок непарна - згортається все після лапки
            int firstIndex, secondIndex;
            while (syntText.Contains("\""))
            {
                firstIndex = syntText.IndexOf('\"');
                secondIndex = syntText.IndexOf('\"', firstIndex + 1);
                if (secondIndex < 0)
                {
                    syntText = syntText.Remove(firstIndex, syntText.Length - firstIndex);
                    break;
                }
                syntText = syntText.Remove(firstIndex, secondIndex - firstIndex + 1);
                syntText = syntText.Insert(firstIndex, "E");
            }
            syntText.TrimEnd(new[] {' '});
            
            //--згортка умов--
            while (syntText.Contains("E > E") || syntText.Contains("E < E") || syntText.Contains("E == E") ||
                   syntText.Contains("( T )"))
            {
                syntText = syntText.Replace("E > E", "T");
                syntText = syntText.Replace("E < E", "T");
                syntText = syntText.Replace("E == E", "T");
                syntText = syntText.Replace("( T )", "T");
            }
            
            //--Згортка мат. операцій--

            while (syntText.Contains("E + E")||syntText.Contains("E - E")||syntText.Contains("E = E")||syntText.Contains("( E )"))
            {
                syntText = syntText.Replace("E + E", "E");
                syntText = syntText.Replace("E - E", "E");
                syntText = syntText.Replace("E = E", "E");
                syntText = syntText.Replace("( E )", "E");
            }

            //--Згортка дій Е--

            while (syntText.Contains("int E")||syntText.Contains("S E F")||syntText.Contains("B B"))
            {
                syntText = syntText.Replace("int E", "E");
                syntText = syntText.Replace("S E F", "B");
                syntText = syntText.Replace("B B", "B");
            }

            //Згортка дій В блоки

            while (syntText.Contains("do { B } while T")||syntText.Contains("if T { B }")||syntText.Contains("else { B }")||syntText.Contains("S E F")||syntText.Contains("B B"))
            {
                syntText = syntText.Replace("do { B } while T", "E");
                syntText = syntText.Replace("if T { B }", "E");
                syntText = syntText.Replace("else { B }", "E");
                syntText = syntText.Replace("S E F", "B");
                syntText = syntText.Replace("B B", "B");
            }

            //Список можливих синтаксичних помилок
            //Перевірка на наявність ключових слів prog i end.
            if (richTxtEntryProgram.Text.IndexOf("prog") != 0)
            {
                errorCounter++;
                syntaxErrorCount++;
                //todo ErrAdd(errorCount, 0, 0, "1", "");
            }

            if (richTxtEntryProgram.Text.IndexOf("end.") != richTxtEntryProgram.Text.Length - 4)
            {
                errorCounter++;
                syntaxErrorCount++;
                //todo ErrAdd
            }

            //перевірка чи кількість відкритих дужок відповідає кількості закритих
            char[] controlBracketText = richTxtEntryProgram.Text.ToCharArray();
            int openBracketCount = 0, closeBracketCount = 0;
            int openZBracketCount = 0, closeZBracketCount = 0;
            for (int i = 0; i < controlBracketText.Length; i++)
            {
                switch (controlBracketText[i])
                {
                    case '{':
                        openZBracketCount++;
                        break;
                    case '}':
                        closeZBracketCount++;
                        break;
                    case '(':
                        openBracketCount++;
                        break;
                    case ')':
                        closeBracketCount++;
                        break;
                }
            }

            if (openBracketCount != closeBracketCount)
            {
                errorCounter++;
                syntaxErrorCount++;
                //todo add this errot to ErrAdd
            }

            if (openZBracketCount != closeZBracketCount)
            {
                errorCounter++;
                syntaxErrorCount++;
                //todo add this errot to ErrAdd
            }

            if (quotesCount%2 == 1)
            {
                errorCounter++;
                syntaxErrorCount++;
                //todo add this error;
            }

            //помилки пов'язані з результатом згортання
            if (syntText != "B" && syntText != "B " && quotesCount%2 == 0)
            {
                if (syntText == "S" || syntText == "S ") //синтаксичний аналізатор не сприймає пустого тексту
                {
                    errorCounter++;
                    syntaxErrorCount++;
                    //todo add this error to ErrAdd
                }
                else if (syntText.Contains("E E"))
                {
                    errorCounter++;
                    syntaxErrorCount++;
                    //todo add this error to ErrAdd
                }
                else if (syntText.Contains("+") || syntText.Contains("-") || syntText.Contains("==") ||
                         syntText.Contains(">") || syntText.Contains("<"))
                {
                    errorCounter++;
                    syntaxErrorCount++;
                    //todo add this error to ErrAdd
                }
                else
                {
                    if (openBracketCount == closeBracketCount || openZBracketCount == closeZBracketCount)
                    {
                        errorCounter++;
                        syntaxErrorCount++;
                        //todo add this error to ErrAdd
                    }
                }

            }
            richTextSyntax.Text = syntText;
        }
    }
}
