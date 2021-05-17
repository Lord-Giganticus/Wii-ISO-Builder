using System;
using System.Drawing;
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
                Classes.Manager.ExtractRecourse.ViaBytes("wit.exe",Properties.Resources.wit);
            }
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var host = new Form();

            host.Load += (x, y) =>
            {
                var main = new Main();
                Rectangle? bounds = null;
                while (main != null)
                {
                    var f = main;
                    main = null;

                    f.Load += (x2, y2) =>
                    {
                        if (bounds != null)
                            f.SetBounds(bounds.Value.X, bounds.Value.Y, bounds.Value.Width, bounds.Value.Height);
                    };

                    f.Shown += (x2, y2) => f.TopLevel = true;

                    f.ShowDialog(host);
                    bounds = f.DesktopBounds;
                }
                host.Close();
            };

            Application.Run(host);
        }
    }
}
