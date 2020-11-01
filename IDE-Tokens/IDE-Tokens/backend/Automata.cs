﻿using System;
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
        private static int cantEstados=49;
        private char[] abecedario = { '0', 'a', '"', '(', '>', '+', '-', '*', '/', '<', '!', '|', '&', ')', ';', ' ', '_', '=', '.', '}', '{',',' };
        private char estadoAhora = 'A';
        private char estadoAnterior = 'A';
        private char[] estadoAceptacion = {'B','D','F','E','G','H','J','K','L','N','O','Q','W','Ñ','Z','X','Y'};
        private Char[,] tabla = new Char[cantEstados, 3];
        private Boolean aceptable = false;
        private Boolean error = false;
        private Boolean noCont2VecesError = false;
        private String mensajeError;
        private String cadena;
        private Color color = Color.Black;
        private LinkedList<String> result = new LinkedList<string>();
        private LinkedList<String> cadenaTokens = new LinkedList<string>();
        private LinkedList<String> resultEstructura = new LinkedList<string>();
        int inicio = 0;
        int lineas=1;
        public Automata()
        {
            funcionesTransicion();
            
        }
        private void cambiarTokensEspecificos()
        {
            cadenaTokens.RemoveLast();
            String token = estadoAhora.ToString();
            cadenaTokens.AddLast(token);
        }
        //aqui estan las palabras que tienen un color en especifico
        private Color palabrasReservadas()
        {
            String cadena1 = cadena.Trim();
           String[] palabrasReservadas = {"SI", "SINO","SINO_SI","MIENTRAS","HACER","DESDE","HASTA","INCREMENTO","principal","imprimir","leer" };
            foreach (String palabra in palabrasReservadas)
            {
                if (cadena1.Equals(palabra, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (cadena1.Equals("principal", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = '@';
                        cambiarTokensEspecificos();
                    }                    
                    
                    if (cadena1.Equals("sino_si", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'é';
                        cambiarTokensEspecificos();
                    }
                    if (cadena1.Equals("sino", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'ü';
                        cambiarTokensEspecificos();
                    }
                    if (cadena1.Equals("si", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'Ç';
                        cambiarTokensEspecificos();
                    }

                    if (cadena1.Equals("mientras", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'â';
                        cambiarTokensEspecificos();
                    }
                     if (cadena1.Equals("hacer", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'ä';
                        cambiarTokensEspecificos();
                    }
                     if (cadena1.Equals("desde", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'à';
                        cambiarTokensEspecificos();
                    }
                     if (cadena1.Equals("hasta", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'å';
                        cambiarTokensEspecificos();
                    }
                     if (cadena1.Equals("incremento", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'ç';
                        cambiarTokensEspecificos();
                    }
                     if (cadena1.Equals("imprimir", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'ê';
                        cambiarTokensEspecificos();
                    }
                     if (cadena1.Equals("leer", StringComparison.InvariantCultureIgnoreCase))
                    {
                        estadoAhora = 'ë';
                        cambiarTokensEspecificos();
                    }

                    return Color.Green;
                }
            }
            if (cadena1.Equals("entero", StringComparison.InvariantCultureIgnoreCase))
            {
                estadoAhora = 'è';
                cambiarTokensEspecificos();
                return Color.Purple;
            }
            if (cadena1.Equals("decimal", StringComparison.InvariantCultureIgnoreCase))
            {
                estadoAhora = 'è';
                cambiarTokensEspecificos();
                return Color.SkyBlue;
            }
            if (cadena1.Equals("cadena", StringComparison.InvariantCultureIgnoreCase))
            {
                estadoAhora = 'è';
                cambiarTokensEspecificos();
                return Color.Gray;
            }
            if (cadena1.Equals("booleano", StringComparison.InvariantCultureIgnoreCase))
            {
                estadoAhora = 'è';
                cambiarTokensEspecificos();
                return Color.Orange;
            }
            if (cadena1.Equals("verdadero", StringComparison.InvariantCultureIgnoreCase))
            {
                estadoAhora = 'ì';
                cambiarTokensEspecificos();
                return Color.Orange;
            }
            if (cadena1.Equals("falso", StringComparison.InvariantCultureIgnoreCase))
            {
                estadoAhora = 'ì';
                cambiarTokensEspecificos();
                return Color.Orange;
            }
            if (cadena1.Equals("caracter", StringComparison.InvariantCultureIgnoreCase))
            {
                estadoAhora = 'è';
                cambiarTokensEspecificos();
                return Color.Brown;
            }
            return Color.Black;
        }

        //se cambian todos los colores que tiene la cadena creada y se configura en el RichTextBox
        public void cambiarcolor(int inicio,System.Windows.Forms.RichTextBox txtEditor)
        {
            if (aceptable)
            {
                BuscarColor();
                txtEditor.Select(inicio, cadena.Length);
                txtEditor.SelectionColor = color;
            }
            else
            {
                txtEditor.Select(inicio, cadena.Length);
                txtEditor.SelectionColor = Color.Black;
            }

        }

        //evalua el caracter siguiente y cambia el estado al que pertenece
        public void cambiarEstado(char charEvaluar, System.Windows.Forms.RichTextBox txtEditor, int inicio)
        {
            
            char auxChar = charEvaluar; //usaremos esta variable para evaluar todoas las posibles opciones 
            excepciones();
            int ascci = Encoding.ASCII.GetBytes(charEvaluar.ToString())[0];//encontramos el assci del caracter
            if (ascci == 10 && noCont2VecesError == false)
            {
                lineas++;//con esto contaremos cuantas lineas tiene el documento
            }
            if (estadoAhora.Equals('A'))
            {
                this.inicio = inicio;
            }
            //verificamos si es un numero
            if (char.IsNumber(charEvaluar))
            {
                auxChar = '0';
            }
            else
            {           
                //vemos si el caracter evualuado esta entre el rando de A-Z o a-z
                if ((ascci >= 65 && ascci <= 90) || (ascci >= 97 && ascci <= 122) || ascci == 164 || ascci == 165 || ascci == 63)
                {
                    auxChar = 'a';
                }
                else if (estadoAhora.Equals('Y') && ascci >=0 && ascci != 47)
                {
                    auxChar = 'a';
                }
                
            }
            
            for (int i = 0; i < cantEstados; i++)
            {
                //buscamos en la tabla de transicion el estado a donde pertenece el caracter
                if (tabla[i, 0].Equals(estadoAhora) && tabla[i, 1].Equals(auxChar))
                {
                    error = false;
                    estadoAnterior = estadoAhora;
                    estadoAhora = tabla[i, 2];
                    verificar();
                    String resultad = resultado(charEvaluar);
                    //result.AddLast(resultad);
                    break;
                }
                else
                {
                    error = true;
                }
            }


            //para agregar los tokens
            String token;
            if (cadenaTokens.Count == 0)
            {
                token = estadoAhora.ToString();
                cadenaTokens.AddLast(token);
            }
            else if (estadoAhora != 'A' && error == true && estadoAhora != 'E' && estadoAhora != 'X' && estadoAhora != 'Ñ' || estadoAhora=='F')
            {
                token = estadoAhora.ToString();
                cadenaTokens.AddLast(token);
            }
            else
            {
                cadenaTokens.RemoveLast();
                token = estadoAhora.ToString();
                cadenaTokens.AddLast(token);

            }


            //si no encontramos una transicion en el estado que estamos y los estados son diferentes A,E y X
            if (estadoAhora != 'A' && error == true && estadoAhora != 'E' && estadoAhora != 'X' && estadoAhora != 'Ñ')
            {
                estadoAhora = 'A'; error = false;
            }  

            if (estadoAhora.Equals('A') && error == false) 
            {
                reiniciar();
                noCont2VecesError = true;//hace que no contemos 2 veces el error por si lo hay
                cambiarEstado(charEvaluar, txtEditor,inicio);//evaluamos de nuevo el caracter
            }
            else
            {
                cadena = cadena + charEvaluar;
                cambiarcolor(this.inicio,txtEditor);//cambiamos el color de la cadena

            }

            if (estadoAhora.Equals('Ñ') && ascci == 10)
            {
                reiniciar();
            } 
            


            if (error)
            {
                //vemos si hay errores y los agregamos en la lista de errores
                if (estadoAhora.Equals('A') && noCont2VecesError == false)
                {
                    //mensajeError = "No hay tansicion con " + charEvaluar;
                    errores(charEvaluar, auxChar);
                }
                else
                {
                    
                }
                
            }


            if (noCont2VecesError == false)
            {
                Estructura estructura = new Estructura(cadenaTokens);
                resultEstructura = estructura.getAutomata();
            }
            
         

            noCont2VecesError = false;//reiniciamos el contador de error

        }
        //veririficamos si estamos en un estado de aceptacion
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
        //buscamos el color del dato que estamos evaluando
        private void BuscarColor()
        {
            if (estadoAhora.Equals('B'))
            {
                color = Color.DarkViolet;
            }
            else if (estadoAhora.Equals('O'))
            {
                color = Color.DarkBlue;
            }
            else if (estadoAhora.Equals('G'))
            {
                color = Color.Brown;
            }
            else if (estadoAhora.Equals('H'))
            {
                color = palabrasReservadas();
            }
            else if (estadoAhora.Equals('E'))
            {
                color = Color.Gray;
            }
            else if (estadoAhora.Equals('F'))
            {
                color = Color.Gray;
            }
            else if (estadoAhora.Equals('N'))
            {
                color = Color.DarkBlue;
            }
 
            else if (estadoAhora.Equals('Q'))
            {
                color = Color.DarkBlue;
            }
            else if (estadoAhora.Equals('W'))
            {
                color = Color.DarkBlue;
            }
            else if (estadoAhora.Equals('D'))
            {
                color = Color.SkyBlue;
            }
            else if (estadoAhora.Equals('J'))
            {
                estadoAhora = '=';
                cambiarTokensEspecificos();
                color = Color.Pink;
            }
            else if (estadoAhora.Equals('K'))
            {
                estadoAhora = ';';
                cambiarTokensEspecificos();
                color = Color.Pink;
            }
            else if (estadoAhora.Equals('L'))
            {

                color = Color.DarkBlue;
            }
            else if (estadoAhora.Equals('Ñ'))
            {
                color = Color.Red;
            }
            else if (estadoAhora.Equals('Z'))
            {
                color = Color.Red;
            }
            else if (estadoAhora.Equals('X'))
            {
                color = Color.Red;
            }
            else if (estadoAhora.Equals('Y'))
            {
                color = Color.Red;
            }
            else
            {
                color = Color.Black;
            }
            
        }
        //verificamos si hay errores
        private void errores(char charEvaluar, char auxChar)
        {
            for (int i = 0; i < abecedario.Length ; i++)
            {
                if (auxChar.Equals(abecedario[i]) || Encoding.ASCII.GetBytes(charEvaluar.ToString())[0] == 10 )
                {
                    error = false;
                    break;
                }
                else
                {
                    error = true;                    
                }
            }

            if (error)
            {
                mensajeError = "Problema en la linea: "+ lineas +" El " + charEvaluar + " No existe en el abecedario";
                //mensajeError = "Problemas con " + charEvaluar;
                result.AddLast(mensajeError);
            }

        }
        //creamos una cadena mostrando como se cambia entre estados con el caracter evaluado
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
        //aqui estan todas las funciones de transicion
        public void funcionesTransicion()
        {
            
            
            tabla[0, 0] = 'A'; tabla[0, 1] = '0'; tabla[0,2] = 'B';
            tabla[1, 0] = 'A'; tabla[1, 1] = '"'; tabla[1, 2] = 'E';
            tabla[2, 0] = 'A'; tabla[2, 1] = 'a'; tabla[2, 2] = 'G';
            tabla[3, 0] = 'A'; tabla[3, 1] = '('; tabla[3, 2] = '(';            
            tabla[4, 0] = 'A'; tabla[4, 1] = '>'; tabla[4, 2] = '>';
            tabla[5, 0] = 'A'; tabla[5, 1] = '<'; tabla[5, 2] = '<';
            tabla[6, 0] = 'A'; tabla[6, 1] = '!'; tabla[6, 2] = '!';
            tabla[7, 0] = 'A'; tabla[7, 1] = '='; tabla[7, 2] = 'J';
            tabla[8, 0] = 'A'; tabla[8, 1] = ';'; tabla[8, 2] = 'K';    
            tabla[9, 0] = 'A'; tabla[9, 1] = '*'; tabla[9, 2] = 'N';
            tabla[10, 0] = 'A'; tabla[10, 1] = '+'; tabla[10, 2] = '+';
            tabla[11, 0] = 'A'; tabla[11, 1] = '-'; tabla[11, 2] = '-';
            tabla[12, 0] = 'A'; tabla[12, 1] = '|'; tabla[12, 2] = '|';
            tabla[13, 0] = 'A'; tabla[13, 1] = '&'; tabla[13, 2] = '&';
            tabla[14, 0] = 'A'; tabla[14, 1] = '/'; tabla[14, 2] = 'W'; 
            tabla[15, 0] = 'A'; tabla[15, 1] = ')'; tabla[15, 2] = ')';

            tabla[45, 0] = 'A'; tabla[45, 1] = '{'; tabla[45, 2] = '{';
            tabla[46, 0] = 'A'; tabla[46, 1] = '}'; tabla[46, 2] = '}';
            tabla[47, 0] = 'A'; tabla[47, 1] = '_'; tabla[47, 2] = '_';
            tabla[48, 0] = 'A'; tabla[48, 1] = ','; tabla[48, 2] = ',';//48 es el mas grande

            tabla[16, 0] = 'B'; tabla[16, 1] = '0'; tabla[16, 2] = 'B';
            
            tabla[18, 0] = 'Ç'; tabla[18, 1] = 'a'; tabla[18, 2] = 'H';
            tabla[19, 0] = 'ü'; tabla[19, 1] = '_'; tabla[19, 2] = 'H';
            
            //tabla[21, 0] = 'B'; tabla[21, 1] = ')'; tabla[21, 2] = 'A';
            //tabla[22, 0] = 'B'; tabla[22, 1] = '+'; tabla[22, 2] = 'A';
            //tabla[23, 0] = 'B'; tabla[23, 1] = ' '; tabla[23, 2] = 'A';

            tabla[24, 0] = 'B'; tabla[24, 1] = '.'; tabla[24, 2] = 'C';

            tabla[25, 0] = 'C'; tabla[25, 1] = '0'; tabla[25, 2] = 'D';

            tabla[26, 0] = 'D'; tabla[26, 1] = '0'; tabla[26, 2] = 'D';

            tabla[27, 0] = 'E'; tabla[27, 1] = '"'; tabla[27, 2] = 'F';


            tabla[28, 0] = 'G'; tabla[28, 1] = '0'; tabla[28, 2] = 'H';
            tabla[29, 0] = 'G'; tabla[29, 1] = 'a'; tabla[29, 2] = 'H';

            tabla[30, 0] = 'H'; tabla[30, 1] = '0'; tabla[30, 2] = 'H';
            tabla[31, 0] = 'H'; tabla[31, 1] = 'a'; tabla[31, 2] = 'H';

            //tabla[20, 0] = 'ü'; tabla[20, 1] = '_'; tabla[20, 2] = 'H';

            tabla[17, 0] = '_'; tabla[17, 1] = '0'; tabla[17, 2] = '_';
            tabla[32, 0] = '_'; tabla[32, 1] = 'a'; tabla[32, 2] = '_';

            //tabla[33, 0] = '='; tabla[33, 1] = '='; tabla[33, 2] = 'N';

            //tabla[34, 0] = 'L'; tabla[34, 1] = '='; tabla[34, 2] = 'N';

            tabla[35, 0] = 'O'; tabla[35, 1] = '+'; tabla[35, 2] = 'N';

            tabla[36, 0] = 'Q'; tabla[36, 1] = '-'; tabla[36, 2] = 'N';

            tabla[37, 0] = 'S'; tabla[37, 1] = '|'; tabla[37, 2] = 'N';

            tabla[38, 0] = 'U'; tabla[38, 1] = '&'; tabla[38, 2] = 'N';

            tabla[39, 0] = 'W'; tabla[39, 1] = '/'; tabla[39, 2] = 'Ñ';
            tabla[40, 0] = 'W'; tabla[40, 1] = '*'; tabla[40, 2] = 'X';

            tabla[41, 0] = 'X'; tabla[41, 1] = '*'; tabla[41, 2] = 'Y';

            tabla[42, 0] = 'Y'; tabla[42, 1] = '/'; tabla[42, 2] = 'Z';
            tabla[43, 0] = 'Y'; tabla[43, 1] = '0'; tabla[43, 2] = 'X';
            tabla[44, 0] = 'Y'; tabla[44, 1] = 'a'; tabla[44, 2] = 'X';


        }
        //hay estados que se comportan diferente y necesitan un reinicio forzado, aqui se almacenan
        private void excepciones()
        {
            if (estadoAhora.Equals('F'))
            {
                reiniciar();
            }
            if (estadoAhora.Equals('Z'))
            {
                reiniciar();
            }
        }
        //regresamos al estado A y borramos todo lo que tenia la cadena
        private void reiniciar()
        {
            cadena = null;
            estadoAhora = 'A';
        }
        //devuelve la lista de errores
        public LinkedList<String> getResult()
        {
            return result;
        }

        public LinkedList<String> getCadenaTokens()
        {
            return cadenaTokens;
        }
        public LinkedList<String> getResultEstructura()
        {
            return resultEstructura;
        }
    }
}
