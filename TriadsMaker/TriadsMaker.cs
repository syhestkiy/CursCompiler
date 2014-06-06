namespace CursCompiler.TriadsMaker
{
    public class TriadsMethods
    {
        public static void GenerateListOfTriads(string progText)
        {
            
        }
    }

    public struct Triad
    {
        public int NumberOfTriad;
        public string TriadPattern;

        public Triad(int num, string pattern)
        {
            NumberOfTriad = num;
            TriadPattern = pattern;
        }
    }
    class TriadsMaker
    {
        private Triad[] typesOfTriads =
        {
            new Triad(1, "a = ( a + const )"),
            new Triad(2,"a = const"),
            new Triad(3,"a = a"),
            new Triad(4,"if( a < b )"),
            new Triad(5,"if( a > b )"),
            new Triad(6,"if( a == b )"),
            new Triad(7,"if( a != b )"),
        };
    }
}
