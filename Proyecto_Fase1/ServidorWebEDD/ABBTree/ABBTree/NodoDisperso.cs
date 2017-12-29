using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBTree
{
    public class NodoDisperso
    {
        private String Dato;
        private NodoDisperso Izquierda;
        private NodoDisperso Derecha;
        private NodoDisperso Arriba;
        private NodoDisperso Abajo;
        private NodoDisperso Frente;
        private NodoDisperso Atras;


        public NodoDisperso(String Dato, NodoDisperso Izquierda, NodoDisperso Derecha, NodoDisperso Arriba, NodoDisperso Abajo, NodoDisperso Frente, NodoDisperso Atras)
        {
            this.Dato = Dato;
            this.Izquierda = Izquierda;
            this.Derecha = Derecha;
            this.Arriba = Arriba;
            this.Abajo = Abajo;
            this.Frente = Frente;
            this.Atras = Atras;
        }

        public string getDato()
        {
            return Dato;
        }
        public void setDato(String Dato)
        {
            this.Dato = Dato;
        }

        public NodoDisperso getIzquierda()
        {
            return Izquierda;
        }
        public void setIzquierda(NodoDisperso Izquierda)
        {
            this.Izquierda = Izquierda;
        }

        public NodoDisperso getDerecha()
        {
            return Derecha;
        }
        public void setDerecha(NodoDisperso Derecha)
        {
            this.Derecha = Derecha;
        }

        public NodoDisperso getArriba()
        {
            return Arriba;
        }
        public void setArriba(NodoDisperso Arriba)
        {
            this.Arriba = Arriba;
        }

        public NodoDisperso getAbajo()
        {
            return Abajo;
        }
        public void setAbajo(NodoDisperso Abajo)
        {
            this.Abajo = Abajo;
        }

        public NodoDisperso getFrente()
        {
            return Frente;
        }
        public void setFrente(NodoDisperso Frente)
        {
            this.Frente = Frente;
        }

        public NodoDisperso getAtras()
        {
            return Atras;
        }
        public void setAtras(NodoDisperso Atras)
        {
            this.Atras = Atras;
        }
    }

}
