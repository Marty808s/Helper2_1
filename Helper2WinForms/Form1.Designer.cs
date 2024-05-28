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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm1));
            lb_version = new Label();
            lb_email = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lb_title = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            lb_intro = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            bt_pozvanky = new Button();
            bt_pripojeni = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // lb_version
            // 
            lb_version.AutoSize = true;
            lb_version.Location = new Point(12, 387);
            lb_version.Name = "lb_version";
            lb_version.Size = new Size(46, 15);
            lb_version.TabIndex = 0;
            lb_version.Text = "2.0.0.24";
            // 
            // lb_email
            // 
            lb_email.AutoSize = true;
            lb_email.Location = new Point(308, 387);
            lb_email.Name = "lb_email";
            lb_email.Size = new Size(114, 15);
            lb_email.TabIndex = 1;
            lb_email.Text = "martin.vlnas@npi.cz";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lb_title, 0, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(410, 100);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // lb_title
            // 
            lb_title.AutoSize = true;
            lb_title.Dock = DockStyle.Fill;
            lb_title.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            lb_title.ForeColor = SystemColors.ButtonHighlight;
            lb_title.Location = new Point(3, 0);
            lb_title.Name = "lb_title";
            lb_title.Size = new Size(404, 100);
            lb_title.TabIndex = 0;
            lb_title.Text = "Helper 2.0";
            lb_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(lb_intro, 0, 0);
            tableLayoutPanel2.Location = new Point(19, 118);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(400, 47);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // lb_intro
            // 
            lb_intro.AutoSize = true;
            lb_intro.Dock = DockStyle.Fill;
            lb_intro.Location = new Point(3, 0);
            lb_intro.Name = "lb_intro";
            lb_intro.Size = new Size(394, 47);
            lb_intro.TabIndex = 0;
            lb_intro.Text = "Zvolte si funkci:";
            lb_intro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(bt_pozvanky, 0, 0);
            tableLayoutPanel3.Controls.Add(bt_pripojeni, 1, 0);
            tableLayoutPanel3.Location = new Point(12, 180);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(410, 50);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // bt_pozvanky
            // 
            bt_pozvanky.Location = new Point(3, 3);
            bt_pozvanky.Name = "bt_pozvanky";
            bt_pozvanky.Size = new Size(199, 44);
            bt_pozvanky.TabIndex = 0;
            bt_pozvanky.Text = "Vytvoř pozvánky na VP";
            bt_pozvanky.UseVisualStyleBackColor = true;
            bt_pozvanky.Click += bt_pozvanky_Click_1;
            // 
            // bt_pripojeni
            // 
            bt_pripojeni.Location = new Point(208, 3);
            bt_pripojeni.Name = "bt_pripojeni";
            bt_pripojeni.Size = new Size(199, 44);
            bt_pripojeni.TabIndex = 1;
            bt_pripojeni.Text = "Vytvoř pozvánku pro připojení";
            bt_pripojeni.UseVisualStyleBackColor = true;
            bt_pripojeni.Click += bt_pripojeni_Click_1;
            // 
            // WinForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(434, 411);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lb_email);
            Controls.Add(lb_version);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(450, 450);
            MinimumSize = new Size(450, 450);
            Name = "WinForm1";
            Text = "Helper2";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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