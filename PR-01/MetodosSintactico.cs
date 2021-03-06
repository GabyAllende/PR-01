using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_01
{
    public class MetodosSintactico
    {

        public static List<List<(string, List<string>, int)>> estados { get; set; }

        public static (string, string[][])[] gramatica1 = new (string, string[][])[]
        {
            ("A", new string[][]
            {
                new string[] {"begin","B","H","end"}
            }),
            ("B", new string[][]
            {
                new string[] {"D",";","C"}
            }),
            ("C", new string[][]
            {
               new string[] {"D",";","C"},
                new string[] {""}
            }),
            ("D", new string[][]
            {
                new string[] {"E","F"},

            }),
            ("E", new string[][]
            {
                new string[] {"zap"},
                new string[] {"smash"},
                new string[] {"sting"},
                new string[] {"boom"},
                new string[] {"crash"}
            }),
            ("F", new string[][]
            {
                new string[] {"identificador"}
            }),
            //("G", new string[][]
            //{
            //    new string[] {",","F"},
            //    new string[] {""}
            //}),
            ("H", new string[][]
            {
                new string[] {"J",";","I"}
            }),
            ("I", new string[][]
            {
                new string[] {"J",";","I"},
                new string[] {""}
            }),
            ("J", new string[][]
            {
                new string[] {"K"},
                new string[] {"Q"},
               // new string[] {"BB"},
                new string[] {"Y"},
                new string[] {"R"}
            }),
            ("K", new string[][]
            {
                new string[] {"if","[","M","]","{","H","L"}

            }),
            ("L", new string[][]
            {
                new string[] {"}"},
                new string[] {"else","{","H","}"}
            }),
            ("M", new string[][]
            {
                new string[] {"O","N","O"},
                //new string[] {"M","W","M"},
                new string[] {"val_boom"}
            }),
            ("N", new string[][]
            {
                new string[] {"="},
                new string[] {"<="},
                new string[] {">="},
                new string[] {"<"},
                new string[] {">"},
                new string[] {"!"}
            }),
            ("O", new string[][]
            {
                new string[] {"identificador"},
                new string[] {"P"},
                new string[] {"val_crash"},
                new string[] {"val_sting"},
            }),
            ("P", new string[][]
            {
                new string[] {"num_entero"},
                new string[] {"num_real"}
            }),
            ("Q", new string[][]
            {
                new string[] {"wham","[","M","]","{","H","}"}
            }),
            ("R", new string[][]
            {
                new string[] {"identificador","->","S"},
                new string[] {"identificador","->","V"},
                new string[] {"identificador","->","val_boom"}
            }),
            ("S", new string[][]
            {
                new string[] {"T"},
                new string[] {"S","+","T"},
                new string[] {"S","-","T"},
            }),
            ("T", new string[][]
            {
                new string[] {"U"},
                new string[] {"T","*","U"},
                new string[] {"T","/","U"},
            }),
            ("U", new string[][]
            {
                new string[] {"P"},
                new string[] {"-","U"},
                new string[] {"(","S",")"},
            }),
            ("V", new string[][]
            {
               // new string[] {"[","V","++","V","]"},
                new string[] {"identificador"},
                new string[] {"val_sting"},
                new string[] {"val_crash"}
            }),
            ("W", new string[][]
            {
                new string[] {"xor"},
                new string[] {"and"},
                new string[] {"not"},
                new string[] {"or"}
            }),
            ("Y", new string[][]
            {
                new string[] {"waw","[","identificador","{","Z","}"}
            }),
            ("Z", new string[][]
            {
                new string[] {"puerta","AA",":","H","break",";","Z"},
                new string[] {"default",":","H","break",";"}
            }),
            ("AA", new string[][]
            {
                new string[] {"P"},
                new string[] {"val_boom"},
                new string[] {"val_crash"},
                new string[] {"val_sting"}
            }),
            //("BB", new string[][]
            //{
            //    new string[] {"fush","[","D","R",";","M",";","R","S","]","{","H","}"}
            //}),
            //("CC", new string[][]
            //{
            //    new string[] {"true"},
            //    new string[] {"false"}

            //})





        };



        public static List<string> terminales = new List<string>(){"begin","end"
            ,";","e","identificador",",","if","[","]","else","=","<=",
            ">=","<",">","num_entero","num_real","wham",
            "fush","waw","zap","smash","sting","boom","crash","xor",
            "and","not","or","{","}","->","+","-","*","/","++","real","!",
            ":",",","puerta","break","default","val_boom","val_crash",
            "val_sting"};


        public static List<string> Noterminales = new List<string>(){"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R",
            "S","T","U","V","W","X","Y","Z","AA","BB"};



        public static List<(string, List<string>)> gramatica2 = new List<(string, List<string>)>()
        {

           ("A", new List<string>(){"begin","B","H","end"}),
           ("B", new List<string>(){"D",";","C"}),
           ("C", new List<string>(){"D",";","C"}),
           ("C", new List<string>(){"e"}),
           ("D", new List<string>(){"E","F"}),
           ("E", new List<string>(){"zap"}),
           ("E", new List<string>(){"smash"}),
           ("E", new List<string>(){"sting"}),
           ("E", new List<string>(){"boom"}),
           ("E", new List<string>(){"crash"}),
           ("F", new List<string>(){"identificador"}),
           //("G", new List<string>(){",","F"}),
           //("G", new List<string>(){"e"}),
           ("H", new List<string>(){"J",";","I"}),
           ("I", new List<string>(){"J",";","I"}),
           ("I", new List<string>(){"e"}),
           ("J", new List<string>(){"K"}),
           ("J", new List<string>(){"Q"}),
           //("J", new List<string>(){"BB"}),
           ("J", new List<string>(){"Y"}),
           ("J", new List<string>(){"R"}),
           ("K", new List<string>(){"if","[","M","]","{","H","L"}),
           ("L", new List<string>(){"}"}),
           ("L", new List<string>(){"else","{","H","}"}),
           ("M", new List<string>(){"O","N","O"}),
          // ("M", new List<string>(){"M","W","M"}),
           ("M", new List<string>(){"val_boom"}),
           ("N", new List<string>(){"="}),
           ("N", new List<string>(){"<="}),
           ("N", new List<string>(){">="}),
           ("N", new List<string>(){"<"}),
           ("N", new List<string>(){">"}),
           ("N", new List<string>(){"!"}),
           ("O", new List<string>(){"identificador"}),
           ("O", new List<string>(){"P"}),
           ("O", new List<string>(){"val_crash"}),
           ("O", new List<string>(){"val_sting"}),
           ("P", new List<string>(){"num_entero"}),
           ("P", new List<string>(){"num_real"}),
           ("Q", new List<string>(){"wham", "[","M","]","{","H","}"}),
           ("R", new List<string>(){"identificador","->","S"}),
           ("R", new List<string>(){ "identificador", "->","V"}),
           ("R", new List<string>(){ "identificador", "->","val_boom"}),
           //("S", new List<string>(){"[","S","U","S","]","T"}),
           ///("S", new List<string>(){ "identificador", "T"}),
           //("S", new List<string>(){"P","T"}),
           //("T", new List<string>(){"U","S","T"}),
           ///("T", new List<string>(){"e"}),
           //("U", new List<string>(){"+"}),
           //("U", new List<string>(){"-"}),
           //("U", new List<string>(){"*"}),
           //("U", new List<string>(){"/"}),
           ("S", new List<string>(){"T"}),
           ("S", new List<string>(){"S","+","T"}),
            ("S", new List<string>(){"S","-","T"}),
            ("T", new List<string>(){"U"}),
           ("T", new List<string>(){"T","*","U"}),
            ("T", new List<string>(){"T","/","U"}),
            ("U", new List<string>(){"P"}),
           ("U", new List<string>(){"-","U"}),
            ("U", new List<string>(){"(","S",")"}),
           //("V", new List<string>(){"[","V","++","V","]"}),
           ("V", new List<string>(){"identificador"}),
           ("V", new List<string>(){"val_sting"}),
           ("V", new List<string>(){"val_crash"}),
           ("W", new List<string>(){"xor"}),
           ("W", new List<string>(){"and"}),
           ("W", new List<string>(){"not"}),
           ("W", new List<string>(){"or"}),
           ("Y", new List<string>(){"waw","[", "identificador", "]","{","Z","}"}),
           ("Z", new List<string>(){"puerta","AA",":","H","break",";","Z"}),
           ("Z", new List<string>(){"default",":","H","break",";"}),
           ("AA", new List<string>(){"P"}),
           ("AA", new List<string>(){"val_boom"}),
           ("AA", new List<string>(){"val_crash"}),
           ("AA", new List<string>(){"val_sting"}),
          // ("BB", new List<string>(){"fush","[","D","R",";","M",";","R","S","]","{","H","}"}),
           //("CC", new List<string>(){"true"}),
           //("CC", new List<string>(){"false"})
        };


        public static bool isNumber(string cadena)
        {
            foreach (char a in cadena)
            {
                if (!Char.IsNumber(a))
                {
                    return false;
                }
            }
            return true;
        }

        public static (string, string[][])[] myArray()
        {
            return gramatica1;
        }

        public static List<(string, List<string>)> getGramatica2()
        {
            return gramatica2;
        }

        public static bool isUpper(string cadena)
        {
            if (cadena == "") { return false; }
            foreach (char a in cadena)
            {
                //if (a == '(' || a == ')' || a == '*' || a == '\\' || a == '-' || a == '/') { return false; }
                //if (!Char.IsUpper(a) && !Char.IsPunctuation(a)) { return false; }
                if (!Char.IsUpper(a) && a != '\'')
                { return false; }
            }
            return true;
        }

        public static string[][] findProd(string produccion)
        {
            if (produccion == "" || produccion == null)
            {
                Console.WriteLine("La produccion a buscar es vacia o null");
                return null;
            }

            (string, string[][])[] array = myArray();

            string[][] myProd = null;


            foreach (var a in array)
            {
                //Console.WriteLine($"EN LA PROD: {a.Item1}");
                if (a.Item1 == produccion)
                {
                    myProd = a.Item2;
                    //Console.WriteLine($"SE ENCUENTRA {produccion}");
                }
            }


            if (myProd == null)
            {
                Console.WriteLine($"No se encontro la produccion: {produccion}");

            }
            return myProd;
        }
        public static List<(string, string[])> findFollowProd(string produccion)
        {
            if (produccion == "" || produccion == null)
            {
                Console.WriteLine("La produccion a buscar es vacia o null");
                return null;
            }

            (string, string[][])[] array = myArray();

            List<(string, string[])> prd = new List<(string, string[])>();

            foreach (var p in array)
            {
                foreach (string[] ors in p.Item2)
                {
                    foreach (string s in ors)
                    {
                        if (s == produccion)//&& p.Item1 != produccion)
                        {
                            prd.Add((p.Item1, ors));
                            Console.WriteLine($"{p.Item1} =>" + "{" + String.Join(" , ", ors) + "}");
                        }
                    }
                }
            }
            return prd;
        }

        public static List<string> siguientes(string nombreProd)
        {
            List<string> temp = new List<string>();
            if (isUpper(nombreProd))
            {
                List<(string, string[])> prodsFollow = findFollowProd(nombreProd);

                if (nombreProd == myArray()[0].Item1) //Si es la primera produccion
                {
                    temp.Add("$");
                }

                if (prodsFollow.Count() > 0)
                {

                    foreach (var a in prodsFollow)
                    {
                        if (a.Item2.Last() == nombreProd && a.Item1 != nombreProd)
                        {
                            temp.AddRange(siguientes(a.Item1));
                        }
                        else
                        {
                            int i = a.Item2.ToList().FindIndex(x => x == nombreProd);
                            i++;

                            if (i < a.Item2.Length)
                            {
                                List<string> primBeta = primeros(a.Item2[i]);
                                if (!primBeta.Contains(""))
                                {
                                    temp.AddRange(primBeta);
                                    temp = temp.Distinct().ToList();
                                }
                                else
                                {
                                    while (i < a.Item2.Length && primeros(a.Item2[i]).Contains(""))
                                    {
                                        List<string> primYSinLmbda = primeros(a.Item2[i]);
                                        primYSinLmbda.RemoveAll(x => x == "");

                                        temp.AddRange(primYSinLmbda);

                                        i++;
                                        if (i == a.Item2.Length)
                                        {
                                            temp.AddRange(siguientes(a.Item1));
                                        }


                                    }
                                    if (i < a.Item2.Length)
                                    {
                                        temp.AddRange(primeros(a.Item2[i]));
                                    }
                                    temp = temp.Distinct().ToList();
                                }
                            }




                        }
                    }
                }
                temp = temp.Distinct().ToList();
                return temp;
            }
            else
            {
                Console.WriteLine("EL NOMBRE PROD DE FOLLOW ES MINUSCULA");
                return null;
            }
        }


        public static List<string> primeros(string nombreProd)
        {
            List<string> temp = new List<string>();
            if (isUpper(nombreProd))
            {
                string[][] miProd = findProd(nombreProd);

                foreach (string[] yn in miProd)
                {

                    int i = 0;

                    if (!isUpper(yn[i]))
                    {
                        if (yn[i] == "")
                        {
                            temp.Add("");
                        }
                        else
                        {
                            temp.Add(yn[i]);
                        }

                    }
                    else
                    {
                        if (yn[i] != nombreProd)
                        {
                            List<string> primerosY = primeros(yn[i]);


                            while (i < yn.Length && primeros(yn[i]).Contains(""))
                            {
                                List<string> primYSinLmbda = primeros(yn[i]);
                                primYSinLmbda.RemoveAll(x => x == "");

                                temp.AddRange(primYSinLmbda);
                                //temp = temp.Distinct().ToList();

                                i++;

                            }

                            if (i == yn.Length)
                            {
                                i--;
                                Console.WriteLine($"i: {i}");
                            }
                            temp.AddRange(primeros(yn[i]));
                            temp = temp.Distinct().ToList();
                        }
                        //else 
                        //{
                        //    Console.WriteLine("=====RECURSION INFINITA======");
                        //    temp.Clear();
                        //    temp.Add("RECURSION INFINITA");
                        //}

                    }
                }
                return temp;
            }
            else
            {
                Console.WriteLine($"EL NOMBRE ES MINUSCULA: {nombreProd}");
                if (nombreProd == "")
                {
                    temp.Add("");
                }
                else
                {
                    temp.Add(nombreProd);
                }
                return temp;
            }




        }



        ////////////////A PARTIR DE ACA SON METODOS PARA EL ANALISIS SINTACTICO
        /// SLR

        public static int encontrarEstadoconEstado(List<List<(string, List<string>, int)>> estados, List<(string, List<string>, int)> new_estado)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            for (int j = 0; j < estados.Count; j++)
            {
                int i = 0;
                if (estados[j].Count == new_estado.Count)
                {

                    foreach (var ne in new_estado)
                    {
                        foreach (var e in estados[j])
                        {

                            if (ne.Item1 == e.Item1 && ne.Item2.Equals(e.Item2) && ne.Item3 == e.Item3)
                            {

                                i++;
                                break;
                            }

                        }

                    }

                    if (i == estados[j].Count)
                    {

                        return j;
                    }


                }

            }

            Console.ForegroundColor = ConsoleColor.White;
            return -2;
        }


        public static void imprimirproduccion((string, List<string>, int) prod)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"({prod.Item1},[{String.Join(",", prod.Item2)}],{prod.Item3} )");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public static void imprimirEstado(List<(string, List<string>, int)> estado)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("## new estado");
            foreach (var e in estado)
            {
                imprimirproduccion(e);
            }
            Console.WriteLine("## fin ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void imprimirEstados(List<List<(string, List<string>, int)>> estados)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("IMPRMIENTOS ESTADOS:");
            for (int i = 0; i < estados.Count; i++)
            {
                Console.WriteLine($"Estado: [{i}]");
                imprimirEstado(estados[i]);
            
            }
      
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static List<(string, List<string>, int)> findAllSimbolo(List<(string, List<string>, int)> estado, string simbolo)
        {
            List<(string, List<string>, int)> aux = new List<(string, List<string>, int)>();
            foreach (var est in estado)
            {
                if (!(est.Item2.Count == est.Item3))
                {
                    if (est.Item2[est.Item3] == simbolo) { aux.Add(est); }
                }

            }
            return aux;

        }


        public static List<(string, List<string>, int)> primerEstado(List<(string, List<string>)> tablaBase, List<string> noterminales)
        {

            List<(string, List<string>, int)> res = new List<(string, List<string>, int)>();

            List<string> segundaParte = new List<string>();
            segundaParte.Add(tablaBase[0].Item1);
            (string, List<string>, int) piece = (tablaBase[0].Item1 + "'", segundaParte, 0);
            res.Add(piece);
            // que vaya por todos los objetos de la lista, de esta forma se va expandiendo
            List<string> added = new List<string>();
            added.Add(res[0].Item1);


            for (int i = 0; i < res.Count; i++)
            {

                string simbolo = res[i].Item2[res[i].Item3];
                //Console.WriteLine($"int i:{i}");
                //Console.WriteLine($"simbolo:{simbolo}");
                
                //si no es terminal y ya no pase por el
                if (noterminales.Contains(simbolo) && !added.Contains(simbolo))
                {
                    //Encontrar todas las producciones 
                    added.Add(simbolo);
                    List<(string, List<string>)> finded = tablaBase.FindAll(produccion => produccion.Item1 == simbolo);
                    //add todas las producciones
                    foreach (var parte in finded)
                    {
                        (string, List<string>, int) toAdd = (parte.Item1, parte.Item2, 0);
                        res.Add(toAdd);
                    }
                }
            }



            return res;
        }
        public static void printGramatica2(List<(string, List<string>)> gramatica)
        {
            foreach (var gr in gramatica)
            {
                Console.WriteLine($"{gr.Item1}  -> {String.Join(",", gr.Item2)} ");
            }

        }

        public static (List<List<(string, string)>>, List<List<(string, List<string>, int)>>) automataSLR(List<string> terminales, List<string> noterminales, List<(string, List<string>)> tablaBase)
        {




            ////Console.WriteLine("IMPRIMIENTO TABLABASE");
            //Console.WriteLine("[");
            //foreach (var ex in tablaBase)
            //{
            //    Console.WriteLine($"( {ex.Item1} , [{String.Join(",", ex.Item2)}]) ,");

            //}
            //Console.WriteLine("  ]");

            //Console.WriteLine($"IMPRIMIENTO NO TERMINALES: [{String.Join(",", noterminales)}]");
            //Console.WriteLine($"IMPRIMIENTO TERMINALES: [{String.Join(",", terminales)}]");



            estados = new List<List<(string, List<string>, int)>>();

            //Crear primer estado

            List<(string, List<string>, int)> estadoInicial = primerEstado(tablaBase, noterminales);

            //Console.WriteLine("ÏMPRIMIENTO ESTADO INICIAL");
            //Console.WriteLine("[");
            //foreach (var ex in estadoInicial)
            //{
            //    Console.WriteLine($"( {ex.Item1} , [{String.Join(",", ex.Item2)}] , {ex.Item3} ) ,");

            //}
            //Console.WriteLine("  ]");

            estados.Add(estadoInicial);
            //imprimirEstados(estados);


            List<List<(string, string)>> caminos = new List<List<(string, string)>>();


            // sido recorridos
            for (int j = 0; j < estados.Count; j++)
            {


                //imprimirEstados(estados);

                //Console.WriteLine($"ESTADO :[I{j}]");

                //ya pase por ese simbolo
                List<string> added = new List<string>();

                //camino de cada estado
                List<(string, string)> caminoIndividual = new List<(string, string)>();

                //Se generan distintos estados de un solo estado , por eso vamos por todas las producciones de un estado
                foreach (var prod in estados[j])
                {
                    (string, string) miniCamino = ("", "");

                    //imprimirproduccion(prod);
                    //Verificacion previa que no esta totalmente consumido

                    if (prod.Item2.Count == prod.Item3)
                    {
                        //consumido
                        //Console.WriteLine("Consumindo");


                        if (!noterminales.Contains(prod.Item1))
                        {
                            //es estado acc
                            miniCamino = ("$", "acc");
                            caminoIndividual.Add(miniCamino);

                        }
                        else
                        {
                            //donde estan los primeras

                            List<string> lista_siguientes = siguientes(prod.Item1);
                            int q = 0;
                            //(string, List<string>) aux = tablaBase.Find(item=> item.Item2.Equals(prod.Item2));
                            while (q < tablaBase.Count)
                            {
                                if (tablaBase[q].Item2.Equals(prod.Item2))
                                {
                                    break;
                                }
                                q++;
                            }
                            foreach (string s in lista_siguientes)
                            {
                                miniCamino = (s, "r" + (q + 1).ToString());
                                caminoIndividual.Add(miniCamino);

                            }


                        }


                    }
                    else
                    {

                        //no consumido
                        //considerar que este es un nuevo estado
                        string simboloParaRecorrer = prod.Item2[prod.Item3];

                        //Console.WriteLine($"SIMBOLO PARA RECORRER:[{simboloParaRecorrer}]");

                        //si no he ido por ese simbolo
                        if (!added.Contains(simboloParaRecorrer))
                        {

                            added.Add(simboloParaRecorrer);

                            //encontrar todos las producciones con este simbolo para avanzar
                            List<(string, List<string>, int)> prodRecorrer = findAllSimbolo(estados[j], simboloParaRecorrer);


                            //Console.WriteLine($"Para recorrer con: {simboloParaRecorrer} hay {prodRecorrer.Count} items");



                            //generar el estado y que sea similar
                            List<(string, List<string>, int)> estadoTemporal = new List<(string, List<string>, int)>();

                            foreach (var miniprod in prodRecorrer)
                            {

                                (string, List<string>, int) sig = (miniprod.Item1, miniprod.Item2, miniprod.Item3 + 1);
                                estadoTemporal.Add(sig);



                            }

                            //para ver si ya pase por la terminal, armando los estados
                            List<string> added2 = new List<string>();



                            //a partir de lo basico agregado ver si hay producciones, y producciones de producciones
                            for (int i = 0; i < estadoTemporal.Count; i++)
                            {
                                //si no es consumido
                                if (estadoTemporal[i].Item2.Count != estadoTemporal[i].Item3)
                                {
                                    string simbolo = estadoTemporal[i].Item2[estadoTemporal[i].Item3];
                                    //si no es terminal y ya no pase por el
                                    if (noterminales.Contains(simbolo) && !added2.Contains(simbolo))
                                    {

                                        added2.Add(simbolo);

                                        //Encontrar todas las producciones 
                                        List<(string, List<string>)> finded = tablaBase.FindAll(produccion => produccion.Item1 == simbolo);
                                        //add todas las producciones
                                        foreach (var parte in finded)
                                        {
                                            (string, List<string>, int) toAdd = (parte.Item1, parte.Item2, 0);
                                            estadoTemporal.Add(toAdd);
                                        }

                                    }

                                }



                            }

                            //analisis si existe un estado similar a estado Temporal

                            //Console.WriteLine("IMPRIMIENDO ESTADO A ENCONTRAAR:");

                            int indice = encontrarEstadoconEstado(estados, estadoTemporal);
                            if (indice == -2)
                            {
                                //Console.WriteLine("NOO HAY IGUAL ESTADO");
                                //no existe
                                estados.Add(estadoTemporal);
                                //Console.WriteLine("====== beg");
                                //imprimirEstado(estadoTemporal);
                                //Console.WriteLine("====== end");

                                int ind = estados.Count - 1;
                                if (terminales.Contains(simboloParaRecorrer))
                                {

                                    miniCamino = (simboloParaRecorrer, "s" + ind.ToString());
                                    caminoIndividual.Add(miniCamino);
                                }
                                else
                                {
                                    miniCamino = (simboloParaRecorrer, ind.ToString());
                                    caminoIndividual.Add(miniCamino);
                                }



                            }
                            else
                            {
                                if (terminales.Contains(simboloParaRecorrer))
                                {

                                    //Console.WriteLine("SI HAY IGUAL ESTADO");
                                    miniCamino = (simboloParaRecorrer, "s" + indice.ToString());
                                    caminoIndividual.Add(miniCamino);

                                }
                                else
                                {

                                    miniCamino = (simboloParaRecorrer, indice.ToString());
                                    caminoIndividual.Add(miniCamino);
                                }
                            }




                        }
                        //else { Console.WriteLine("Ya se lo trato"); }


                    }



                }
                caminos.Add(caminoIndividual);
                //caminoIndividual.Clear();

            }

            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.WriteLine("Imprimiendo estados ");
            //imprimirEstados(estados);
            //Console.ForegroundColor = ConsoleColor.White;

            return (caminos, estados);
        }

        /// a es caminos
        public static (bool, List<(int, string)>, List<(int, string)>) procesarCadena(string c, List<List<(string, string)>> a)
        {

            
          

            //Console.WriteLine("IMPRIMIENTO LOS CAMINOS");
            //for (int indice = 0; indice < a.Count; indice ++)
            //{

            //    Console.WriteLine($"[{indice}]  = [" + String.Join(",", a[indice]) + "]");
            //}
          


            Stack<string> pila = new Stack<string>();
            pila.Push("0");
            string antes = c + " $";


            string[] cadena = antes.Split(' ');
            int i = 0;
            string b = cadena[i];

            string devuelve;

            int estado = 0;

            //Console.WriteLine(tabla[1][1].Item1);

            bool aceptado = false;
            List<(string, List<string>)> gramatica = gramatica2;

            List<(int, string)> pendientes = new List<(int, string)>();
            List<(int, string)> registro = new List<(int, string)>();
            List<(int, string)> grafo = new List<(int, string)>();


            int contador = -1;

            do
            {

                string s = pila.First();
                Console.WriteLine($"elemento de la pila : {s}");
                Console.WriteLine($"elemento de la cadena : {b}");
                devuelve = Accion(s, b, a); //Primera produccion y primera palabra de mi cadena
                Console.WriteLine($"devuelve despues de Accion : {devuelve}");

                if (devuelve == null)
                {
                    Console.WriteLine("cadena erronea");
                    break;
                }
                else if (devuelve.Contains("s"))
                {
                    contador++;
                    //Agregamos pendientes
                    pendientes.Add((contador, b));
                    registro.Add((contador, b));
                    //contador++;

                    Console.WriteLine("Contiene s");
                    devuelve = devuelve.Replace("s", string.Empty);//nos quedamos solo con el numero
                    pila.Push(devuelve);
                    estado = int.Parse(devuelve);
                    Console.WriteLine($"Push de devuelve: {devuelve}");
                    i++;
                    b = cadena[i];


                }
                else if (devuelve.Contains("r")) //reduce
                {
                    Console.WriteLine("Contiene r");
                    devuelve = devuelve.Replace("r", string.Empty);//nos quedamos solo con el numero

                    string conexion = gramatica[int.Parse(devuelve) - 1].Item1;
                    List<string> debe = gramatica[int.Parse(devuelve) - 1].Item2;

                    //pendientes.Add(conexion);
                    List<(int, string)> subPendientes = new List<(int, string)>();
                    Console.ForegroundColor = ConsoleColor.Red;
                    foreach (var pe in pendientes)
                    {
                        Console.WriteLine("pendiendtes: " + pe.Item1 + "," + pe.Item2);
                    }
                    for (int j = debe.Count - 1; j > -1; j--)
                    {
                        int aux = pendientes.Count - debe.Count;
                        Console.WriteLine("debe[j]: " + debe[j]);
                        if (pendientes[j + aux].Item2 == debe[j])
                        {

                            subPendientes.Add(pendientes[j + aux]);
                        }
                        else
                        {
                            Console.WriteLine("cadena erronea");
                        };
                    }

                    pendientes.RemoveRange(pendientes.Count - subPendientes.Count, subPendientes.Count);

                    contador++;
                    Console.WriteLine("contador: " + contador);
                    pendientes.Add((contador, conexion));
                    registro.Add((contador, conexion));
                    Console.WriteLine("conexion: " + conexion);
                    foreach (var graf in subPendientes)
                    {
                        Console.WriteLine("graf.Item2: " + graf.Item2);
                        grafo.Add((contador, graf.Item1.ToString()));
                    }
                    //contador++;

                    Console.ForegroundColor = ConsoleColor.White;

                    for (int j = 0; j < gramatica[int.Parse(devuelve) - 1].Item2.Count; j++)
                    {
                        pila.Pop();
                    }
                    string p = pila.First();
                    Console.WriteLine("p : " + p);
                    string A = gramatica[int.Parse(devuelve) - 1].Item1;
                    Console.WriteLine("A : " + A);
                    estado = int.Parse(p);
                    pila.Push(Accion(p, A, a));




                }
                else if (devuelve.Contains("acc"))
                {

                    //Devuelve el arbol

                    Console.WriteLine("Estado de Aceptacion");
                    aceptado = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Solo ir a....");

                    pila.Push(Accion(s, b, a));
                }



            } while (true);
            return (aceptado, grafo, registro);
        }

        public static string Accion(string s, string m, List<List<(string, string)>> a)
        {
            List<(string, string)> revisar = new List<(string, string)>();
            int index;
            revisar = a[int.Parse(s)];

            index = revisar.FindIndex(T => T.Item1 == m);
            if (!(index == -1))
            {
                Console.WriteLine($"Index : {index}");
                return revisar[index].Item2;
            }

            return null;

        }




    }
}
