using System;
using CursCompiler.LexAnalyzer;

namespace CursCompiler.TriadsMaker
{
    public class TriadsMethods
    {
        public static void GenerateListOfTriads(string progText)
        {
            progText=progText.Replace("prog", String.Empty).Replace("end.",String.Empty);
            progText = TextEditor.SpaceCorrector(progText);
        }
    }

    class TriadsMaker
    {
    }
}
