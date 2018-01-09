using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBDestino
{
    public class NodoRamaArbol
    {

        private int codigoDestino;
        private String nombreDestino;
        private NodoRamaArbol anterior, siguiente;
        private RamaArbol derecha, izquierda;
        private NodoMatriz FilaPrimero;
        private NodoMatriz ColumnaPrimero;

        public NodoRamaArbol(int codDes, String nomDes)
        {
            this.codigoDestino = codDes;
            this.nombreDestino = nomDes;
        }


        public int getCodigoDestino()
        {
            return codigoDestino;
        }

        public void setCodigoDestino(int codDes)
        {
            this.codigoDestino = codDes;
        }

        public String getNombreDestino()
        {
            return nombreDestino;
        }

        public void setNombreDestino(String nomDes)
        {
            this.nombreDestino=nomDes;
        }   

        /**
         *
         * @return
         */

        public NodoMatriz getFilaPrimero()
        {
            return FilaPrimero;
        }

        /**
         *
         * @param anterior
         */
        public void setFilaPrimero(NodoMatriz FilaPrimero)
        {
            this.FilaPrimero = FilaPrimero;
        }

        public NodoMatriz getColumnaPrimero()
        {
            return ColumnaPrimero;
        }

        /**
         *
         * @param anterior
         */
        public void setColumnaPrimero(NodoMatriz ColumnaPrimero)
        {
            this.ColumnaPrimero = ColumnaPrimero;
        }


        public NodoRamaArbol getAnterior()
        {
            return anterior;
        }

        /**
         *
         * @param anterior
         */
        public void setAnterior(NodoRamaArbol anterior)
        {
            this.anterior = anterior;
        }

        /**
         *
         * @return
         */
        public NodoRamaArbol getSiguiente()
        {
            return siguiente;
        }

        /**
         *
         * @param siguiente
         */
        public void setSiguiente(NodoRamaArbol siguiente)
        {
            this.siguiente = siguiente;
        }

        /**
         *
         * @return
         */
        public RamaArbol getDerecha()
        {
            return derecha;
        }

        /**
         *
         * @param derecha
         */
        public void setDerecha(RamaArbol derecha)
        {
            this.derecha = derecha;
        }

        /**
         *
         * @return
         */
        public RamaArbol getIzquierda()
        {
            return izquierda;
        }

        /**
         *
         * @param izquierda
         */
        public void setIzquierda(RamaArbol izquierda)
        {
            this.izquierda = izquierda;
        }

    }

}
