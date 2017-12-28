using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ABBTree
{
    public class ListaDoble
    {
        public NodoListaDoble primero;
        public NodoListaDoble ultimo;

        public ListaDoble()
        {
            primero = null;
            ultimo = null;
        }

        public Boolean ListaVacia(NodoListaDoble primero)
        {
            if (primero == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void InsertarEnLista(String Nickname, String NicknameOponente, int UnidadesDesplegadas, int UnidadesSobrevivientes, int UnidadesDestruidas, int EstadoVictoria)
        {
            NodoListaDoble nuevo = new NodoListaDoble(Nickname, NicknameOponente, UnidadesDesplegadas, UnidadesSobrevivientes, UnidadesDestruidas, EstadoVictoria);
            if (ListaVacia(primero))
            {
                this.primero = nuevo;
                this.ultimo = nuevo;
                return;
            }
            this.ultimo.setSiguiente(nuevo);
            nuevo.setAnterior(this.ultimo);
            this.ultimo = nuevo;
        }

      
        public void EliminarEnLista(String Nickname, String NicknameOponente)
        {
            Boolean condicion=false;
            if (ListaVacia(primero))
            {
                Console.WriteLine("La lista no posee elementos, esta vacía");
            }
            else
            {
                NodoListaDoble actual = this.primero;
                while (actual != null)
                {
                    if (actual.getNickname()==Nickname)
                    {
                        condicion = true;
                        break;
                    }
                    actual = actual.getSiguiente();
                }
                
                if (condicion==true)
                {
                    Console.WriteLine("El dato existe en la lista, se eliminó correctamente");
                }
                else
                {
                    Console.WriteLine("El dato no existe en la lista!!!");
                }

                if (actual != null)
                {
                    if (actual == this.primero)
                    {
                        this.primero = actual.getSiguiente();

                        if (actual.getSiguiente() != null)
                        {
                            actual.getSiguiente().setAnterior(null);
                        }
                    }
                    else if (actual.getSiguiente() != null)
                    {
                        actual.getAnterior().setSiguiente(actual.getSiguiente());
                        actual.getSiguiente().setAnterior(actual.getAnterior());
                    }
                    else
                    {
                        actual.getAnterior().setSiguiente(null);
                    }
                }
                actual = null;
                return;
            }
        }

        public void RecorrerLista()
        {
            NodoListaDoble actual = this.primero;
            while (actual != null)
            {
                Console.Write(actual.getNickname() + " <-> ");
                actual = actual.getSiguiente();
            }
        }



        public void graficar(String path)
        {
            StreamWriter fichero = null;
            int id = 0;
            NodoListaDoble actual = this.primero;

            try
            {
                fichero = new StreamWriter("ListaDobleJuegos.dot");
                fichero.Write("digraph grafica{\n" +
                   "rankdir=TB;\n" +
                   "node [shape = record, style=filled, fillcolor=aquamarine2];\n");

                while (actual != null)
                {

                    fichero.Write("nodo" + id + " [ label =\"" +"Oponente: "+ actual.getNicknameOponente() +"\\n Unidades Desplegadas: "+ actual.getUnidadesDesplegadas().ToString()+ "\\n Unidades Sobrevivientes: "+ actual.getUnidadesSobrevivientes().ToString()+"\\n Unidades Destruidas: "+actual.getUnidadesDestruidas().ToString()+"\\n Estado Victoria: "+actual.getEstadoVictoria().ToString()+ "\"];\n");
                    id++;
                    actual = actual.getSiguiente();
                }

                actual = this.primero;
                id = 0;
                while (actual != null)
                {
                    if (id == 0)
                    {
                        fichero.Write("nodo" + (id) + "->" + "nodo" + (id + 1) + ";\n");
                        id++;
                    }
                    else
                    {
                        fichero.Write("nodo" + (id) + "->" + "nodo" + (id - 1) + ";\n");
                        fichero.Write("nodo" + (id) + "->" + "nodo" + (id + 1) + ";\n");
                        id++;
                    }
                    actual = actual.getSiguiente();
                }
                fichero.Write("}\n");


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
                startInfo.Arguments = "dot -Tpng -o" + path + " ListaDobleJuegos.dot";
                Process.Start(startInfo);
                Process.Start("ListaDobleJuegos.png");

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error al generar la imagen para el archivo ListaDobleJuegos.dot" + ex.ToString());

            }
        }
    }
}
