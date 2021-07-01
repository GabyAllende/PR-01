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
    public partial class Notepad : Form
    {

        private string[] contents;
        private string myFile;

        private Tablas tabla = new Tablas();
        private Metodos metodos = new Metodos();
        //private MetodosSintactico metodosS = new MetodosSintactico();



        List<List<(string, List<string>, int)>> estados { get; set; }

        

        List<List<(string, string)>> caminos { get; set; }



        public Notepad(string filename)
        {
            this.myFile = filename;
            this.contents = System.IO.File.ReadAllLines(this.myFile);
            InitializeComponent();
            rtxt_codigo.Lines = contents;
            lb_numbers.Font = new Font(rtxt_codigo.Font.FontFamily, rtxt_codigo.Font.Size);

            //primero crear el automata y los caminos
            (caminos, estados) = MetodosSintactico.automataSLR(MetodosSintactico.terminales, MetodosSintactico.Noterminales, MetodosSintactico.gramatica2 );
            
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
            




            tabla.Simbolos.Clear();
            int cont = 0;

            List<string> words = new List<string>();


            for (int i = 0; i < contents.Length; i++)
            {
                
                //string[] temp2 = metodos.SepararLineas(contents[i]);
                string[] temp = metodos.charByChar2(contents[i]);
                Console.WriteLine($"Fila {i+1}:");
                Console.WriteLine("VERSION ANDY: [{0}]", string.Join(",", temp));
                //Console.WriteLine("VERSION GABY-TEFF: [{0}]", string.Join(",", temp2));

                List<string> aux = temp.ToList();
                aux.RemoveAll(item => item == "\t" || item.Equals("") || item.Equals("\n"));

                words.AddRange(aux);

                for (int j = 0; j < temp.Length; j++)
                {

                   

                    if (!string.IsNullOrEmpty(temp[j]) && !string.IsNullOrWhiteSpace(temp[j]))
         
                    {
                        if (tabla.Reservadas.Contains(temp[j]))
                        {
                            tabla.Simbolos.Add(
                                new Simbolo()
                                {
                                    Token = temp[j],
                                    Lexema = temp[j],
                                    Fila = i + 1,
                                    Columna = j + 1
                                }

                                );

                            rtxt_codigo.Select(cont, temp[j].Length);
                            rtxt_codigo.SelectionColor = Color.SpringGreen;

                        }
                        else
                        {
                            if (metodos.validarIdentificadorCompleto(temp[j]))
                            {


                                if (metodos.validarSigno(temp[j]))
                                {
                                    tabla.Simbolos.Add(
                                    new Simbolo()
                                    {
                                        Token = temp[j],
                                        Lexema = temp[j],
                                        Fila = i + 1,
                                        Columna = j + 1
                                    }

                                    );
                                }
                                else if (metodos.validarNumeros(temp[j]))
                                {
                                    tabla.Simbolos.Add(
                                    new Simbolo()
                                    {
                                        Token = "Numeros",
                                        Lexema = temp[j],
                                        Fila = i + 1,
                                        Columna = j + 1
                                    }

                                    );

                                }
                                else if (metodos.validarChar(temp[j]))
                                {
                                    tabla.Simbolos.Add(
                                    new Simbolo()
                                    {
                                        Token = "Crash",
                                        Lexema = temp[j],
                                        Fila = i + 1,
                                        Columna = j + 1
                                    }

                                    );

                                }
                                else if (metodos.validarString(temp[j]))
                                {
                                    tabla.Simbolos.Add(
                                    new Simbolo()
                                    {
                                        Token = "Sting",
                                        Lexema = temp[j],
                                        Fila = i + 1,
                                        Columna = j + 1
                                    }

                                    );

                                }
                                else
                                {
                                    tabla.Simbolos.Add(
                                    new Simbolo()
                                    {
                                        Token = "Identificador",
                                        Lexema = temp[j],
                                        Fila = i + 1,
                                        Columna = j + 1
                                    }

                                    );
                                }

                                rtxt_codigo.Select(cont, temp[j].Length);
                                rtxt_codigo.SelectionColor = Color.Gold;
                            }
                            else
                            {
                                tabla.Simbolos.Add(
                                new Simbolo()
                                {
                                    Token = "Identificador",
                                    Lexema = temp[j],
                                    Fila = i + 1,
                                    Columna = j + 1,
                                    Error = true
                                }

                                );
                                rtxt_codigo.Select(cont, temp[j].Length);
                                rtxt_codigo.SelectionColor = Color.Red;
                            }


                        }


                        

                    }

                    else 
                    {

                        cont += 1;
                    }

                    if (temp[j] == "\t")
                    {
                        Console.WriteLine("ESSS TAB ");
                       

                    }
                    else
                    {
                        cont += temp[j].Length;
                    }
                    



                }




              
                cont += 1;





                





            }

            string megaString = String.Join(" ", words);
            (bool, List<(int, string)>, List<(int, string)>) respuesta = MetodosSintactico.procesarCadena(megaString, caminos);

            if (respuesta.Item1)
            {
                Console.WriteLine("ESTAAA CORRRECTO");

            }
            else 
            {
                Console.WriteLine("ESTAAA MAAL");
            }

            Console.WriteLine("IMPRIMIENDO CAMINOOS");
            foreach (var item in respuesta.Item2)
            {
                Console.WriteLine($"[{item.Item1} - {item.Item2}]");
            
            }

            Console.WriteLine("IMPRIMIENDO EQUIVALENCIAS");
            foreach (var item in respuesta.Item3)
            {
                Console.WriteLine($"[{item.Item1} - {item.Item2}]");

            }


            txt_simbolos.Lines = tabla.StringArraySimbolos();
        }
    }
}
