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

            //MetodosSintactico.printPrimerosSiguientes();
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


            rtxt_codigo.Select(0, rtxt_codigo.Text.Length);
            rtxt_codigo.SelectionColor = Color.White;


            tabla.Simbolos.Clear();
            int cont = 0;

            List<string> words = new List<string>();

            List<(string, string, string)> pendientes = new List<(string, string, string)>();
            for (int i = 0; i < contents.Length; i++)
            {
                
                //string[] temp2 = metodos.SepararLineas(contents[i]);
                string[] temp = metodos.charByChar2(contents[i]);
                //Console.WriteLine($"Fila {i+1}:");
                //Console.WriteLine("VERSION ANDY: [{0}]", string.Join(",", temp));
                //Console.WriteLine("VERSION GABY-TEFF: [{0}]", string.Join(",", temp2));

                List<string> aux = temp.ToList();
                aux.RemoveAll(item => item == "\t" || item.Equals("") || item.Equals("\n"));

                //words.AddRange(aux);

                
                string reserva = null;
                bool declaracion = false;
                bool asignacion = false;


                (string, string, string) intermedio = (null, null, null);

                for (int j = 0; j < temp.Length; j++)
                {

                    void auxBreak()
                    {

                        int a = cont;

                        for (int y = j; y < temp.Length; y++)
                        {
                            //Console.WriteLine("palabra en gold:{0}", temp[y]);
                            //Console.WriteLine("cont:{0}", cont);
                            rtxt_codigo.Select(cont, temp[y].Length);
                            rtxt_codigo.SelectionColor = Color.Gold;
                            if (string.IsNullOrEmpty(temp[y]) || string.IsNullOrWhiteSpace(temp[y]))
                            {
                                cont++;
                            }
                            if (temp[y] == "\t")
                            {
                                //Console.WriteLine("ESSS TAB ");


                            }
                            else
                            {
                                cont += temp[y].Length;
                            }

                        }
                        rtxt_codigo.Select(a, temp[j].Length);
                        rtxt_codigo.SelectionColor = Color.Blue;



                    }
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
                            words.Add(temp[j]);

                            // si es palabra de tipo
                            if(metodos.validarTipo(temp[j]))
                            {
                                intermedio.Item1 = temp[j];

                                
                                declaracion = true;
                            }



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

                                    words.Add(temp[j]);

                                    if (reserva != null)
                                    {
                                        //solo me interesa para asignar
                                        if (temp[j] == "->") { asignacion = true; }

                                        else { reserva = null; }
                                    }





                                }
                                else if (metodos.validarNumerosEnteros(temp[j]))
                                {
                                    tabla.Simbolos.Add(
                                    new Simbolo()
                                    {
                                        Token = "num_entero",
                                        Lexema = temp[j],
                                        Fila = i + 1,
                                        Columna = j + 1
                                    }

                                    );
                                    words.Add("num_entero");

                                    if (asignacion)
                                    {
                                        //int index = pendientes.FindIndex(item => item.Item2 == pendiente);
                                        int index = metodos.buscarindexItem2(pendientes, reserva);
                                        //revisar luego
                                        (string, string, string) auxiliar = (pendientes[index].Item1, pendientes[index].Item2, temp[j]);
                                        if (auxiliar.Item1 == "zap")
                                        {

                                            pendientes.RemoveAt(index);
                                            pendientes.Add(auxiliar);
                                            asignacion = false;
                                            reserva = null;


                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR DE TIPO");

                                            auxBreak();
                                            break;
                                        }



                                    }

                                }
                                else if (metodos.validarNumerosDecimales(temp[j]))
                                {
                                    tabla.Simbolos.Add(
                                    new Simbolo()
                                    {
                                        Token = "num_real",
                                        Lexema = temp[j],
                                        Fila = i + 1,
                                        Columna = j + 1
                                    }

                                    );
                                    words.Add("num_real");


                                    if (asignacion)
                                    {
                                        //int index = pendientes.FindIndex(item => item.Item2 == pendiente);
                                        int index = metodos.buscarindexItem2(pendientes, reserva);
                                        //revisar luego
                                        (string, string, string) auxiliar = (pendientes[index].Item1, pendientes[index].Item2, temp[j]);
                                        if (auxiliar.Item1 == "smash")
                                        {

                                            pendientes.RemoveAt(index);
                                            pendientes.Add(auxiliar);
                                            asignacion = false;
                                            reserva = null;
                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR DE TIPO");

                                            auxBreak();
                                           
                                            break;
                                        }




                                    }
                                }
                                else if (metodos.validarChar(temp[j]))
                                {
                                    tabla.Simbolos.Add(
                                    new Simbolo()
                                    {
                                        Token = "val_crash",
                                        Lexema = temp[j],
                                        Fila = i + 1,
                                        Columna = j + 1
                                    }

                                    );
                                    words.Add("val_crash");

                                    if (asignacion)
                                    {
                                        //int index = pendientes.FindIndex(item => item.Item2 == pendiente);
                                        int index = metodos.buscarindexItem2(pendientes, reserva);
                                        //revisar luego
                                        (string, string, string) auxiliar = (pendientes[index].Item1, pendientes[index].Item2, temp[j]);
                                        if (auxiliar.Item1 == "crash")
                                        {

                                            pendientes.RemoveAt(index);
                                            pendientes.Add(auxiliar);
                                            asignacion = false;
                                            reserva = null;

                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR DE TIPO");

                                            auxBreak();
                                           

                                            break;

                                        }

                                    }
                                }
                                else if (metodos.validarString(temp[j]))
                                {
                                    tabla.Simbolos.Add(
                                    new Simbolo()
                                    {
                                        Token = "val_sting",
                                        Lexema = temp[j],
                                        Fila = i + 1,
                                        Columna = j + 1
                                    }

                                    );
                                    words.Add("val_sting");

                                    if (asignacion)
                                    {
                                        //int index = pendientes.FindIndex(item => item.Item2 == pendiente);
                                        int index = metodos.buscarindexItem2(pendientes, reserva);
                                        //revisar luego
                                        (string, string, string) auxiliar = (pendientes[index].Item1, pendientes[index].Item2, temp[j]);
                                        if (auxiliar.Item1 == "sting" )
                                        {

                                            pendientes.RemoveAt(index);
                                            pendientes.Add(auxiliar);
                                            asignacion = false;
                                            reserva = null;

                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR DE TIPO");

                                            auxBreak();
                                            break;

                                        }
                                    }
                                }
                                else if (temp[j] == "true" || temp[j] == "false")
                                {
                                    //validadcion bool
                                    tabla.Simbolos.Add(
                                   new Simbolo()
                                   {
                                       Token = "val_boom",
                                       Lexema = temp[j],
                                       Fila = i + 1,
                                       Columna = j + 1
                                   }

                                   );
                                    words.Add("val_boom");

                                    if (asignacion)
                                    {
                                        //int index = pendientes.FindIndex(item => item.Item2 == pendiente);
                                        int index = metodos.buscarindexItem2(pendientes,reserva);
                                        //revisar luego
                                        (string, string, string) auxiliar = (pendientes[index].Item1, pendientes[index].Item2, temp[j]);
                                        if (auxiliar.Item1 == "boom")
                                        {

                                            pendientes.RemoveAt(index);
                                            pendientes.Add(auxiliar);
                                            asignacion = false;
                                            reserva = null;

                                        }
                                        else
                                        {
                                            Console.WriteLine("ERROR DE TIPO");

                                            auxBreak();
                                            break;
                                        }
                                    }



                                }

                                else
                                {

                                    tabla.Simbolos.Add(
                                        new Simbolo()
                                        {
                                            Token = "identificador",
                                            Lexema = temp[j],
                                            Fila = i + 1,
                                            Columna = j + 1
                                        }

                                    );
                                    if (temp[j] == "e")
                                    {
                                        words.Add("e");
                                    }
                                    else
                                    {
                                        
                                        //words.Add(temp[j]);
                                        // si es estas en proceso de declaracion
                                        if (declaracion)
                                        {

                                            intermedio.Item2 = temp[j];
                                            declaracion = false;
                                            pendientes.Add(intermedio);
                                            //Console.WriteLine("AGREGADO A PENDIENTES");

                                            //Console.ForegroundColor = ConsoleColor.Cyan;
                                            //Console.WriteLine("Imprimiento");
                                            //foreach (var it in pendientes)
                                            //{
                                            //    Console.WriteLine($"[{it.Item1}  - {it.Item2}  - {it.Item3}]");
                                            //}
                                            //Console.ForegroundColor = ConsoleColor.White;



                                            words.Add("identificador");

                                        }
                                        else if (asignacion)
                                        {

                                            //List<(string, string, string)> respuestas = pendientes.FindAll(item => item.Item2 == temp[j]);
                                            List<(string, string, string)> respuestas = metodos.buscarItem2(pendientes, temp[j]);
                                            //si es mas de uno
                                            if (respuestas.Count > 1)
                                            {
                                                
                                                Console.WriteLine("Doble asignacion");


                                                auxBreak();
                                                break;

                                            }
                                            else if (respuestas.Count == 0)
                                            {//si existe
                                                Console.WriteLine("No existe");

                                                auxBreak();
                                                break;
                                            }
                                            else if (respuestas[0].Item3 == null)
                                            {
                                                Console.WriteLine("NO esta asignando");

                                                auxBreak();
                                                break;

                                            }
                                            else 
                                            {

                                               
                                                string aux2 = "";
                                                switch (respuestas[0].Item1)
                                                {
                                                    case "zap":
                                                        aux2 = "num_entero";
                                                        break;
                                                    case "crash":
                                                        aux2 = "val_crash";
                                                        break;
                                                    case "boom":
                                                        aux2 = "val_boom";
                                                        break;
                                                    case "sting":
                                                        aux2 = "val_sting";
                                                        break;
                                                    case "smash":
                                                        aux2 = "num_real";
                                                        break;
                                                    default:
                                                        aux2 = "identificador";
                                                        break;

                                                }

                                                words.Add(aux2);



                                                //int index = pendientes.FindIndex(item => item.Item2 == reserva);
                                                int index = metodos.buscarindexItem2(pendientes, reserva);
                                                



                                                //revisar luego
                                                (string, string, string) auxiliar = (pendientes[index].Item1, pendientes[index].Item2, respuestas[0].Item3);
                                                
                                                    pendientes.RemoveAt(index);
                                                    pendientes.Add(auxiliar);
                                                    asignacion = false;
                                                    reserva = null;

                                                
                                            }
                                            
                                        }
                                        else
                                        {
                                            //buscamos en pendientes 
                                            List<(string, string, string)> respuestas = metodos.buscarItem2(pendientes, temp[j]);
                                            //List<(string, string, string)> answer = pendientes.FindAll(item => item.Item2 == temp[j]);
                                            //si hay mas de uno, no funciona
                                            if (respuestas.Count > 1)
                                            {

                                                Console.WriteLine("Doble asignacion");


                                          
                                                auxBreak();
                                                break;

                                            }
                                            else if (respuestas.Count == 0)
                                            {//si existe
                                                Console.WriteLine("No existe");

                                                auxBreak();
                                                break;
                                            }
                                            else if (respuestas[0].Item3 == null)
                                            {
                                                Console.WriteLine("NO esta asignando");

                                                //rtxt_codigo.Select(cont, temp[j].Length);
                                                //rtxt_codigo.SelectionColor = Color.Blue;
                                                //break;
                                                words.Add("identificador");
                                                reserva = temp[j];
                                            }
                                            else
                                            {
                                                string aux2 = "";
                                                switch (respuestas[0].Item1)
                                                {
                                                    case "zap":
                                                        aux2 = "num_entero";
                                                        break;
                                                    case "crash":
                                                        aux2 = "val_crash";
                                                        break;
                                                    case "boom":
                                                        aux2 = "val_boom";
                                                        break;
                                                    case "sting":
                                                        aux2 = "val_sting";
                                                        break;
                                                    case "smash":
                                                        aux2 = "num_real";
                                                        break;
                                                    default:
                                                        aux2 = "identificador";
                                                        break;

                                                }

                                                words.Add(aux2);

                                                reserva = temp[j];


                                            }



                                        }

                                    }

                                    
                                }
                                rtxt_codigo.Select(cont, temp[j].Length);
                                rtxt_codigo.SelectionColor = Color.Gold;
                            }
                            else
                            {
                                //ESS UN ERROR , CONSIDERAR LUEGO
                                tabla.Simbolos.Add(
                                new Simbolo()
                                {
                                    Token = "identificador",
                                    Lexema = temp[j],
                                    Fila = i + 1,
                                    Columna = j + 1,
                                    Error = true
                                }

                                );
                                words.Add("#Error");

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
                        //Console.WriteLine("ESSS TAB ");
                       

                    }
                    else
                    {
                        cont += temp[j].Length;
                    }
                    



                }


              
                cont += 1;





            }




            //Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("Imprimiento");
            //foreach (var it in pendientes)
            //{
            //    Console.WriteLine($"[{it.Item1}  - {it.Item2}  - {it.Item3}]");
            //}
            //Console.ForegroundColor = ConsoleColor.White;

            //Console.WriteLine("VERSION WORDS ANTES: [{0}]", string.Join(",", words));


            //for (int i = 0; i < words.Count; i++)
            //{
            //    //(string, string, string) aux = new(string, string, string);
            //    if (!MetodosSintactico.terminales.Contains(words[i]))
            //    {
            //        //es varaible
            //        List<(string, string, string)> aux = metodos.buscarItem2(pendientes, words[i]);
            //        string aux2 = "";
            //        switch (aux[0].Item1) 
            //        {
            //            case "zap":
            //                aux2 = "num_entero";
            //                break;
            //            case "crash":
            //                aux2 = "val_crash";
            //                break;
            //            case "boom":
            //                aux2 = "val_boom";
            //                break;
            //            case "sting":
            //                aux2 = "val_sting";
            //                break;
            //            case "smash":
            //                aux2 = "num_real";
            //                break;
            //            default:
            //                aux2 = "identificador";
            //                break;

            //        }
            //        words[i] = aux2;




            //    }
            
            //}



            //Console.WriteLine("VERSION R: [{0}]", string.Join(",", words));


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

            //Console.WriteLine("IMPRIMIENDO CAMINOOS");
            //foreach (var item in respuesta.Item2)
            //{
            //    Console.WriteLine($"[{item.Item1} - {item.Item2}]");

            //}

            //Console.WriteLine("IMPRIMIENDO EQUIVALENCIAS");
            //foreach (var item in respuesta.Item3)
            //{
            //    Console.WriteLine($"[{item.Item1} - {item.Item2}]");

            //}


            txt_simbolos.Lines = tabla.StringArraySimbolos();
            }
    }
}
