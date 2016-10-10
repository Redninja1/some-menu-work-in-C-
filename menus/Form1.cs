using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            string Saved_File = "";
            saveFD.InitialDirectory = "C:";
            saveFD.Title = "Save a File";
            saveFD.FileName = "";

            saveFD.Filter = "Text Files|*.Txt|All Files|*.*";

            if (saveFD.ShowDialog()!=DialogResult.Cancel)

            {
                Saved_File = saveFD.FileName;
                richTextBox1.SaveFile(Saved_File,RichTextBoxStreamType.PlainText);

            }
        }

        private void mnuQuit_Click(object sender, EventArgs e)
       
        {
            
            MessageBox.Show("are you sure you wwant to quit?");
              if (MessageBox.Show("Really quit?", "Exit", MessageBoxButtons.OKCancel)==DialogResult.OK)
              {
                  Application.Exit();  
              }
            
        }
 

        private void mnuCut_Click(object sender, EventArgs e)
        
        {
            string someText;
            if (textBox1.SelectedText != "")
            {
                someText = textBox1.SelectedText;
                MessageBox.Show(someText);
                textBox1.Cut();
            }
            else if (textBox2.SelectedText != "")
            {
                someText = textBox2.SelectedText;
                MessageBox.Show(someText);
                textBox2.Cut();
            }
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            if (textBox1.CanUndo == true)
            {

                textBox1.Undo();
                textBox1.ClearUndo();
            }
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Copy();
            }
            else if (textBox2.SelectionLength > 0)
            {
                textBox2.Copy();
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                textBox2.Paste();
                textBox1.Paste();
                Clipboard.Clear();
            }
        }
        
        private void mnuVeiwTextBoxes_Click(object sender, EventArgs e)
        {

            mnuVeiwTextboxes.Checked = !mnuVeiwTextboxes.Checked;

            if (mnuVeiwTextboxes.Checked)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void mnuVeiwImagies_Click(object sender, EventArgs e)
        {
            string chosen_file = "";
            

            openFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFD.Title = "Insert an Imagie";
            openFD.FileName = "";
            openFD.Filter = "JPEG imagies|*.jpg|GIF imagies|*.gif|BITMAPS|*.bmp";


            if (openFD.ShowDialog() != DialogResult.Cancel)
            {
                chosen_file = openFD.FileName;
                pictureBox1.Image = Image.FromFile(chosen_file);
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string chosen_file = "";

            openFD.InitialDirectory = "C:";
            openFD.Title = "Open a Text File";
            openFD.FileName = "";
            openFD.Filter = "Text Files|*.txt|Word Documents|*.DOC";

            if (openFD.ShowDialog() != DialogResult.Cancel) 
            {
                chosen_file = openFD.FileName;
                richTextBox1.LoadFile(chosen_file, RichTextBoxStreamType.PlainText);
            }

        }
    }
}
