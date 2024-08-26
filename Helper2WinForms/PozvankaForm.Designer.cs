using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace Helper2WinForms
{
    partial class PozvankaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PozvankaForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_pridejOdkaz = new System.Windows.Forms.Button();
            this.btn_vytvorVystup = new System.Windows.Forms.Button();
            this.btn_otevriVystup = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.80916F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.19084F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tableLayoutPanel1.Controls.Add(this.btn_pridejOdkaz, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_vytvorVystup, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_otevriVystup, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 44);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_pridejOdkaz
            // 
            this.btn_pridejOdkaz.Location = new System.Drawing.Point(3, 3);
            this.btn_pridejOdkaz.Name = "btn_pridejOdkaz";
            this.btn_pridejOdkaz.Size = new System.Drawing.Size(187, 38);
            this.btn_pridejOdkaz.TabIndex = 0;
            this.btn_pridejOdkaz.Text = "Přidej odkaz";
            this.btn_pridejOdkaz.UseVisualStyleBackColor = true;
            this.btn_pridejOdkaz.Click += new System.EventHandler(this.btn_pridejOdkaz_Click);
            // 
            // btn_vytvorVystup
            // 
            this.btn_vytvorVystup.Location = new System.Drawing.Point(196, 3);
            this.btn_vytvorVystup.Name = "btn_vytvorVystup";
            this.btn_vytvorVystup.Size = new System.Drawing.Size(188, 38);
            this.btn_vytvorVystup.TabIndex = 1;
            this.btn_vytvorVystup.Text = "Vytvoř výstup";
            this.btn_vytvorVystup.UseVisualStyleBackColor = true;
            this.btn_vytvorVystup.Click += new System.EventHandler(this.btn_vytvorVystup_Click);
            // 
            // btn_otevriVystup
            // 
            this.btn_otevriVystup.Location = new System.Drawing.Point(390, 3);
            this.btn_otevriVystup.Name = "btn_otevriVystup";
            this.btn_otevriVystup.Size = new System.Drawing.Size(216, 38);
            this.btn_otevriVystup.TabIndex = 2;
            this.btn_otevriVystup.Text = "Otevři výstup";
            this.btn_otevriVystup.UseVisualStyleBackColor = true;
            this.btn_otevriVystup.Click += new System.EventHandler(this.btn_otevriVystup_Click);
            // 
            // PozvankaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(629, 444);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(645, 612);
            this.MinimumSize = new System.Drawing.Size(645, 439);
            this.Name = "PozvankaForm";
            this.Text = "Helper2 | Pozvanka";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_pridejOdkaz;
        private Button btn_vytvorVystup;
        private Button btn_otevriVystup;
    }
}