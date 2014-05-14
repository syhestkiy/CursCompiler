using System;

namespace CursCompiler.LexAnalyzer
{
    class CommentParser
    {

        //method which get string with entry file text end removes all comments
        public static string[] Analyze(string entryFile)
        {
            string[] allLines = entryFile.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in allLines)
            {
                Console.WriteLine(line);
            }
            return allLines;
        }


    }
}
