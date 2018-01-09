using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Diagnostics;


namespace ServidorWebEDD
{
    class TablaHash
    {
        NodoTablaHash[] vector;
        int cuenta;
        String dot;


        public TablaHash()
        {
            vector = new NodoTablaHash[7];

            inicializaTabla();
        }

        public bool existeNombre(String nombre)
        {
            return buscaNodo(nombre) != null;
        }

        public NodoTablaHash buscaNodo(String nombre)
        {
            int indice = hash(nombre);
            if (vector[indice].getNombre() != null)
            {
                if (vector[indice].getNombre() != nombre)
                    return manejaColisionBusqueda(indice, nombre);
            }
            else
                return manejaColisionBusqueda(indice, nombre);
            return vector[indice];
        }

        private NodoTablaHash manejaColisionBusqueda(int indice, String buscado)
        {
            int index = indice;
            int guia = 1;
            int cuadrado;
            int conteo = 0;
            while (true && conteo <= vector.Length)
            {
                conteo++;
                cuadrado = guia;
                cuadrado *= cuadrado;
                index += cuadrado;
                guia += 1;
                while (index >= vector.Length)
                {
                    index = index - vector.Length;
                }
                if (vector[index].getNombre() != null)
                    if (vector[index].getNombre() == buscado)
                        return vector[index];
            }
            return null;
        }

        public void insertarNodo(String nombre)
        {
            int indice = hash(nombre);
            cuenta++;

            if (vector[indice].isUsada())
            {
                indice = manejaColision(indice);
            }
            vector[indice].nuevo(nombre);
            vector[indice].setUsada(true);

            double limite = 0.5;
            double fc = ((double)cuenta / (double)vector.Length);
            if (fc > limite)
            {
                //Aca se graficaba la tabla previo a aumentar su tamaño :D
                //this.grafica("hash");
                rehash();
            }
        }

        private void rehash()
        {
            //aca se hace el rehashing
            int nuevoTamaño = primoSiguiente(vector.Length);
            NodoTablaHash[] vectorAux = vector;
            vector = new NodoTablaHash[nuevoTamaño];
            inicializaTabla();
            for (int i = 0; i < vectorAux.Length; i++)
            {
                if (vectorAux[i].isUsada())
                {
                    insertarNodo(vectorAux[i].getNombre());
                }
            }
        }



        private int manejaColision(int indice)
        {
            int index = indice;
            int guia = 1;
            int cuadrado;
            while (true)
            {

                cuadrado = guia;
                cuadrado *= cuadrado;
                index += cuadrado;
                guia += 1;
                while (index >= vector.Length)
                {
                    index = index - vector.Length;
                }
                if (!vector[index].isUsada())
                    return index;
            }
        }







        private int Asc(char s)
        {
            return Encoding.ASCII.GetBytes(s.ToString())[0];
        }

        private int hash(String nombre)
        {
            Char[] caracNombre = nombre.ToCharArray();
            int k = Convert.ToInt32(Asc(caracNombre[0])) + Convert.ToInt32(Asc(caracNombre[1])) + Convert.ToInt32(Asc(caracNombre[2]));
            int indice = k % vector.Length;
            return indice;
        }

        private void inicializaTabla()
        {
            cuenta = 0;
            dot = "";
            for (int i = 0; i < vector.Length; i++)
                vector[i] = new NodoTablaHash(false);
        }

        private int primoSiguiente(int numero)
        {
            int aux = numero;
            while (true)
            {
                aux++;
                if (esPrimo(aux))
                {
                    return aux;
                }
            }
        }

        private bool esPrimo(int numero)
        {
            for (int i = 2; i < numero; i++)
            {
                if (numero % i == 0)
                    return false;
            }
            return true;
        }

        public void grafica(String nombreArchivo)
        {
            dot = "digraph lista{ \n";
            dot += " nodesep=.05;\n";
            dot += "rankdir = LR; \n";
            dot += "node [shape=record,width=.1,height=.1];\n";
            dot += "nodeArreglo [label = \"<f0> 0 ";
            for (int i = 1; i < vector.Length; i++)
            {
                dot += " |<f" + i + "> " + i;

            }
            dot += "\",height=2.5];\n";
            dot += " node [width = 1.5];\n";

            /*
             * node1 [label = "{<n> hola  }"];
             * node0:f1 -> node1:n; 
             * 
             */

            for (int j = 0; j < vector.Length; j++)
            {

                if (vector[j].isUsada())
                {
                    dot += "node" + j + "[label = \" {<n> " + vector[j].getNombre() + "} \" ];\n";
                    dot += "nodeArreglo:f" + j + "-> node" + j + ":n;\n";
                }
            }
            dot += "}";
            StreamWriter fichero = null;
            try
            {
                fichero = new StreamWriter(nombreArchivo + ".dot");
                fichero.Write(dot);
            }
            catch (Exception e) { //MessageBox.Show(e.ToString()); 
            }
            finally
            {
                try
                {
                    if (null != fichero)
                        fichero.Close();
                }
                catch (Exception e2) { //MessageBox.Show(e2.ToString()); 
                }
            }
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe");
                startInfo.Arguments = "-Tpng  " + nombreArchivo + ".dot  -o  " + nombreArchivo + ".png ";
                Process.Start(startInfo);
                Process.Start(nombreArchivo + ".png ");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en generar archivo dot " + ex.ToString());
            }
        }


        public void eliminarNodo(String nombre)
        {
            buscaNodo(nombre).setUsada(false);
        }





    }
}