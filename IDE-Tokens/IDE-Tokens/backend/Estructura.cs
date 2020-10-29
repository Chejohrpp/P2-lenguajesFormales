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

        private LinkedList<String> resultErrores = new LinkedList<string>();

        public Estructura()
        {

        }

        public void errores()
        {
            
        }
        public LinkedList<String> getResultErrores()
        {
            return resultErrores;
        }
    }
}
