namespace Arbeitsplan_Zitzmann
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
            this.which_user_label = new System.Windows.Forms.Label();
            this.user_selection_combobox = new System.Windows.Forms.ComboBox();
            this.which_month_label = new System.Windows.Forms.Label();
            this.month_selection_combobox = new System.Windows.Forms.ComboBox();
            this.create_table_button = new System.Windows.Forms.Button();
            this.creator_tag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // which_user_label
            // 
            this.which_user_label.AutoSize = true;
            this.which_user_label.Location = new System.Drawing.Point(189, 122);
            this.which_user_label.Name = "which_user_label";
            this.which_user_label.Size = new System.Drawing.Size(289, 13);
            this.which_user_label.TabIndex = 0;
            this.which_user_label.Text = "Welcher Benutzer möchte auf seinen Arbeitsplan zugreifen?";
            // 
            // user_selection_combobox
            // 
            this.user_selection_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.user_selection_combobox.Location = new System.Drawing.Point(192, 138);
            this.user_selection_combobox.Name = "user_selection_combobox";
            this.user_selection_combobox.Size = new System.Drawing.Size(286, 21);
            this.user_selection_combobox.TabIndex = 1;
            // 
            // which_month_label
            // 
            this.which_month_label.AutoSize = true;
            this.which_month_label.Location = new System.Drawing.Point(208, 191);
            this.which_month_label.Name = "which_month_label";
            this.which_month_label.Size = new System.Drawing.Size(255, 26);
            this.which_month_label.TabIndex = 2;
            this.which_month_label.Text = "Möchten Sie auf einen bestimmten Monat zugreifen?\r\n                        (leer " +
    "= aktueller Monat)";
            // 
            // month_selection_combobox
            // 
            this.month_selection_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.month_selection_combobox.Items.AddRange(new object[] {
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
            this.month_selection_combobox.Location = new System.Drawing.Point(235, 220);
            this.month_selection_combobox.Name = "month_selection_combobox";
            this.month_selection_combobox.Size = new System.Drawing.Size(210, 21);
            this.month_selection_combobox.TabIndex = 3;
            // 
            // create_table_button
            // 
            this.create_table_button.Location = new System.Drawing.Point(211, 282);
            this.create_table_button.Name = "create_table_button";
            this.create_table_button.Size = new System.Drawing.Size(252, 23);
            this.create_table_button.TabIndex = 4;
            this.create_table_button.Text = "Tabelle anzeigen";
            this.create_table_button.UseVisualStyleBackColor = true;
            this.create_table_button.Click += new System.EventHandler(this.create_table_button_Click);
            // 
            // creator_tag
            // 
            this.creator_tag.AutoSize = true;
            this.creator_tag.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creator_tag.ForeColor = System.Drawing.Color.DimGray;
            this.creator_tag.Location = new System.Drawing.Point(12, 413);
            this.creator_tag.Name = "creator_tag";
            this.creator_tag.Size = new System.Drawing.Size(153, 15);
            this.creator_tag.TabIndex = 5;
            this.creator_tag.Text = "Version X / Robert Schmidt";
            // 
            // Arbeitsplan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 433);
            this.Controls.Add(this.creator_tag);
            this.Controls.Add(this.create_table_button);
            this.Controls.Add(this.month_selection_combobox);
            this.Controls.Add(this.which_month_label);
            this.Controls.Add(this.user_selection_combobox);
            this.Controls.Add(this.which_user_label);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Arbeitsplan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arbeitsplan (2021)";
            this.Load += new System.EventHandler(this.Arbeitsplan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label which_user_label;
        private System.Windows.Forms.ComboBox user_selection_combobox;
        private System.Windows.Forms.Label which_month_label;
        private System.Windows.Forms.ComboBox month_selection_combobox;
        private System.Windows.Forms.Button create_table_button;
        private System.Windows.Forms.Label creator_tag;
    }
}

