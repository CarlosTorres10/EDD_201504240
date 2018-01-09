using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBDestino
{
    class SolucionDijkstra
    {
        int tam;
        decimal[,] ma;
        int ori;
        Paso[,] mSolucion;
        public SolucionDijkstra(int tam, decimal[,] matriz, int origen) {
            this.tam = tam;
            this.ma = matriz;
            this.ori = origen;
        }
    }
}
