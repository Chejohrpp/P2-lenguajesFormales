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
        private char[] estadoAceptacion = {'D'};
        private Char[,] tabla = new Char[cantEstados, 3];
        private Boolean aceptable = false;
        private Boolean error = false;
        private String mensajeError;
        private String cadena;
        private Color color;
        public Automata()
        {
            funcionesTransicion();
            
        }
        private void palabrasReservadas(String cadena)
        {
           String[] palabrasReservadas = {"SI", "SINO,SINO_SI,MENTRAS,HACER,DESDE,HASTA,INCREMENTO" };
            foreach (String palabra in palabrasReservadas)
            {
                if (cadena.Equals(palabra, StringComparison.InvariantCultureIgnoreCase))
                {
                    color = Color.Green;
                }
            }
            if (cadena.Equals("entero", StringComparison.InvariantCultureIgnoreCase))
            {
                color = Color.Purple;
            }
            if (cadena.Equals("decimal", StringComparison.InvariantCultureIgnoreCase))
            {
                color = Color.SkyBlue;
            }
            if (cadena.Equals("cadena", StringComparison.InvariantCultureIgnoreCase))
            {
                color = Color.Gray;
            }
            if (cadena.Equals("booleano", StringComparison.InvariantCultureIgnoreCase))
            {
                color = Color.Orange;
            }
            if (cadena.Equals("verdadero", StringComparison.InvariantCultureIgnoreCase))
            {
                color = Color.Orange;
            }
            if (cadena.Equals("falso", StringComparison.InvariantCultureIgnoreCase))
            {
                color = Color.Orange;
            }
            if (cadena.Equals("caracter", StringComparison.InvariantCultureIgnoreCase))
            {
                color = Color.Brown;
            }
            
        }
        public void cambiarcolor(System.Windows.Forms.RichTextBox txtEditor)
        {
            if (aceptable)
            {
                txtEditor.Find(cadena);
                txtEditor.SelectionColor = color;
            }
            else
            {
                txtEditor.Find(cadena);
                txtEditor.SelectionColor = Color.Black;
            }
        }

        public String cambiarEstado(char charEvaluar)
        {
            errores(charEvaluar);

            for (int i = 0; i < cantEstados; i++)
            {
                if (tabla[i, 0].Equals(estadoAhora) && tabla[i, 1].Equals(charEvaluar))
                {
                    cadena = cadena + charEvaluar;
                    estadoAnterior = estadoAhora;
                    estadoAhora = tabla[i, 2];
                    verificar();

                    return resultado(charEvaluar);
                }
            }

            error = true;
            mensajeError = "No hay tansicion con " + charEvaluar;
            return mensajeError;

        }
        private void verificar()
        {
            for (int i = 0; i < estadoAceptacion.Length; i++)
            {
                if (estadoAhora.Equals(estadoAceptacion[i]))
                {
                    aceptable = true;
                }
                else
                {
                    aceptable = false;
                    BuscarColor();
                }
            }

            if (estadoAhora.Equals('A'))
            {
                reiniciar();
            }
        }
        private void BuscarColor()
        {
           
            
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
            
            tabla[0, 0] = 'A'; tabla[0, 1] = ';'; tabla[0,2] = 'A';
            tabla[1, 0] = 'A'; tabla[1, 1] = ' '; tabla[1, 2] = 'A';

            tabla[2, 0] = 'B'; tabla[2, 1] = '0'; tabla[2, 2] = 'C';
            tabla[3, 0] = 'B'; tabla[3, 1] = '1'; tabla[3, 2] = 'D';

            tabla[4, 0] = 'C'; tabla[4, 1] = 'Ñ'; tabla[4, 2] = 'C';
            tabla[5, 0] = 'C'; tabla[5, 1] = '1'; tabla[5, 2] = 'B';

            tabla[6, 0] = 'D'; tabla[6, 1] = '0'; tabla[6, 2] = 'C';
            tabla[7, 0] = 'D'; tabla[7, 1] = '1'; tabla[7, 2] = 'D';


        }

        private void reiniciar()
        {
            cadena = null;
            estadoAhora = 'A';
        }
    }
}
