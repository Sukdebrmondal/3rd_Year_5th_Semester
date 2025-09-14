using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad Application\nVersion 1.0\n© 2024 Your Company Sukdeb", "About Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void exiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich text Format (*.rtf)|*.rtf|pdf (*.pdf)|*.pdf";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    MessageBox.Show("Invalid file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(Path.GetExtension(openFileDialog.FileName).ToLower() == ".txt")
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
                if(Path.GetExtension(openFileDialog.FileName).ToLower() == ".rtf")
                {
                    richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                if(Path.GetExtension(openFileDialog.FileName).ToLower() == ".pdf")
                {
                    MessageBox.Show("PDF files are not supported for viewing in this Notepad application.", "Unsupported Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            this.Text = Path.GetFileName(openFileDialog.FileName) + " - Notepad";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
