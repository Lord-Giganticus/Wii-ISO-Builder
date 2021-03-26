using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ISO_Builder
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void AboutMenu_Click(object sender, EventArgs e)
        {
            GUI.AboutBox aboutBox = new GUI.AboutBox();
            aboutBox.BackColor = BackColor;
            aboutBox.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Title = "Search for a Wii/GC game",
                Multiselect = false,
                Filter = "WIT Image Formats (*.ico;*.wbfs)|*.ico;*.wbfs|ico file (*.iso)|*.iso|wbfs file (*.wbfs)|*.wbfs|All files (*.*)|*.*",
                CheckFileExists = true,
                FilterIndex = 1,
                InitialDirectory = Directory.GetCurrentDirectory()
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Title = "Search for Patch.zip",
                Multiselect = false,
                Filter = "zip file (*.zip)|*.zip|All files (*.*)|*.*",
                FilterIndex = 1,
                InitialDirectory = Directory.GetCurrentDirectory(),
                FileName = "Patch.zip"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = open.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Classes.Builder builder = new Classes.Builder();
            SaveFileDialog save = new SaveFileDialog {
                Title = "Save the new Wii Image",
                Filter = "WIT Image Formats (*.iso;*.wbfs)|*.iso;*.wbfs|iso file (*.iso)|*.iso|wbfs file (*.wbfs)|*.wbfs|All files (*.*)|*.*",
                FilterIndex = 1,
                InitialDirectory = Directory.GetCurrentDirectory(),
                FileName = Path.GetFileNameWithoutExtension(textBox1.Text),
                DefaultExt = ".wbfs"
            };
            if (save.ShowDialog() == DialogResult.OK)
            {
                string ext = "";
                if (save.FileName.EndsWith(save.DefaultExt))
                {
                    ext = Classes.StringExtension.GetLast(save.FileName, 5);
                } else if (save.FileName.EndsWith(".iso"))
                {
                    ext = Classes.StringExtension.GetLast(save.FileName, 4);
                }
                builder.Build(textBox1.Text, textBox2.Text, ext, save.FileName);
                MessageBox.Show("Complete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo process1 = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/c wit ID6 \""+textBox1.Text + "\" > ID.txt"
                };
                process.StartInfo = process1;
                process.Start();
                process.WaitForExit();
            }
            var ID = File.ReadAllText("ID.txt");
            File.Delete("ID.txt");
            if (!string.IsNullOrEmpty(ID))
            {
                Properties.Settings.Default.LastID = ID;
                Properties.Settings.Default.Save();
            }
            Riivolution_XML_Generator.Riiv riiv = new Riivolution_XML_Generator.Riiv(Properties.Settings.Default.LastID, Path.GetFileNameWithoutExtension(textBox1.Text));
            riiv.BackColor = BackColor;
            riiv.ShowDialog();
        }

        private void ThemeMenu_Click(object sender, EventArgs e)
        {
            if (BackColor == SystemColors.Control)
            {
                BackColor = SystemColors.ControlDarkDark;
                menuStrip1.BackColor = SystemColors.ControlDarkDark;
            } else if (BackColor == SystemColors.ControlDarkDark)
            {
                BackColor = SystemColors.Control;
                menuStrip1.BackColor = SystemColors.Control;
            } else
            {
                BackColor = SystemColors.Control;
                menuStrip1.BackColor = SystemColors.Control;
            }
        }


        private void RngThemeMenu_Click(object sender, EventArgs e)
        {
            Classes.Color color = new Classes.Color();
            BackColor = color.RandomColor;
            menuStrip1.BackColor = BackColor;
        }
    }
}
