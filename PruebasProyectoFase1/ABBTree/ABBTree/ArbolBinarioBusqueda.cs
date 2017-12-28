using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ABBTree
{
    public class ArbolBinarioBusqueda
    {
        private NodoArbolABB RaizABB;
        public int Verificacion;

        public ArbolBinarioBusqueda()
        {
            RaizABB = null;
        }

        public Boolean ArbolVacio(NodoArbolABB Raiz)
        {
            if (Raiz == null)
                return true;
            else
                return false;
        }

        public void Insertar(IComparable Nickname, String Password, String Correo, int IndicadorConexion,ListaDoble ListaJuegos)
        {
            if (ArbolVacio(RaizABB))
                RaizABB = new NodoArbolABB(Nickname, Password, Correo, IndicadorConexion,null,ListaJuegos);
            else
                RaizABB.insertar(Nickname, Password, Correo, IndicadorConexion,ListaJuegos);
        }

        public void borrarnodo(IComparable usuario, String contra, String Correo, int IndicadorConexion) {
            Reemplazar(RaizABB, usuario, contra, Correo, IndicadorConexion);
        }

        private void Reemplazar(NodoArbolABB raiz,IComparable usuario, String contra, String Correo, int IndicadorConexion)
        {
            if (raiz != null)
            {
                if (raiz.getNicknamee() == usuario.ToString())
                {
                    //Console.WriteLine("datos encontrados");
                    raiz.EliminarNodo(raiz, usuario,contra,Correo,IndicadorConexion);
                    
                }
                else if (usuario.CompareTo(raiz.getNickname()) <= 0)
                {
                    Reemplazar(raiz.getIzquierdo(), usuario, contra, Correo, IndicadorConexion);
                }
                else
                {
                    Reemplazar(raiz.getDerecho(), usuario, contra, Correo, IndicadorConexion);
                }
            }
        }

        public void ValidarUsuario(IComparable Nickname, String Password)
        {
           
        }

        public void ValidarLogin(IComparable Nickname, String Password)
        {

            buscar2(RaizABB, Nickname, Password);
            if (Verificacion == 0)
            {
                Console.WriteLine("El usuario no existe o los datos ingresados son incorrectos!!!");
            }
            else
            {
                Console.WriteLine("Los datos ingresados son correctos!!!");
            }
        }

        private void buscar2(NodoArbolABB raiz, IComparable usuario, String password)
        {
            Verificacion = 0;
            if (raiz == null)
            {
                //Console.WriteLine("datos incorrectos");
                Verificacion = 0;
            }
            else
            {
                if (raiz.getNickname().ToString() == usuario.ToString())
                {
                    //Console.WriteLine("datos encontrados");
                    Verificacion = 1;
                }
                else if (usuario.CompareTo(raiz.getNickname())<=0)
                {
                    buscar2(raiz.getIzquierdo(), usuario, password);
                }
                else
                {
                    buscar2(raiz.getDerecho(), usuario, password);
                }
            }

        }
        
        public void graficarlis(ListaDoble Lista)
        {
            Lista.graficar("ListaDobleJuegos.png");
        }
    
        public void graficar(String path)
        {
            if (ArbolVacio(RaizABB))
                Console.WriteLine("El arbol no se puede graficar porque no tiene elementos");
            else
                RaizABB.graficar(path);
        }

        public void inorden()
        {
            Console.WriteLine("Recorrido inorden del árbol binario de búsqueda:");
            inorden(RaizABB);
            Console.WriteLine();
        }

        private void inorden(NodoArbolABB a)
        {
            if (a == null)
                return;
            inorden(a.getIzquierdo());
            Console.Write(a.getNicknamee()+",");
            //if (a.getPadre() == null)
            //{
            //    Console.WriteLine(" {//} "+a.getNickname().ToString() + ",");
            //}
            //else
            //{
            //    Console.WriteLine(a.getNickname().ToString() + " " + a.getPadre().getNickname().ToString() + " , ");
            //}
            
            inorden(a.getDerecho());
            
        }

       
    }
}
