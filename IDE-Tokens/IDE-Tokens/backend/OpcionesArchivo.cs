using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace IDE_Tokens.backend
{
    class OpcionesArchivo
    {
        public OpcionesArchivo()
        {

        }
        public void abrir(RichTextBox txtEditor)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Hola|*.gt";
            FlowDocument flowDocument = new FlowDocument();
            //Leemos el documento
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.OpenFile()))
                {
                    txtEditor.Text = reader.ReadToEnd();
                }

            }
        }
    }
}
