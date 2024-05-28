
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper2;



namespace Helper2WinForms
{
    public partial class PozvankaForm : Form
    {
        private PrevodnikPozvanky prevodnik;
        private Director program;

        List<string> seznamOdkazu;

        private int lastTextBoxBottom = 60;

        public PozvankaForm(Director director)
        {
            InitializeComponent();
            seznamOdkazu = new List<string>();

            prevodnik = new PrevodnikPozvanky();
            program = director;
            program.Prevodnik = prevodnik;

            btn_vytvorVystup.Enabled = false;
            btn_otevriVystup.Enabled = false;

        }

        private void btn_pridejOdkaz_Click(object sender, EventArgs e)
        {
            VytvorNovyOdkazTextBox();
        }

        private void VytvorNovyOdkazTextBox()
        {
            bool status;

            TextBox newTextBox = new TextBox();
            Button newButton = new Button();

            btn_pridejOdkaz.Enabled = false;

            newTextBox.Location = new Point(10, lastTextBoxBottom + 10); // Posunuto dolů o 10 pixelů
            newTextBox.Width = this.ClientSize.Width - 250;
            newTextBox.Height = 20;

            newButton.Location = new Point(newTextBox.Right + 10, lastTextBoxBottom + 10);
            newButton.Width = 150;
            newButton.Height = 24;
            newButton.BackColor = SystemColors.ButtonFace;
            newButton.Text = "Kontrola";

            newButton.Click += async (s, args) => //obsluha událostí
            {

                status = await prevodnik.VyzkousejAdresu(newTextBox.Text);

                OdkazLabel(status, lastTextBoxBottom + 10);

                if (!status)
                {
                    this.Controls.Remove(newButton);
                    this.Controls.Remove(newTextBox);
                    btn_pridejOdkaz.Enabled = true;
                    lastTextBoxBottom = 60;
                }

                if (status)
                {
                    seznamOdkazu.Add(newTextBox.Text);
                    Console.WriteLine(seznamOdkazu.Count);

                    btn_pridejOdkaz.Enabled = true;

                    if (seznamOdkazu.Count > 0)
                    {
                        btn_vytvorVystup.Enabled = true;
                    }
                }

            };

            lastTextBoxBottom = newTextBox.Bottom;

            this.Controls.Add(newTextBox);
            this.Controls.Add(newButton);
        }

        private async void OdkazLabel(bool status, int y)
        {
            Label temporaryLabel = new Label();

            temporaryLabel.Location = new Point((this.ClientSize.Width - temporaryLabel.Width) / 2, y);
            temporaryLabel.Width = 200;
            temporaryLabel.Height = 30;
            temporaryLabel.ForeColor = Color.Green;

            if (status)
            {
                temporaryLabel.Text = "Odkaz je OK!";
            }
            else
            {
                temporaryLabel.ForeColor = Color.Red;
                temporaryLabel.Text = "Chybný odkaz!";
            }

            this.Controls.Add(temporaryLabel);

            await Task.Delay(500);

            this.Controls.Remove(temporaryLabel);
        }

        private async void btn_vytvorVystup_Click(object sender, EventArgs e)
        {
            btn_pridejOdkaz.Enabled = false;

            try
            {

                foreach (string indexer in seznamOdkazu)
                {
                    await program.VygenerujPozvanku(indexer);
                }

                MessageBox.Show("Výstup byl úspěšně vytvořen!", "Informace", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btn_otevriVystup.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při generování pozvánek: {ex.Message}", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_otevriVystup_Click(object sender, EventArgs e)
        {

            string outputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output_pozvanka.html");

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
    }
}
