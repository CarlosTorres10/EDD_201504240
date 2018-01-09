using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.Estructuras.Matriz
{
    public class NodoMatrizBidimensional
    {
        public enum EUnidad
        {
            NEOSATELITE,
            BOMBARDERO,
            CAZA,
            HELICOPTERO,
            FRAGATA,
            CRUCERO,
            SUBMARINO
        }

        // Punteros de nodo
        NodoMatrizBidimensional anterior, siguiente, arriba, abajo;
        // Atributos de nodo
        EUnidad unidad;
        int movimiento;
        int alcance;
        int danio;
        int vida;
        string id;

        public NodoMatrizBidimensional(EUnidad unidad, int movimiento, int alcance, int danio, int vida, string id)
        {
            anterior = null;
            siguiente = null;
            arriba = null;
            abajo = null;
            this.Unidad = unidad;
            this.Movimiento = movimiento;
            this.Alcance = alcance;
            this.Danio = danio;
            this.Vida = vida;
            this.Id = id;
        }

        public NodoMatrizBidimensional(string id)
        {
            this.id = id;
        }

        public NodoMatrizBidimensional getAbajo()
        {
            return abajo;
        }

        public void setAbajo(NodoMatrizBidimensional abajo)
        {
            this.abajo = abajo;
        }

        public NodoMatrizBidimensional getAnterior()
        {
            return anterior;
        }

        public void setAnterior(NodoMatrizBidimensional anterior)
        {
            this.anterior = anterior;
        }

        public NodoMatrizBidimensional getArriba()
        {
            return arriba;
        }

        public void setArriba(NodoMatrizBidimensional arriba)
        {
            this.arriba = arriba;
        }

        public NodoMatrizBidimensional getSiguiente()
        {
            return siguiente;
        }

        public void setSiguiente(NodoMatrizBidimensional siguiente)
        {
            this.siguiente = siguiente;
        }

        public EUnidad Unidad
        {
            get
            {
                return unidad;
            }

            set
            {
                unidad = value;
            }
        }

        public int Movimiento
        {
            get
            {
                return movimiento;
            }

            set
            {
                movimiento = value;
            }
        }

        public int Alcance
        {
            get
            {
                return alcance;
            }

            set
            {
                alcance = value;
            }
        }

        public int Danio
        {
            get
            {
                return danio;
            }

            set
            {
                danio = value;
            }
        }

        public int Vida
        {
            get
            {
                return vida;
            }

            set
            {
                vida = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

    }
}
