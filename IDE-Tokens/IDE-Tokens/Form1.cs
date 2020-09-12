using IDE_Tokens.backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE_Tokens
{
    public partial class Form1 : Form
    {
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

        private void btnCompilar_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
