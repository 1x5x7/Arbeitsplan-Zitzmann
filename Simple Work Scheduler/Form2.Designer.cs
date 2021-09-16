namespace Simple_Work_Scheduler
{
    partial class Arbeitsplan_Tabelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arbeitsplan_Tabelle));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.save_button = new System.Windows.Forms.Button();
            this.calc_button = new System.Windows.Forms.Button();
            this.label_hinweis1 = new System.Windows.Forms.Label();
            this.label_hinweis2 = new System.Windows.Forms.Label();
            this.label_TotalHrsSoll = new System.Windows.Forms.Label();
            this.textBox_TotalHrsSoll = new System.Windows.Forms.TextBox();
            this.label_Saldo = new System.Windows.Forms.Label();
            this.label_uberLast = new System.Windows.Forms.Label();
            this.textBox_FromLastMonth = new System.Windows.Forms.TextBox();
            this.label_FromLastMonth = new System.Windows.Forms.Label();
            this.textBox_TotalHrsIst = new System.Windows.Forms.TextBox();
            this.label_TotalHrsIst = new System.Windows.Forms.Label();
            this.label_uberNext = new System.Windows.Forms.Label();
            this.label_IntoNextMonth = new System.Windows.Forms.Label();
            this.textBox_IntoNextMonth = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView.Size = new System.Drawing.Size(1070, 705);
            this.dataGridView.TabIndex = 1;
            // 
            // save_button
            // 
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.save_button.Location = new System.Drawing.Point(1088, 12);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(145, 51);
            this.save_button.TabIndex = 2;
            this.save_button.Text = "Speichern";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // calc_button
            // 
            this.calc_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calc_button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.calc_button.Location = new System.Drawing.Point(1088, 79);
            this.calc_button.Name = "calc_button";
            this.calc_button.Size = new System.Drawing.Size(145, 51);
            this.calc_button.TabIndex = 3;
            this.calc_button.Text = "Tabelle auswerten";
            this.calc_button.UseVisualStyleBackColor = true;
            this.calc_button.Click += new System.EventHandler(this.calc_button_Click);
            // 
            // label_hinweis1
            // 
            this.label_hinweis1.AutoSize = true;
            this.label_hinweis1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_hinweis1.Location = new System.Drawing.Point(9, 740);
            this.label_hinweis1.Name = "label_hinweis1";
            this.label_hinweis1.Size = new System.Drawing.Size(458, 13);
            this.label_hinweis1.TabIndex = 4;
            this.label_hinweis1.Text = "HINWEIS: Bei den Berechnungen wird das Ausfüllen der ersten beiden von-bis Zellen" +
    " priorisiert.";
            // 
            // label_hinweis2
            // 
            this.label_hinweis2.AutoSize = true;
            this.label_hinweis2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_hinweis2.Location = new System.Drawing.Point(62, 755);
            this.label_hinweis2.Name = "label_hinweis2";
            this.label_hinweis2.Size = new System.Drawing.Size(322, 13);
            this.label_hinweis2.TabIndex = 5;
            this.label_hinweis2.Text = "Sind diese beiden leer, so sind die weiteren von-bis Zellen ungültig.";
            // 
            // label_TotalHrsSoll
            // 
            this.label_TotalHrsSoll.AutoSize = true;
            this.label_TotalHrsSoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalHrsSoll.Location = new System.Drawing.Point(1102, 280);
            this.label_TotalHrsSoll.Name = "label_TotalHrsSoll";
            this.label_TotalHrsSoll.Size = new System.Drawing.Size(54, 16);
            this.label_TotalHrsSoll.TabIndex = 8;
            this.label_TotalHrsSoll.Text = "Sollzeit:";
            // 
            // textBox_TotalHrsSoll
            // 
            this.textBox_TotalHrsSoll.Location = new System.Drawing.Point(1105, 299);
            this.textBox_TotalHrsSoll.MaxLength = 7;
            this.textBox_TotalHrsSoll.Name = "textBox_TotalHrsSoll";
            this.textBox_TotalHrsSoll.ReadOnly = true;
            this.textBox_TotalHrsSoll.Size = new System.Drawing.Size(100, 20);
            this.textBox_TotalHrsSoll.TabIndex = 9;
            // 
            // label_Saldo
            // 
            this.label_Saldo.AutoSize = true;
            this.label_Saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Saldo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label_Saldo.Location = new System.Drawing.Point(1102, 169);
            this.label_Saldo.Name = "label_Saldo";
            this.label_Saldo.Size = new System.Drawing.Size(111, 20);
            this.label_Saldo.TabIndex = 4;
            this.label_Saldo.Text = "Monatssaldo";
            // 
            // label_uberLast
            // 
            this.label_uberLast.AutoSize = true;
            this.label_uberLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_uberLast.Location = new System.Drawing.Point(1102, 206);
            this.label_uberLast.Name = "label_uberLast";
            this.label_uberLast.Size = new System.Drawing.Size(61, 16);
            this.label_uberLast.TabIndex = 5;
            this.label_uberLast.Text = "Übertrag";
            // 
            // textBox_FromLastMonth
            // 
            this.textBox_FromLastMonth.Location = new System.Drawing.Point(1106, 244);
            this.textBox_FromLastMonth.MaxLength = 7;
            this.textBox_FromLastMonth.Name = "textBox_FromLastMonth";
            this.textBox_FromLastMonth.ReadOnly = true;
            this.textBox_FromLastMonth.Size = new System.Drawing.Size(100, 20);
            this.textBox_FromLastMonth.TabIndex = 7;
            // 
            // label_FromLastMonth
            // 
            this.label_FromLastMonth.AutoSize = true;
            this.label_FromLastMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FromLastMonth.Location = new System.Drawing.Point(1103, 222);
            this.label_FromLastMonth.Name = "label_FromLastMonth";
            this.label_FromLastMonth.Size = new System.Drawing.Size(103, 16);
            this.label_FromLastMonth.TabIndex = 6;
            this.label_FromLastMonth.Text = "aus September:";
            // 
            // textBox_TotalHrsIst
            // 
            this.textBox_TotalHrsIst.Location = new System.Drawing.Point(1105, 358);
            this.textBox_TotalHrsIst.MaxLength = 7;
            this.textBox_TotalHrsIst.Name = "textBox_TotalHrsIst";
            this.textBox_TotalHrsIst.ReadOnly = true;
            this.textBox_TotalHrsIst.Size = new System.Drawing.Size(100, 20);
            this.textBox_TotalHrsIst.TabIndex = 10;
            // 
            // label_TotalHrsIst
            // 
            this.label_TotalHrsIst.AutoSize = true;
            this.label_TotalHrsIst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalHrsIst.Location = new System.Drawing.Point(1102, 337);
            this.label_TotalHrsIst.Name = "label_TotalHrsIst";
            this.label_TotalHrsIst.Size = new System.Drawing.Size(44, 16);
            this.label_TotalHrsIst.TabIndex = 11;
            this.label_TotalHrsIst.Text = "Istzeit:";
            // 
            // label_uberNext
            // 
            this.label_uberNext.AutoSize = true;
            this.label_uberNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_uberNext.Location = new System.Drawing.Point(1102, 395);
            this.label_uberNext.Name = "label_uberNext";
            this.label_uberNext.Size = new System.Drawing.Size(61, 16);
            this.label_uberNext.TabIndex = 12;
            this.label_uberNext.Text = "Übertrag";
            // 
            // label_IntoNextMonth
            // 
            this.label_IntoNextMonth.AutoSize = true;
            this.label_IntoNextMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_IntoNextMonth.Location = new System.Drawing.Point(1102, 411);
            this.label_IntoNextMonth.Name = "label_IntoNextMonth";
            this.label_IntoNextMonth.Size = new System.Drawing.Size(87, 16);
            this.label_IntoNextMonth.TabIndex = 13;
            this.label_IntoNextMonth.Text = "in Dezember:";
            // 
            // textBox_IntoNextMonth
            // 
            this.textBox_IntoNextMonth.Location = new System.Drawing.Point(1105, 433);
            this.textBox_IntoNextMonth.MaxLength = 7;
            this.textBox_IntoNextMonth.Name = "textBox_IntoNextMonth";
            this.textBox_IntoNextMonth.ReadOnly = true;
            this.textBox_IntoNextMonth.Size = new System.Drawing.Size(100, 20);
            this.textBox_IntoNextMonth.TabIndex = 14;
            // 
            // Arbeitsplan_Tabelle
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1245, 787);
            this.Controls.Add(this.textBox_IntoNextMonth);
            this.Controls.Add(this.label_IntoNextMonth);
            this.Controls.Add(this.label_uberNext);
            this.Controls.Add(this.label_TotalHrsIst);
            this.Controls.Add(this.textBox_TotalHrsIst);
            this.Controls.Add(this.label_FromLastMonth);
            this.Controls.Add(this.textBox_FromLastMonth);
            this.Controls.Add(this.label_uberLast);
            this.Controls.Add(this.label_Saldo);
            this.Controls.Add(this.textBox_TotalHrsSoll);
            this.Controls.Add(this.label_TotalHrsSoll);
            this.Controls.Add(this.label_hinweis2);
            this.Controls.Add(this.label_hinweis1);
            this.Controls.Add(this.calc_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Arbeitsplan_Tabelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arbeitsplan von X";
            this.Load += new System.EventHandler(this.Arbeitsplan_Tabelle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button calc_button;
        private System.Windows.Forms.Label label_hinweis1;
        private System.Windows.Forms.Label label_hinweis2;
        private System.Windows.Forms.Label label_TotalHrsSoll;
        private System.Windows.Forms.TextBox textBox_TotalHrsSoll;
        private System.Windows.Forms.Label label_Saldo;
        private System.Windows.Forms.Label label_uberLast;
        private System.Windows.Forms.TextBox textBox_FromLastMonth;
        private System.Windows.Forms.Label label_FromLastMonth;
        private System.Windows.Forms.TextBox textBox_TotalHrsIst;
        private System.Windows.Forms.Label label_TotalHrsIst;
        private System.Windows.Forms.Label label_uberNext;
        private System.Windows.Forms.Label label_IntoNextMonth;
        private System.Windows.Forms.TextBox textBox_IntoNextMonth;
    }
}