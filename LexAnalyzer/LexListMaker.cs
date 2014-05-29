namespace CursCompiler.LexAnalyzer
{
    public class LexListMaker
    {
// ReSharper disable once InconsistentNaming
        public static BinaryTree BTKeyWords=new BinaryTree();
// ReSharper disable once InconsistentNaming
        public static BinaryTree BTOperators=new BinaryTree();

        public int ErrorCount=0;
        public bool LexAnalizerPerformed = false;
        public bool AnalizPerformed = false;

        //Формуємо бінарні дерева при завантаженні форми
        public static void InitializeBinaryTrees()
        {
            for (int i = 0; i < Lex.KeyWords.Length; i++)
            {
                BTKeyWords.Insert(Lex.KeyWords[i], i);
            }

            for (int i = 0; i < Lex.Operators.Length; i++)
            {
                BTOperators.Insert(Lex.Operators[i].Name, i);
            }
        }
    }
}
