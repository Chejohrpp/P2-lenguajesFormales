using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IDE_Tokens.backend
{
    class Estructura
    {
        private static int cantCambiosMatriz = 78;
        private int cantTokens = 0;
        private LinkedList<String> resultErrores = new LinkedList<string>();
        private LinkedList<String> cadenaTokens = new LinkedList<string>();
        private LinkedList<String> automataPila = new LinkedList<string>();

        private LinkedList<String> tokensArbol = new LinkedList<string>();
        private LinkedList<String> tokensArbolAnterior = new LinkedList<string>();//se guardan los tokens de un nivel atras
        private int posTokenCambiar = 1; //sirve para conocer la posicion de la hoja en el arbol
        String hojasArbol = null;
        String todasHojas = null;
        String todasApuntarHojas = null;

        private String[,] tabla = new String[cantCambiosMatriz, 4];
        private String estadoActual = "A";


        public Estructura(LinkedList<String> cadenaTokens)
        {
            this.cadenaTokens = new LinkedList<string> (cadenaTokens);
            matriz();
            automataPila.AddLast(estadoActual);
            tokensArbolAnterior.AddLast(estadoActual);
            cantTokens = this.cadenaTokens.Count;
            verificarPila();

        }
        private void verificarPila()
        {
            if(cantTokens != 0 && cadenaTokens.Count != 0 && automataPila.Count != 0)
            {
                arreglarTokens();
                if (cadenaTokens.First.Value.Equals(automataPila.Last.Value))
                {
                    cadenaTokens.RemoveFirst();
                    automataPila.RemoveLast();
                    try
                    {
                        if (tokensArbolAnterior.Count != 0)
                        {
                            tokensArbolAnterior.RemoveLast();//para generar el arbol
                        }                        
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message +" posible null en tokedndsArbolAnterior");
                    }                    
                    cantTokens = cadenaTokens.Count;
                    posTokenCambiar++;//para cambiar el num de los tokens
                    verificarPila();
                }
                else
                {
                    for (int i = 0; i < cantCambiosMatriz; i++)
                    {
                        if (tabla[i, 1].Equals(automataPila.Last.Value) && 
                            tabla[i, 2].Equals(cadenaTokens.First.Value))
                        {
                            
                            automataPila.RemoveLast();
                            separarNodos(tabla[i, 3]);
                            generarArbol();
                            cantTokens = cadenaTokens.Count;

                            break;
                        }
                        else
                        {
                            cantTokens = 0;
                        }
                    }

                    if (automataPila.Count != 0)
                    {
                        if (automataPila.Last.Value.Equals("e"))
                        {
                            automataPila.RemoveLast();
                        }
                    }                    
                    verificarPila();
                }
            }

        }
        private void arreglarTokens()
        {
            String token = cadenaTokens.First.Value;
            if (token.Equals("A") || token.Equals("F") || token.Equals("X") || token.Equals("Z") || token.Equals("Ñ") || token.Equals("Y"))
            {
                
            }
            if (token.Equals("B") || token.Equals("D") || token.Equals("E") || token.Equals("G"))
            {
                cadenaTokens.RemoveFirst();
                cadenaTokens.AddFirst("ï");
            } 
            
        }
        private void separarNodos(String cadena)
        {
            String nodoCompuesto = null;
            for (int i = (cadena.Length)-1; i >= 0; i--)
            {
                char newNodo = cadena[i];            

                if (newNodo.Equals('´'))
                {                    
                    nodoCompuesto = nodoCompuesto + newNodo.ToString();                  

                }
                else
                {
                    nodoCompuesto = nodoCompuesto + newNodo.ToString();
                    String nodoInvertido = invertir(nodoCompuesto);
                    automataPila.AddLast(nodoInvertido);                    
                    tokensArbol.AddLast(nodoInvertido);// lo necesitamos agregar tokens tmp para el arbol
                    nodoCompuesto = null;
                }
                
            }

            
        }
        private static string invertir(string cadena)
        {
            // Convertir a arreglo
            char[] cadenaComoCaracteres = cadena.ToCharArray();
            // Invertir el arreglo usando métodos incorporados
            Array.Reverse(cadenaComoCaracteres);
            // Convertir de nuevo el arreglo a cadena
            return new string(cadenaComoCaracteres);
        }

        private void errores()
        {
            if (automataPila.Count == 0)
            {

            }
        }
        public LinkedList<String> getResultErrores()
        {
            return resultErrores;
        }
        public LinkedList<String> getAutomata()
        {
            return automataPila;
        }
        //significado de cada caracter:
        //principal-@		64
        //si - Ç   			128
        //sino- ü			129
        //sino_si- é           	130
        //mientras- â 	131
        //hacer- ä		132
        //desde-à		133
        //hasta-å		134
        //incremento-ç	135
        //imprimir-ê	136	
        //leer-ë		137
        //id -è 138
        //cont- ï  139
        //verdadero/falso - ì 141
        private void matriz()
        {
            tabla[0, 1] = "A";  tabla[0, 2] = "@"; tabla[0, 3] = "@(){B}";

            tabla[1, 1] = "B"; tabla[1, 2] = "è";       tabla[1, 3] = "CB";
            tabla[2, 1] = "B"; tabla[2, 2] = "ê";       tabla[2, 3] = "DB";
            tabla[3, 1] = "B"; tabla[3, 2] = "ë";       tabla[3, 3] = "DB";
            tabla[4, 1] = "B"; tabla[4, 2] = "Ç";       tabla[4, 3] = "EB";
            tabla[5, 1] = "B"; tabla[5, 2] = "â";       tabla[5, 3] = "FB";
            tabla[6, 1] = "B"; tabla[6, 2] = "ä";       tabla[6, 3] = "FB";
            tabla[7, 1] = "B"; tabla[7, 2] = "à";       tabla[7, 3] = "GB";
            tabla[8, 1] = "B"; tabla[8, 2] = "_";        tabla[8, 3] = "HB";
            tabla[9, 1] = "B"; tabla[9, 2] = "}";        tabla[9, 3] = "e";

            tabla[10, 1] = "C"; tabla[10, 2] = "è";        tabla[10, 3] = "è_C´;";

            tabla[11, 1] = "C´"; tabla[11, 2] = "=";        tabla[11, 3] = "=K";
            tabla[12, 1] = "C´"; tabla[12, 2] = ",";        tabla[12, 3] = ",_C´";
            tabla[13, 1] = "C´"; tabla[13, 2] = ";";        tabla[13, 3] = "e";

            tabla[14, 1] = "D"; tabla[14, 2] = "ê";   tabla[14, 3] = "ê(J);";
            tabla[15, 1] = "D"; tabla[15, 2] = "ë";       tabla[15, 3] = "ë(J);";
            tabla[16, 1] = "D"; tabla[16, 2] = "}";          tabla[16, 3] = "e";

            tabla[17, 1] = "E"; tabla[17, 2] = "Ç";         tabla[17, 3] = "Ç(I){B}E´E´´";
            tabla[18, 1] = "E"; tabla[18, 2] = "}";          tabla[18, 3] = "}";

            tabla[19, 1] = "E´"; tabla[19, 2] = "è";           tabla[19, 3] = "e";
            tabla[20, 1] = "E´"; tabla[20, 2] = "ê";     tabla[20, 3] = "e";
            tabla[21, 1] = "E´"; tabla[21, 2] = "ë";         tabla[21, 3] = "e";
            tabla[22, 1] = "E´"; tabla[22, 2] = "Ç";           tabla[22, 3] = "e";
            tabla[23, 1] = "E´"; tabla[23, 2] = "â";     tabla[23, 3] = "e";
            tabla[24, 1] = "E´"; tabla[24, 2] = "ä";        tabla[24, 3] = "e";
            tabla[25, 1] = "E´"; tabla[25, 2] = "à";        tabla[25, 3] = "e";
            tabla[26, 1] = "E´"; tabla[26, 2] = "_";            tabla[26, 3] = "e";
            tabla[27, 1] = "E´"; tabla[27, 2] = "é";         tabla[27, 3] = "é(I){B}E´";
            tabla[28, 1] = "E´"; tabla[28, 2] = "ü";      tabla[28, 3] = "e";
            tabla[29, 1] = "E´"; tabla[29, 2] = "}";            tabla[29, 3] = "e";

            tabla[30, 1] = "E´´"; tabla[30, 2] = "è";           tabla[30, 3] = "e";
            tabla[31, 1] = "E´´"; tabla[31, 2] = "è";           tabla[31, 3] = "e";
            tabla[32, 1] = "E´´"; tabla[32, 2] = "ê";       tabla[32, 3] = "e";
            tabla[33, 1] = "E´´"; tabla[33, 2] = "ë";         tabla[33, 3] = "e";
            tabla[34, 1] = "E´´"; tabla[34, 2] = "Ç";           tabla[34, 3] = "e";
            tabla[35, 1] = "E´´"; tabla[35, 2] = "â";       tabla[35, 3] = "e";
            tabla[36, 1] = "E´´"; tabla[36, 2] = "ä";        tabla[36, 3] = "e";
            tabla[37, 1] = "E´´"; tabla[37, 2] = "à";        tabla[37, 3] = "e";
            tabla[38, 1] = "E´´"; tabla[38, 2] = "_";        tabla[38, 3] = "e";
            tabla[39, 1] = "E´´"; tabla[39, 2] = "ü";       tabla[39, 3] = "ü{B}";
            tabla[40, 1] = "E´´"; tabla[40, 2] = "}";        tabla[40, 3] = "e";

            tabla[41, 1] = "F"; tabla[41, 2] = "â";       tabla[41, 3] = "â(I){B}";
            tabla[42, 1] = "F"; tabla[42, 2] = "ä";          tabla[42, 3] = "ä(I){B}â(I)";
            tabla[43, 1] = "F"; tabla[43, 2] = "}";              tabla[43, 3] = "e";

            tabla[44, 1] = "G"; tabla[44, 2] = "à";          tabla[44, 3] = "à_=ïå_I´çï{B}";
            tabla[45, 1] = "G"; tabla[45, 2] = "}";              tabla[45, 3] = "e";

            tabla[46, 1] = "H"; tabla[46, 2] = "_";              tabla[46, 3] = "_H´;";
            tabla[47, 1] = "H"; tabla[47, 2] = "}";              tabla[47, 3] = "e";

            tabla[48, 1] = "H´"; tabla[48, 2] = "+"; tabla[48, 3] = "++";
            tabla[49, 1] = "H´"; tabla[49, 2] = "-"; tabla[49, 3] = "--";
            tabla[50, 1] = "H´"; tabla[50, 2] = "="; tabla[50, 3] = "=ï";

            tabla[51, 1] = "I"; tabla[51, 2] = "_";          tabla[51, 3] = "KI´L";
            tabla[52, 1] = "I"; tabla[52, 2] = "ï";       tabla[52, 3] = "KI´L";
            tabla[53, 1] = "I"; tabla[53, 2] = "(";          tabla[53, 3] = "(KI´)L";
            tabla[54, 1] = "I"; tabla[54, 2] = "ì";         tabla[54, 3] = "KI´L"; //verdadero
            tabla[55, 1] = "I"; tabla[55, 2] = "ì";         tabla[55, 3] = "KI´L"; //falso

            tabla[56, 1] = "I´"; tabla[56, 2] = "="; tabla[56, 3] = "==K";
            tabla[57, 1] = "I´"; tabla[57, 2] = "!"; tabla[57, 3] = "!=K";
            tabla[58, 1] = "I´"; tabla[58, 2] = "<"; tabla[58, 3] = "<MK";
            tabla[59, 1] = "I´"; tabla[59, 2] = ">"; tabla[59, 3] = ">MK";

            tabla[60, 1] = "J"; tabla[60, 2] = "_";          tabla[60, 3] = "KJ´";
            tabla[61, 1] = "J"; tabla[61, 2] = "ï";       tabla[61, 3] = "KJ´";
            tabla[62, 1] = "J"; tabla[62, 2] = "ì";  tabla[62, 3] = "KJ´";
            tabla[63, 1] = "J"; tabla[63, 2] = "ì";      tabla[63, 3] = "KJ´";

            tabla[64, 1] = "J´"; tabla[64, 2] = "+"; tabla[64, 3] = "+J";
            tabla[65, 1] = "J´"; tabla[65, 2] = ")"; tabla[65, 3] = "e";

            tabla[66, 1] = "K"; tabla[66, 2] = "_";          tabla[66, 3] = "_";
            tabla[67, 1] = "K"; tabla[67, 2] = "ï";       tabla[67, 3] = "ï";
            tabla[68, 1] = "K"; tabla[68, 2] = "ì";      tabla[68, 3] = "ì";
            tabla[69, 1] = "K"; tabla[69, 2] = "ì";  tabla[69, 3] = "ì";

            tabla[70, 1] = "L"; tabla[70, 2] = "&"; tabla[70, 3] = "&&I";
            tabla[71, 1] = "L"; tabla[71, 2] = "|"; tabla[71, 3] = "||I";
            tabla[72, 1] = "L"; tabla[72, 2] = ")"; tabla[72, 3] = "e";

            tabla[73, 1] = "M"; tabla[73, 2] = "_";          tabla[73, 3] = "e";
            tabla[74, 1] = "M"; tabla[74, 2] = "ï";       tabla[74, 3] = "e";
            tabla[75, 1] = "M"; tabla[75, 2] = "=";          tabla[75, 3] = "=";
            tabla[76, 1] = "M"; tabla[76, 2] = "ì";  tabla[76, 3] = "e";
            tabla[77, 1] = "M"; tabla[77, 2] = "ì";      tabla[77, 3] = "e";
        }
        private void generarArbol()
        {
            try
            {
                if (tokensArbolAnterior.Count != 0)
                {
                    String crearHoja = posTokenCambiar + " [label=\" " + tokensArbolAnterior.Last.Value + " \"]; ";
                    todasHojas = todasHojas + crearHoja;
                    int cont = 1;
                    foreach (String token in tokensArbol.Reverse())
                    {
                        crearHoja = posTokenCambiar + cont + " [label=\" " + token + " \" ]; ";
                        todasHojas = todasHojas + crearHoja;
                        cont++;
                    }

                    for (int i = 0; i < tokensArbol.Count; i++)
                    {
                        String apuntarHojas = posTokenCambiar + " -> " + (posTokenCambiar + 1 + i) + "; ";
                        todasApuntarHojas = todasApuntarHojas + apuntarHojas;
                    }
                    posTokenCambiar += tokensArbol.Count + 1;//+1 puede cambiar

                    tokensArbolAnterior = new LinkedList<string>(tokensArbol);
                    tokensArbol.Clear();
                }
                
            }
            catch(Exception e)
            {

            }
            
            
        }
        public String codigoArbol()
        {
            hojasArbol = todasHojas + todasApuntarHojas;
            String codigoArbol = "digraph G {"+hojasArbol+"}";
            return codigoArbol;
        }
    }
}
