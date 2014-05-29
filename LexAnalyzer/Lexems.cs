using System;
using System.Xml;

namespace CursCompiler.LexAnalyzer
{
    public struct AllWords
    {
        public string Name;
        public int CharNum;
        public int RowNum;
        public int CharInRowNum;
    }

    public struct Op
    {
        public string Name;
        public string Type;

        public Op(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    class Lex
    {
        public AllWords[] Lexems;

        public static string[] KeyWords =
        {
            "prog", //з нього повинна повинна починатися програма
            "end.", //закінчення програми
            "if", //якщо 
            "else", //інакше
            "while",//поки
            "do"//виконати
        };

        public static Op[] Operators =
        {
            new Op("+", "Знак суми"),
            new Op("-", "Знак різниці"),
            new Op("--","Декремент"), 
            new Op("&", "Логічне І"),
            new Op("||", "Логічне АБО"),
            new Op("!", "Логічне НЕ"),
            new Op("=", "Знак присвоєння"),
            new Op("==", "Перевірка на рівність"),
            new Op(">", "Знак порівняння"),
            new Op("<", "Знак порівняння"),
            new Op("(", "Відкриваюча дужка"),
            new Op(")", "Закриваюча дужка"),
            new Op("{", "Початок блоку операторів"),
            new Op("}", "Кінець блоку операторів"),
            new Op(",", "Кома(синтаксис)"),
            new Op(";", "Символ закінцення рядка")
        };
    }
}
