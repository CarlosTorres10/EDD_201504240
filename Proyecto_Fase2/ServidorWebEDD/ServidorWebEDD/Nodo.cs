using Cubo.Estructuras.Matriz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.Estructuras.Cubo
{
    public class Nodo
    {
        MatrizBidimensional cara;
        Nodo siguiente;

        public Nodo(MatrizBidimensional cara)
        {
            this.cara = cara;
        }
        public MatrizBidimensional Cara
        {
            get
            {
                return cara;
            }

            set
            {
                cara = value;
            }
        }

        public Nodo Siguiente
        {
            get
            {
                return siguiente;
            }

            set
            {
                siguiente = value;
            }
        }
    }
}
