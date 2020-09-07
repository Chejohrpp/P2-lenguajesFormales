using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace P1Lenguajes.Backend
{
    class LeerGT
    {
        public LeerGT()
        {

        }
        public void buscarGT(RichTextBox txtEditor)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Hola|*.gt";
            FlowDocument flowDocument = new FlowDocument();

            if (openFileDialog.ShowDialog() == true)
                flowDocument.Blocks.Add(new Paragraph(new Run(File.ReadAllText(openFileDialog.FileName))));
                txtEditor.Document = flowDocument;
        }

    }
    
}
