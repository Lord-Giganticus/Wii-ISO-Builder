using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO.Compression;

namespace ISO_Builder.Classes
{
    public class Builder
    {
        public void Build(string file, string zip, string extension)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo process1 = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/c wit extract "+file+" "+ Path.GetFileNameWithoutExtension(file)
                };
                process.StartInfo = process1;
                process.Start();
                process.WaitForExit();
            }
            ZipFile.ExtractToDirectory(zip, Directory.GetCurrentDirectory() + "/" + Path.GetFileNameWithoutExtension(file) + "/files");
            using (Process process = new Process())
            {
                ProcessStartInfo process1 = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/c wit copy "+Path.GetFileNameWithoutExtension(file) + " " + Path.GetFileNameWithoutExtension(file) + extension
                };
                process.StartInfo = process1;
                process.Start();
                process.WaitForExit();
            }
        }
    }
}
