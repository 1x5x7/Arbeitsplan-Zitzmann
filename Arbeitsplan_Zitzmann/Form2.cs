using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace Arbeitsplan_Zitzmann
{
    public partial class Arbeitsplan_Tabelle : Form
    {
        private string[] m_nameCol = { "Datum", "Tag", "von", "bis", "Istzeit", "Sollzeit", "Differenz", "Abwesenheit" };
        private string[] m_zeiten = { "09:00", "09:00", "05:30", "09:00", "06:00" }; // Einstellungen hinzufügen und Arbeitstage manuell mit Zeiten anpassen!
        private int daysInMonth = 0; // total days in month; keep 0 until Form1 initializes month
        string blocker = "//////"; // string for blocking cells
        DateTime date = DateTime.Now; // current date

        public Arbeitsplan_Tabelle()
        {
            InitializeComponent();
        }

        private void Arbeitsplan_Tabelle_Load(object sender, EventArgs e)
        {
            // links EventHandler upon loading table (closing form = closing application entirely)
            this.FormClosed += new FormClosedEventHandler(Arbeitsplan_Tabelle_FormClosed);

            // initializations
            daysInMonth = DateTime.DaysInMonth(Program.version_year, Arbeitsplan.month); // set total days in month upon loading Form (which is AFTER retrieving the month from previous Form!)

            // check file for existing content => empty file gets filled with empty entries
            if (IsTextFileEmpty(Arbeitsplan.fpathString))
            {
                createNewFile(Arbeitsplan.fpathString);
            }

            create_table();
        }

        // METHOD: Ask user to save; FormClosing = Saving table into file

        private void Arbeitsplan_Tabelle_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        public static bool IsTextFileEmpty(string fileName)
        {
            var info = new FileInfo(fileName);
            if (info.Length == 0) return true; // size = 0? => empty

            // certain files could contain a byte order mark (max size: 6)! 
            if (info.Length < 6) // precautious check for a length of less than 6
            {
                var content = File.ReadAllText(fileName);
                return content.Length == 0;
            }

            return false;
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            save_table();
            MessageBox.Show("Ihre Tabelle wurde erfolgreich gespeichert.");
        }

        // calculate each line individually
        private void calc_button_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < daysInMonth; row++) // iterate through each row
            {
                string status = "" + dataGridView1.Rows[row].Cells[dataGridView1.Columns[9].Name].Value; // Abwesenheit = status
                if (status.Length == 0 || status.Equals(" "))
                {
                    calc_existing_row(row); // calculate cell values (if possible)
                } else // block time cells
                {
                    dataGridView1.Rows[row].Cells[2].Value = blocker;
                    dataGridView1.Rows[row].Cells[3].Value = blocker;
                    dataGridView1.Rows[row].Cells[4].Value = blocker;
                    dataGridView1.Rows[row].Cells[5].Value = blocker;
                    dataGridView1.Rows[row].Cells[6].Value = blocker;
                    dataGridView1.Rows[row].Cells[7].Value = blocker;
                    dataGridView1.Rows[row].Cells[8].Value = "00:00";
                }
            }
        }

        private void calc_existing_row(int row)
        {
            date = new DateTime(Program.version_year, Arbeitsplan.month, row + 1); // get date for row's day
            int day = (int)date.DayOfWeek;
            // check if day is NOT on weekend! => weekends stay blocked
            if (day != 6 && day != 0)
            {
                // clear all blocked cells (since their status is clean)
                for (int i = 2; i < 6; i++)
                {
                    if (dataGridView1.Rows[row].Cells[i].Value == null || dataGridView1.Rows[row].Cells[i].Value.Equals(blocker))
                    {
                        dataGridView1.Rows[row].Cells[i].Value = "";
                    }
                }

                // Sollzeit has to be adjusted out of the loop
                dataGridView1.Rows[row].Cells[7].Value = m_zeiten[day - 1];

                string[] times = new string[4]; // gather times from cells
                string[] time_diff = new string[2]; // time calculations

                for (int i = 0; i < 4; i++)
                {
                    times[i] = CellFilter(dataGridView1.Rows[row].Cells[i + 2].Value.ToString());
                }

                if (times[0].Equals(" ") || times[1].Equals(" ")) // first time cells empty?
                {
                    // clear all time cells
                    dataGridView1.Rows[row].Cells[2].Value = "";
                    dataGridView1.Rows[row].Cells[3].Value = "";
                    dataGridView1.Rows[row].Cells[4].Value = "";
                    dataGridView1.Rows[row].Cells[5].Value = "";

                    dataGridView1.Rows[row].Cells[6].Value = "00:00";

                }
                else
                {
                    if (times[2].Equals(" ") || times[3].Equals(" ")) // second time cells empty? => calculate first time cells only!
                    {
                        // clear second time cells; try to correct first time cells
                        dataGridView1.Rows[row].Cells[2].Value = times[0];
                        dataGridView1.Rows[row].Cells[3].Value = times[1];
                        dataGridView1.Rows[row].Cells[4].Value = "";
                        dataGridView1.Rows[row].Cells[5].Value = "";

                        string[] time1 = new string[2], time2 = new string[2];
                        time1[0] = times[0].Split(':')[0]; // hh:
                        time1[1] = times[0].Split(':')[1]; // :mm
                        time2[0] = times[1].Split(':')[0]; // hh: //2
                        time2[1] = times[1].Split(':')[1]; // :mm //2

                        string[] result = calcTimeDifference(time1, time2, false);

                        dataGridView1.Rows[row].Cells[6].Value = (result[0] + ":" + result[1]);

                    }
                    else // calculate both time cells!
                    {
                        // try to correct first and second time cells
                        dataGridView1.Rows[row].Cells[2].Value = times[0];
                        dataGridView1.Rows[row].Cells[3].Value = times[1];
                        dataGridView1.Rows[row].Cells[4].Value = times[2];
                        dataGridView1.Rows[row].Cells[5].Value = times[3];

                        string[] time1 = new string[2], time2 = new string[2];
                        time1[0] = times[0].Split(':')[0]; // hh:
                        time1[1] = times[0].Split(':')[1]; // :mm
                        time2[0] = times[1].Split(':')[0]; // hh: //2
                        time2[1] = times[1].Split(':')[1]; // :mm //2

                        string[] result1 = calcTimeDifference(time1, time2, false);

                        time1[0] = times[2].Split(':')[0]; // hh:
                        time1[1] = times[2].Split(':')[1]; // :mm
                        time2[0] = times[3].Split(':')[0]; // hh: //2
                        time2[1] = times[3].Split(':')[1]; // :mm //2

                        string[] result2 = calcTimeDifference(time1, time2, false);

                        ////
                        ///
                        //


                        // add time differences of both results
                        int hours_diff = Int32.Parse(result1[0]) + Int32.Parse(result2[0]);
                        int minute_diff = Int32.Parse(result1[1]) + Int32.Parse(result2[1]);

                        // configurate values if necessary
                        if (minute_diff > 59)
                        {
                            minute_diff -= 60;
                            hours_diff += 1;
                        }

                        dataGridView1.Rows[row].Cells[6].Value = "00:00"; // pre-initialize cell to prevent NullExceptions

                        if (hours_diff < 10 && minute_diff < 10)
                        {
                            dataGridView1.Rows[row].Cells[6].Value = "0" + hours_diff + ":0" + minute_diff; // 0h:0m
                        }
                        else if (hours_diff < 10)
                        {
                            dataGridView1.Rows[row].Cells[6].Value = "0" + hours_diff + ":" + minute_diff; // 0h:mm
                        }
                        else if (minute_diff < 10)
                        {
                            dataGridView1.Rows[row].Cells[6].Value = hours_diff + ":0" + minute_diff; // hh:0m
                        }
                        else
                        {
                            dataGridView1.Rows[row].Cells[6].Value = hours_diff + ":" + minute_diff; // hh:mm
                        }
                    }
                }

                // calculate difference between Sollzeit and Istzeit if content available

                string[] difference = calcTimeDifference(dataGridView1.Rows[row].Cells[6].Value.ToString().Split(':'), dataGridView1.Rows[row].Cells[7].Value.ToString().Split(':'), true); // split strings for hh:mm

                dataGridView1.Rows[row].Cells[8].Value = difference[0] + ":" + difference[1];
            }
}

        private void createNewFile(string path)
        {
            // StreamWriter initialization; writes lines into file
            StreamWriter sw = new StreamWriter(path);

            // file is empty; fill placeholders
            for (int i = 0; i < daysInMonth; i++)
            {
                try
                {
                    sw.WriteLine(" ; ; ; ;0"); // csv-file; all 5 entries are empty
                }
                catch (Exception excp)
                {
                    Console.WriteLine("Exception occurred; " + excp.Message);
                }

            }

            // close StreamWriter after writing data
            sw.Close();
        }

        private void create_table()
        {
            string[] _insert = null; // initialize row(s)

            // setup the amount of text columns to be added (hint: Abwesenheit is NOT a text column"
            dataGridView1.ColumnCount = 9;

            /* Set the column names + prevent "to be locked" columns from being editable */
            for (int i = 0; i < 9; i++)
            {
                if (i > 3)
                {
                    dataGridView1.Columns[i].Name = m_nameCol[i - 2];
                }
                else
                {
                    dataGridView1.Columns[i].Name = m_nameCol[i];
                }

                if (i == 0 || i == 1 || i == 6 || i == 7 || i == 8)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }
            }

            // create last column manually as combobox

            DataGridViewComboBoxColumn abwesenheit = new DataGridViewComboBoxColumn();
            {

                // set header name of column
                abwesenheit.Name = m_nameCol[7];

                // add items into column
                abwesenheit.Items.AddRange(" ", "Krank", "Urlaub/Frei", "Betriebsurlaub", "Feiertag");
            }

            dataGridView1.Columns.Add(abwesenheit);

            // adjust size of last column to window manually
            dataGridView1.Columns[9].Width = 118;

            // prevent sorting for each column (because it looks buggy)
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            int row_counter = 0; // amount of total rows created

            // create each row
            for (int i = 0; i < daysInMonth; i++)
            {
                StreamReader sr = new StreamReader(Arbeitsplan.fpathString); ; // initialize StreamReader to enable file-reading
                string line = ""; // placeholder string for StreamReader; iterates through file
                string[] split_line = new string[5]; // string with 5 entries when correct line found
                _insert = new string[9]; // configure _insert for 9 text(!) columns
                bool abwesenheit_aktiv = false; // check if last cell is active

                int counter = 0; // initialize counter to read through file till i is reached

                // iterate through file
                while ((line = sr.ReadLine()) != null)
                {
                    if (counter == i) // stops reading when reaching specific line and exits loop
                    {
                        split_line = line.Split(';'); // split read line at all ';' (csv)
                        break;
                    }

                    counter++; // increases counter if demanded line not found
                }

                sr.Close(); // close StreamReader

                // declare date for further functions such as DayOfWeek and reading the month
                date = new DateTime(Program.version_year, Arbeitsplan.month, i + 1);

                // Allgemeine Generierung von Datum/Tag für jede Tabelle
                _insert[0] = ((i + 1) + "." + Arbeitsplan.month); // Datum
                _insert[1] = date.ToString("ddd" + ".", new CultureInfo("de-DE")); // Tag

                // Sollzeit
                switch (_insert[1])
                {
                    case "Mo.":
                        _insert[7] = m_zeiten[0];
                        break;
                    case "Di.":
                        _insert[7] = m_zeiten[1];
                        break;
                    case "Mi.":
                        _insert[7] = m_zeiten[2];
                        break;
                    case "Do.":
                        _insert[7] = m_zeiten[3];
                        break;
                    case "Fr.":
                        _insert[7] = m_zeiten[4];
                        break;
                    default:
                        _insert[7] = "FREI";
                        break;
                }

                // determine value in last file entry
                int abwesenheit_value = Int32.Parse(split_line[4]);

                // if (Saturday (Day 6) OR Sunday (Day 0)) => disable row, remove the rest operations
                if (((int)date.DayOfWeek == 6) || ((int)date.DayOfWeek == 0))
                {
                    // mark blocked cells
                    for (int j = 2; j < 9; j++)
                    {
                        _insert[j] = blocker;
                    }

                    // => last column stays empty

                }
                else if ((abwesenheit_value > 0)) // if Abwesenheit
                {
                    // mark blocked cells
                    for (int j = 2; j < 9; j++)
                    {
                        _insert[j] = blocker;
                    }

                    abwesenheit_aktiv = true;
                }
                else // Wochentag + keine Abwesenheit
                {
                    // => last column stays empty

                    // Istzeit

                    if (split_line[0].Equals(" ") || split_line[1].Equals(" ") || split_line[0].Length < 5 || split_line[1].Length < 5) // first time cells empty?
                    {
                        // clear all time cells
                        _insert[2] = "";
                        _insert[3] = "";
                        _insert[4] = "";
                        _insert[5] = "";

                        _insert[6] = "00:00";

                    }
                    else
                    {
                        if (split_line[2].Equals(" ") || split_line[3].Equals(" ") || split_line[2].Length < 5 || split_line[3].Length < 5) // second time cells empty? => calculate first time cells only!
                        {
                            // only set first time cells
                            _insert[2] = split_line[0];
                            _insert[3] = split_line[1];
                            _insert[4] = ""; // clear second time cells
                            _insert[5] = "";

                            var hrs_min = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(':')).ToArray(); // splits the read string (per line) twice

                            string[] time1 = new string[2], time2 = new string[2];
                            time1[0] = hrs_min[0][0]; // hh:
                            time1[1] = hrs_min[0][1]; // :mm
                            time2[0] = hrs_min[1][0]; // hh: //2
                            time2[1] = hrs_min[1][1]; // :mm //2

                            string[] result = calcTimeDifference(time1, time2, false);

                            _insert[6] = (result[0] + ":" + result[1]);

                        }
                        else // calculate both time cells!
                        {
                            // set all cells
                            _insert[2] = split_line[0];
                            _insert[3] = split_line[1];
                            _insert[4] = split_line[2];
                            _insert[5] = split_line[3];

                            var hrs_min = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(':')).ToArray(); // splits the read string (per line) twice

                            string[] time1 = new string[2], time2 = new string[2];
                            time1[0] = hrs_min[0][0]; // hh:
                            time1[1] = hrs_min[0][1]; // :mm
                            time2[0] = hrs_min[1][0]; // hh: //2
                            time2[1] = hrs_min[1][1]; // :mm //2

                            string[] result1 = calcTimeDifference(time1, time2, false);

                            time1[0] = hrs_min[2][0]; // hh:
                            time1[1] = hrs_min[2][1]; // :mm
                            time2[0] = hrs_min[3][0]; // hh:
                            time2[1] = hrs_min[3][1]; // :mm

                            string[] result2 = calcTimeDifference(time1, time2, false);

                            ////
                            ///
                            //


                            // add time differences of both results
                            int hours_diff = Int32.Parse(result1[0]) + Int32.Parse(result2[0]);
                            int minute_diff = Int32.Parse(result1[1]) + Int32.Parse(result2[1]);

                            // configurate values if necessary
                            if (minute_diff > 59)
                            {
                                minute_diff -= 60;
                                hours_diff += 1;
                            }

                            _insert[6] = "00:00"; // pre-initialize cell to prevent NullExceptions

                            if (hours_diff < 10 && minute_diff < 10)
                            {
                                _insert[6] = "0" + hours_diff + ":0" + minute_diff; // 0h:0m
                            }
                            else if (hours_diff < 10)
                            {
                                _insert[6] = "0" + hours_diff + ":" + minute_diff; // 0h:mm
                            }
                            else if (minute_diff < 10)
                            {
                                _insert[6] = hours_diff + ":0" + minute_diff; // hh:0m
                            }
                            else
                            {
                                _insert[6] = hours_diff + ":" + minute_diff; // hh:mm
                            }


                        }
                    }
                }

                // calculate difference between Sollzeit and Istzeit if content available
                string t1 = "00:00", t2 = "00:00"; // initialize Ist-/Sollzeit cells as strings
                if (!(_insert[6].Equals(blocker)) || !(_insert[7].Equals(blocker))) // check if any of those are blocked!
                {
                    t1 = readTimeFromCell(_insert[6]);
                    t2 = readTimeFromCell(_insert[7]);
                }

                string[] difference = calcTimeDifference(t1.Split(':'), t2.Split(':'), true); // split strings for hh:mm

                _insert[8] = difference[0] + ":" + difference[1];

                dataGridView1.Rows.Add(_insert);

                if (abwesenheit_aktiv)
                {
                    // (!) EXISTING BUG: first item in the Combobox (in this case: " " at Index 0) not able to be applied, everything >0 will work!
                    dataGridView1.Rows[row_counter].Cells[dataGridView1.Columns[9].Name].Value = (dataGridView1.Rows[row_counter].Cells[dataGridView1.Columns[9].Name] as DataGridViewComboBoxCell).Items[abwesenheit_value];
                }
                row_counter++;
            }
        }

        private string[] calcTimeDifference (string[] time1, string[] time2, bool pos_neg)
        {
            int hour1 = 0, hour2 = 0, minute1 = 0, minute2 = 0; // initialization of numbers

            string[] result = new string[2]; // initialization of the result strings ([0] = hours; [1] = minutes)
            result[0] = "00";
            result[1] = "00";

            int pos_neg_sign = 0; // 1 = positive // 2 = negative
            char[] sign = { '+', '-'};

            try // try to parse parameters
            {
                hour1 = Int32.Parse(time1[0]);
                hour2 = Int32.Parse(time2[0]);
                minute1 = Int32.Parse(time1[1]);
                minute2 = Int32.Parse(time2[1]);
            } catch (FormatException fexcp)
            {
                Console.WriteLine(fexcp);
            } finally
            {
                if ((Enumerable.Range(0, 23).Contains(hour1)) || (Enumerable.Range(0, 23).Contains(hour2)) || (Enumerable.Range(0, 59).Contains(minute1)) ||  (Enumerable.Range(0, 59).Contains(minute2))) // hours/minutes check
                {
                    int hours_diff = 0, minute_diff = 0; // initialization of time differences

                    if (pos_neg) // checks for positive/negative difference between two close times
                    {
                        
                        if (hour2 == hour1) // are hours equal?
                        {
                            if (minute2 > minute1) // calculate difference of minutes for negative sign
                            {
                                minute_diff = minute2 - minute1;
                                pos_neg_sign = 2;
                            } else if (minute2 < minute1) // calculate difference of minutes for positive sign
                            {
                                minute_diff = minute1 - minute2;
                                pos_neg_sign = 1;
                            }
                        } else if (hour2 > hour1) // hours calculate into favor of negative difference
                        {
                            hours_diff = hour2 - hour1;
                            minute_diff = minute2 - minute1;
                            pos_neg_sign = 2;
                        } else // hours calculate into favor of positive difference
                        {
                            hours_diff = hour1 - hour2;
                            minute_diff = minute1 - minute2;
                            pos_neg_sign = 1;
                        }
                    } else
                    {
                        // CASE 1: times are on TWO DIFFERENT days
                        if (hour1 > hour2) // second time is on the next day
                        {
                            // find difference between first day ---> midnight
                            hours_diff = 23 - hour1;
                            minute_diff = 60 - minute1;

                            // check if minutes are untouched
                            if (minute_diff == 60)
                            {
                                hours_diff += 1;
                                minute_diff = 0;
                            }

                            // midnight ---> second day
                            hours_diff += hour2;
                            minute_diff += minute2;

                            // check if minutes exceed :59
                            if (minute_diff > 59)
                            {
                                minute_diff -= 60;
                                hours_diff += 1;
                            }
                        }
                        else // CASE 2: normal times on one day
                        {
                            hours_diff = hour2 - hour1;
                            minute_diff = minute2 - minute1;
                        }
                    }

                    // value configuration if necessary
                    if (minute_diff < 0)
                    {
                        minute_diff += 60;
                        hours_diff -= 1;
                    }

                    // determine manual addition of 0 (design purpose)
                    if (hours_diff < 10 && minute_diff < 10) // 0h:0m
                    {
                        result[0] = "0" + hours_diff;
                        result[1] = "0" + minute_diff;
                    } else if (hours_diff < 10)              // 0h:mm
                    {
                        result[0] = "0" + hours_diff;
                        result[1] = "" + minute_diff;
                    } else if (minute_diff < 10)              // hh:m
                    {
                        result[0] = "" + hours_diff;
                        result[1] = "0" + minute_diff;
                    } else                                    // hh:mm
                    {
                        result[0] = "" + hours_diff;
                        result[1] = "" + minute_diff;
                    }
                }
            }

            // sets sign if set
            if (pos_neg_sign > 0)
            {
                result[0] = sign[pos_neg_sign - 1] + result[0];
            }

            return result;
        }

        private string readTimeFromCell(string readString)
        {
            try
            {
                int counter = 0; // counter determines if hour/minute is being read
                var items = new List<int>(); // list to save split items from cell

                foreach (var intString in readString.Split(':')) // each value (in this case: hours and minutes) is being parsed from Istzeit
                {
                    int value;
                    if (Int32.TryParse(intString, out value) && counter == 0) // try to parse hh:
                    {
                        readString = value + ":"; // if hour is valid, it gets put in
                    }
                    else if (Int32.TryParse(intString, out value) && counter > 0) // try to parse :mm
                    {
                        readString += value;
                    }
                    else
                    {
                        throw new Exception(); // throw Exception if any value couldn't be parsed
                    }
                    counter++;
                }
            } catch (Exception excp) when (excp is FormatException || excp is Exception) // if Format invalid of manual exception is thrown: run catch-block
            {
                return "00:00";
            }

            return readString;
        }

        // method checks if cell is blocked, empty or invalid; returns cell value if valid
        private string CellFilter(string readString)
        {
            if (readString == null || readString.Equals(blocker) || readString.Length == 0) // checks if readString equals the blocker-string or is invalid in length
            {
                return " "; // return space symbol if cell is blocked/empty/invalid
            }

            for (int i = 0; i < readString.Length; i++) // checks for correct symbols additionally
            {
                int symbol = (int) readString[i] - 48; // convert symbol to ASCII minus 48 (for true number values)

                if ((i == 1 || i == 2) && symbol == 10){} // ASCII 10 = ':' // check if seperator is on third (occasionally second) spot
                else if ((symbol > 9 || symbol < 0)) // check for valid number between 0-9
                {
                    return " ";
                }

                // correct cells for proper consistency on the output
                if (readString.Split(':')[0].Length < 2)
                {
                    readString = "0" + readString; // 0h:mm
                }

                if (readString.Split(':')[1].Length < 2)
                {
                    readString = readString.Split(':')[0] + ":0" + readString.Split(':')[1]; // hh:0m
                }
            }

            return readString;
        }

        private void save_table()
        {
            //Console.WriteLine("DataGridView contains " + dataGridView1.Rows.Count + " rows. " + daysInMonth + " of these rows have been created.");
            StreamWriter sw = new StreamWriter(Arbeitsplan.fpathString); // writer for file

            for (int row = 0; row < daysInMonth; row++) // not using dataGridView1.Rows.Count because it adds up one unnecessary row; remain with the valid row amount
            {
                string saveString = ""; // initialize string to write per line
                for (int col = 0; col < 5; col++) // read the 5 columns and create 5 file entries seperated by semicolons (csv)
                {
                    string block_string; // string that turns into a space-symbol if checked cell is blocked; else: copies cell value
                    switch (col)
                    {
                        case 0:
                            block_string = CellFilter(dataGridView1.Rows[row].Cells[2].Value.ToString()); // method to modify block_string
                            saveString += block_string + ";";
                            break;
                        case 1:
                            block_string = CellFilter(dataGridView1.Rows[row].Cells[3].Value.ToString());
                            saveString += block_string + ";";
                            break;
                        case 2:
                            block_string = CellFilter(dataGridView1.Rows[row].Cells[4].Value.ToString());
                            saveString += block_string + ";";
                            break;
                        case 3:
                            block_string = CellFilter(dataGridView1.Rows[row].Cells[5].Value.ToString());
                            saveString += block_string + ";";
                            break;
                        case 4:
                            switch (dataGridView1.Rows[row].Cells[dataGridView1.Columns[9].Name].Value) // read combobox by value
                            {
                                case "Krank":
                                    saveString += 1;
                                    break;
                                case "Urlaub/Frei":
                                    saveString += 2;
                                    break;
                                case "Betriebsurlaub":
                                    saveString += 3;
                                    break;
                                case "Feiertag":
                                    saveString += 4;
                                    break;
                                default:
                                    saveString += 0;
                                    break;
                            }
                            break;
                        default:
                            saveString = " ; ; ; ;0"; // default string for empty row
                            break;
                    }
                }

                sw.WriteLine(saveString); // write line into csv-file
            }

            sw.Close(); // close writer
        }

        private void calc_label_Click(object sender, EventArgs e)
        {

        }
    }
}


///////////////////////////////////////////////////////////////////////////////////////////////////////////
///
/// -> Check, ob value für cell leer ist
/* foreach (DataGridViewRow rw in this.dataGridView1.Rows)
{
  for (int i = 0; i<rw.Cells.Count; i++)
  {
    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString())
    {
      // here is your message box...
    }
  } 
}
    */