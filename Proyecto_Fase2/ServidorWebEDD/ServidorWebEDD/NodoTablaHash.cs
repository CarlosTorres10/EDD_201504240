using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorWebEDD
{
    class NodoTablaHash
    {
        private String nombre;
        private bool usada;

        public NodoTablaHash(bool usada)
        {
            this.usada = usada;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public bool isUsada()
        {
            return usada;
        }

        public void setUsada(bool usada)
        {
            this.usada = usada;
        }

        public void nuevo(String nombre)
        {
            setNombre(nombre);
        }
    }
}