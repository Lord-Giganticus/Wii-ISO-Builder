using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using Wii_U_Homebrew_Installer_GUI.Classes;

namespace ISO_Builder.Classes
{
    public class Builder
    {
        public static void Build(string file, string zip, string extension, string output)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo process1 = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/c wit extract \"{file}\" \"{Path.GetFileNameWithoutExtension(file)}\""
                };
                process.StartInfo = process1;
                process.Start();
                process.WaitForExit();
            }
            ZipFile.ExtractToDirectory(zip, Directory.GetCurrentDirectory() + "/files");
            Copier.DirectoryCopy("files",Path.GetFileNameWithoutExtension(file) + "/files",true, true);
            using (Process process = new Process())
            {
                ProcessStartInfo process1 = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = $"/c wit copy \"{Path.GetFileNameWithoutExtension(file)}\" \"{Path.GetFileNameWithoutExtension(file)}{extension}\" && rd /s /q files && rd /s /q \"{Path.GetFileNameWithoutExtension(file)}\""
                };
                process.StartInfo = process1;
                process.Start();
                process.WaitForExit();
            }
            File.Move($"{Path.GetFileNameWithoutExtension(file)}{extension}", output);
        }
    }
}
