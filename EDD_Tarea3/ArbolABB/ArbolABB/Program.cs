using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolABB
{
    public class ArbolBinarioBusqueda {

        class Nodo {
            public int dato;
       
            public Nodo izq, der;
        }
        Nodo Raiz;

        public ArbolBinarioBusqueda() {
            Raiz = null;
        }

        public void Insertar(int dato) {
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.dato = dato;
            nuevo.izq = null;
            nuevo.der = null;

            if (Raiz == null)
                Raiz = nuevo;
            else
            {
                Nodo anterior = null, reco;
                reco = Raiz;
                while (reco != null) {
                    anterior = reco;
                    if (dato < reco.dato)
                        reco = reco.izq;
                    else
                        reco = reco.der;
                }
                if (dato < anterior.dato)
                    anterior.izq = nuevo;
                else
                    anterior.der = nuevo;
            }
        }

        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Console.Write(reco.dato + ",");
                ImprimirPre(reco.izq);
                ImprimirPre(reco.der);
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(Raiz);
            Console.WriteLine();
        }

        private void ImprimirInorden(Nodo reco)
        {
            if (reco != null)
            {
                
                ImprimirPre(reco.izq);
                Console.Write(reco.dato + ",");
                ImprimirPre(reco.der);
            }
        }

        public void ImprimirInorden()
        {
            ImprimirInorden(Raiz);
            Console.WriteLine();
        }

        private void ImprimirPostOrden(Nodo reco)
        {
            if (reco != null)
            {

                ImprimirPre(reco.izq);
                ImprimirPre(reco.der);
                Console.Write(reco.dato + ",");
                
            }
        }

        public void ImprimirPostOrden()
        {
            ImprimirPostOrden(Raiz);
            Console.WriteLine();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
            arbol.Insertar(50);
            arbol.Insertar(100);
            arbol.Insertar(85);
            arbol.Insertar(15);
            arbol.Insertar(5);
            arbol.Insertar(35);
            arbol.Insertar(70);
            arbol.Insertar(80);
            arbol.Insertar(66);
            arbol.Insertar(77);
            arbol.Insertar(33);

            Console.WriteLine("Datos en pre-orden: ");
            arbol.ImprimirPre();
            Console.WriteLine();

            Console.WriteLine("Datos en post-orden: ");
            arbol.ImprimirPostOrden();
            Console.WriteLine();

            Console.WriteLine("Datos en Inorden: ");
            arbol.ImprimirInorden();
            

            Console.ReadKey();

        }
    }
}
