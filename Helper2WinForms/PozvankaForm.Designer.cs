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
            tableLayoutPanel1 = new TableLayoutPanel();
            btn_pridejOdkaz = new Button();
            btn_vytvorVystup = new Button();
            btn_otevriVystup = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.8091621F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.1908379F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 258F));
            tableLayoutPanel1.Controls.Add(btn_pridejOdkaz, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_vytvorVystup, 1, 0);
            tableLayoutPanel1.Controls.Add(btn_otevriVystup, 2, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(710, 51);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_pridejOdkaz
            // 
            btn_pridejOdkaz.Location = new Point(3, 3);
            btn_pridejOdkaz.Name = "btn_pridejOdkaz";
            btn_pridejOdkaz.Size = new Size(219, 45);
            btn_pridejOdkaz.TabIndex = 0;
            btn_pridejOdkaz.Text = "Přidej odkaz";
            btn_pridejOdkaz.UseVisualStyleBackColor = true;
            btn_pridejOdkaz.Click += btn_pridejOdkaz_Click;
            // 
            // btn_vytvorVystup
            // 
            btn_vytvorVystup.Location = new Point(228, 3);
            btn_vytvorVystup.Name = "btn_vytvorVystup";
            btn_vytvorVystup.Size = new Size(220, 45);
            btn_vytvorVystup.TabIndex = 1;
            btn_vytvorVystup.Text = "Vytvoř výstup";
            btn_vytvorVystup.UseVisualStyleBackColor = true;
            btn_vytvorVystup.Click += btn_vytvorVystup_Click;
            // 
            // btn_otevriVystup
            // 
            btn_otevriVystup.Location = new Point(454, 3);
            btn_otevriVystup.Name = "btn_otevriVystup";
            btn_otevriVystup.Size = new Size(253, 45);
            btn_otevriVystup.TabIndex = 2;
            btn_otevriVystup.Text = "Otevři výstup";
            btn_otevriVystup.UseVisualStyleBackColor = true;
            btn_otevriVystup.Click += btn_otevriVystup_Click;
            // 
            // PozvankaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(734, 461);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(750, 700);
            MinimumSize = new Size(750, 500);
            Name = "PozvankaForm";
            Text = "Helper2 | Pozvanka";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_pridejOdkaz;
        private Button btn_vytvorVystup;
        private Button btn_otevriVystup;
    }
}