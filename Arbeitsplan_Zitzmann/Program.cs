using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbeitsplan_Zitzmann
{
    static class Program
    {
        // current version of program
        public static string VERSION = "1.1";

        // main path for program
        public static string PATHSTRING = @"C:\ProgramData\Arbeitsplan\";

        // earliest year allowed to create tables in
        public static int STARTING_YEAR = 2021;

        // current date for specific time-related operations
        public static System.DateTime CURRENT_TIME = System.DateTime.Now;

        // strings for editing, filtering, checking, etc.
        public static string EMPTY = ""; // empty string
        public static string WHITESPACE = " "; // whitespace symbol
        public static string BLOCKER = "//////"; // string for blocking cells

        public static Arbeitsplan Form_menu = new Arbeitsplan();
        public static Arbeitsplan_Tabelle Form_table = new Arbeitsplan_Tabelle();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false); // TextRenderingDefault is automatically set false / causes errors

            Application.Run(Form_menu);
        }
    }
}