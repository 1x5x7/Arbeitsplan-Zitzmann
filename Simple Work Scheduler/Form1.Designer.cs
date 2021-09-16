namespace Simple_Work_Scheduler
{
    partial class Arbeitsplan
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arbeitsplan));
            this.label_user = new System.Windows.Forms.Label();
            this.combobox_userSelection = new System.Windows.Forms.ComboBox();
            this.label_whichMonth = new System.Windows.Forms.Label();
            this.combobox_month = new System.Windows.Forms.ComboBox();
            this.button_createTable = new System.Windows.Forms.Button();
            this.label_creator = new System.Windows.Forms.Label();
            this.button_settings = new System.Windows.Forms.Button();
            this.combobox_year = new System.Windows.Forms.ComboBox();
            this.button_info = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(193, 122);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(289, 13);
            this.label_user.TabIndex = 0;
            this.label_user.Text = "Welcher Benutzer möchte auf seinen Arbeitsplan zugreifen?";
            // 
            // combobox_userSelection
            // 
            this.combobox_userSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_userSelection.Enabled = false;
            this.combobox_userSelection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combobox_userSelection.Location = new System.Drawing.Point(195, 138);
            this.combobox_userSelection.MaxDropDownItems = 32;
            this.combobox_userSelection.Name = "combobox_userSelection";
            this.combobox_userSelection.Size = new System.Drawing.Size(286, 21);
            this.combobox_userSelection.TabIndex = 1;
            // 
            // label_whichMonth
            // 
            this.label_whichMonth.AutoSize = true;
            this.label_whichMonth.Location = new System.Drawing.Point(210, 191);
            this.label_whichMonth.Name = "label_whichMonth";
            this.label_whichMonth.Size = new System.Drawing.Size(255, 26);
            this.label_whichMonth.TabIndex = 2;
            this.label_whichMonth.Text = "Möchten Sie auf einen bestimmten Monat zugreifen?\r\n                        (leer " +
    "= aktueller Monat)";
            // 
            // combobox_month
            // 
            this.combobox_month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_month.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combobox_month.Items.AddRange(new object[] {
            "Januar",
            "Februar",
            "März",
            "April",
            "Mai",
            "Juni",
            "Juli",
            "August",
            "September",
            "Oktober",
            "November",
            "Dezember"});
            this.combobox_month.Location = new System.Drawing.Point(233, 220);
            this.combobox_month.MaxDropDownItems = 12;
            this.combobox_month.Name = "combobox_month";
            this.combobox_month.Size = new System.Drawing.Size(210, 21);
            this.combobox_month.TabIndex = 3;
            // 
            // button_createTable
            // 
            this.button_createTable.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_createTable.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_createTable.Location = new System.Drawing.Point(212, 300);
            this.button_createTable.Name = "button_createTable";
            this.button_createTable.Size = new System.Drawing.Size(252, 49);
            this.button_createTable.TabIndex = 4;
            this.button_createTable.Text = "Tabelle anzeigen";
            this.button_createTable.UseVisualStyleBackColor = true;
            this.button_createTable.Click += new System.EventHandler(this.button_createTable_Click);
            // 
            // label_creator
            // 
            this.label_creator.AutoSize = true;
            this.label_creator.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_creator.ForeColor = System.Drawing.Color.DimGray;
            this.label_creator.Location = new System.Drawing.Point(10, 413);
            this.label_creator.Name = "label_creator";
            this.label_creator.Size = new System.Drawing.Size(151, 15);
            this.label_creator.TabIndex = 5;
            this.label_creator.Text = "Version X | Robert Schmidt";
            // 
            // button_settings
            // 
            this.button_settings.BackColor = System.Drawing.Color.Transparent;
            this.button_settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_settings.ForeColor = System.Drawing.Color.Transparent;
            this.button_settings.Image = ((System.Drawing.Image)(resources.GetObject("button_settings.Image")));
            this.button_settings.Location = new System.Drawing.Point(605, 386);
            this.button_settings.Margin = new System.Windows.Forms.Padding(2);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(45, 45);
            this.button_settings.TabIndex = 6;
            this.button_settings.UseVisualStyleBackColor = false;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // combobox_year
            // 
            this.combobox_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_year.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combobox_year.FormattingEnabled = true;
            this.combobox_year.Location = new System.Drawing.Point(278, 247);
            this.combobox_year.Name = "combobox_year";
            this.combobox_year.Size = new System.Drawing.Size(120, 21);
            this.combobox_year.TabIndex = 7;
            this.combobox_year.SelectedIndexChanged += new System.EventHandler(this.combobox_year_SelectedIndexChanged);
            // 
            // button_info
            // 
            this.button_info.BackColor = System.Drawing.Color.Transparent;
            this.button_info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_info.ForeColor = System.Drawing.Color.Transparent;
            this.button_info.Image = ((System.Drawing.Image)(resources.GetObject("button_info.Image")));
            this.button_info.Location = new System.Drawing.Point(556, 386);
            this.button_info.Margin = new System.Windows.Forms.Padding(2);
            this.button_info.Name = "button_info";
            this.button_info.Size = new System.Drawing.Size(45, 45);
            this.button_info.TabIndex = 8;
            this.button_info.UseVisualStyleBackColor = false;
            this.button_info.Click += new System.EventHandler(this.button_info_Click);
            // 
            // Arbeitsplan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(660, 433);
            this.Controls.Add(this.button_info);
            this.Controls.Add(this.combobox_year);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.label_creator);
            this.Controls.Add(this.button_createTable);
            this.Controls.Add(this.combobox_month);
            this.Controls.Add(this.label_whichMonth);
            this.Controls.Add(this.combobox_userSelection);
            this.Controls.Add(this.label_user);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Arbeitsplan";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arbeitsplan";
            this.Load += new System.EventHandler(this.Arbeitsplan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_whichMonth;
        private System.Windows.Forms.ComboBox combobox_month;
        private System.Windows.Forms.Button button_createTable;
        private System.Windows.Forms.Label label_creator;
        private System.Windows.Forms.Button button_settings;
        public System.Windows.Forms.ComboBox combobox_userSelection;
        private System.Windows.Forms.ComboBox combobox_year;
        private System.Windows.Forms.Button button_info;
    }
}

