using System;
using System.IO;
using System.Windows.Forms;

namespace ISO_Builder
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists("wit.exe"))
            {
                Classes.Manager.ExtractRecourse extract = new Classes.Manager.ExtractRecourse();
                extract.ViaBytes("wit.exe",Properties.Resources.wit);
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
