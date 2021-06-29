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

        public bool validarNumeros(string palabra)
        {
            var regex = @"^\-?[0-9]*$|^\-?[0-9]*.[0-9][0-9]*$";
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
            row = Regex.Replace(row, @"\s+", " ");

            //taking out space from the end
            row = row.TrimEnd();

            int j = 0;
            int i = 0;

            bool str_a = false;
            bool ch_a = false;
            bool num = false;


            string a = "";
            string b = "";

            List<string> simbolos = new List<string>();




            while (i < row.Length)
            {
                a = "";
                b = "";
                Console.WriteLine($"row[{i}]: [{row[i]}]");

                Console.WriteLine("=== en while ===");
                Console.WriteLine($"j : [{j}]");

                //gets space
                if (row[i] == ' ' && !str_a && !ch_a)
                {
                    Console.WriteLine("--> es vacio");

                    b = row.Substring(i + 1, row.Length - i - 1);
                    simbolos.Add("");
                    if (i != 0)
                    {
                        //case is 0 just ignore de first one
                        // ignore cause we need column
                        a = row.Substring(0, i);
                        simbolos.Add(a);
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
                    if (!str_a)
                    {

                        num = false;
                        Console.WriteLine("-->Empieza string");
                        str_a = true;
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("--> termina string");
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
                    if (!ch_a)
                    {
                        Console.WriteLine("-->Empieza string");
                        ch_a = true;
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("--> termina string");
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

                    Console.WriteLine("--> hay ; ");
                    if (i != 0)
                    {
                        ///it has to continue if it is is . and num
                        ///

                        if (!((row[i] == '.') && num))
                        {
                            Console.WriteLine("--> al final ");


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
                                Console.WriteLine("--> al principio ");
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
                                Console.WriteLine("-> es un numero");
                                num = true;
                                i++;
                            }
                            else
                            {
                                Console.WriteLine("--> al principio ");
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
                            Console.WriteLine("--> al principio ");
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
                    num = true;
                }

                else
                {
                    Console.WriteLine("--> esta en else");
                    i++;

                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("======Despues de ingresar=============");
                Console.WriteLine($"a: [{a}]");
                Console.WriteLine($"b:  [{b}]");
                Console.WriteLine("======Fin de ingresar=============");
                Console.ForegroundColor = ConsoleColor.White;


                j++;
            }


            if (row.Length != 0)
            {
                a = row.Substring(0, i);

                simbolos.Add(a);


            }



            return simbolos.ToArray();



        }





    }
}
