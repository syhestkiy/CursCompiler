using System;

namespace CursCompiler.LexAnalyzer
{
    public enum CommAP
    {
        TrueCode,
        CommOpenBracket,
        CommOpenStar,
        CommChar,
        CommCloseStar,
        CommCloseBracket
    }
    class CommentParser
    {

        //method which get string with entry file text end removes all comments
        public static string[] Analyze(string entryFile)
        {
            string[] allLines = entryFile.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            char[] tempIn = allLines.ToString().ToCharArray();
            string returOut;
            CommAP state=CommAP.TrueCode;
            int startPosition=0,finishPosition=0;

            for (int i = 0; i < tempIn.Length; i++)
            {
                if(state!=CommAP.CommChar)
                {
                    switch (tempIn[i])
                    {
                        case '(':
                            startPosition = i;
                            state = CommAP.CommOpenBracket;
                            break;
                        case '*':

                    }
                }
            }
            return allLines;
        }


    }
}