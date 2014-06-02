using System;
using System.Windows.Forms;
using CursCompiler.ErrorLoger;

namespace CursCompiler.Forms
{
    public partial class ErrorReportForm : Form
    {
        public ErrorReportForm()
        {
            InitializeComponent();
            richTxtListOfErrors.Text = String.Empty;
            richTxtListOfErrors.Text = ErrorLogger.GetAllErrors();
        }
    }
}
