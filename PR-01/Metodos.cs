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

    }
}
