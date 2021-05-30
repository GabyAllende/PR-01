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

namespace PR_01
{
    public partial class Form1 : Form
    {
        
        private string[] contents;
        private string myFile;
        
        public Form1(string filename)
        {
            this.myFile = filename;
            this.contents = System.IO.File.ReadAllLines(this.myFile);
            InitializeComponent();
            rtxt_codigo.Lines = contents;
        }
        
      
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            contents = rtxt_codigo.Lines;
        }

       

      

        private void btn_save_Click_1(object sender, EventArgs e)
        {
           
            System.IO.File.WriteAllLines(this.myFile, this.contents);
            MessageBox.Show("Se guardaron los cambios correctamente", "GUARDADO CORRECTAMENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
