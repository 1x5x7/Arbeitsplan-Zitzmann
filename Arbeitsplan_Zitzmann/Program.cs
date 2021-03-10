using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbeitsplan_Zitzmann
{
    static class Program
    {
        // version 1.0 
        public static string version = "1.0";

        public static System.DateTime current_time = System.DateTime.Now;
        public static int version_year = current_time.Year; // determine current year

        public static Arbeitsplan menu = new Arbeitsplan();
        public static Arbeitsplan_Tabelle table = new Arbeitsplan_Tabelle();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false); // TextRenderingDefault is automatically set false / causes errors

            Application.Run(menu);
        }
    }


}
