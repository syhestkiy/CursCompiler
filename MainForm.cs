using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CursCompiler.ErrorLoger;
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
            var fs = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
            var sb = new StringBuilder();
            using (var sr = new StreamReader(fs))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            var allines = sb.ToString().ToLower();

            richTxtEntryProgram.Text = allines;
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
            var save = new SaveFileDialog();
            save.FileName = "DefaultOutputName.txt";
            save.Filter = "Text File | *.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                string line;
                var writer = new StreamWriter(save.OpenFile());
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
            KeyPreview = true;
            LexListMaker.InitializeBinaryTrees();
            //todo Paste here prioryty matrix initializator
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {
            //------------Lexical analiz--------------
            string lexProg = String.Empty;
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
                    lexProg += temp + "\r\n";
                }
            }

            lexProg = TextEditor.CommentRemover("(*", "*)", lexProg);
            string[] lexLines = lexProg.Split(new Char[] { '\r' });
            lexProg = String.Empty;
            for (int i = 0; i < lexLines.Length - 1; i++)
            {
                lexProg += TextEditor.SpaceCorrector(lexLines[i]);
            }
            int wordCount = 0; //word counter
            int unknownLexemsCount = 0; //counter for unknown lexems
            int sting = 0, sts = 0; //зміщення в тексті при пошуку лексем
            int row = 0, symbol = 0;
            string tempStringConstant = String.Empty; //для збірки рядкових констант
            bool tsc = false;
            int quotesCount = 0;
            int errorCounter = 0;

            //проводимо перевірку по словах 
            string[] lexWords = lexProg.Split(new char[] { ' ' });
            foreach (var temp in lexWords)
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
                            var templet = temp.ToCharArray();
                            int numbersOfDigits = 0, numbersOfLawSymbols = 0;
                            foreach (char t in templet)
                            {
                                if (char.IsDigit(t))
                                    numbersOfDigits++;
                                if (char.IsLetterOrDigit(t) || t == '-')
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
                                ErrorLogger.AddError(new Error(errorCounter,"1",temp,row,symbol,"Невідома лексема"));
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
            //лексичний аналіз завершено;

            //----------Синтаксичний аналіз---------------
            int syntaxErrorCount = 0;
            string syntText = String.Empty;
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
            //syntText = syntText.Replace("prog ", String.Empty);
            //syntText = syntText.Replace("end.", String.Empty);
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
                ErrorLogger.AddError(new Error(errorCounter,"2","Відсутнє ключове слово \"prog\""));
            }

            if (richTxtEntryProgram.Text.IndexOf("end.") != richTxtEntryProgram.Text.Length - 5)//-5 тому що останній символ \n
            {
                errorCounter++;
                syntaxErrorCount++;
                ErrorLogger.AddError(new Error(errorCounter, "2", "Відсутнє ключове слово \"end.\""));
            }

            //перевірка чи кількість відкритих дужок відповідає кількості закритих
            var controlBracketText = richTxtEntryProgram.Text.ToCharArray();
            int openBracketCount = 0, closeBracketCount = 0;
            int openZBracketCount = 0, closeZBracketCount = 0;
            foreach (char t in controlBracketText)
            {
                switch (t)
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
                ErrorLogger.AddError(new Error(errorCounter,"2","Невідповідність кількості відкритих та закрити дужок "));
            }

            if (openZBracketCount != closeZBracketCount)
            {
                errorCounter++;
                syntaxErrorCount++;
                ErrorLogger.AddError(new Error(errorCounter, "2", "Невідповідність кількості відкритих та закрити дужок "));
            }

            if (quotesCount%2 == 1)
            {
                errorCounter++;
                syntaxErrorCount++;
                ErrorLogger.AddError(new Error(errorCounter, "2", "Невідповідність кількості відкритих та закрити лапок "));
            }

            //помилки пов'язані з результатом згортання
            if (syntText != "B" && syntText != "B " && quotesCount%2 == 0)
            {
                if (syntText == "S" || syntText == "S ") //синтаксичний аналізатор не сприймає пустого тексту
                {
                    errorCounter++;
                    syntaxErrorCount++;
                    ErrorLogger.AddError(new Error(errorCounter, "2", "Синтаксичний аналізатор не сприймає пустого тексту"));
                }
                else if (syntText.Contains("E E"))
                {
                    errorCounter++;
                    syntaxErrorCount++;
                    ErrorLogger.AddError(new Error(errorCounter, "2", "Помилка згортання"));
                }
                //else if (syntText.Contains("+") || syntText.Contains("-") || syntText.Contains("==") ||
                //         syntText.Contains(">") || syntText.Contains("<"))
                //{
                //    errorCounter++;
                //    syntaxErrorCount++;
                //    ErrorLogger.AddError(new Error(errorCounter, "2", "Помилка згортання"));
                //}
                //else
                //{
                //    if (openBracketCount == closeBracketCount || openZBracketCount == closeZBracketCount)
                //    {
                //        errorCounter++;
                //        syntaxErrorCount++;
                //        ErrorLogger.AddError(new Error(errorCounter, "2", "Помилка згортання"));
                //    }
                //}

            }
            richTextSyntax.Text = syntText+"\n";
            richTextSyntax.Text += ErrorLogger.GetAllErrors();
            //end of syntax Analiz
        }
    }
}
