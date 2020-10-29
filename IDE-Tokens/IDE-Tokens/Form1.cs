using IDE_Tokens.backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;



namespace IDE_Tokens
{
    public partial class Form1 : Form
    {
        LinkedList<String> resul = new LinkedList<string>();
        public Form1()
        {
            InitializeComponent();

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpcionesArchivo opciones = new OpcionesArchivo();
            opciones.abrir(txtEditor);
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpcionesArchivo opciones = new OpcionesArchivo();
            opciones.guardar(txtEditor);
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //compilamos el codigo
        private void compilar()
        {
            listaResult.Items.Clear();
            String cadena = txtEditor.Text;
            Automata automata = new Automata();
            

            for (int i = 0; i < cadena.Length; i++)
            {
                char caracter = cadena[i];
                automata.cambiarEstado(caracter, txtEditor, i);                
            }

             resul = automata.getResult();
            if (resul.Count == 0)
            {
                listaResult.Items.Add("No hay problemas");
            }
            foreach (String respuestas in resul)
            {
                listaResult.Items.Add(respuestas);
            }
            
        }

        private void btnCompilar_Click(object sender, EventArgs e)
        {
            compilar();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            compilar();
            txtEditor.Select(txtEditor.Text.Length, txtEditor.Text.Length);
                
        }       

        private void txtEditor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
        }

        private void txtEditor_KeyDown(object sender, KeyEventArgs e)
        {
            /*PositionCursor position = new PositionCursor();
            int x = position.positionX(txtEditor);
            int y = position.positionY(txtEditor);
            int star = txtEditor.SelectionStart;
            int ok = txtEditor.GetPositionFromCharIndex(txtEditor.SelectionStart).X;
            int xx = txtEditor.GetCharIndexFromPosition(txtEditor.GetPositionFromCharIndex(txtEditor.SelectionStart));
            int yy = txtEditor.PointToClient(new Point(x, y)).Y;            
            lblColumna.Text = star.ToString();
            lblFila.Text = xx.ToString();*/
            
        }

        private void txtEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void exportarElLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpcionesArchivo opciones = new OpcionesArchivo();
            opciones.exportarLog(resul);
        }

        private void archioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    
}
