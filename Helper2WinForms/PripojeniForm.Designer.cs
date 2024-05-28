namespace Helper2WinForms
{
    partial class PripojeniForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PripojeniForm));
            tableLayoutPanel1 = new TableLayoutPanel();
            btn_pripojeniZprac = new Button();
            btn_pripOtevriVystup = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btn_pripojeniKOdkaz = new Button();
            label1 = new Label();
            label2 = new Label();
            lab_inst_pripojeni = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label3 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.8091621F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.1908379F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 258F));
            tableLayoutPanel1.Controls.Add(btn_pripojeniZprac, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_pripOtevriVystup, 2, 0);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(710, 51);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btn_pripojeniZprac
            // 
            btn_pripojeniZprac.Location = new Point(3, 3);
            btn_pripojeniZprac.Name = "btn_pripojeniZprac";
            btn_pripojeniZprac.Size = new Size(219, 45);
            btn_pripojeniZprac.TabIndex = 0;
            btn_pripojeniZprac.Text = "Vytvoř výstup";
            btn_pripojeniZprac.UseVisualStyleBackColor = true;
            btn_pripojeniZprac.Click += btn_pripojeniZprac_Click;
            // 
            // btn_pripOtevriVystup
            // 
            btn_pripOtevriVystup.Location = new Point(454, 3);
            btn_pripOtevriVystup.Name = "btn_pripOtevriVystup";
            btn_pripOtevriVystup.Size = new Size(253, 45);
            btn_pripOtevriVystup.TabIndex = 2;
            btn_pripOtevriVystup.Text = "Otevři výstup";
            btn_pripOtevriVystup.UseVisualStyleBackColor = true;
            btn_pripOtevriVystup.Click += btn_pripOtevriVystup_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 127);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(707, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 193);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(707, 23);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // btn_pripojeniKOdkaz
            // 
            btn_pripojeniKOdkaz.BackColor = SystemColors.ButtonFace;
            btn_pripojeniKOdkaz.Location = new Point(15, 272);
            btn_pripojeniKOdkaz.Name = "btn_pripojeniKOdkaz";
            btn_pripojeniKOdkaz.Size = new Size(704, 27);
            btn_pripojeniKOdkaz.TabIndex = 4;
            btn_pripojeniKOdkaz.Text = "Kontrola";
            btn_pripojeniKOdkaz.UseVisualStyleBackColor = false;
            btn_pripojeniKOdkaz.Click += btn_pripojeniKOdkaz_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 109);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 6;
            label1.Text = "Vložte odkaz na VP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 175);
            label2.Name = "label2";
            label2.Size = new Size(191, 15);
            label2.TabIndex = 7;
            label2.Text = "Vložte odkaz pro připojení - Teams:";
            // 
            // lab_inst_pripojeni
            // 
            lab_inst_pripojeni.AutoSize = true;
            lab_inst_pripojeni.Dock = DockStyle.Fill;
            lab_inst_pripojeni.Location = new Point(3, 0);
            lab_inst_pripojeni.Name = "lab_inst_pripojeni";
            lab_inst_pripojeni.Size = new Size(704, 28);
            lab_inst_pripojeni.TabIndex = 8;
            lab_inst_pripojeni.Text = "Vložte odkaz na VP společně s odkazem pro připojení na Teams";
            lab_inst_pripojeni.TextAlign = ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(lab_inst_pripojeni, 0, 0);
            tableLayoutPanel2.Location = new Point(12, 66);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(710, 28);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(194, 100);
            label3.TabIndex = 8;
            label3.Text = "Vložte odkaz na VP společně s odkazem pro připojení na Teams";
            label3.TextAlign = ContentAlignment.BottomCenter;
            // 
            // PripojeniForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(734, 311);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_pripojeniKOdkaz);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(750, 350);
            MinimumSize = new Size(750, 350);
            Name = "PripojeniForm";
            Text = "Helper2 | Pripojeni";
            Load += PripojeniForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_pripojeniZprac;
        private Button btn_pripOtevriVystup;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btn_pripojeniKOdkaz;
        private Label label1;
        private Label label2;
        private Label lab_inst_pripojeni;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label3;
    }
}