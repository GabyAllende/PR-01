using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_01
{
    public class Tablas
    {
        public string[] Reservadas { get; set; } = {
            "begin",
            "end",
            "zap",
            "smash",
            "sting",
            "boom",
            "crash",
            "else",
            "if",
            "wham",
            "fush",
            "waw",
            "puerta",
            "break",
            "default",
            "and",
            "or",
            "xor",
            "not",
            "true",
            "false"

        };
        public List<Simbolo> Simbolos { get; set; } = new List<Simbolo>();
        public string[] StringArraySimbolos() 
        {
            List<string> simbs = new List<string>();
            foreach (var s in Simbolos)
            {
                simbs.Add(s.ToString());
            }
            return simbs.ToArray();
        }
    }

    public class Simbolo 
    {
        public string Token { get; set; }
        public string Lexema { get; set; }
        public object Valor { get; set; } = null;
        public bool Error { get; set; } = false;
        public int Fila { get; set; }
        public int Columna { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Token)}={Token}, {nameof(Lexema)}={Lexema}, {nameof(Valor)}={Valor}, {nameof(Error)}={Error.ToString()}, {nameof(Fila)}={Fila.ToString()}, {nameof(Columna)}={Columna.ToString()}}}";
        }
    }
}
