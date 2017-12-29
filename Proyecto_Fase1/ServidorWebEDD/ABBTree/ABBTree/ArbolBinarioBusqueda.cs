using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace ABBTree
{
    public class ArbolBinarioBusqueda
    {
        private NodoArbolABB RaizABB;
        public int Verificacion;
        StreamWriter fichero = new StreamWriter("Arbol_Usuarios.dot");
        public int contador = 0;

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

        public void Insertar(IComparable Nickname, String Password, String Correo, int IndicadorConexion, ListaDoble ListaJuegos)
        {
            if (ArbolVacio(RaizABB))
                RaizABB = new NodoArbolABB(Nickname, Password, Correo, IndicadorConexion,null, ListaJuegos);
            else
                RaizABB.insertar(Nickname, Password, Correo, IndicadorConexion);
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
            inorden(a.getDerecho());
            
        }

        private void Rlista(NodoArbolABB actual)
        {
            if (actual != null)
            {

                if (actual.getListaJuegos().primero != null )
                {
                    
                    NodoListaDoble actual2 = actual.getListaJuegos().primero;
                    while(actual2 != null)
                    {
                        
                        if (actual.getNicknamee() == actual2.getNickname())
                        {
                            if (contador == 0)
                            {
                                fichero.Write(actual2.getNickname() + ":f1 -> " + "\"" +"Usuario: "+ actual2.getNickname() + ", \n Oponente: " + actual2.getNicknameOponente() + ", \n Unidades Desplegadas: " + actual2.getUnidadesDesplegadas().ToString() + ", \n Unidades Sobrevivientes: " + actual2.getUnidadesSobrevivientes().ToString() + ", \n Unidades Destruidas: " + actual2.getUnidadesDestruidas().ToString() + ", \n Victoria: " + actual2.getEstadoVictoria().ToString() +  "\"[dir=both];");
                                fichero.Write("\n");
                                contador = 1;
                            }
                            else
                            {
                                fichero.Write("\"" +"Usuario: "+ actual2.getNickname() + ", \n Oponente: " + actual2.getAnterior().getNicknameOponente() + ", \n Unidades Desplegadas: " + actual2.getUnidadesDesplegadas().ToString() + ", \n Unidades Sobrevivientes: " + actual2.getUnidadesSobrevivientes().ToString() + ", \n Unidades Destruidas: " + actual2.getUnidadesDestruidas().ToString() + ", \n Victoria: " + actual2.getEstadoVictoria().ToString() + "\"" + "->" + "\"" +"Usuario: "+ actual2.getNickname() + ", \n Oponente: " + actual2.getNicknameOponente() + ", \n Unidades Desplegadas: " + actual2.getUnidadesDesplegadas().ToString() + ", \n Unidades Sobrevivientes: " + actual2.getUnidadesSobrevivientes().ToString() + ", \n Unidades Destruidas: " + actual2.getUnidadesDestruidas().ToString() + ", \n Victoria: " + actual2.getEstadoVictoria().ToString() + "\"[dir=both];");
                                fichero.Write("\n");
                            }

                            //Console.WriteLine(actual2.getNickname() + " Oponente: " + actual2.getNicknameOponente());
                            actual2 = actual2.getSiguiente();
                        }
                        else
                        {
                            actual2 = actual2.getSiguiente();
                        }
                        
                    }
                    contador = 0;
                }
            }
             
        }

        private void list(NodoArbolABB actual)
        {
            
            if (actual.getIzquierdo() != null)
            {
                
                Rlista(actual.getIzquierdo());
                list(actual.getIzquierdo());
            }
            if (actual.getDerecho() != null)
            {
                Rlista(actual.getDerecho());
                list(actual.getDerecho());
            }
        }

        private void grafoArbol(NodoArbolABB actual)
        {
            
            //StreamWriter fichero = new StreamWriter("ABBTreeConLista.dot");
            if (actual.getIzquierdo() != null)
            {
                fichero.Write(actual.getIzquierdo().getNicknamee() + " [label=\"<f0> |<f1>" + actual.getIzquierdo().getNicknamee() + " |<f2>\"];");
                fichero.Write("\n");
                fichero.Write(actual.getNicknamee()+ ":f0 -> " + actual.getIzquierdo().getNicknamee() + ":f1;");
                fichero.Write("\n");
                Rlista(actual.getIzquierdo());
                //Console.WriteLine(graflista(actual.getIzquierdo()));
                grafoArbol(actual.getIzquierdo());
            }
            if (actual.getDerecho() != null)
            {
                fichero.Write(actual.getDerecho().getNicknamee() + " [label=\"<f0> |<f1>" + actual.getDerecho().getNicknamee() + " |<f2>\"];");
                fichero.Write("\n");
                fichero.Write(actual.getNicknamee() + ":f2 -> " + actual.getDerecho().getNicknamee() + ":f1;");
                fichero.Write("\n");
                Rlista(actual.getDerecho());
                //Console.WriteLine(graflista(actual.getIzquierdo()));
                grafoArbol(actual.getDerecho());
            }
        }

        public void graficarArbol(String path)
        {
            //StreamWriter fichero = null;

            try
            {
                //fichero = new StreamWriter("ABBTreeConLista.dot");
                fichero.Write("digraph grafica{\n" +
                   "rankdir=TB;\n" +
                   "node [shape = record, style=filled, fillcolor=burlywood2];\n");

                //Inicia cuerpo del grafo
                fichero.Write(RaizABB.getNicknamee() + " [label=\"<f0> | <f1>" + RaizABB.getNicknamee() + " |<f2>\"];");
                fichero.Write("\n");
                //fichero.Close();
                grafoArbol(RaizABB);
                fichero.Write("}");
                //fichero.Close();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error al escribir en el archivos dot" + e.ToString());

            }
            finally
            {
                try
                {
                    if (null != fichero)
                        fichero.Close();
                }
                catch (Exception e2)
                {
                    Console.Error.WriteLine("Error al cerrar el archivo .dot" + e2.ToString());
                }
            }
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Program Files (x86)\\Graphviz\\bin\\dot.exe");
                startInfo.Arguments = "dot -Tpng -o" + path + " Arbol_Usuarios.dot";
                Process.Start(startInfo);
                Process.Start("Arbol_Usuarios.png");

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error al generar la imagen para el archivo Arbol_Usuarios.dot" + ex.ToString());

            }
        }


    }
}
