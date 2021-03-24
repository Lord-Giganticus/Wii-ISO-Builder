using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            aboutBox.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Title = "Search for a Wii/GC game",
                Multiselect = false,
                Filter = "Wii Image Formats (*.ico,*.ciso,*.wdi,*.wdf,*.wia,*.wbfs)|*.ico;*.ciso;*.wdi;*.wdf;*.wia;*.wbfs|ico file (*.iso)|*.iso|ciso file (*.ciso)|*.ciso|wbi file (*.wbi)|*.wbi|wdf file (*.wdf)|*.wdf|wia file (*.wia)|*.wia|wbfs file (*.wbfs)|*.wbfs|All files (*.*)|*.*",
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
            if (checkBox1.Checked)
            {
                builder.Build(textBox1.Text, textBox2.Text, ".iso");
            } else if (checkBox2.Checked)
            {
                builder.Build(textBox1.Text, textBox2.Text, ".ciso");
            } else if (checkBox3.Checked)
            {
                builder.Build(textBox1.Text, textBox2.Text, ".wbi");
            } else if (checkBox4.Checked)
            {
                builder.Build(textBox1.Text, textBox2.Text, ".wdf");
            } else if (checkBox5.Checked)
            {
                builder.Build(textBox1.Text, textBox2.Text, ".wia");
            } else if (checkBox6.Checked)
            {
                builder.Build(textBox1.Text, textBox2.Text, ".wbfs");
            } else
            {
                return;
            }
            MessageBox.Show("Complete!","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            return;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Riivolution_XML_Generator.Riiv riiv = new Riivolution_XML_Generator.Riiv
            {
                folder = textBox2.Text
            };
            riiv.ShowDialog();
        }
    }
}
