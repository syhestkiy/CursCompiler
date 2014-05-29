using System;

namespace CursCompiler.LexAnalyzer
{
    internal class TextEditor
    {
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


        public string SpaceCorrector(string textline)
        {
            int i;
            //розділення деяких операторів (для зручнішого зчитування)
            //Індуський код, але простіший для розуміння. Якщо додавати пробіли тільки для операторів, які його
            //не мають, то прийдеться розбивати кожного разу string на масив char. Складніше і довше для
            //виконання процесором, але зручніше для використання в C#
            for (i = 0; i < Operators.Length; i++)
            {
                if (textline.Contains(Operators[i].name + Operators[i].name))
                {
                    if (Operators[i].name == "+" || Operators[i].name == "-" || Operators[i].name == "=" || Operators[i].name == "|")
                    {
                        textline = textline.Replace(Operators[i].name + Operators[i].name, (" " + Operators[i].name + Operators[i].name + " "));
                    }
                    else
                    {
                        textline = textline.Replace(Operators[i].name, (" " + Operators[i].name + " "));
                    }
                }
                else
                {
                    textline = textline.Replace(Operators[i].name, (" " + Operators[i].name + " "));
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