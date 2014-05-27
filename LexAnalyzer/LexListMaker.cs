namespace CursCompiler.LexAnalyzer
{
    //prog, end., if, else, begin, end, while, do, or, xor, and, not, <, >, =, <>, (, ), -, +, --, a, c , ;, :=,(*,*); 
    internal enum LexTypeList
    {
        LexProg,
        LexFin,
        LexIf,
        LexElse,
        LexBegin,
        LexEnd,
        LewWhile,
        LexDo,
        LexOr,
        LexAnd,
        LexXor,
        LexNot,
        LexLess,
        LexMore,
        LexEqual,
        LexNotEqual,
        LexOpenBracket,
        LexCloseBracket,
        LexSub,
        LexAdd,
        LexDec,
        LexConst,
        LexVar,
        LexDivider,
        LexAssign,//todo make correct name here

    }

    internal enum LexAutomatStates
    {
        Prog1,
        Prog2,
        Prog3,
        Prog4,
        Fin1,
        Fin2, 
        Fin3,
        Fin4,
        If1,
        If2,
        Else1,
        Else2,
        Else3,
        Else4,
        Begin1,
        Begin2,
        Begin3,
        Begin4,
        Begin5,
        End1,
        End2,
        End3,
        While1,
        While2,
        While3,
        While4,
        While5,
        Do1,
        Do2,
        Or1,
        Or2,
        And1,
        And2,
        And3,
        Not1,
        Not2,
        Not3,
        Xor1,
        Xor2,
        Xor3,
        Les,//менше
        More,//більше
        Equal,
        NotEqual,
        OpenBracket,
        CloseBracket,
        Add,
        Sub,
        Dec,
        Var,
        Const,
        Divider,//;
        Assign,//присвоєння // todo make correct name here
        CommOpen1,
        CommOpen2,
        CommClose1,
        CommClose2
    }

    //Data structure for LexTable
    internal class LexListMaker
    {
        private string _lexName;
        private LexTypeList _lexType;
        private int _startPosition;
        private int _finishPosition;

        //Constructor for two parameters of lexem position
        public LexListMaker(string lexName, LexTypeList lexType, int startPostion, int finishPosition)
        {
            _lexName = lexName;
            _lexType = lexType;
            _startPosition = startPostion;
            _finishPosition = finishPosition;
        }

        //Constructor for one parameter of lexem position
        public LexListMaker(string lexName, LexTypeList lexType, int position)
        {
            _lexName = lexName;
            _lexType = lexType;
            _startPosition = position;
            _finishPosition = position;
        }

        public string LexName
        {
            get { return _lexName; }
            set { _lexName = value; }
        }

        public LexTypeList LexType
        {
            get { return _lexType; }
            set { _lexType = value; }
        }

        public int StartPosition
        {
            get { return _startPosition; }
            set { _startPosition = value; }
        }

        public int FinishPosition
        {
            get { return _finishPosition; }
            set { _finishPosition = value; }
        }


        //Methods 
        // This method returns string with name of lexem type
        public string GetLexemTypeName(LexTypeList lex)
        {
            string result = string.Empty;
            switch (lex)
            {
                case LexTypeList.LexOpenBracket:
                    result = "Open bracket";
                    return result;
                case LexTypeList.LexCloseBracket:
                    result = "Close bracket";
                    return result;
                case LexTypeList.LexAssign:
                    result = "Set value";
                    return result;
                case LexTypeList.LexConst:
                    result = "Constant";
                    return result;
                case LexTypeList.LexVar:
                    result = "Variable";
                    return result;
                case LexTypeList.LexDivider:
                    result = "Divider";
                    return result;
                case LexTypeList.LexAdd:
                case LexTypeList.LexSub:
                case LexTypeList.LexDec:
                case LexTypeList.LexLess:
                case LexTypeList.LexMore:
                case LexTypeList.LexEqual:
                case LexTypeList.LexNotEqual:
                    result = "Operation";
                    return result;
                default:
                    result = "Key word";
                    return result;
            }
        }

        //method returns text info about lex type
        public string GetLexTypeInfo(LexTypeList lex)
        {
            string result = string.Empty;
            switch (lex)
            {
                case LexTypeList.LexProg:
                    result = "prog";
                    return result;
                case LexTypeList.LexFin:
                    result = "end.";
                    return result;
                case LexTypeList.LexDivider:
                    result = ";";
                    return result;
                case LexTypeList.LexIf:
                    result = "if";
                    return result;
                case LexTypeList.LexOpenBracket:
                    result = "(";
                    return result;
                case LexTypeList.LexCloseBracket:
                    result = ")";
                    return result;
                case LexTypeList.LexElse:
                    result = "else";
                    return result;
                case LexTypeList.LexBegin:
                    result = "begin";
                    return result;
                case LexTypeList.LexEnd:
                    result = "end";
                    return result;
                case LexTypeList.LewWhile:
                    result = "while";
                    return result;
                case LexTypeList.LexDo:
                    result = "do";
                    return result;
                case LexTypeList.LexVar:
                    result = "a";
                    return result;
                case LexTypeList.LexConst:
                    result = "c";
                    return result;
                case LexTypeList.LexAssign:
                    result = ":=";
                    return result;
                case LexTypeList.LexOr:
                    result = "or";
                    return result;
                case LexTypeList.LexAnd:
                    result = "and";
                    return result;
                case LexTypeList.LexXor:
                    result = "xor";
                    return result;
                case LexTypeList.LexNot:
                    result = "not";
                    return result;
                case LexTypeList.LexLess:
                    result = "<";
                    return result;
                case LexTypeList.LexMore:
                    result = ">";
                    return result;
                case LexTypeList.LexEqual:
                    result = "=";
                    return result;
                case LexTypeList.LexNotEqual:
                    result = "<>";
                    return result;
                case LexTypeList.LexAdd:
                    result = "+";
                    return result;
                case LexTypeList.LexSub:
                    result = "-";
                    return result;
                case LexTypeList.LexDec:
                    result = "--";
                    return result;
                default:
                    result = string.Empty;
                    return result;
            } //end of case
        } //end of GetLexTypeInfo


        public static void AddVarToList(LexAutomatStates currentState,int linePosiion, int lineNumber)
        {

        }

}
}
