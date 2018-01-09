using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBDestino
{
    public class NodoMatriz
    {
        private int CodigoPrimerPais;
        private int CodigosegundoPais;
        private float Costo;
        private float Tiempo;
        private NodoMatriz AnteriorMatriz;
        private NodoMatriz SiguienteMatriz;
        private NodoMatriz AribaMatriz;
        private NodoMatriz AbajoMatriz;
        private NodoRamaArbol IzquierdaCabecera;
        private NodoRamaArbol ArribaCabecera;


        public NodoMatriz(int PrimerPais, int SegundoPais, float Costo, float Tiempo) {
            this.CodigoPrimerPais = PrimerPais;
            this.CodigosegundoPais = SegundoPais;
            this.Costo = Costo;
            this.Tiempo = Tiempo;
            this.AnteriorMatriz = null;
            this.SiguienteMatriz = null;
            this.AribaMatriz = null;
            this.AbajoMatriz = null;
        }
        public int getCodigoPrimerPais(){
            return CodigoPrimerPais;
        }
        public void setCodigoPrimerPais(int CodigoPrimerPais)
        {
            this.CodigoPrimerPais = CodigoPrimerPais;
        }
        public int getCodigosegundoPais()
        {
            return CodigosegundoPais;
        }
        public void setCodigosegundoPais(int CodigosegundoPais)
        {
            this.CodigosegundoPais = CodigosegundoPais;
        }
        public float getCosto()
        {
            return Costo;
        }
        public void setCosto(float Costo)
        {
            this.Costo = Costo;
        }
        public float getTiempo()
        {
            return Tiempo;
        }
        public void setTiempo(float Tiempo)
        {
            this.Tiempo = Tiempo;
        }
        public NodoMatriz getAnteriorMatriz()
        {
            return AnteriorMatriz;
        }
        public void setAnteriorMatriz(NodoMatriz AnteriorMatriz)
        {
            this.AnteriorMatriz = AnteriorMatriz;
        }
        public NodoMatriz getSiguienteMatriz()
        {
            return SiguienteMatriz;
        }
        public void setSiguienteMatriz(NodoMatriz SiguienteMatriz)
        {
            this.SiguienteMatriz = SiguienteMatriz;
        }
        //
        public NodoMatriz getAribaMatriz()
        {
            return AribaMatriz;
        }
        public void setAribaMatriz(NodoMatriz AribaMatriz)
        {
            this.AribaMatriz = AribaMatriz;
        }
        public NodoMatriz getAbajoMatriz()
        {
            return AbajoMatriz;
        }
        public void setAbajoMatriz(NodoMatriz AbajoMatriz)
        {
            this.AbajoMatriz = AbajoMatriz;
        }
        //
        public NodoRamaArbol getIzquierdaCabecera()
        {
            return IzquierdaCabecera;
        }
        public void setIzquierdaCabecera(NodoRamaArbol IzquierdaCabecera)
        {
            this.IzquierdaCabecera = IzquierdaCabecera;
        }
        public NodoRamaArbol getArribaCabecera()
        {
            return ArribaCabecera;
        }
        public void setArribaCabecera(NodoRamaArbol ArribaCabecera)
        {
            this.ArribaCabecera = ArribaCabecera;
        }
    }
}
