using System;

namespace CursCompiler.LexAnalyzer
{
    internal class CommentParser
    {
        public static string CommentRemover(string CommentOpen, string CommentClose, string textmas)
        {
            int op = 0, cl = 0;
            while (textmas.Contains(CommentOpen))
            {
                op = textmas.IndexOf(CommentOpen, op, StringComparison.Ordinal);
                cl = textmas.IndexOf(CommentClose, op, StringComparison.Ordinal);
                textmas = textmas.Remove(op, cl - op + 2);
            }
            return textmas;
        }



    }
}