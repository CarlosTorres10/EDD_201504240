using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBDestino
{
    class NodoListaDoble
    {
        private int Codigo;
        private string Nombre;
        NodoListaDoble Anterior;
        NodoListaDoble Siguiente;

        public NodoListaDoble(int Codigo, string Nombre) {
            this.Codigo = Codigo;
            this.Nombre = Nombre;

        }

        public int getCodigo() {
            return Codigo;
        }

        public void setCodigo(int Codigo) {
            this.Codigo = Codigo;
        }

        public string getNombre() {
            return Nombre;
        }

        public void setNombre(string Nombre) {
            this.Nombre = Nombre;
        }

        public NodoListaDoble getAnterior() {
            return Anterior;
        }

        public void setAnterior(NodoListaDoble Anterior) {
            this.Anterior = Anterior;
        }

        public NodoListaDoble getSiguiente() {
            return Siguiente;
        }

        public void setSiguiente(NodoListaDoble Siguiente) {
            this.Siguiente = Siguiente;
        }

    }
}
