using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Helper2;



namespace Helper2WinForms
{
    public partial class PripojeniForm : Form
    {
        private string url_VP;
        private bool status;

        private Director program;
        private PrevodnikPripojeni prevodnik;

        public PripojeniForm(Director director) //zde přiřadím
        {
            InitializeComponent();
            prevodnik = new PrevodnikPripojeni();
            program = director;
            program.Prevodnik = prevodnik;

            btn_pripojeniZprac.Enabled = false;
            btn_pripOtevriVystup.Enabled = false;
        }

        private async void OdkazLabel(bool status)
        {
            Label temporaryLabel = new Label();

            temporaryLabel.Location = new Point((this.ClientSize.Width - temporaryLabel.Width) / 2, 100);
            temporaryLabel.Width = 200;
            temporaryLabel.Height = 30;
            temporaryLabel.ForeColor = Color.Green;


            if (status)
            {
                temporaryLabel.Text = "Odkazy jsou OK!";
                btn_pripojeniZprac.Enabled = true;

            }
            else
            {
                temporaryLabel.ForeColor = Color.Red;
                temporaryLabel.Text = "Chyba! Zadal jsi oba odkazy?";
            }

            this.Controls.Add(temporaryLabel);

            await Task.Delay(1000);

            this.Controls.Remove(temporaryLabel);
        }

        public void OdkazTeams(string url) //přesunout od formuláře
        {
            try
            {
                prevodnik.odkazTeams = url;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async void KontrolaOdkazu(string url)
        {

            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(prevodnik.odkazTeams))
            {
                status = await prevodnik.VyzkousejAdresu(url);
                OdkazLabel(status);
            }

            else
            {
                status = false;
                MessageBox.Show("Nevložili jste všechny odkazy!", "Informace - Odkaz!");
                OdkazLabel(status);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            url_VP = textBox1.Text;

        }

        private void btn_pripojeniKOdkaz_Click(object sender, EventArgs e)
        {
            KontrolaOdkazu(url_VP);

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OdkazTeams(textBox2.Text);
        }




        private async void btn_pripojeniZprac_Click(object sender, EventArgs e)
        {
            try
            {
                await program.VygenerujPozvanku(url_VP);
                MessageBox.Show("Výstup byl úspěšně vytvořen!", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_pripOtevriVystup.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při generování pozvánek: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_pripOtevriVystup_Click(object sender, EventArgs e)
        {
            string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output_pripojeni.html");

            if (File.Exists(outputFilePath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = outputFilePath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Soubor neexistuje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PripojeniForm_Load(object sender, EventArgs e)
        {

        }
    }
}
