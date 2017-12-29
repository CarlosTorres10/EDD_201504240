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

            //listadoble.InsertarEnLista("pedro", "pez", 10, 11, 12, 0);
            //listadoble.InsertarEnLista("maria", "pollo", 10, 11, 12, 0);
            //listadoble.InsertarEnLista("carlos", "pozo", 10, 11, 12, 0);
            //listadoble.InsertarEnLista("jorge", "tele", 10, 11, 12, 0);
            //listadoble.InsertarEnLista("kevin", "leon", 10, 11, 12, 0);
            //listadoble.InsertarEnLista("pepito", "pinguino", 10, 11, 12, 0);
            //listadoble.InsertarEnLista("toby", "sillon", 10, 11, 12, 0);
            //listadoble.InsertarEnLista("pepe", "kevin", 10, 11, 12, 0);
            //listadoble.InsertarEnLista("pepe", "kevin", 10, 11, 12, 0);
            //listadoble.InsertarEnLista("pepe", "kevin", 10, 11, 12, 0);
            //listadoble.graficar("ListaDobleJuegos.png");
            //listadoble.RecorrerLista();
            //Console.WriteLine();
            //listadoble.EliminarEnLista("kevin", "leon");
            //listadoble.graficar("ListaDobleJuegos.png");
            //listadoble.InsertarEnLista("pepe", "123", 10, 11, 12, 0);
            //listadoble.graficar("ListaDobleJuegos.png");


            listadoble.InsertarEnLista("m", "pez", 10, 11, 12, 0);
            listadoble.InsertarEnLista("r", "pollo", 10, 11, 12, 0);
            listadoble.InsertarEnLista("t", "pozo", 10, 11, 12, 0);
            listadoble.InsertarEnLista("l", "tele", 10, 11, 12, 0);

            listadoble.InsertarEnLista("a", "leon", 10, 11, 12, 0);
            listadoble.InsertarEnLista("f", "pinguino", 10, 11, 12, 0);
            listadoble.InsertarEnLista("b", "sillon", 10, 11, 12, 0);
            listadoble.InsertarEnLista("h", "kevin", 10, 11, 12, 0);

            listadoble.InsertarEnLista("s", "kevin", 10, 11, 12, 0);
            listadoble.InsertarEnLista("v", "kevin2", 10, 11, 12, 0);
            listadoble.InsertarEnLista("g", "kevin3", 10, 11, 12, 0);
            listadoble.InsertarEnLista("u", "kevin4", 10, 11, 12, 0);

            arbol_texto.Insertar("g","contra","gmail.com",0,listadoble);
            arbol_texto.Insertar("f", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("r", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("a", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("b", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("l", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("m", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("h", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("t", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("s", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("v", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("u", "contra", "gmail.com", 0, listadoble);
            arbol_texto.Insertar("mario", "contra", "gmail.com", 0, listadoble);
            



            arbol_texto.inorden();
            Console.WriteLine();
            //listadoble.RecorrerLista();
            Console.WriteLine();
            //arbol_texto.recorrer();
            Console.WriteLine();
            //arbol_texto.recorrer();
            arbol_texto.graficarArbol("Arbol_Usuarios.png");
            //arbol_texto.graficar("Arbol_Usuario_Espejo.png");
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
