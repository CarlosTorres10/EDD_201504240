using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBDestino
{
    class Paso
    {
        public decimal distancia;
        public int origen;
        public int nodoOrigen;
        public int destino;
        public bool seleccionado;

        public Paso(decimal dis, int ori, int des, int nodoOri, bool sel) {
            distancia = dis;
            origen = ori;
            destino = des;
            seleccionado = sel;
            nodoOrigen = nodoOri;
        }
    }
}
