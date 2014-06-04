using System;

namespace CursCompiler.LexAnalyzer
{
    internal class TextEditor
    {
        public static string Convolution(string symbOpen, string symbClose, string text, string charToReplase)
        {
            int op = 0;
            int cl = 0;
            while (text.Contains(symbOpen))
            {
                op = text.IndexOf(symbOpen, op, StringComparison.Ordinal);
                cl = text.IndexOf(symbClose, op, StringComparison.Ordinal);
                var temp = text.ToCharArray();
                string stringtemp=String.Empty;
                for (int i = op; i <= cl; i++)
                {
                    stringtemp += temp[i];
                }
                text = text.Replace(stringtemp,charToReplase);
            }
            return text;
        }

        public static string CommentRemover(string commentOpen, string commentClose, string textmas)
        {
            int op = 0;
            int cl = 0;
            while (textmas.Contains(commentOpen))
            {
                op = textmas.IndexOf(commentOpen, op, StringComparison.Ordinal);
                cl = textmas.IndexOf(commentClose, op, StringComparison.Ordinal);
                textmas = textmas.Remove(op, cl - op + 2);
            }
            return textmas;
        }

        public static string SpaceCorrector(string textline)
        {
            int i;
            //розділення деяких операторів (для зручнішого зчитування)
            //Індуський код, але простіший для розуміння. Якщо додавати пробіли тільки для операторів, які його
            //не мають, то прийдеться розбивати кожного разу string на масив char. Складніше і довше для
            //виконання процесором, але зручніше для використання в C#
            for (i = 0; i < Lex.Operators.Length; i++)
            {
                if (textline.Contains(Lex.Operators[i].Name + Lex.Operators[i].Name))
                {
                    if (Lex.Operators[i].Name == "+" || Lex.Operators[i].Name == "-" || Lex.Operators[i].Name == "=" || Lex.Operators[i].Name == "|")
                    {
                        textline = textline.Replace(Lex.Operators[i].Name + Lex.Operators[i].Name, (" " + Lex.Operators[i].Name + Lex.Operators[i].Name + " "));
                    }
                    else
                    {
                        textline = textline.Replace(Lex.Operators[i].Name, (" " + Lex.Operators[i].Name + " "));
                    }
                }
                else
                {
                    textline = textline.Replace(Lex.Operators[i].Name, (" " + Lex.Operators[i].Name + " "));
                }
            }
            //Видалення повторень пробілів на початку та в кінці рядка
            textline = textline.Trim(new Char[] { ' ', '\t', '\r', '\n' });
            //видалення табуляції (якщо випадково попала в середину рядка)
            while (textline.Contains("\t"))
            {
                textline = textline.Replace("\t", " ");
            }
            //видалення повторення пробілів в середині рядка
            while (textline.Contains("  "))
            {
                textline = textline.Replace("  ", " ");
            }
            textline = textline + " ";
            return textline;
        }
    }
}