using System;
using System.Windows.Forms;
using Helper2;

namespace Helper2WinForms
{
    public partial class WinForm1 : Form //Vytvo�it directora
    {
        public Director program;

        public WinForm1()
        {
            InitializeComponent();
            program = new Director();

        }


        private void bt_pozvanky_Click(object sender, EventArgs e)
        {
            using (PozvankaForm pozvankaForm = new PozvankaForm(program))//<- da do konstruktoru directora
            {
                pozvankaForm.ShowDialog();
            }
        }

        private void bt_pripojeni_Click(object sender, EventArgs e)
        {
            using (PripojeniForm pripojeniForm = new PripojeniForm(program))//<- da do konstruktoru directora
            {
                pripojeniForm.ShowDialog();
            }
        }
    }
}