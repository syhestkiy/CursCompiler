﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CursCompiler.ErrorLoger;
using CursCompiler.LexAnalyzer;

namespace CursCompiler.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //заповнення шапки таблиці лексем
            gridLexems.Columns.Add("wordCount", "№ Слова");
            gridLexems.Columns.Add("lex", "Лексема");
            gridLexems.Columns.Add("description", "Опис");
            gridLexems.Columns.Add("rowNumber", "№ рядка");
            gridLexems.Columns.Add("charNumber", "№ символа");
            gridLexems.Columns[0].Width = 80;
            gridLexems.Columns[1].Width = 140;
            gridLexems.Columns[2].Width = 270;
            gridLexems.Columns[3].Width = 85;
            gridLexems.Columns[4].Width = 88;
            //заповнюємо шапку таблиці ідентифікаторів
            gridIdintifers.Columns.Add("identNumber", "№ ідентифікатора");
            gridIdintifers.Columns.Add("idintifer", "Ідентифікатор");
            gridIdintifers.Columns.Add("identType", "Тип");
            gridIdintifers.Columns.Add("row", "Рядок");
            gridIdintifers.Columns.Add("symbol", "Символ");
            gridIdintifers.Columns[0].Width = 140;
            gridIdintifers.Columns[1].Width = 270;
            gridIdintifers.Columns[2].Width = 90;
            gridIdintifers.Columns[3].Width = 85;
            gridIdintifers.Columns[4].Width = 88;
            //заповнюємо шапку таблиці тріад
            gridTriads.Columns.Add("triadNumber", "№ тріади");
            gridTriads.Columns.Add("triad", "Тріада");
            gridTriads.Columns[0].Width = 200;
            gridTriads.Columns[1].Width = 270;
            lblRowNumber.Font = new Font(richTxtEntryProgram.Font.FontFamily, richTxtEntryProgram.Font.Size);
            
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
            var save = new SaveFileDialog {FileName = "DefaultOutputName.txt", Filter = @"Text File | *.txt"};
            if (save.ShowDialog() == DialogResult.OK)
            {
                string line;
                var writer = new StreamWriter(save.OpenFile());
                for (int i = 0; i < richTxtEntryProgram.Lines.Count(); i++)
                {
                    line = richTxtEntryProgram.Lines[i];
                    writer.WriteLine(line);
                }
                
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
            gridIdintifers.Rows.Clear();
            ErrorLogger.Clear();
            richTextSyntax.Text = String.Empty;
            //додаємо заголовок таблиці
            
            foreach (var temp in richTxtEntryProgram.Lines)
            {
                if (temp != String.Empty)
                {
                    lexProg += temp + "\r\n";
                }
            }

            lexProg = TextEditor.CommentRemover("(*", "*)", lexProg);
            var lexLines = lexProg.Split(new[] { '\r' });
            lexProg = String.Empty;
            for (int i = 0; i < lexLines.Length - 1; i++)
            {
                lexProg += TextEditor.SpaceCorrector(lexLines[i]);
            }
            var wordCount = 0; //word counter
            var unknownLexemsCount = 0; //counter for unknown lexems
            int sting = 0, sts = 0; //зміщення в тексті при пошуку лексем
            int row = 0, symbol = 0;
            var tempStringConstant = String.Empty; //для збірки рядкових констант
            var tsc = false;
            var quotesCount = 0;
            var errorCounter = 0;

            //проводимо перевірку по словах 
            var lexWords = lexProg.Split(new[] { ' ' });
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
                    row = richTxtEntryProgram.GetLineFromCharIndex(richTxtEntryProgram.Text.IndexOf(temp, sting, StringComparison.Ordinal));
                    symbol = richTxtEntryProgram.Lines[row].IndexOf(temp, sts, StringComparison.Ordinal);
                    if (richTxtEntryProgram.Lines[row].LastIndexOf(temp, StringComparison.Ordinal) != richTxtEntryProgram.Lines[row].IndexOf(temp, StringComparison.Ordinal))
                    {
                        sts = richTxtEntryProgram.Lines[row].IndexOf(temp, sts, StringComparison.Ordinal);
                    }
                    else
                    {
                        sts = 0;
                    }
                    row++;
                    symbol++;
                    sting = richTxtEntryProgram.Text.IndexOf(temp, sting, StringComparison.Ordinal);

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
                        syntText += "a ";
                        break;
                    case "8-ва константа":
                        syntText += "c ";
                        break;
                        
                    
                    case "Знак закінчення рядка":
                        try
                        {
                            if (gridLexems["lex", i + 1].Value.ToString() == "} " || i == gridLexems.RowCount - 2)
                                syntText += " F ";
                            else
                                syntText += " F S "; //розбиваємо на символ початку та кінця рядка
                        }
                        catch
                        {
                            syntText += " F ";
                        }
                        break;
                    case "Знак відкриття блоку":
                        syntText += "{ ";
                        break;
                    case "Знак закриття блоку":
                        if (gridLexems["lex", i + 1].Value.ToString() == " } ")
                            syntText += " } F ";
                        else
                            syntText += " } F S ";
                        break;
                }
            }
            richTextSyntax.Text += syntText+"\n";
          // згортка порівнянь
            while (syntText.Contains("a < a") || syntText.Contains("a > a")
                   || syntText.Contains("a != a") || syntText.Contains("a == a")
                   || syntText.Contains("a < c") || syntText.Contains("a > c")
                   || syntText.Contains("a != c") || syntText.Contains("a == c")
                   || syntText.Contains("c < c") || syntText.Contains("c > c")
                   || syntText.Contains("c != c") || syntText.Contains("c == c")
                   || syntText.Contains("c < a") || syntText.Contains("c > a")
                   || syntText.Contains("c != a") || syntText.Contains("c == a"))
            {
                syntText = syntText.Replace("a < a", "D");
                syntText = syntText.Replace("a > a", "D");
                syntText = syntText.Replace("a == a", "D");
                syntText = syntText.Replace("a != a", "D");
                syntText = syntText.Replace("c < c", "D");
                syntText = syntText.Replace("c > c", "D");
                syntText = syntText.Replace("c == c", "D");
                syntText = syntText.Replace("c != c", "D");
                syntText = syntText.Replace("a < c", "D");
                syntText = syntText.Replace("a > c", "D");
                syntText = syntText.Replace("a == c", "D");
                syntText = syntText.Replace("a != c", "D");
                syntText = syntText.Replace("c < a", "D");
                syntText = syntText.Replace("c > a", "D");
                syntText = syntText.Replace("c == a", "D");
                syntText = syntText.Replace("c != a", "D");
            }

            while (syntText.Contains("a + a") || syntText.Contains("a - a")
     || syntText.Contains("( a )") || syntText.Contains("c + c")
     || syntText.Contains("c - c") || syntText.Contains("( c )")
    || syntText.Contains("a + c") || syntText.Contains("a - c")
    || syntText.Contains("c + a") || syntText.Contains("c - a")
    || syntText.Contains("a --"))
            {
                syntText = syntText.Replace("a + a", "E ");
                syntText = syntText.Replace("a - a", "E ");
                syntText = syntText.Replace("( a )", "( E ) ");
                syntText = syntText.Replace("c + c", "E ");
                syntText = syntText.Replace("c - c", "E ");
                syntText = syntText.Replace("( c )", "( E ) ");
                syntText = syntText.Replace("a + c", "E ");
                syntText = syntText.Replace("a - c", "E ");
                syntText = syntText.Replace("c + a", "E ");
                syntText = syntText.Replace("c - a", "E ");
                syntText = syntText.Replace("a --", " E ");
            }
            richTextSyntax.Text += syntText + "\n";
            //згортка логічних операцій

            while (syntText.Contains("c & c") || syntText.Contains("c || c") 
                || syntText.Contains("! ( c )") || syntText.Contains("a & a") 
                || syntText.Contains("a || a") || syntText.Contains("! ( a )"))
            {
                syntText = syntText.Replace("a & a", "B");
                syntText = syntText.Replace("a || a", "B");
                syntText = syntText.Replace("! ( a )", "B");
                syntText = syntText.Replace("c & c", "B");
                syntText = syntText.Replace("c || c", "B");
                syntText = syntText.Replace("! ( c )", "B");
                
                
            }

            //згортка присвоєнь
            while (syntText.Contains("a = ( B )") || syntText.Contains("a = E")
                || syntText.Contains("a = ! ( E )") || syntText.Contains("a = ! ( B )")
                ||syntText.Contains("a = a") || syntText.Contains("a = c")
                ||syntText.Contains(" E "))
            {
                syntText=syntText.Replace("a = ( B )", "O ");
                syntText = syntText.Replace("a = E", "O ");
                syntText = syntText.Replace("a = ! ( E )", "O ");
                syntText = syntText.Replace("a = ! ( B )", "O ");
                syntText = syntText.Replace("a = a", "O ");
                syntText = syntText.Replace("a = c", "O ");
                syntText = syntText.Replace(" E ", " O ");
            }
            syntText = TextEditor.SpaceCorrector(syntText);
            richTextSyntax.Text += syntText+"\n";

            while (syntText.Contains("int O"))
                syntText = syntText.Replace("int O", "O ");
            richTextSyntax.Text += syntText + "\n";
            syntText = TextEditor.SpaceCorrector(syntText);

            while (syntText.Contains("if ( D ) O ; else O ;")
                   || syntText.Contains("if ( D ) O ;"))
            {
                syntText = syntText.Replace("if ( D ) O ; else O ;", "O ");
                syntText = syntText.Replace("if ( D ) O ;", "O ");
            }
            syntText = TextEditor.SpaceCorrector(syntText);
            richTextSyntax.Text += syntText + "\n";

            syntText = TextEditor.Convolution("{", "}", syntText, "L");
            richTextSyntax.Text += syntText + "\n";

            while (syntText.Contains("do L while ( D ) ") || syntText.Contains("L L"))
            {
                syntText = syntText.Replace("do L while ( D )", "L ");
                syntText = syntText.Replace("L L", "L ");
            }
            syntText = TextEditor.SpaceCorrector(syntText);
            richTextSyntax.Text += syntText + "\n";

            while (syntText.Contains("L L"))
            {
                syntText = syntText.Replace("L L", "L ");
            }
            richTextSyntax.Text += syntText + "\n";

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

            }
            //end of syntax Analiz

            //Semantic analiz
            //список оголошених ідентифікаторів
            int declaredIdentCounter = 0;
            bool twiceDeclared = false;
            for (int i = 0; i < gridLexems.RowCount-1; i++)
            {
                if (gridLexems["description", i].Value.ToString() == "Змінна")
                {
                        for(int k=0;k<gridIdintifers.RowCount-1;k++)
                            if (gridIdintifers["idintifer", k].Value.ToString() == gridLexems["lex", i].Value.ToString())
                                twiceDeclared = true;

                        if (gridLexems["lex", i - 1].Value.ToString() == "int"&&twiceDeclared==false) //можливе розширення типів даних
                        {
                            declaredIdentCounter++;
                            gridIdintifers.Rows.Add(declaredIdentCounter.ToString(),
                                gridLexems["lex", i].Value.ToString(), "int",
                                gridLexems["rowNumber", i].Value , gridLexems["charNumber", i].Value);
                            
                        }
                        else if (gridLexems["lex", i - 1].Value.ToString() == "int" && twiceDeclared == true)
                        {
                            errorCounter++;//формуємо помилку що така змінна вже була оголошена
                            ErrorLogger.AddError(new Error(errorCounter, "3", gridLexems["lex", i].Value.ToString(),
                                Convert.ToInt32(gridLexems["rowNumber", i].Value.ToString()),
                                Convert.ToInt32(gridLexems["charNumber", i].Value.ToString()), "Змінна вже була оголошена"));
                            
                        }
                        twiceDeclared = false;//для наступного кроку перевірки
                }


            }

            bool idFinded = false;
            for (int i = 0; i < gridLexems.RowCount-1; i++)
            {
                if (gridLexems["description", i].Value.ToString() == "Змінна")
                {
                    for (int j = 0; j < declaredIdentCounter; j++)
                    {
                        if (gridLexems["lex", i].Value.ToString() == gridIdintifers["idintifer", j].Value.ToString())
                        {
                            idFinded = true;//ідентифікатор був оголошений
                        }
                    }
                    if (idFinded == false)
                    {
                        errorCounter++;
                        ErrorLogger.AddError(new Error(errorCounter, "3", gridLexems["lex", i].Value.ToString(),
                            Convert.ToInt32(gridLexems["rowNumber", i].Value.ToString()),
                            Convert.ToInt32(gridLexems["charNumber", i].Value.ToString()), "Невідома змінна"));
                    }
                    idFinded = false;//for next iteration
                }
            }
            //end of symantic analiz

            //Make triads
            int triadsCounter = 1;
            for (int i = 0; i < gridLexems.RowCount - 1; i++)
            {
                if (gridLexems["description", i].Value.ToString() == "Змінна" &&
                    gridLexems["lex", i - 1].Value.ToString() == "int"&&
                    gridLexems["lex",i+2].Value.ToString()!="!")
                {
                    triadsCounter++;
                    gridTriads.Rows.Add(triadsCounter.ToString(),
                        gridLexems["lex", i + 4].Value.ToString() + " (" + gridLexems["lex", i + 3].Value.ToString() +
                        " , " + gridLexems["lex", i + 5].Value.ToString() + ")");
                    
                    triadsCounter++;
                    gridTriads.Rows.Add(triadsCounter.ToString(),
                        gridLexems["lex", i + 1].Value.ToString() + " (" + gridLexems["lex", i].Value.ToString() + " , " +
                        "^" + (triadsCounter - 1).ToString() + ")");
                    
                }
                if (gridLexems["description", i].Value.ToString() == "Змінна" &&
                    gridLexems["lex", i - 1].Value.ToString() == "int" &&
                    gridLexems["lex", i + 2].Value.ToString() == "!")
                {
                    triadsCounter++;
                    gridTriads.Rows.Add(triadsCounter,
                        gridLexems["lex", i + 2].Value.ToString() + " (" + gridLexems["lex", i + 4].Value.ToString() +
                        ",0 )");
                    triadsCounter++;
                    gridTriads.Rows.Add(triadsCounter,
                        gridLexems["lex", i + 1].Value.ToString() + " (" + gridLexems["lex", i].Value.ToString() + ",^" +
                        (triadsCounter - 1).ToString()+" )");
                }
            }
            //end of triads maker
            if (errorCounter > 0)
            {
                Form errorForm=new ErrorReportForm();
                errorForm.Show();
            }
            else
            {
                MessageBox.Show(@"Успішно скомпільовано",@"Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }
        //обробка клавіатурних скорочень
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control)
                switch (e.KeyCode)
                {
                    case Keys.O:
                        btnOpen.PerformClick();
                        break;
                    case Keys.S:
                        btnSaveAs.PerformClick();
                        break;
                    case Keys.D:
                        btnDeleteTextFromTextEdit.PerformClick();
                        break;
                    case Keys.K:
                        btnCompile.PerformClick();
                        break;
                    case Keys.Q:
                        btnExit.PerformClick();
                        break;
                    case Keys.H:
                        btnHelp.PerformClick();
                        break;
                }
        }
        //нумерація рядків 
        private void UpdateNumberLabel()
        {
            Point pos =new Point(0,0);
            int firstIndex = richTxtEntryProgram.GetCharIndexFromPosition(pos);
            int firstLine = richTxtEntryProgram.GetLineFromCharIndex(firstIndex);

            pos.X = ClientRectangle.Width;
            pos.Y = ClientRectangle.Height;

            int lastIndex = richTxtEntryProgram.GetCharIndexFromPosition(pos);
            int lastLine = richTxtEntryProgram.GetLineFromCharIndex(lastIndex);

            pos = richTxtEntryProgram.GetPositionFromCharIndex(lastIndex);

            lblRowNumber.Text = "";
            for (int i = firstLine; i < lastLine+2; i++)
            {
                lblRowNumber.Text += i + 1 + "\n";
            }
        }

        private void richTxtEntryProgram_TextChanged(object sender, EventArgs e)
        {
            UpdateNumberLabel();
        }

        private void richTxtEntryProgram_VScroll(object sender, EventArgs e)
        {
            int d = richTxtEntryProgram.GetPositionFromCharIndex(1).Y%(richTxtEntryProgram.Font.Height+1);
            lblRowNumber.Location=new Point(0,d);
            UpdateNumberLabel();
        }

        private void richTxtEntryProgram_Resize(object sender, EventArgs e)
        {
            richTxtEntryProgram_VScroll(null, null);
        }

        private void richTxtEntryProgram_FontChanged(object sender, EventArgs e)
        {
            UpdateNumberLabel();
            richTxtEntryProgram_VScroll(null, null);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Form helpForm=new HelpForm();
            helpForm.Show();
        }

    }

}
