using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PR_01
{
    public class Metodos
    {
        public bool validarIdentificador(string palabra)
        {
            var regex = @"^[A-Z|a-z]([A-Z|a-z|0-9|\-|_])*$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }

        public bool validarSigno(string palabra)
        {
            var regex = @"^[\;|\:|\{|\}|\[|\]|>|<|=|+|\-|*|%|\\|,|""|/|.|!|']$|^<=$|^>=$|^->$|^\+\+$";

            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }
        public bool validarNumerosString(string palabra)
        {
            var regex = @"^""[^""|*]*""$|^\-?[0-9]*$|^\-?[0-9]*.[0-9][0-9]*$|^'.'$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }

        
        public bool validarString(string palabra)
        {
            var regex = @"^""[^""|*]*""$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }

        public bool validarNumerosEnteros(string palabra)
        {
            var regex = @"^\-?[0-9]*$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }
        public bool validarNumerosDecimales(string palabra)
        {
            var regex = @"^\-?[0-9]*.[0-9][0-9]*$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }
        public bool validarChar(string palabra)
        {
            var regex = @"^'.'$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }

        public bool validarIdentificadorCompleto(string palabra) 
        {
            var regex = @"^[A-Z|a-z]([A-Z|a-z|0-9|\-|_])*$|^[\;|\:|\{|\}|\[|\]|>|<|=|+|\-|*|%|\\|,|""|/|.|!|']$|^<=$|^>=$|^->$|^\+\+$|^""[^""|*]*""$|^\-?[0-9]*$|^\-?[0-9]*.[0-9][0-9]*$|^'.'$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;
        }
        public bool simbolosLateralesPalabrasReservadas(string palabra) 
        {
            throw new Exception("Aun ni implementaste este metodo bro xdxd");
        }




        public bool validarReservada(string palabra)
        {

            var regex = @"\b(begin|end|zap|smash|sting|boom|crash|if|else|wham|fush|waw|puerta|break|default|and|or|xor|not)\b";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;
        }

        public bool validarTipo(string palabra)
        {
            var regex = @"\b(zap|smash|sting|boom|crash)\b";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;


        }
        public bool validarBoom(string palabra)
        {
            var regex = @"\b(true|false)\b";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;


        }
        public bool validarOperadorMatematico(string palabra)
        {
            var regex = @"^[+|\-|*|%|\\]$";

            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }
        public static bool validarOperadorBooleano(string palabra)
        {
            var regex = @"[\b(and|or|xor|not)\b|^[>|<|!|=]$|^<=$|^>=$|^->$]";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;


        }


        public List<(string, string, string)> buscarItem2(List<(string, string, string)> pendiente , string item)
        {
            List<(string, string, string)> answer = new List<(string, string, string)>();
            
                foreach (var obj in pendiente)
                {
                    if (obj.Item2 != null)
                    {
                        if (obj.Item2 == item)
                        {
                            answer.Add(obj);

                        }

                    }
                }

            
            
            return answer;

        }

        public int buscarindexItem2(List<(string, string, string)> pendiente, string item)
        {
            //List<(string, string, string)> answer = new List<(string, string, string)>();
            //List<int> answer = new List<int>();
            if (pendiente != null)
            {
                for (int i = 0; i < pendiente.Count; i++)
                //foreach (var obj in pendiente)
                {
                    if (pendiente[i].Item2 != null)
                    {
                        if (pendiente[i].Item2 == item)
                        {
                            return i;

                        }

                    }
                }


            }
            
            return -1;

        }

        public string[] SepararLineas(string linea)
        {
            int cont = 0;
            List<string> palabras = new List<string>();
            for (int i = 0; i < linea.Length; i++)
            {
                if (i == linea.Length - 1 && linea[i] != '"')
                {
                    string substr = linea.Substring(i - cont, cont + 1);
                    substr = substr.Trim();
                    palabras.Add(substr);
                    cont = 0;
                }

                if (linea[i] == ' ')
                {

                    string substr = linea.Substring(i - cont, cont + 1);
                    substr = substr.Trim();
                    palabras.Add(substr);
                    cont = 0;

                }
                else if (linea[i] == '"' && (i == 0 || linea[i - 1] == ' '))
                {
                    int cont2 = i + 1;
                    while (linea[cont2] != '"')
                    {
                        cont2++;
                    }
                    if(linea[cont2+1] == ' ')
                    {
                        string substr = linea.Substring(i, cont2 - i + 1);
                        i = cont2 + 1;
                        palabras.Add(substr);
                        cont = 0;
                    }
                    
                }

                

                cont += 1;
            }
            return palabras.ToArray();
        }


        public string[] charByChar2(string row)
        {
            int tam = row.Length;
            //row = Regex.Replace(row, @"\s+", " ");

            //taking out space from the end
            //row = row.TrimEnd();

            int j = 0;
            int i = 0;

            bool str_a = false;
            bool ch_a = false;
            bool num = false;


            string a = "";
            string b = "";
            string b_aux = "a";
            List<string> simbolos = new List<string>();


            bool principio = true;
            bool final = false;
            bool enMedio = false;

            while (i < row.Length)
            {
                a = "";
                b = "";

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"row[{i}]: [{row[i]}]");
                Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine("=== en while ===");
                //Console.WriteLine($"j : [{j}]");

                if (row[i] == '\t' && !str_a && !ch_a)
                {
                    //Console.WriteLine("--> es vacio");
                    //b_aux = row.Substring(i , row.Length - i );

                    b = row.Substring(i + 1, row.Length - i - 1);



                    if (i == 0)
                    {
                        Console.WriteLine("HAY TAB AL INICION");
                        simbolos.Add("\t");
                    }
                    //simbolos.Add("");
                    else if (i != 0)
                    {
                        Console.WriteLine("HAY TAB AL medio");
                        //case is 0 just ignore de first one
                        // ignore cause we need column
                        a = row.Substring(0, i);
                        simbolos.Add(a);
                        simbolos.Add("\t");
                        if (num)
                        {
                            num = false;

                        }

                    }

                    row = b;
                    i = 0;
                }


                else {

                    //gets space
                    if (row[i] == ' ' && !str_a && !ch_a)
                    {
                        //Console.WriteLine("--> es vacio");
                        //b_aux = row.Substring(i , row.Length - i );

                        b = row.Substring(i + 1, row.Length - i - 1);



                        if (i == 0)
                        {
                            simbolos.Add("");
                        }
                        //simbolos.Add("");
                        else if (i != 0)
                        {
                            //case is 0 just ignore de first one
                            // ignore cause we need column
                            a = row.Substring(0, i);
                            simbolos.Add(a);
                            simbolos.Add("");
                            if (num)
                            {
                                num = false;

                            }

                        }

                        row = b;
                        i = 0;
                    }

                    //get begining of string and end
                    else if (row[i] == '"' && (i == 0 || str_a))
                    {
                        principio = false;
                        if (!str_a)
                        {

                            num = false;
                            //Console.WriteLine("-->Empieza string");
                            str_a = true;
                            i++;
                        }
                        else
                        {
                            //Console.WriteLine("--> termina string");
                            a = row.Substring(0, i + 1);
                            b = row.Substring(i + 1, row.Length - i - 1);
                            simbolos.Add(a);
                            row = b;
                            i = 0;
                            str_a = false;
                        }
                    }
                    //get begining of char and end
                    else if (row[i] == '\'' && (i == 0 || ch_a))
                    {
                        principio = false;
                        if (!ch_a)
                        {
                            //Console.WriteLine("-->Empieza string");
                            ch_a = true;
                            i++;
                        }
                        else
                        {
                            //Console.WriteLine("--> termina string");
                            a = row.Substring(0, i + 1);
                            b = row.Substring(i + 1, row.Length - i - 1);
                            simbolos.Add(a);
                            row = b;
                            i = 0;
                            ch_a = false;
                        }
                    }


                    //any kind of signo
                    else if (validarSigno(row[i].ToString()) && !str_a && !ch_a)
                    {
                        principio = false;
                        //Console.WriteLine("--> hay signo ");
                        if (i != 0)
                        {
                            ///it has to continue if it is is . and num
                            ///

                            if (!((row[i] == '.') && num))
                            {
                                //Console.WriteLine("--> al final ");


                                a = row.Substring(0, i);
                                simbolos.Add(a);


                                b = row.Substring(i, row.Length - i);
                                row = b;


                                num = false;

                                i = 0;

                            }
                            else { i++; }


                        }

                        else
                        {
                            //if i exists and with the next char is a signo
                            if (i + 1 != row.Length)
                            {
                                if (validarSigno(row[i].ToString() + row[i + 1].ToString()))
                                {
                                    //Console.WriteLine("--> al principio ");
                                    a = row.Substring(0, 2);
                                    simbolos.Add(a);
                                    if (i + 2 != row.Length)
                                    {
                                        b = row.Substring(i + 2, row.Length - i - 2);
                                        row = b;
                                    }
                                    else
                                    {
                                        row = "";
                                    }
                                    i = 0;

                                }
                                //for numbrers with decimal o integer
                                else if (row[i].ToString() == "-" && char.IsDigit(row[i + 1]))
                                {
                                    // si viene de un identificaodor
                                    //Console.WriteLine("-> es un numero");
                                    num = true;
                                    i++;
                                }
                                else
                                {
                                    //Console.WriteLine("--> al principio ");
                                    a = row.Substring(0, 1);
                                    simbolos.Add(a);

                                    if (i + 1 != row.Length)
                                    {
                                        b = row.Substring(i + 1, row.Length - i - 1);
                                        row = b;
                                    }
                                    else
                                    {
                                        row = "";
                                    }
                                    i = 0;

                                }
                            }
                            else
                            {
                                //Console.WriteLine("--> al principio ");
                                a = row.Substring(0, 1);
                                simbolos.Add(a);

                                if (i + 1 != row.Length)
                                {
                                    b = row.Substring(i + 1, row.Length - i - 1);
                                    row = b;
                                }
                                else
                                {
                                    row = "";
                                }

                                i = 0;

                            }


                        }


                    }


                    else if (char.IsDigit(row[i]) && !num)
                    {
                        principio = false;
                        num = true;
                    }

                    else
                    {
                        principio = false;
                        //Console.WriteLine("--> esta en else");
                        i++;

                    }


                }

               

                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine("======Despues de ingresar=============");
                //Console.WriteLine($"a: [{a}]");
                //Console.WriteLine($"b:  [{b}]");
                //Console.WriteLine("======Fin de ingresar=============");
                //Console.ForegroundColor = ConsoleColor.White;


                j++;
            }


            if (row.Length != 0)
            {
                
                a = row.Substring(0, i);
                Console.WriteLine($"al final hay : [{a}]");
                simbolos.Add(a);


            }



            return simbolos.ToArray();



        }





    }
}
