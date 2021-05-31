using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PR_01
{
    class Metodos
    {
        public static bool validarIdentificador(string palabra)
        {
            var regex = @"^[A-Z|a-z]([A-Z|a-z|0-9|\-|_])*$";
            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }

        public static bool validarSigno(string palabra)
        {
            var regex = @"^[\;|\:|\{|\}|\[|\]|>|<|=|+|\-|*|%|\\|,|""|/|.|!|']$|^<=$|^>=$|^->$|^\+\+$";

            var match = Regex.Match(palabra, regex, RegexOptions.IgnoreCase);

            return match.Success;

        }
    }
}
