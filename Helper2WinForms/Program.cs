using System.IO;

namespace Helper2WinForms
{
    internal static class Program
    {
        //Signle-Threaded Apartment - vyu�it� pro aplikace  GUI v .NET - jedn� se o po�adavek WinForms
        [STAThread]

        //Vstupn� bod programu
        static void Main()
      {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Vytvo�en� nov�ho vl�kna pro b�h WinFormu
            Thread t = new Thread(() =>
            {
                Application.Run(new WinForm1());
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }
    }
}