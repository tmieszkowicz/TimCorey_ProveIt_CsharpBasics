using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

//Load records from the StandardDataSet into the users
//list (at least first and last name). Then create a new
//record and save it to the list and then the file.
//Load all columns from the StandardDataSet and then,
//without changing any codeexcept the text file name,
//load the AdvancedDataSet and ensure the data all
//goes in the correct columns. Ensure saving the data
//correctly puts the data back in the text file in the right
//column order.

namespace TextFileChallenge
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChallengeForm());
        }
    }
}
