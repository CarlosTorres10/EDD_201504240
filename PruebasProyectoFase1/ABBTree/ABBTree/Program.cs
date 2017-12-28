using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioBusqueda arbol_texto = new ArbolBinarioBusqueda();
            ListaDoble listadoble = new ListaDoble();

            listadoble.InsertarEnLista("pedro", "pez", 10, 11, 12, 0);
            listadoble.InsertarEnLista("maria", "pollo", 10, 11, 12, 0);
            listadoble.InsertarEnLista("carlos", "pozo", 10, 11, 12, 0);
            listadoble.InsertarEnLista("jorge", "tele", 10, 11, 12, 0);
            listadoble.InsertarEnLista("kevin", "leon", 10, 11, 12, 0);
            listadoble.InsertarEnLista("pepito", "pinguino", 10, 11, 12, 0);
            listadoble.InsertarEnLista("toby", "sillon", 10, 11, 12, 0);
            listadoble.InsertarEnLista("pepe", "kevin", 10, 11, 12, 0);
            listadoble.InsertarEnLista("pepe", "kevin", 10, 11, 12, 0);
            listadoble.InsertarEnLista("pepe", "kevin", 10, 11, 12, 0);
            listadoble.graficar("ListaDobleJuegos.png");
            listadoble.RecorrerLista();
            Console.WriteLine();
            //listadoble.EliminarEnLista("kevin", "leon");
            //listadoble.graficar("ListaDobleJuegos.png");
            //listadoble.InsertarEnLista("pepe", "123", 10, 11, 12, 0);
            //listadoble.graficar("ListaDobleJuegos.png");
            arbol_texto.Insertar("pedro","contra","gmail.com",0,listadoble);
            arbol_texto.Insertar("maria", "contra", "gmail.com", 0,listadoble);
            arbol_texto.Insertar("carlos", "contra", "gmail.com", 0,listadoble);
            arbol_texto.Insertar("kevin", "contra", "gmail.com", 0,listadoble);
            arbol_texto.Insertar("pepito", "contra", "gmail.com", 0,listadoble);
            arbol_texto.Insertar("toby", "contra", "gmail.com", 0,listadoble);
            arbol_texto.Insertar("pepe", "contra", "gmail.com", 0,listadoble);
            arbol_texto.Insertar("luis", "contra", "gmail.com", 0,listadoble);
            //Graficamos el árbol generando la imagen arbol_texto.jpg
            //arbol_texto.graficar("ABBTree.png");
            //Imprimimos el contenido del árbol ordenado
            //arbol_texto.inorden();
            //Console.WriteLine();
            //arbol_texto.ValidarLogin(7, "pepiti");
            //Console.WriteLine();
            //arbol_texto.borrarnodo(8, "pepiti", "gmail.com", 0);
            //Console.WriteLine();
            //arbol_texto.inorden();
            //arbol_texto.Insertar(6, "pepiti", "gmail.com", 0);
            //Console.WriteLine();
            //arbol_texto.inorden();

            //arbol_texto.borrarnodo(17, "pepiti", "gmail.com", 0);
            //arbol_texto.borrarnodo(15, "pepiti", "gmail.com", 0);

            //Console.WriteLine();
            //arbol_texto.inorden();

            //arbol_texto.graficar("ABBTree.png");

            Console.ReadKey();
        }
    }
}
