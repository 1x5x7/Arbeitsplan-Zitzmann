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
    public partial class Arbeitsplan_Einstellungen : Form
    {
        private short form_status = 0; // 0 = main window / 1 = add user / 2 = remove user / 3 = set times // necessary for toggling menu

        public Arbeitsplan_Einstellungen()
        {
            InitializeComponent();
        }

        private void Arbeitsplan_Einstellungen_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(Arbeitsplan_Einstellungen_FormClosed);
            //Console.WriteLine(Arbeitsplan.spathString);
        }

        private void Arbeitsplan_Einstellungen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Form_menu.update_Settings();
        }

        // updates times in settings-file
        private void save_Times(string[] input, string path)
        {
            StreamReader sr = new StreamReader(path);
            string usersLine = sr.ReadLine(); // read first line
            sr.Close();

            StreamWriter sw = new StreamWriter(path);

            sw.WriteLine(usersLine);
            sw.WriteLine(input[0] + ";" + input[1] + ";" + input[2] + ";" + input[3] + ";" + input[4]);

            sw.Close();
        }

        // appends new username to users in settings-file
        private void save_User(string input, string path)
        {
            StreamReader sr = new StreamReader(path);
            string usersLine = sr.ReadLine(); // read first line
            string timesLine = sr.ReadLine(); // read second line (to prevent data being lost, copy and rewrite)
            sr.Close();

            StreamWriter sw = new StreamWriter(path);

            if (!(String.IsNullOrEmpty(usersLine)) && !(usersLine.Equals("@USERS"))) // entries already existing?
            {
                sw.WriteLine(usersLine + ";" + input); // append input to usernames
            } else // no entries; user is first entry of line
            {
                sw.WriteLine(input);
            }

            sw.WriteLine(timesLine);
            sw.Close();
        }

        // deletes existing user from settings-file
        private void delete_User(string input, string path)
        {
            StreamReader sr = new StreamReader(path);
            string usersLine = sr.ReadLine();
            string timesLine = sr.ReadLine();
            sr.Close();

            StreamWriter sw = new StreamWriter(path);

            string[] usersLine_split = usersLine.Split(';');

            // remove user from line and insert edited string back into file
            if (usersLine_split.Length.Equals(1)) // special case: only one entry
            {
                sw.WriteLine("@USERS");
            } else
            {
                string[] remaining_users = new string[usersLine_split.Length - 1]; // put all valid entries into another string[]

                // collect all entries that will NOT be deleted; instead rewritten into file
                for (int i = 0, j = 0; i < usersLine_split.Length; i++)
                {
                    if (!(usersLine_split[i].Equals(input)))
                    {
                        remaining_users[j] = usersLine_split[i];
                        j++;
                    }
                }

                // append all elements in line
                for (int j = 0; j < remaining_users.Length; j++)
                {
                    if (j.Equals(0)) // first element to be added
                    {
                        if (remaining_users.Length.Equals(1)) // if it's the only element, create whole line
                        {
                            sw.WriteLine(remaining_users[0]);
                        } else // else, append with 'Write' only
                        {
                            sw.Write(remaining_users[0]);
                        }
                    } else if (j < remaining_users.Length - 1) // all elements between first and last
                    {
                        sw.Write(";" + remaining_users[j]); // all other elements get appended
                    } else // last element
                    {
                        sw.WriteLine(";" + remaining_users[j]); // last element skips line
                    }
                }
            }

            sw.WriteLine(timesLine);
            sw.Close();
        }

        // deletes all tables from a specific user in all table-paths
        private void delete_Tables(string input, string path)
        {
            int directoryCount = Directory.GetDirectories(path).Length; // total amount of subdirectories (years)
            string[] spath = new string[directoryCount]; // save all subdirectories

            // iterate through directory and delete user's tables in every subdirectory
            for (int i = 0; i < directoryCount; i++)
            {
                // reference each subdirectory in array
                DirectoryInfo dir = new DirectoryInfo(path);
                DirectoryInfo[] dirArr = dir.GetDirectories();

                // append subdirectories to path and save each
                spath[i] = path + dirArr[i].ToString();

                // delete all associated files in each subdirectory
                foreach (string sFile in Directory.GetFiles(spath[i], input + "-*.dat"))
                    {
                        File.Delete(sFile);
                    }
            }
        }

        // refreshes content of combobox_deleteUser
        private void update_combobox_deleteUser()
        {
            // clear combobox, fill with items
            combobox_deleteUser.Items.Clear();

            string[] users_toDelete = Program.Form_menu.read_Users();

            combobox_deleteUser.Enabled = false;

            // add users to combobox for selection
            for (int i = 0; i < users_toDelete.Length; i++)
            {
                combobox_deleteUser.Enabled = true; // if at least one user exists, enable combobox
                combobox_deleteUser.Items.Add(users_toDelete[i]);
            }
        }

        // toggles visibility of the main settings menu
        private void toggle_Menu(short status)
        {
            if (status.Equals(0))                   // show main menu
            {
                label_user.Visible = true;
                label_arbeitszeiten.Visible = true;
                label_language.Visible = true;
                button_addUser.Visible = true;
                button_deleteUser.Visible = true;
                button_arbeitszeiten.Visible = true;
                combobox_language.Visible = true;

                // precautiously disable visibility of different menu elements
                textbox_addUser.Visible = false;
                label_addUser.Visible = false;
                combobox_deleteUser.Visible = false;
                label_deleteUser.Visible = false;
                checkbox_deleteTables.Visible = false;
                textbox_mon.Visible = false;
                textbox_tue.Visible = false;
                textbox_wed.Visible = false;
                textbox_thu.Visible = false;
                textbox_fri.Visible = false;
                label_monday.Visible = false;
                label_tuesday.Visible = false;
                label_wednesday.Visible = false;
                label_thursday.Visible = false;
                label_friday.Visible = false;

                button_confirm.Visible = false;
                button_back.Visible = false;

                form_status = 0; // status of form is 0 (main menu is being shown)
            } else                                  // hide main menu
            {
                label_user.Visible = false;
                label_arbeitszeiten.Visible = false;
                label_language.Visible = false;
                button_addUser.Visible = false;
                button_deleteUser.Visible = false;
                button_arbeitszeiten.Visible = false;
                combobox_language.Visible = false;

                button_confirm.Visible = true;
                button_back.Visible = true;

                form_status = status; // status of form is determined by parameter

                // visibility of each menu is set here
                switch (status)
                {
                    case 1: // menu for adding users
                        textbox_addUser.Text = Program.EMPTY;
                        textbox_addUser.Visible = true;
                        label_addUser.Visible = true;

                        break;
                    case 2: // menu for removing users
                        combobox_deleteUser.Visible = true;
                        label_deleteUser.Visible = true;
                        checkbox_deleteTables.Visible = true;

                        break;
                    case 3: // menu for setting worktimes
                        string[] textbox_times = Program.Form_menu.read_Times(); // read times from file and insert them into textboxes
                        textbox_mon.Text = textbox_times[0];
                        textbox_tue.Text = textbox_times[1];
                        textbox_wed.Text = textbox_times[2];
                        textbox_thu.Text = textbox_times[3];
                        textbox_fri.Text = textbox_times[4];
                        textbox_mon.Visible = true;
                        textbox_tue.Visible = true;
                        textbox_wed.Visible = true;
                        textbox_thu.Visible = true;
                        textbox_fri.Visible = true;
                        label_monday.Visible = true;
                        label_tuesday.Visible = true;
                        label_wednesday.Visible = true;
                        label_thursday.Visible = true;
                        label_friday.Visible = true;

                        break;
                    default:
                        break;
                }
            }
        }

        // KeyPresses adjust the input to remain compliant
        private void textbox_addUser_KeyPress(object sender, KeyPressEventArgs e) // filter usernames
        {
                e.Handled = !(char.IsLetter(e.KeyChar)) && !(char.IsControl(e.KeyChar));
        }

        private void textbox_times_KeyPress(object sender, KeyPressEventArgs e) // filter times
        {
            e.Handled = !(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(e.KeyChar.Equals(':')); // handle all presses which are not valid
        }

        private void button_addUser_Click(object sender, EventArgs e)
        {
            toggle_Menu(1);
        }

        private void button_deleteUser_Click(object sender, EventArgs e)
        {
            toggle_Menu(2);
            update_combobox_deleteUser();
        }

        private void button_arbeitszeiten_Click(object sender, EventArgs e)
        {
            toggle_Menu(3);
            // TextBox onChanged => filtern
            // Bestätigen-button => wenn alles gültig: Dialog (Erfolgreich); ansonsten: rote Label an fehlerhaftem Wochentag
        }

        // allows to toggle menu on/off
        private void button_back_Click(object sender, EventArgs e)
        {
            toggle_Menu(0);
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            string input;
            switch (form_status)
            {
                case 1: // confirmation button works for adding users
                    input = textbox_addUser.Text;

                    // check if user already exists in file
                    if (!(input.Equals(Program.EMPTY))) // no input = await input
                        {
                        // checks for users in file
                        string[] users_read = Program.Form_menu.read_Users();

                        try
                        {
                            for (int i = 0; i < users_read.Length; i++) // try to find an entry which equals input
                            {
                                if (users_read[i].ToUpper().Equals(input.ToUpper())) // usage of ToUpper() to prevent same names with different casings
                                {
                                    throw new Exception(); // if found, throw exception
                                }
                            }

                            // user couldn't be found; proceed to add him
                            save_User(input, Arbeitsplan.spathString);
                            MessageBox.Show("Benutzer '" + input + "' wurde erfolgreich hinzugefügt.");
                        }
                        catch (Exception excp) // user exists => abort
                        {
                            MessageBox.Show("Benutzer '" + input + "' existiert bereits! Versuchen Sie es bitte erneut.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        textbox_addUser.Text = Program.EMPTY; // clear out textbox for further inputs
                    }
                    break;
                case 2: // confirmation button works for removal of specific user
                    try
                    {
                        input = combobox_deleteUser.SelectedItem.ToString(); // try to fetch selected item in combobox

                        if (!(input.Equals(Program.EMPTY))) // check if no selection has been made
                        {
                            // open dialog to ask user, if he REALLY wishes to delete
                            DialogResult dialogResult = MessageBox.Show("Sind Sie sicher, dass Sie den Nutzer '" + input + "' löschen möchten?", "Löschen", MessageBoxButtons.YesNo);

                            // different operations, dependant on selection of Yes/No*
                            if (dialogResult == DialogResult.Yes)
                            {
                                delete_User(input, Arbeitsplan.spathString); // delete user

                                // if tables are wished to be deleted, run delete_Tables()
                                switch(checkbox_deleteTables.CheckState)
                                {
                                    case CheckState.Checked: // delete tables for removed user
                                        delete_Tables(input, Program.PATHSTRING);
                                        break;
                                    default: // don't delete tables for removed user
                                        break;
                                }
                            } // else: no operation

                            update_combobox_deleteUser(); // update combobox for currently available users
                        }
                    } catch (NullReferenceException excp) // combobox is empty; can't select user, confirmation button does nothing
                    {
                        //Console.WriteLine("No user has been selected.");
                    }
                    break;
                case 3:
                    int check = 0;
                    string[] textbox_times = new string[5];

                    for (int i = 0; i < 5; i++)
                    {
                        switch(i)
                        {
                            case 0:
                                input = textbox_mon.Text;
                                input = Program.Form_table.CellFilter(input, false);

                                if (input.Equals(Program.EMPTY)) // filtering unsuccessful
                                {
                                    textbox_mon.Text = Program.EMPTY; // textbox clears
                                    break;
                                }
                                else // filtering successful
                                {
                                    textbox_mon.Text = input; // correct textbox with filtered input
                                    textbox_times[0] = input; // save content
                                }

                                check++;
                                break;
                            case 1: // repeat steps from case '0' for textbox_tue
                                input = textbox_tue.Text;
                                input = Program.Form_table.CellFilter(input, false);

                                if (input.Equals(Program.EMPTY))
                                {
                                    textbox_tue.Text = Program.EMPTY;
                                    break;
                                }
                                else
                                {
                                    textbox_tue.Text = input;
                                    textbox_times[1] = input;
                                }

                                check++;
                                break;
                            case 2: // repeat steps from case '0' for textbox_wed
                                input = textbox_wed.Text;
                                input = Program.Form_table.CellFilter(input, false);

                                if (input.Equals(Program.EMPTY))
                                {
                                    textbox_wed.Text = Program.EMPTY;
                                    break;
                                }
                                else
                                {
                                    textbox_wed.Text = input;
                                    textbox_times[2] = input;
                                }

                                check++;
                                break;
                            case 3: // repeat steps from case '0' for textbox_thu
                                input = textbox_thu.Text;
                                input = Program.Form_table.CellFilter(input, false);

                                if (input.Equals(Program.EMPTY))
                                {
                                    textbox_thu.Text = Program.EMPTY;
                                    break;
                                }
                                else
                                {
                                    textbox_thu.Text = input;
                                    textbox_times[3] = input;
                                }

                                check++;
                                break;
                            case 4: // repeat steps from case '0' for textbox_fri
                                input = textbox_fri.Text;
                                input = Program.Form_table.CellFilter(input, false);

                                if (input.Equals(Program.EMPTY))
                                {
                                    textbox_fri.Text = Program.EMPTY;
                                    break;
                                }
                                else
                                {
                                    textbox_fri.Text = input;
                                    textbox_times[4] = input;
                                }

                                check++;
                                break;
                            default:
                                break;
                        }
                    }

                    if (check != 5)
                    {
                        MessageBox.Show("Sie müssen für jeden Wochentag eine korrekte Zeit angeben. Versuchen Sie es bitte erneut.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else
                    {
                        save_Times(textbox_times, Arbeitsplan.spathString);
                        MessageBox.Show("Arbeitszeiten wurden erfolgreich angepasst.");
                    }

                    break;
                default:
                    Console.WriteLine("Error; Confirmation-button can't determine current state of menu.");
                    break;
            }
        }
    }
}