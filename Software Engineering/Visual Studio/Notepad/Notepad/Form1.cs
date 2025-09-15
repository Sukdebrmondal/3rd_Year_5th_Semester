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
        #region fields
        private bool isFileAlreadySaved;
        private bool isFileDirty;
        private string currOpenFileName;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// About Notepad menu code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad Application\nVersion 1.0\n© 2024 Your Company Sukdeb", "About Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFileDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to save your changes?", "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (result)
                {
                    case DialogResult.Yes:
                        // User chose to save changes
                        SaveFileMenu();
                        
                        break;
                    case DialogResult.No:
                        // User chose not to save changes
                        
                        break;
                }

            
            }
            ClearScreen();
            isFileAlreadySaved= false;
            currOpenFileName = "";
        }

        /// <summary>
        /// Exit Notepad application code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void exiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Open file menu code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                this.Text = Path.GetFileName(openFileDialog.FileName) + " - Notepad(Create By Sukdeb)";
                isFileAlreadySaved = true;
                isFileDirty = false;
                currOpenFileName = openFileDialog.FileName;

            }
            //this.Text = Path.GetFileName(openFileDialog.FileName) + " - Notepad";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isFileAlreadySaved = false;
            isFileDirty = false;
            currOpenFileName = "";
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich text Format (*.rtf)|*.rtf|pdf (*.pdf)|*.pdf";
            //DialogResult result = saveFileDialog.ShowDialog();  
            //if (result == DialogResult.OK) {
            //    if (string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            //    {
            //        MessageBox.Show("Invalid file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    if(Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
            //    {
            //        richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
            //    }
            //    if(Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
            //    {
            //        richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            //    }
            //    if(Path.GetExtension(saveFileDialog.FileName).ToLower() == ".pdf")
            //    {
            //        MessageBox.Show("PDF files are not supported for saving in this Notepad application.", "Unsupported Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    this.Text = Path.GetFileName(saveFileDialog.FileName) + " - Notepad";
            //}
            SaveFileMenu();
        }

        private void SaveAsFileMenu()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich text Format (*.rtf)|*.rtf|pdf (*.pdf)|*.pdf";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    MessageBox.Show("Invalid file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
                if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".pdf")
                {
                    MessageBox.Show("PDF files are not supported for saving in this Notepad application.", "Unsupported Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Text = Path.GetFileName(saveFileDialog.FileName) + " - Notepad(Create By Sukdeb)";
                isFileAlreadySaved = true;
                isFileDirty = false;
                currOpenFileName = saveFileDialog.FileName;
            }
        }


        private void SaveFileMenu()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich text Format (*.rtf)|*.rtf|pdf (*.pdf)|*.pdf";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(saveFileDialog.FileName))
                {
                    MessageBox.Show("Invalid file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".txt")
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
                if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".rtf")
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                if (Path.GetExtension(saveFileDialog.FileName).ToLower() == ".pdf")
                {
                    MessageBox.Show("PDF files are not supported for saving in this Notepad application.", "Unsupported Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                this.Text = Path.GetFileName(saveFileDialog.FileName) + " - Notepad(Create By Sukdeb)";
                isFileAlreadySaved = true;
                isFileDirty = false;
                currOpenFileName = saveFileDialog.FileName;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (isFileAlreadySaved)
            //{
            //    if (Path.GetExtension(currOpenFileName) == ".rtf")
            //        richTextBox1.SaveFile(currOpenFileName, RichTextBoxStreamType.RichText);
            //    if (Path.GetExtension(currOpenFileName) == ".txt")
            //        richTextBox1.SaveFile(currOpenFileName, RichTextBoxStreamType.PlainText);
            //    isFileDirty = false;
            //}
            //else
            //{
            //    if (isFileDirty)
            //    {

            //        SaveAsFileMenu();
            //    }
            //    else
            //    {
            //        richTextBox1.Clear();
            //        this.Text = "Untitled - Notepad!";
            //        isFileDirty = false;
            //    }

                //}
                SaveAsFileMenu();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            isFileDirty=true;
            undoToolStripMenuItem.Enabled = true;
        }

        //clear screen method
        private void ClearScreen()
        {
            richTextBox1.Clear();
            this.Text = "Untitled - Notepad(Create By Sukdeb)";
            isFileDirty = false;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = true;
        }
    }
}
