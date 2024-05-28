using System.IO;

namespace Helper2WinForms
{
    internal static class Program
    {
        //Signle-Threaded Apartment - využití pro aplikace  GUI v .NET - jedná se o požadavek WinForms
        [STAThread]

        //Vstupní bod programu
        static void Main()
      {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Vytvoøení nového vlákna pro bìh WinFormu
            Thread t = new Thread(() =>
            {
                Application.Run(new WinForm1());
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }
    }
}