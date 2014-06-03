using System;
using System.Collections.Generic;

namespace CursCompiler.ErrorLoger
{
    public class Error
    {
        private int _numberOfError;//загальний номер помилки
        private string _errorType;//тип помилки (1-лексична 2-синтаксична 3-семантична)
        private string _errorItem ;//обєкт який сигналізує про помилку
        private int _rowNumber;//номер рядка у якому виявлено помилку 
        private int _symbolNumber;//позиція у рядку де виявлено помилку
        private string _description;//пояснення до помилки
                
        public int NumberOfError 
        {
            get { return _numberOfError; }
            set { _numberOfError = value; }
        }

        public string ErrorType
        {
            get { return _errorType; }
            set { _errorType = value; }
        }
        
        public string ErrorItem
        {
            get { return _errorItem; }
            set { _errorItem = value; }
        }

        public int RowNumber
        {
            get { return _rowNumber; }
            set { _rowNumber = value; }
        }

        public int SymbolNumber
        {
            get { return _symbolNumber; }
            set { _symbolNumber = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        //constructor for lexical errors
        public Error(int errorNum, string errorType, string errorItem, int rowNum, int symbolNum, string desription)
        {
            _numberOfError = errorNum;
            _errorType = errorType;
            _errorItem = errorItem;
            _rowNumber = rowNum;
            _symbolNumber = symbolNum;
            _description = desription;
        }
        //constructor for syntax errors
        public Error(int errorNum, string errorType, string desription)
        {
            _numberOfError = errorNum;
            _errorType = errorType;
            _description = desription;
            _errorItem = String.Empty;
            _rowNumber = 0;
            _symbolNumber = 0;
        }

        public static List<Error> ListOfErrors = new List<Error>();
    }
    class ErrorLogger
    {
        public static void AddError(Error error)
        {
            Error.ListOfErrors.Add(error);
        }

        public static string GetAllErrors()
        {
            string errors=String.Empty;
            foreach (var error in Error.ListOfErrors)
            {
                errors += error.NumberOfError.ToString() + " "
                          + error.ErrorType.ToString() + " "
                          + error.ErrorItem.ToString() + " "
                          + error.RowNumber.ToString() + " "
                          + error.SymbolNumber.ToString() + " "
                          + error.Description.ToString() + "\n";
            }
            return errors;
        }

        public static void Clear()
        {
            Error.ListOfErrors.Clear();
        }

    }
}
