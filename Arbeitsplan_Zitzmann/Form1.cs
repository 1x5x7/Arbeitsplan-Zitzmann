using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Arbeitsplan_Zitzmann
{
    public partial class Arbeitsplan : Form
    {
        public static int month = 0; // month as integer (1=January;12=December)
        public static int year = Program.CURRENT_TIME.Year; // year as subdirectory

        public static string pathString = Program.PATHSTRING + Program.CURRENT_TIME.Year;   // path for program
        public static string fpathString = null;                                            // path for the specific month-file
        public static string spathString = null;                                            // path for the settings

        public static string[] users; // usernames
        public static string[] times = new string[5]; // preset worktimes for each weekday
        readonly string[] months = { "Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };
        
        public Arbeitsplan()
        {
            InitializeComponent();
        }
        private void Arbeitsplan_Load(object sender, EventArgs e)
        {
            this.label_creator.Text = "Version " + Program.VERSION + " | Robert Schmidt"; // see: Program.version

            add_Years_toCombobox(); // add years for usage of different plans
            fetch_Settings(); // read/create settings file
        }

        private void add_Years_toCombobox()
        {
            for (int i = Program.STARTING_YEAR; i <= Program.CURRENT_TIME.Year; i++)
            {
                combobox_year.Items.Add(i);
            }

            combobox_year.SelectedItem = Program.CURRENT_TIME.Year;
        }

        // read user-data from first line of settings-file
        public string[] read_Users()
        {
            StreamReader sr = new StreamReader(spathString); ; // initialize StreamReader to enable file-reading
            string firstLine = sr.ReadLine(); // placeholder string for the read line

            string[] users_read = { };

            // read first line of file (where usernames are stored)
            if (!(String.IsNullOrEmpty(firstLine)) && !(firstLine.Equals("@USERS")))
            {
                users_read = firstLine.Split(';'); // split and store names
            }
            
            sr.Close(); // close StreamReader

            return users_read;
        }

        // read times-data from second line of settings-file
        public string[] read_Times()
        {
            StreamReader sr = new StreamReader(spathString); ; // initialize StreamReader to enable file-reading
            string secondLine = sr.ReadLine(); // placeholder string for the read line
            secondLine = sr.ReadLine();        // => read second line specifically!

            string[] times_read = new string[5];

            // read first line of file (where usernames are stored)
            if (!(String.IsNullOrEmpty(secondLine)) && !(secondLine.Equals("@TIMES")))
            {
                for (int i = 0; i < 5; i++)
                {
                    times_read[i] = secondLine.Split(';')[i]; // split and store names (precautiously limit to 5 entries)
                }
            } else
            {
                // fill times with no specific worktime
                for (int i = 0; i < 5; i++)
                {
                    times_read[i] = "00:00";
                }
            }

            sr.Close(); // close StreamReader

            return times_read;
        }

        // searches for settings-file, if not found creates it (and adds placeholders) or reads and sets data from it
        private void fetch_Settings()
        {
            string settingsName = "settings.csv";
            spathString = System.IO.Path.Combine(Program.PATHSTRING, settingsName);

            // check for file's existance
            if (!File.Exists(spathString))
            {
                FileStream fs = File.Create(spathString); // creates file at path
                fs.Dispose(); // after checking file's existance, remove object to prevent IOExceptions after this condition finishes

                StreamWriter sw = new StreamWriter(spathString); // allows writing into that file

                // write lines to hold as placeholders for actual data
                sw.WriteLine("@USERS");
                sw.WriteLine("@TIMES");

                sw.Close();   // close StreamWriter
            } else // in case it exists but might be empty, proceed to fill with placeholders
            {
                StreamReader sr = new StreamReader(spathString);
                string firstLine = sr.ReadLine();
                string secondLine = sr.ReadLine();
                sr.Close();

                StreamWriter sw = new StreamWriter(spathString);

                if (String.IsNullOrEmpty(firstLine))
                {
                    sw.WriteLine("@USERS");
                } else
                {
                    sw.WriteLine(firstLine);
                }

                if (String.IsNullOrEmpty(secondLine))
                {
                    sw.WriteLine("@TIMES");
                } else
                {
                    sw.WriteLine(secondLine);
                }

                sw.Close();

            }

            update_Settings();
        }

        // updates saved users and times and refreshes comboboxes
        public void update_Settings()
        {
            users = read_Users();
            times = read_Times();
            //read_Language()

            // reset combobox with usernames and disable it until user(s) are found
            combobox_userSelection.Items.Clear();
            combobox_userSelection.Enabled = false;

            // add users to combobox for selection
            for (int i = 0; i < users.Length; i++)
            {
                combobox_userSelection.Enabled = true; // if at least one user exists, enable combobox
                combobox_userSelection.Items.Add(users[i]);
            }
        }

        private void create_Table(string username, int month)
        {
            Program.Form_menu.Hide();

            string fileName = username + "-" + month + ".dat"; // username-month.dat / file to attach
            fpathString = System.IO.Path.Combine(pathString, fileName); // C:\ProgramData\Arbeitsplan\year\username-month.dat

            // changes form's name according to user and month
            Program.Form_table.Text = "Arbeitsplan von " + username + " für " + months[month-1] + " (" + year + ")";

            // create file if month empty
            if (!File.Exists(fpathString))
            {
                FileStream fs = File.Create(fpathString);
                // after checking file's existance, remove object to prevent IOExceptions after this condition finishes
                fs.Dispose();
            }

            Program.Form_table.Show();
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            Arbeitsplan_Einstellungen Form_settings = new Arbeitsplan_Einstellungen();
            Form_settings.ShowDialog();
        }

        private void button_createTable_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pathString))
            {
                Console.WriteLine("Directory exists.");
                Console.WriteLine(pathString);
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(pathString);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathString));
                Console.WriteLine(pathString);
            }

            // determine month selected by combobox
            if (String.IsNullOrEmpty(combobox_month.Text))
            {
                month = Program.CURRENT_TIME.Month;
            }
            else
            {
                switch (combobox_month.Text)
                {
                    case "Januar": // months HAVE to be constants
                        month = 1;
                        break;
                    case "Februar":
                        month = 2;
                        break;
                    case "März":
                        month = 3;
                        break;
                    case "April":
                        month = 4;
                        break;
                    case "Mai":
                        month = 5;
                        break;
                    case "Juni":
                        month = 6;
                        break;
                    case "Juli":
                        month = 7;
                        break;
                    case "August":
                        month = 8;
                        break;
                    case "September":
                        month = 9;
                        break;
                    case "Oktober":
                        month = 10;
                        break;
                    case "November":
                        month = 11;
                        break;
                    case "Dezember": // months HAVE to be constants
                        month = 12;
                        break;

                }

            }

            try
            {
                // determine selected user
                for (int i = 0; i < users.Length; i++)
                {
                    if (combobox_userSelection.Text.Equals(users[i]))
                    {
                        create_Table(combobox_userSelection.Text, month); // create table when user has been found
                    }
                }
            } catch (NullReferenceException excp) { } // if combobox is disabled (= no users found), run exception
        }

        private void combobox_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = (int) combobox_year.SelectedItem;
            pathString = Program.PATHSTRING + year;
        }
    }
}