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
        public static int month = 0; // month as integer (1=January;12=December"
        private string pathString = @"C:\ProgramData\Arbeitsplan\" + Program.version_year; // path for program
        public static string fpathString = null;
        readonly string[] users = { "User1", "User2", "User3" }; // Einstellungen hinzufügen und users manuell einfügen
        readonly string[] months = { "Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };

        public Arbeitsplan()
        {
            InitializeComponent();
        }

        private void Arbeitsplan_Load(object sender, EventArgs e)
        {
            this.creator_tag.Text = "Version " + Program.version + " / Robert Schmidt"; // see: Program.version

            // add all users to selection-combobox
            for (int i = 0; i < users.Length; i++)
            {
                user_selection_combobox.Items.Add(users[i]);
            }

            if (Directory.Exists(pathString))
                {
                    Console.WriteLine("Directory already exists.");
                    Console.WriteLine(pathString);
                }
            else
                {
                    DirectoryInfo di = Directory.CreateDirectory(pathString);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(pathString));
                    Console.WriteLine(pathString);
                }

        }

        private void create_table_button_Click(object sender, EventArgs e)
        {
            // 1. determine month

            if (String.IsNullOrEmpty(month_selection_combobox.Text))
            {
                month = Program.current_time.Month;
            } else
            {
                switch(month_selection_combobox.Text) 
                {
                    case "Januar": // months HAVE to be constant
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
                    case "Dezember": // months HAVE to be constant
                        month = 12;
                        break;

                }

            }

            // check if selection has been made
            for (int i = 0; i < users.Length; i++)
            {
                if (user_selection_combobox.Text.Equals(users[i]))
                {
                    create_table(user_selection_combobox.Text, month); // create table when user has been found
                }

                // else: awaits user..
            }
            
        }

        private void create_table(string username, int month)
        {
            Program.menu.Hide();

            string fileName = username + "-" + month + ".dat"; // username-month.dat / file to attach
            fpathString = System.IO.Path.Combine(pathString, fileName); // C:\ProgramData\Arbeitsplan\username-month.dat

            // changes form's name according to user and month
            Program.table.Text = "Arbeitsplan von " + username + " für " + months[month-1];

            // create file if month empty
            if (!File.Exists(fpathString))
            {
                FileStream fs = File.Create(fpathString);
                // after checking file's existance, remove object to prevent IOExceptions after this condition finishes
                fs.Dispose();
            }

            Program.table.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.settings.ShowDialog();
        }
    }
}