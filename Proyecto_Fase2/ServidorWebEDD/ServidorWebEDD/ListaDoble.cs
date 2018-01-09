using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBDestino
{
    class ListaDoble
    {
        private NodoListaDoble primero;

        public NodoListaDoble getPrimero() {
            return primero;
        }

        public void setPrimero(NodoListaDoble primero) {
            this.primero = primero;
        }

        public Boolean ListaVacia() {
            return primero == null;
        }

        public void Insertar(int Codigo, string Nombre) {
            NodoListaDoble Nuevo = new NodoListaDoble(Codigo, Nombre);
            if (ListaVacia())
            {
                primero = Nuevo;
                primero.setSiguiente(null);
            }
            else {
                NodoListaDoble auxiliar = primero;
                while (auxiliar.getSiguiente() != null) {
                    auxiliar = auxiliar.getSiguiente();
                }
                auxiliar.setSiguiente(Nuevo);
                Nuevo.setAnterior(auxiliar);
            }
        }
        
    }
}
