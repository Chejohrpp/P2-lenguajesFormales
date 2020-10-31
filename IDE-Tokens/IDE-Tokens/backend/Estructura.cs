using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IDE_Tokens.backend
{
    class Estructura
    {
        private static int cantCambiosMatriz = 78;
        private LinkedList<String> resultErrores = new LinkedList<string>();
        private LinkedList<String> automataPila = new LinkedList<string>();
        private String[,] tabla = new String[cantCambiosMatriz, 4];

        public Estructura(LinkedList<String> automataPila)
        {
            this.automataPila = automataPila;
            matriz();
            verificarPila();
        }
        private void verificarPila()
        {

        }

        public void errores()
        {
            
        }
        public LinkedList<String> getResultErrores()
        {
            return resultErrores;
        }

        private void matriz()
        {
            tabla[0, 1] = "A";  tabla[0, 2] = "PRINCIPAL"; tabla[0, 3] = "PRINCIPAL(){B}";

            tabla[1, 1] = "B"; tabla[1, 2] = "id";       tabla[1, 3] = "CB";
            tabla[2, 1] = "B"; tabla[1, 2] = "IMPRIMIR"; tabla[1, 3] = "DB";
            tabla[3, 1] = "B"; tabla[1, 2] = "LEER";     tabla[1, 3] = "DB";
            tabla[4, 1] = "B"; tabla[1, 2] = "SI";       tabla[1, 3] = "EB";
            tabla[5, 1] = "B"; tabla[1, 2] = "MIENTRAS"; tabla[1, 3] = "FB";
            tabla[6, 1] = "B"; tabla[1, 2] = "HACER";    tabla[1, 3] = "FB";
            tabla[7, 1] = "B"; tabla[1, 2] = "DESDE";    tabla[1, 3] = "GB";
            tabla[8, 1] = "B"; tabla[1, 2] = "_";        tabla[1, 3] = "HB";
            tabla[9, 1] = "B"; tabla[1, 2] = "}";        tabla[1, 3] = "e";

            tabla[10, 1] = "C"; tabla[1, 2] = "SI"; tabla[1, 3] = "id_variableC´;";

            tabla[11, 1] = "C´"; tabla[1, 2] = "="; tabla[1, 3] = "=cont";
            tabla[12, 1] = "C´"; tabla[1, 2] = ","; tabla[1, 3] = ", _variableC´";
            tabla[13, 1] = "C´"; tabla[1, 2] = ";"; tabla[1, 3] = "e´";

            tabla[14, 1] = "D"; tabla[1, 2] = "IMPRIMIR"; tabla[1, 3] = "IMPRIMIR(J)";
            tabla[15, 1] = "D"; tabla[1, 2] = "LEER"; tabla[1, 3] = "LEER(J)";
            tabla[16, 1] = "D"; tabla[1, 2] = "}"; tabla[1, 3] = "e";

            tabla[17, 1] = "E"; tabla[1, 2] = "SI"; tabla[1, 3] = "SI(I){B}E´E´´";
            tabla[18, 1] = "E"; tabla[1, 2] = "}"; tabla[1, 3] = "}";

            tabla[19, 1] = "E´"; tabla[1, 2] = "id"; tabla[1, 3] = "e";
            tabla[20, 1] = "E´"; tabla[1, 2] = "IMPRIMIR"; tabla[1, 3] = "e";
            tabla[21, 1] = "E´"; tabla[1, 2] = "LERR"; tabla[1, 3] = "e";
            tabla[22, 1] = "E´"; tabla[1, 2] = "SI"; tabla[1, 3] = "e";
            tabla[23, 1] = "E´"; tabla[1, 2] = "MIENTRAS"; tabla[1, 3] = "e";
            tabla[24, 1] = "E´"; tabla[1, 2] = "HACER"; tabla[1, 3] = "e";
            tabla[25, 1] = "E´"; tabla[1, 2] = "DESDE"; tabla[1, 3] = "e";
            tabla[26, 1] = "E´"; tabla[1, 2] = "_"; tabla[1, 3] = "e";
            tabla[27, 1] = "E´"; tabla[1, 2] = "SINO"; tabla[1, 3] = "e";
            tabla[28, 1] = "E´"; tabla[1, 2] = "SINO_SI"; tabla[1, 3] = "SINO_SI(I){B}E´";
            tabla[29, 1] = "E´"; tabla[1, 2] = "}"; tabla[1, 3] = "e";

            tabla[30, 1] = "E´´"; tabla[1, 2] = "id"; tabla[1, 3] = "e";
            tabla[31, 1] = "E´´"; tabla[1, 2] = "id"; tabla[1, 3] = "e";
            tabla[32, 1] = "E´´"; tabla[1, 2] = "IMPRIMIR"; tabla[1, 3] = "e";
            tabla[33, 1] = "E´´"; tabla[1, 2] = "LERR"; tabla[1, 3] = "e";
            tabla[34, 1] = "E´´"; tabla[1, 2] = "SI"; tabla[1, 3] = "e";
            tabla[35, 1] = "E´´"; tabla[1, 2] = "MIENTRAS"; tabla[1, 3] = "e";
            tabla[36, 1] = "E´´"; tabla[1, 2] = "HACER"; tabla[1, 3] = "e";
            tabla[37, 1] = "E´´"; tabla[1, 2] = "DESDE"; tabla[1, 3] = "e";
            tabla[38, 1] = "E´´"; tabla[1, 2] = "_"; tabla[1, 3] = "e";
            tabla[39, 1] = "E´´"; tabla[1, 2] = "SINO"; tabla[1, 3] = "SINO{B}";
            tabla[40, 1] = "E´´"; tabla[1, 2] = "}"; tabla[1, 3] = "e";

            tabla[41, 1] = "F"; tabla[1, 2] = "MIENTRAS"; tabla[1, 3] = "MIENTRAS(I){B}";
            tabla[42, 1] = "F"; tabla[1, 2] = "HACER"; tabla[1, 3] = "HACER(I){B}MIENTRAS(I)";
            tabla[43, 1] = "F"; tabla[1, 2] = "}"; tabla[1, 3] = "e";

            tabla[44, 1] = "G"; tabla[1, 2] = "DESDE"; tabla[1, 3] = "DESDE_variable=numHASTA_variableI´INCREMENTOnum{B}";
            tabla[45, 1] = "G"; tabla[1, 2] = "}"; tabla[1, 3] = "e";

            tabla[46, 1] = "H"; tabla[1, 2] = "_"; tabla[1, 3] = "_variableH´;";
            tabla[47, 1] = "H"; tabla[1, 2] = "}"; tabla[1, 3] = "e";

            tabla[48, 1] = "H´"; tabla[1, 2] = "+"; tabla[1, 3] = "++";
            tabla[49, 1] = "H´"; tabla[1, 2] = "-"; tabla[1, 3] = "--";
            tabla[50, 1] = "H´"; tabla[1, 2] = "="; tabla[1, 3] = "=cont";

            tabla[51, 1] = "I"; tabla[1, 2] = "_"; tabla[1, 3] = "KI´L";
            tabla[52, 1] = "I"; tabla[1, 2] = "cont"; tabla[1, 3] = "KI´L";
            tabla[53, 1] = "I"; tabla[1, 2] = "("; tabla[1, 3] = "(KI´)L";
            tabla[54, 1] = "I"; tabla[1, 2] = "VERDADERO"; tabla[1, 3] = "KI´L";
            tabla[55, 1] = "I"; tabla[1, 2] = "FALSO"; tabla[1, 3] = "KI´L";

            tabla[56, 1] = "I´"; tabla[1, 2] = "="; tabla[1, 3] = "==K";
            tabla[57, 1] = "I´"; tabla[1, 2] = "!"; tabla[1, 3] = "!=K";
            tabla[58, 1] = "I´"; tabla[1, 2] = "<"; tabla[1, 3] = "<MK";
            tabla[59, 1] = "I´"; tabla[1, 2] = ">"; tabla[1, 3] = ">MK";

            tabla[60, 1] = "J"; tabla[1, 2] = "_"; tabla[1, 3] = "KJ´";
            tabla[61, 1] = "J"; tabla[1, 2] = "cont"; tabla[1, 3] = "KJ´";
            tabla[62, 1] = "J"; tabla[1, 2] = "VERDADERO"; tabla[1, 3] = "KJ´";
            tabla[63, 1] = "J"; tabla[1, 2] = "FALSO"; tabla[1, 3] = "KJ´";

            tabla[64, 1] = "J´"; tabla[1, 2] = "+"; tabla[1, 3] = "+J";
            tabla[65, 1] = "J´"; tabla[1, 2] = "}"; tabla[1, 3] = "e";

            tabla[66, 1] = "K"; tabla[1, 2] = "_"; tabla[1, 3] = "_variable";
            tabla[67, 1] = "K"; tabla[1, 2] = "cont"; tabla[1, 3] = "cont";
            tabla[68, 1] = "K"; tabla[1, 2] = "FALSO"; tabla[1, 3] = "VERDADERO";
            tabla[69, 1] = "K"; tabla[1, 2] = "VERDADERO"; tabla[1, 3] = "FALSO";

            tabla[70, 1] = "L"; tabla[1, 2] = "&"; tabla[1, 3] = "&&I";
            tabla[71, 1] = "L"; tabla[1, 2] = "|"; tabla[1, 3] = "||I";
            tabla[72, 1] = "L"; tabla[1, 2] = ")"; tabla[1, 3] = "e";

            tabla[73, 1] = "M"; tabla[1, 2] = "_"; tabla[1, 3] = "e";
            tabla[74, 1] = "M"; tabla[1, 2] = "cont"; tabla[1, 3] = "e";
            tabla[75, 1] = "M"; tabla[1, 2] = "="; tabla[1, 3] = "=";
            tabla[76, 1] = "M"; tabla[1, 2] = "VERDADERO"; tabla[1, 3] = "e";
            tabla[77, 1] = "M"; tabla[1, 2] = "FALSO"; tabla[1, 3] = "e";
        }
    }
}
