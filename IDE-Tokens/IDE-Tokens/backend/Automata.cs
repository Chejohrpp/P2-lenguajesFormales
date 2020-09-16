using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace IDE_Tokens.backend
{
    class Automata
    {
        private static int cantEstados=8;
        private char[] abecedario = { '0', '1' };
        private char estadoAhora = 'A';
        private char estadoAnterior = 'A';
        private char[] estadoAceptacion = {'A','B','D','F','G','H','I','K','L','M','N','O','P','Q','R','T','V','W','Ñ','Z'};
        private Char[,] tabla = new Char[cantEstados, 3];
        private Boolean aceptable = false;
        private Boolean error = false;
        private String mensajeError;
        private String cadena;
        private Color color = Color.Black;
        private LinkedList<String> result;
        public Automata()
        {
            funcionesTransicion();
            
        }
        private Color palabrasReservadas()
        {
           String[] palabrasReservadas = {"SI", "SINO,SINO_SI,MENTRAS,HACER,DESDE,HASTA,INCREMENTO" };
            foreach (String palabra in palabrasReservadas)
            {
                if (cadena.Equals(palabra, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Color.Green;
                }
            }
            if (cadena.Equals("entero", StringComparison.InvariantCultureIgnoreCase))
            {
                return Color.Purple;
            }
            if (cadena.Equals("decimal", StringComparison.InvariantCultureIgnoreCase))
            {
                return Color.SkyBlue;
            }
            if (cadena.Equals("cadena", StringComparison.InvariantCultureIgnoreCase))
            {
                return Color.Gray;
            }
            if (cadena.Equals("booleano", StringComparison.InvariantCultureIgnoreCase))
            {
                return Color.Orange;
            }
            if (cadena.Equals("verdadero", StringComparison.InvariantCultureIgnoreCase))
            {
                return Color.Orange;
            }
            if (cadena.Equals("falso", StringComparison.InvariantCultureIgnoreCase))
            {
                return Color.Orange;
            }
            if (cadena.Equals("caracter", StringComparison.InvariantCultureIgnoreCase))
            {
                return Color.Brown;
            }
            return Color.Black;
        }
        public void cambiarcolor(System.Windows.Forms.RichTextBox txtEditor)
        {
            if (aceptable)
            {
                BuscarColor();
                txtEditor.Find(cadena);
                txtEditor.SelectionColor = color;
            }
            else
            {
                txtEditor.Find(cadena);
                txtEditor.SelectionColor = Color.Black;
            }

            if (estadoAhora.Equals('A') || estadoAhora.Equals('@'))
            {
                reiniciar();                
            }

        }

        public void cambiarEstado(char charEvaluar, System.Windows.Forms.RichTextBox txtEditor)
        {
            char auxChar = charEvaluar;
            errores(charEvaluar);

            if (char.IsNumber(charEvaluar))
            {
                auxChar = '0';
            }
            else
            {
                int ascci = Encoding.ASCII.GetBytes(charEvaluar.ToString())[0];
                if ((ascci >= 65 && ascci <= 90) || (ascci >= 97 && ascci <= 122) || ascci == 164 || ascci == 165)
                {
                    auxChar = 'a';
                }
            }           

            for (int i = 0; i < cantEstados; i++)
            {
                if (tabla[i, 0].Equals(estadoAhora) && tabla[i, 1].Equals(auxChar))
                {
                    error = false;
                    estadoAnterior = estadoAhora;
                    estadoAhora = tabla[i, 2];
                    verificar();
                    result.AddLast(resultado(charEvaluar));
                    break;
                }
                else
                {
                    error = true;
                }
            }
            if (estadoAhora.Equals('A') && error == false) 
            {
                reiniciar();
                cambiarEstado(charEvaluar, txtEditor);
            }
            else
            {
                cadena = cadena + charEvaluar;
                cambiarcolor(txtEditor);
            }
            if (error)
            {
                if (estadoAhora.Equals('A'))
                {
                }
                else
                {
                    mensajeError = "No hay tansicion con " + charEvaluar;
                    result.AddLast(mensajeError);
                }
                
            }


        }
        private void verificar()
        {
            for (int i = 0; i < estadoAceptacion.Length; i++)
            {
                if (estadoAhora.Equals(estadoAceptacion[i]))
                {
                    aceptable = true;                    
                    break;
                }
                else
                {
                    aceptable = false;
                    
                }
            }
        }
        private void BuscarColor()
        {
            if (true)
            {

            }
            
        }

        private void errores(char charEvaluar)
        {
            for (int i = 0; i < abecedario.Length ; i++)
            {
                if (charEvaluar.Equals(abecedario[i]))
                {
                    error = false;
                    break;
                }

                else
                {
                    error = true;
                    mensajeError = "El " + charEvaluar + " No existe en el abecedario";
                }
            }

        }
        private String resultado(char charEvaluar)
        {
            if (error == false)
            {
                if (aceptable)
                {
                    return "d(" + estadoAnterior + "," + charEvaluar + ")= " + estadoAhora + "-Aceptable";
                }
                return "d(" + estadoAnterior + ", " + charEvaluar + ") = " + estadoAhora;
            }
            return mensajeError;
            
        }

        public void funcionesTransicion()
        {
         
            
            tabla[0, 0] = 'A'; tabla[0, 1] = '0'; tabla[0,2] = 'B';
            tabla[1, 0] = 'A'; tabla[1, 1] = '"'; tabla[1, 2] = 'E';
            tabla[2, 0] = 'A'; tabla[2, 1] = 'a'; tabla[2, 2] = 'G';
            tabla[3, 0] = 'A'; tabla[3, 1] = '('; tabla[3, 2] = 'J';
            tabla[4, 0] = 'A'; tabla[4, 1] = '>'; tabla[4, 2] = 'L';
            tabla[5, 0] = 'A'; tabla[5, 1] = '<'; tabla[5, 2] = 'L';
            tabla[6, 0] = 'A'; tabla[6, 1] = '!'; tabla[6, 2] = 'L';
            tabla[7, 0] = 'A'; tabla[7, 1] = '='; tabla[7, 2] = 'L';
            tabla[8, 0] = 'A'; tabla[8, 1] = ';'; tabla[8, 2] = 'N';
            tabla[9, 0] = 'A'; tabla[9, 1] = '*'; tabla[9, 2] = 'N';
            tabla[10, 0] = 'A'; tabla[10, 1] = '+'; tabla[10, 2] = 'O';
            tabla[11, 0] = 'A'; tabla[11, 1] = '-'; tabla[11, 2] = 'Q';
            tabla[12, 0] = 'A'; tabla[12, 1] = '|'; tabla[12, 2] = 'S';
            tabla[13, 0] = 'A'; tabla[13, 1] = '&'; tabla[13, 2] = 'U';
            tabla[14, 0] = 'A'; tabla[14, 1] = '/'; tabla[14, 2] = 'W';

            tabla[16, 0] = 'B'; tabla[16, 1] = '0'; tabla[16, 2] = 'B';
            tabla[17, 0] = 'B'; tabla[17, 1] = '+'; tabla[17, 2] = 'A';
            tabla[18, 0] = 'B'; tabla[18, 1] = '-'; tabla[18, 2] = 'A';
            tabla[19, 0] = 'B'; tabla[19, 1] = '&'; tabla[19, 2] = 'A';
            tabla[20, 0] = 'B'; tabla[20, 1] = '('; tabla[20, 2] = 'A';
            tabla[21, 0] = 'B'; tabla[21, 1] = ')'; tabla[21, 2] = 'A';
            tabla[22, 0] = 'B'; tabla[22, 1] = '+'; tabla[22, 2] = 'A';
            tabla[23, 0] = 'B'; tabla[23, 1] = ' '; tabla[23, 2] = 'A';





        }

        private void reiniciar()
        {
            cadena = null;
            //estadoAhora = 'A';
        }
        public LinkedList<String> getResult()
        {
            return result;
        }
    }
}
