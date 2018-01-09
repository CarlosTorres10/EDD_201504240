using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cubo.Estructuras.Matriz;

namespace Cubo.Estructuras.Cubo
{
    public class CuboTridimensional
    {
        Nodo inicio;
        public CuboTridimensional()
        {
            inicio = null;
        }

        public void insertarCara(MatrizBidimensional cara)
        {
            Nodo nuevo = new Nodo(cara);
            nuevo.Siguiente = inicio;
            inicio = nuevo;
        }

        public bool estaVacia()
        {
            return inicio == null;
        }

        public void setValor(int movimiento, int vida, int fila, int col, int nivel)
        {
            Nodo aux = inicio;
            if (estaVacia())
                return;
            for (int i = 0; i < nivel; i++, aux = aux.Siguiente) { }
            aux.Cara.setValor(movimiento, vida, fila, col);
        }

        
        public NodoMatrizBidimensional getValor(int fila, int col, int nivel)
        {
            Nodo aux = inicio;
            if (estaVacia())
                return null;
            for (int i = 0; i < nivel; i++, aux = aux.Siguiente) { }
            return aux.Cara.getNodo(fila, col);
        }


        public void graficar(int nivel)
        {
            Nodo aux = inicio;
            if (estaVacia())
                return;
            for (int i = 0; i < nivel; i++, aux = aux.Siguiente) { }
            aux.Cara.grafica("Reporte" + nivel);
        }

    }
}
