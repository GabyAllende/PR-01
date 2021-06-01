using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_01
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btn_openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog loader = new OpenFileDialog();
            DialogResult locRes = loader.ShowDialog();
            if (locRes == DialogResult.OK)
                load(loader.FileName);
        }
        private void load(string file)
        {
            if (System.IO.Path.GetExtension(file).Equals(".bros"))
            {

                Console.WriteLine(file);
                Form1 myForm1 = new Form1(file);
                myForm1.ShowDialog();
                
            }
            else
                MessageBox.Show("Unrecognized File");
        }

        private void btn_newfile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saver = new SaveFileDialog();
            DialogResult LocRes = saver.ShowDialog();
            string file="";
            if (LocRes == DialogResult.OK)
            {
                file = saver.FileName + ".bros";
                string[] temp = { "" }; 
                System.IO.File.WriteAllLines(file, temp);
                Form1 myForm1 = new Form1(file);
                myForm1.ShowDialog();
            }
                
           
        }
    }
}
