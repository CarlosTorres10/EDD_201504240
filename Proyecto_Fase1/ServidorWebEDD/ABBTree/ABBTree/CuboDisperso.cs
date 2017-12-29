using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBTree
{
   public class CuboDisperso
    {
        public NodoDisperso x;
        public NodoDisperso y;
        public NodoDisperso cabecera;


        public CuboDisperso()
        {
            x = null;
            y = null;
            cabecera = null;
        }
        
        public void Insertar(String Dato, NodoDisperso x, NodoDisperso y)
        {

        }
        
        private void crear_cabeceras(NodoDisperso x, NodoDisperso y)
        {
            if (cabecera.getDerecha() == null)
            {
                NodoDisperso nuevo = new NodoDisperso(null, x, cabecera, null, null, null, null);
            }
        }


    }
}
