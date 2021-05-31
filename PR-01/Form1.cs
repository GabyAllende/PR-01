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

        private Tablas tabla = new Tablas();
        
        public Form1(string filename)
        {
            this.myFile = filename;
            this.contents = System.IO.File.ReadAllLines(this.myFile);
            InitializeComponent();
            rtxt_codigo.Lines = contents;
            lb_numbers.Font = new Font(rtxt_codigo.Font.FontFamily, rtxt_codigo.Font.Size);
            updateNumberLabel();
        }
        
      
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

      

        private void btn_save_Click_1(object sender, EventArgs e)
        {
           
            System.IO.File.WriteAllLines(this.myFile, this.contents);
            MessageBox.Show("Se guardaron los cambios correctamente", "GUARDADO CORRECTAMENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateNumberLabel()
        {
            
            //we get index of first visible char and number of first visible line
            Point pos = new Point(0, 0);
            int firstIndex = rtxt_codigo.GetCharIndexFromPosition(pos);
            int firstLine = rtxt_codigo.GetLineFromCharIndex(firstIndex);

            //now we get index of last visible char and number of last visible line
            pos.X = ClientRectangle.Width;
            pos.Y = ClientRectangle.Height;
            int lastIndex = rtxt_codigo.GetCharIndexFromPosition(pos);
            int lastLine = rtxt_codigo.GetLineFromCharIndex(lastIndex);

            //this is point position of last visible char, we'll use its Y value for calculating numberLabel size
            pos = rtxt_codigo.GetPositionFromCharIndex(lastIndex);
            

            //finally, renumber label
            lb_numbers.Text = "";
            
            for (int i = firstLine; i <= lastLine + 1; i++)
            {
                lb_numbers.Text += i + 1 + "\n";
            }

        }

        private void rtxt_codigo_Resize(object sender, EventArgs e)
        {
            rtxt_codigo_VScroll(null, null);
        }

        private void rtxt_codigo_VScroll(object sender, EventArgs e)
        {
            //move location of numberLabel for amount of pixels caused by scrollbar
            int d = rtxt_codigo.GetPositionFromCharIndex(0).Y % (rtxt_codigo.Font.Height + 1);
            lb_numbers.Location = new Point(0, d);

            updateNumberLabel();
        }

        private void rtxt_codigo_FontChanged(object sender, EventArgs e)
        {
            updateNumberLabel();
            rtxt_codigo_VScroll(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void rtxt_codigo_TextChanged(object sender, EventArgs e)
        {
            contents = rtxt_codigo.Lines;
            updateNumberLabel();
        }

        private void print_Click(object sender, EventArgs e)
        {

        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            int cont = 0;
            for (int i  = 0; i< contents.Length; i++) 
            {
                string[] temp = contents[i].Split(' ');
                Color[] color = new Color[temp.Length];
                
                
                for (int j = 0; j < temp.Length; j++) 
                {
                    

                    if (tabla.Reservadas.Contains(temp[j]))
                    {
                        tabla.Simbolos.Add(
                            new Simbolo()
                            {
                                Token = temp[j],
                                Lexema = temp[j],
                                Fila = i,
                                Columna = j
                            }

                            );
                        
                        rtxt_codigo.Select(cont, temp[j].Length);
                        rtxt_codigo.SelectionColor = Color.Indigo;

                    }
                    else 
                    {
                        tabla.Simbolos.Add(
                            new Simbolo()
                            {
                                Token = "Identificador",
                                Lexema = temp[j],
                                Fila = i,
                                Columna = j
                            }

                            );
                       
                        rtxt_codigo.Select(cont, temp[j].Length);
                        rtxt_codigo.SelectionColor = Color.DeepPink;

                    }

                    cont += temp[j].Length+1;
                }
            }
            
            txt_simbolos.Lines = tabla.StringArraySimbolos();
            //rtxt_codigo.= Color.Black;


        }
    }
}
