using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace ABBTree
{
    public class NodoArbolABB {

        private readonly IComparable Nickname;
        private String Usuario;
        private String Password;
        private String Correo;
        private int IndicadorConexion;
        static int Correlativo = 1;
        private int id;
        private NodoArbolABB Padre;
        private NodoArbolABB Izquierdo;
        private NodoArbolABB Derecho;
        private ListaDoble ListaJuegos;

        public NodoArbolABB(IComparable Nickname, String Password, String Correo, int IndicadorConexion, NodoArbolABB Padre,ListaDoble ListaJuegos)
        {
            this.Nickname = Nickname;
            this.Usuario = Nickname.ToString();
            this.Password = Password;
            this.Correo = Correo;
            this.IndicadorConexion = IndicadorConexion;
            this.Padre = Padre;
            this.Izquierdo = null;
            this.ListaJuegos = ListaJuegos;
            this.Derecho = null;
            this.id = Correlativo++;
            //this.id = Correlativo++;
        }

        public ListaDoble getListaJuegos()
        {
            return ListaJuegos;
        }

        public void setListaJuegos(ListaDoble ListaJuegos)
        {
            this.ListaJuegos = ListaJuegos;
        }

        public NodoArbolABB getPadre()
        {
            return Padre;
        }

        public void setPadre(NodoArbolABB Padre)
        {
            this.Padre = Padre;
        }
        public void setNickname(IComparable Nickname)
        {
            this.Usuario = Nickname.ToString();
        }

        public string getNicknamee()
        {
            return Usuario;
        }

        public IComparable getNickname()
        {
            return Nickname;
        }
        
        public string getPassword()
        {
            return Password;
        }

        public void setPassword(String Password)
        {
            this.Password = Password;
        }
        public string getCorreo()
        {
            return Correo;
        }

        public void setCorreo(String Correo)
        {
            this.Correo = Correo;
        }

        public int getIndicadorConexion()
        {
            return IndicadorConexion;
        }

        public void setIndicadorConexion(int IndicadorConexion)
        {
            this.IndicadorConexion = IndicadorConexion;
        }

        public NodoArbolABB getIzquierdo()
        {
            return Izquierdo;
        }

        public void setIzquierdo(NodoArbolABB Izquierdo)
        {
            this.Izquierdo = Izquierdo;
        }

        public NodoArbolABB getDerecho()
        {
            return Derecho;
        }

        public void setDerecho(NodoArbolABB Derecho)
        {
            this.Derecho = Derecho;
        }

        private void insertarConPadre(IComparable Usuario, String Contra, String Email, int Conexion, NodoArbolABB Padre,ListaDoble ListaJuegos)
        {
            if (Usuario.CompareTo(Nickname)<0)
            {
                if (Izquierdo==null)
                {
                    Izquierdo = new NodoArbolABB(Usuario, Contra, Email, Conexion,this,ListaJuegos);
                }
                else
                {
                    Izquierdo.insertarConPadre(Usuario, Contra, Email, Conexion,this,ListaJuegos);
                }
            }
            else if (Usuario.CompareTo(Nickname) > 0)
            {
                if (Derecho == null)
                {
                    Derecho = new NodoArbolABB(Usuario, Contra, Email, Conexion,this,ListaJuegos);
                }
                else
                {
                    Derecho.insertarConPadre(Usuario, Contra, Email, Conexion,this,ListaJuegos);
                }
            }
            else
            {
                Console.WriteLine("No se permiten valores duplicados--> " + Usuario.ToString());
            }
        }

        

        public void insertar(IComparable Usuario, String Contra, String Email, int Conexion,ListaDoble ListaJuegos)
        {
            insertarConPadre(Usuario, Contra, Email, Conexion, this,ListaJuegos);
        }

        private NodoArbolABB minimo()
        {
            if (getIzquierdo()!=null)
            {
                return getIzquierdo().minimo();
            }
            else
            {
                return this;
            }
        }

        public void EliminarNodo(NodoArbolABB valor,IComparable usuario,String Contra, String Email, int Conexion)
        {
            if ((valor.getIzquierdo() != null) && (valor.getDerecho() != null))
            {
                //Elimina con 2 hijos
                //NodoArbolABB minimo = valor.getDerecho().minimo();
                //this.setNickname(minimo.getNickname());
                //valor.getDerecho().EliminarNodo(valor, minimo.getNickname(), Contra, Email, Conexion);
                

            }
            else if ((valor.getIzquierdo() != null) || (valor.getDerecho() != null))
            {
                //Eliminar con 1 hijo
                NodoArbolABB sustituto = valor.getIzquierdo() != null ? valor.getIzquierdo() : valor.getDerecho();
                this.setNickname(sustituto.getNickname());
                this.setIzquierdo(sustituto.getIzquierdo());
                this.setDerecho(sustituto.getDerecho());
                
            }
            else
            {
                //Eliminar sin hijos
                if (valor.getPadre() != null)
                {
                    //if (raiz == raiz.getPadre().getIzquierdo()) raiz.getPadre().getIzquierdo() = null;
                    if (this == valor.getPadre().getIzquierdo()) valor.getPadre().setIzquierdo(null);
                    if (this == valor.getPadre().getDerecho()) valor.getPadre().setDerecho(null);
                    valor.setPadre(null);

                }
                valor = null;
            }
        }

        public void graficar(String path)
        {
            StreamWriter fichero = null;
          
            try
            {
                fichero = new StreamWriter("ABBTree.dot");
                fichero.Write(getCodigoGraphviz());
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
                startInfo.Arguments = "dot -Tpng -o" + path +  " ABBTree.dot";
                Process.Start(startInfo);
                Process.Start("ABBTree.png");
                
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error al generar la imagen para el archivo ABBTree.dot" + ex.ToString());
              
            }
        }



        private String getCodigoGraphviz()
        {
            return "digraph grafica{\n" +
                   "rankdir=TB;\n" +
                   "node [shape = record, style=filled, fillcolor=burlywood2];\n" +
                    getCodigoInterno() +
                    "}\n";
        }

        private String getCodigoInterno()
        {
            String etiqueta;
            NodoListaDoble actual = this.ListaJuegos.primero;
            if (Izquierdo == null && Derecho == null)
            {
                etiqueta = "nodo" + id + " [ label =\"" + Usuario + "\"];\n";
                while (actual != null)
                {

                    etiqueta="nodo" + id + " [ label =\"" + "Oponente: " + actual.getNicknameOponente() + "\\n Unidades Desplegadas: " + actual.getUnidadesDesplegadas().ToString() + "\\n Unidades Sobrevivientes: " + actual.getUnidadesSobrevivientes().ToString() + "\\n Unidades Destruidas: " + actual.getUnidadesDestruidas().ToString() + "\\n Estado Victoria: " + actual.getEstadoVictoria().ToString() + "\"];\n");
                    id++;
                    actual = actual.getSiguiente();
                }

            }
            else
            {
                etiqueta = "nodo" + id + " [ label =\"<C0>|" + Usuario + "|<C1>\"];\n";
            }
            if (Izquierdo != null)
            {
                etiqueta = etiqueta + Izquierdo.getCodigoInterno() +
                   "nodo" + id + ":C0->nodo" + Izquierdo.id + "\n";
            }
            if (Derecho != null)
            {
                etiqueta = etiqueta + Derecho.getCodigoInterno() +
                   "nodo" + id + ":C1->nodo" + Derecho.id + "\n";
            }
            return etiqueta;
        }


    }
}
