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
            var regex = @"^""[^""|*]*""$|^[0-9]*$|^[0-9]*.[0-9][0-9]*$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }

        public bool validarIdentificadorCompleto(string palabra) 
        {
            var regex = @"^[A-Z|a-z]([A-Z|a-z|0-9|\-|_])*$|^[\;|\:|\{|\}|\[|\]|>|<|=|+|\-|*|%|\\|,|""|/|.|!|']$|^<=$|^>=$|^->$|^\+\+$|^""[^""|*]*""$|^[0-9]*$|^[0-9]*.[0-9][0-9]*$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;
        }
        public bool simbolosLateralesPalabrasReservadas(string palabra) 
        {
            throw new Exception("Aun ni implementaste este metodo bro xdxd");
        }
    }
}
