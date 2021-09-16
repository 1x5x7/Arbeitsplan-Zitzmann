
namespace Simple_Work_Scheduler
{
    partial class Arbeitsplan_Einstellungen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arbeitsplan_Einstellungen));
            this.label_user = new System.Windows.Forms.Label();
            this.button_addUser = new System.Windows.Forms.Button();
            this.button_deleteUser = new System.Windows.Forms.Button();
            this.label_arbeitszeiten = new System.Windows.Forms.Label();
            this.button_arbeitszeiten = new System.Windows.Forms.Button();
            this.label_language = new System.Windows.Forms.Label();
            this.combobox_language = new System.Windows.Forms.ComboBox();
            this.button_back = new System.Windows.Forms.Button();
            this.button_confirm = new System.Windows.Forms.Button();
            this.textbox_addUser = new System.Windows.Forms.TextBox();
            this.label_addUser = new System.Windows.Forms.Label();
            this.label_deleteUser = new System.Windows.Forms.Label();
            this.combobox_deleteUser = new System.Windows.Forms.ComboBox();
            this.checkbox_deleteTables = new System.Windows.Forms.CheckBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label_monday = new System.Windows.Forms.Label();
            this.label_tuesday = new System.Windows.Forms.Label();
            this.label_wednesday = new System.Windows.Forms.Label();
            this.label_thursday = new System.Windows.Forms.Label();
            this.label_friday = new System.Windows.Forms.Label();
            this.textbox_mon = new System.Windows.Forms.TextBox();
            this.textbox_tue = new System.Windows.Forms.TextBox();
            this.textbox_wed = new System.Windows.Forms.TextBox();
            this.textbox_thu = new System.Windows.Forms.TextBox();
            this.textbox_fri = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(146, 40);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(49, 13);
            this.label_user.TabIndex = 0;
            this.label_user.Text = "Benutzer";
            // 
            // button_addUser
            // 
            this.button_addUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_addUser.Location = new System.Drawing.Point(149, 56);
            this.button_addUser.Name = "button_addUser";
            this.button_addUser.Size = new System.Drawing.Size(220, 23);
            this.button_addUser.TabIndex = 1;
            this.button_addUser.Text = "Hinzufügen";
            this.button_addUser.UseVisualStyleBackColor = true;
            this.button_addUser.Click += new System.EventHandler(this.button_addUser_Click);
            // 
            // button_deleteUser
            // 
            this.button_deleteUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_deleteUser.Location = new System.Drawing.Point(149, 85);
            this.button_deleteUser.Name = "button_deleteUser";
            this.button_deleteUser.Size = new System.Drawing.Size(220, 23);
            this.button_deleteUser.TabIndex = 2;
            this.button_deleteUser.Text = "Entfernen";
            this.button_deleteUser.UseVisualStyleBackColor = true;
            this.button_deleteUser.Click += new System.EventHandler(this.button_deleteUser_Click);
            // 
            // label_arbeitszeiten
            // 
            this.label_arbeitszeiten.AutoSize = true;
            this.label_arbeitszeiten.Location = new System.Drawing.Point(146, 133);
            this.label_arbeitszeiten.Name = "label_arbeitszeiten";
            this.label_arbeitszeiten.Size = new System.Drawing.Size(67, 13);
            this.label_arbeitszeiten.TabIndex = 3;
            this.label_arbeitszeiten.Text = "Arbeitszeiten";
            // 
            // button_arbeitszeiten
            // 
            this.button_arbeitszeiten.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_arbeitszeiten.Location = new System.Drawing.Point(149, 149);
            this.button_arbeitszeiten.Name = "button_arbeitszeiten";
            this.button_arbeitszeiten.Size = new System.Drawing.Size(220, 23);
            this.button_arbeitszeiten.TabIndex = 4;
            this.button_arbeitszeiten.Text = "Anpassen";
            this.button_arbeitszeiten.UseVisualStyleBackColor = true;
            this.button_arbeitszeiten.Click += new System.EventHandler(this.button_arbeitszeiten_Click);
            // 
            // label_language
            // 
            this.label_language.AutoSize = true;
            this.label_language.Location = new System.Drawing.Point(146, 203);
            this.label_language.Name = "label_language";
            this.label_language.Size = new System.Drawing.Size(47, 13);
            this.label_language.TabIndex = 5;
            this.label_language.Text = "Sprache";
            // 
            // combobox_language
            // 
            this.combobox_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_language.Enabled = false;
            this.combobox_language.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combobox_language.FormattingEnabled = true;
            this.combobox_language.Location = new System.Drawing.Point(149, 219);
            this.combobox_language.Name = "combobox_language";
            this.combobox_language.Size = new System.Drawing.Size(220, 21);
            this.combobox_language.TabIndex = 6;
            // 
            // button_back
            // 
            this.button_back.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_back.Location = new System.Drawing.Point(221, 258);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(76, 23);
            this.button_back.TabIndex = 7;
            this.button_back.Text = "Zurück";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Visible = false;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // button_confirm
            // 
            this.button_confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_confirm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_confirm.Location = new System.Drawing.Point(162, 215);
            this.button_confirm.Name = "button_confirm";
            this.button_confirm.Size = new System.Drawing.Size(197, 30);
            this.button_confirm.TabIndex = 8;
            this.button_confirm.Text = "Bestätigen";
            this.button_confirm.UseVisualStyleBackColor = true;
            this.button_confirm.Visible = false;
            this.button_confirm.Click += new System.EventHandler(this.button_confirm_Click);
            // 
            // textbox_addUser
            // 
            this.textbox_addUser.Location = new System.Drawing.Point(149, 132);
            this.textbox_addUser.MaxLength = 20;
            this.textbox_addUser.Name = "textbox_addUser";
            this.textbox_addUser.Size = new System.Drawing.Size(220, 20);
            this.textbox_addUser.TabIndex = 9;
            this.textbox_addUser.Visible = false;
            this.textbox_addUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_addUser_KeyPress);
            // 
            // label_addUser
            // 
            this.label_addUser.AutoSize = true;
            this.label_addUser.Location = new System.Drawing.Point(90, 110);
            this.label_addUser.Name = "label_addUser";
            this.label_addUser.Size = new System.Drawing.Size(351, 13);
            this.label_addUser.TabIndex = 10;
            this.label_addUser.Text = "Bitte geben Sie den Namen des Nutzers ein, der hinzugefügt werden soll:";
            this.label_addUser.Visible = false;
            // 
            // label_deleteUser
            // 
            this.label_deleteUser.AutoSize = true;
            this.label_deleteUser.Location = new System.Drawing.Point(120, 110);
            this.label_deleteUser.Name = "label_deleteUser";
            this.label_deleteUser.Size = new System.Drawing.Size(281, 13);
            this.label_deleteUser.TabIndex = 11;
            this.label_deleteUser.Text = "Bitte wählen Sie den Nutzer aus, der gelöscht werden soll:";
            this.label_deleteUser.Visible = false;
            // 
            // combobox_deleteUser
            // 
            this.combobox_deleteUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_deleteUser.Enabled = false;
            this.combobox_deleteUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combobox_deleteUser.Location = new System.Drawing.Point(149, 132);
            this.combobox_deleteUser.MaxDropDownItems = 32;
            this.combobox_deleteUser.Name = "combobox_deleteUser";
            this.combobox_deleteUser.Size = new System.Drawing.Size(220, 21);
            this.combobox_deleteUser.TabIndex = 12;
            this.combobox_deleteUser.Visible = false;
            // 
            // checkbox_deleteTables
            // 
            this.checkbox_deleteTables.AutoSize = true;
            this.checkbox_deleteTables.Checked = true;
            this.checkbox_deleteTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkbox_deleteTables.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkbox_deleteTables.Location = new System.Drawing.Point(134, 164);
            this.checkbox_deleteTables.Name = "checkbox_deleteTables";
            this.checkbox_deleteTables.Size = new System.Drawing.Size(265, 18);
            this.checkbox_deleteTables.TabIndex = 13;
            this.checkbox_deleteTables.Text = "Arbeitspläne für diesen Nutzer endgültig löschen?";
            this.checkbox_deleteTables.UseVisualStyleBackColor = true;
            this.checkbox_deleteTables.Visible = false;
            // 
            // label_monday
            // 
            this.label_monday.AutoSize = true;
            this.label_monday.Location = new System.Drawing.Point(170, 52);
            this.label_monday.Name = "label_monday";
            this.label_monday.Size = new System.Drawing.Size(43, 13);
            this.label_monday.TabIndex = 14;
            this.label_monday.Text = "Montag";
            this.label_monday.Visible = false;
            // 
            // label_tuesday
            // 
            this.label_tuesday.AutoSize = true;
            this.label_tuesday.Location = new System.Drawing.Point(168, 82);
            this.label_tuesday.Name = "label_tuesday";
            this.label_tuesday.Size = new System.Drawing.Size(49, 13);
            this.label_tuesday.TabIndex = 15;
            this.label_tuesday.Text = "Dienstag";
            this.label_tuesday.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_tuesday.Visible = false;
            // 
            // label_wednesday
            // 
            this.label_wednesday.AutoSize = true;
            this.label_wednesday.Location = new System.Drawing.Point(168, 112);
            this.label_wednesday.Name = "label_wednesday";
            this.label_wednesday.Size = new System.Drawing.Size(50, 13);
            this.label_wednesday.TabIndex = 16;
            this.label_wednesday.Text = "Mittwoch";
            this.label_wednesday.Visible = false;
            // 
            // label_thursday
            // 
            this.label_thursday.AutoSize = true;
            this.label_thursday.Location = new System.Drawing.Point(164, 142);
            this.label_thursday.Name = "label_thursday";
            this.label_thursday.Size = new System.Drawing.Size(62, 13);
            this.label_thursday.TabIndex = 17;
            this.label_thursday.Text = "Donnerstag";
            this.label_thursday.Visible = false;
            // 
            // label_friday
            // 
            this.label_friday.AutoSize = true;
            this.label_friday.Location = new System.Drawing.Point(172, 172);
            this.label_friday.Name = "label_friday";
            this.label_friday.Size = new System.Drawing.Size(39, 13);
            this.label_friday.TabIndex = 18;
            this.label_friday.Text = "Freitag";
            this.label_friday.Visible = false;
            // 
            // textbox_mon
            // 
            this.textbox_mon.Location = new System.Drawing.Point(234, 50);
            this.textbox_mon.MaxLength = 5;
            this.textbox_mon.Name = "textbox_mon";
            this.textbox_mon.Size = new System.Drawing.Size(116, 20);
            this.textbox_mon.TabIndex = 20;
            this.textbox_mon.Visible = false;
            this.textbox_mon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_times_KeyPress);
            // 
            // textbox_tue
            // 
            this.textbox_tue.Location = new System.Drawing.Point(234, 80);
            this.textbox_tue.MaxLength = 5;
            this.textbox_tue.Name = "textbox_tue";
            this.textbox_tue.Size = new System.Drawing.Size(116, 20);
            this.textbox_tue.TabIndex = 22;
            this.textbox_tue.Visible = false;
            this.textbox_tue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_times_KeyPress);
            // 
            // textbox_wed
            // 
            this.textbox_wed.Location = new System.Drawing.Point(234, 110);
            this.textbox_wed.MaxLength = 5;
            this.textbox_wed.Name = "textbox_wed";
            this.textbox_wed.Size = new System.Drawing.Size(116, 20);
            this.textbox_wed.TabIndex = 24;
            this.textbox_wed.Visible = false;
            this.textbox_wed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_times_KeyPress);
            // 
            // textbox_thu
            // 
            this.textbox_thu.Location = new System.Drawing.Point(233, 140);
            this.textbox_thu.MaxLength = 5;
            this.textbox_thu.Name = "textbox_thu";
            this.textbox_thu.Size = new System.Drawing.Size(117, 20);
            this.textbox_thu.TabIndex = 26;
            this.textbox_thu.Visible = false;
            this.textbox_thu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_times_KeyPress);
            // 
            // textbox_fri
            // 
            this.textbox_fri.Location = new System.Drawing.Point(232, 170);
            this.textbox_fri.MaxLength = 5;
            this.textbox_fri.Name = "textbox_fri";
            this.textbox_fri.Size = new System.Drawing.Size(117, 20);
            this.textbox_fri.TabIndex = 28;
            this.textbox_fri.Visible = false;
            this.textbox_fri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_times_KeyPress);
            // 
            // Arbeitsplan_Einstellungen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(502, 293);
            this.Controls.Add(this.textbox_fri);
            this.Controls.Add(this.textbox_thu);
            this.Controls.Add(this.textbox_wed);
            this.Controls.Add(this.textbox_tue);
            this.Controls.Add(this.textbox_mon);
            this.Controls.Add(this.label_friday);
            this.Controls.Add(this.label_thursday);
            this.Controls.Add(this.label_wednesday);
            this.Controls.Add(this.label_tuesday);
            this.Controls.Add(this.label_monday);
            this.Controls.Add(this.checkbox_deleteTables);
            this.Controls.Add(this.combobox_deleteUser);
            this.Controls.Add(this.label_deleteUser);
            this.Controls.Add(this.label_addUser);
            this.Controls.Add(this.textbox_addUser);
            this.Controls.Add(this.button_confirm);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.combobox_language);
            this.Controls.Add(this.label_language);
            this.Controls.Add(this.button_arbeitszeiten);
            this.Controls.Add(this.label_arbeitszeiten);
            this.Controls.Add(this.button_deleteUser);
            this.Controls.Add(this.button_addUser);
            this.Controls.Add(this.label_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Arbeitsplan_Einstellungen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.Arbeitsplan_Einstellungen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Button button_addUser;
        private System.Windows.Forms.Button button_deleteUser;
        private System.Windows.Forms.Label label_arbeitszeiten;
        private System.Windows.Forms.Button button_arbeitszeiten;
        private System.Windows.Forms.Label label_language;
        private System.Windows.Forms.ComboBox combobox_language;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button_confirm;
        private System.Windows.Forms.TextBox textbox_addUser;
        private System.Windows.Forms.Label label_addUser;
        private System.Windows.Forms.Label label_deleteUser;
        private System.Windows.Forms.ComboBox combobox_deleteUser;
        private System.Windows.Forms.CheckBox checkbox_deleteTables;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label_monday;
        private System.Windows.Forms.Label label_tuesday;
        private System.Windows.Forms.Label label_wednesday;
        private System.Windows.Forms.Label label_thursday;
        private System.Windows.Forms.Label label_friday;
        private System.Windows.Forms.TextBox textbox_mon;
        private System.Windows.Forms.TextBox textbox_tue;
        private System.Windows.Forms.TextBox textbox_wed;
        private System.Windows.Forms.TextBox textbox_thu;
        private System.Windows.Forms.TextBox textbox_fri;
    }
}