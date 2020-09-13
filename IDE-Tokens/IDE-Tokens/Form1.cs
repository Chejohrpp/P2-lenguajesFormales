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

        private void txtEditor_TextChanged(object sender, EventArgs e)
        {
            /*PositionCursor position = new PositionCursor();
            lblFila.Text = "Fila: " + position.positionY(txtEditor).ToString();
            lblColumna.Text = "Columna: " + position.positionX(txtEditor).ToString();*/
        }
        private void txtEditor_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Declare the string to search for in the control.
            //string searchString = "brown";

            // Determine whether the user clicks the left mouse button and whether it is a double click.
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                // Obtain the character index where the user clicks on the control.
                int positionToSearch = txtEditor.GetCharIndexFromPosition(new Point(e.X, e.Y));
                lblFila.Text = positionToSearch.ToString();
                // Search for the search string text within the control from the point the user clicked.
                int textLocation = txtEditor.Find(txtEditor.Text, positionToSearch, RichTextBoxFinds.None);
                lblColumna.Text = textLocation.ToString();
                // If the search string is found (value greater than -1), display the index the string was found at.
                if (textLocation >= 0)
                    MessageBox.Show("The search string was found at character index " + textLocation.ToString() + ".");
                //else
                    // Display a message box alerting the user that the text was not found.
                    //MessageBox.Show("The search string was not found within the text of the control.");
            }
        }

    }
    
}
