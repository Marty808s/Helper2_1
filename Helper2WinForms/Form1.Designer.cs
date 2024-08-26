using System;
using System.Windows.Forms;
using System.Drawing;


namespace Helper2WinForms
{
    partial class WinForm1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_version = new System.Windows.Forms.Label();
            this.lb_email = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_title = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_intro = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.bt_pozvanky = new System.Windows.Forms.Button();
            this.bt_pripojeni = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_version
            // 
            this.lb_version.AutoSize = true;
            this.lb_version.Location = new System.Drawing.Point(10, 335);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(46, 13);
            this.lb_version.TabIndex = 0;
            this.lb_version.Text = "2.0.1.24";
            // 
            // lb_email
            // 
            this.lb_email.AutoSize = true;
            this.lb_email.Location = new System.Drawing.Point(264, 335);
            this.lb_email.Name = "lb_email";
            this.lb_email.Size = new System.Drawing.Size(102, 13);
            this.lb_email.TabIndex = 1;
            this.lb_email.Text = "martin.vlnas@npi.cz";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lb_title, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(351, 87);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_title.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold);
            this.lb_title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_title.Location = new System.Drawing.Point(3, 0);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(345, 87);
            this.lb_title.TabIndex = 0;
            this.lb_title.Text = "Helper 2.0";
            this.lb_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lb_intro, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 102);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(343, 41);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // lb_intro
            // 
            this.lb_intro.AutoSize = true;
            this.lb_intro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_intro.Location = new System.Drawing.Point(3, 0);
            this.lb_intro.Name = "lb_intro";
            this.lb_intro.Size = new System.Drawing.Size(337, 41);
            this.lb_intro.TabIndex = 0;
            this.lb_intro.Text = "Zvolte si funkci:";
            this.lb_intro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.bt_pozvanky, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.bt_pripojeni, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(10, 156);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(351, 43);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // bt_pozvanky
            // 
            this.bt_pozvanky.Location = new System.Drawing.Point(3, 3);
            this.bt_pozvanky.Name = "bt_pozvanky";
            this.bt_pozvanky.Size = new System.Drawing.Size(169, 37);
            this.bt_pozvanky.TabIndex = 0;
            this.bt_pozvanky.Text = "Vytvoř pozvánky na VP";
            this.bt_pozvanky.UseVisualStyleBackColor = true;
            this.bt_pozvanky.Click += new System.EventHandler(this.bt_pozvanky_Click);
            // 
            // bt_pripojeni
            // 
            this.bt_pripojeni.Location = new System.Drawing.Point(178, 3);
            this.bt_pripojeni.Name = "bt_pripojeni";
            this.bt_pripojeni.Size = new System.Drawing.Size(170, 37);
            this.bt_pripojeni.TabIndex = 1;
            this.bt_pripojeni.Text = "Vytvoř pozvánku pro připojení";
            this.bt_pripojeni.UseVisualStyleBackColor = true;
            this.bt_pripojeni.Click += new System.EventHandler(this.bt_pripojeni_Click);
            // 
            // WinForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(372, 356);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lb_email);
            this.Controls.Add(this.lb_version);
            this.MaximumSize = new System.Drawing.Size(388, 395);
            this.MinimumSize = new System.Drawing.Size(388, 395);
            this.Name = "WinForm1";
            this.Text = "Helper2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lb_version;
        private Label lb_email;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lb_title;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lb_intro;
        private TableLayoutPanel tableLayoutPanel3;
        private Button bt_pozvanky;
        private Button bt_pripojeni;
    }
}