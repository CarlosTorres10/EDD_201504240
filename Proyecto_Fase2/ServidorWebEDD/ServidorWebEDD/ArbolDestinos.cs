using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ArbolBDestino
{

    public class ArbolDestinos
    {

        private RamaArbol raiz;
        private String nodos = "";
        string ContenidoGrafo = "";
        bool envio = false;
        bool paso = false;
        bool error = false;
        string errores = "";
        
        public static string Contenido = "";
        public static string Contenido2 = "";
        int contadorcabeceras = 0;
        int contadorfilas = 0;
        int contadorcabeceras2 = 0;
        int contadorcabecerasfilas = 0;
        int contadorcabecerasfilasoriginal = 0;
        int contadorcabecerasfilas2 = 0;
        ListaDoble listacabeceras = new ListaDoble();
        /**
         * Constructor de Arbol B para destinos
         */
         //agregado
        private bool matrizcosto = false;
        private bool matriztiempo = false;
        public bool getMatrizCosto() {
            return matrizcosto;
        }
        public bool getMatriztiempo()
        {
            return matriztiempo;
        }
        //agregado

        public ArbolDestinos()
        {
        }

        /**
         * Verifica el contenido del árbol
         * @return true - Si el árbol está vacío; false - Si no lo está
         */
        public Boolean estaVacio()
        {
            return raiz == null;
        }

        /**
         *
         * @param val
         */
        public void insertar(int codDes, String nomDes)
        {
            NodoRamaArbol nodo = new NodoRamaArbol(codDes, nomDes);
            if (estaVacio())
            {
                raiz = new RamaArbol();
                raiz.insertar(nodo);
            }
            else
            {
                Object obj = inserta(nodo, raiz);
                if (obj is NodoRamaArbol)
                {
                    raiz = new RamaArbol();
                    raiz.insertar((NodoRamaArbol)obj);
                    raiz.setHoja(false);
                }
            }
        }

    

        private Object inserta(NodoRamaArbol nodo, RamaArbol rama)
        {
            if (rama.esHoja())
            {
                rama.insertar(nodo);
                if (rama.getCuenta() == 5)
                {
                    return dividir(rama);
                }
                else
                {
                    return rama;
                }
            }
            else
            {
                NodoRamaArbol temp = rama.getPrimero();
                do
                {
                    if (nodo.getCodigoDestino() == temp.getCodigoDestino())
                    {
                        return rama;
                    }
                    else if (nodo.getCodigoDestino() < temp.getCodigoDestino())
                    {
                        Object obj = inserta(nodo, temp.getIzquierda());
                        if (obj is NodoRamaArbol)
                        {
                            rama.insertar((NodoRamaArbol)obj);
                            if (rama.getCuenta() == 5)
                            {
                                return dividir(rama);
                            }
                        }
                        return rama;
                    }
                    else if (temp.getSiguiente() == null)
                    {
                        Object obj = inserta(nodo, temp.getDerecha());
                        if (obj is NodoRamaArbol)
                        {
                            rama.insertar((NodoRamaArbol)obj);
                            if (rama.getCuenta() == 5)
                            {
                                return dividir(rama);
                            }
                        }
                        return rama;
                    }
                    temp = temp.getSiguiente();
                } while (temp != null);
            }
            return rama;
        }

        private NodoRamaArbol dividir(RamaArbol rama)
        {
            RamaArbol derecha = new RamaArbol(), izquierda = new RamaArbol();
            NodoRamaArbol medio = null, temp = rama.getPrimero();
            for (int i = 1; i < 6; i++, temp = temp.getSiguiente())
            {
                NodoRamaArbol nodo = new NodoRamaArbol(temp.getCodigoDestino(), temp.getNombreDestino());
                nodo.setIzquierda(temp.getIzquierda());
                nodo.setDerecha(temp.getDerecha());
                if (nodo.getDerecha() != null && nodo.getIzquierda() != null)
                {
                    izquierda.setHoja(false);
                    derecha.setHoja(false);
                }
                switch (i)
                {
                    case 1:
                    case 2:
                        izquierda.insertar(nodo);
                        break;
                    case 3:
                        medio = nodo;
                        break;
                    case 4:
                    case 5:
                        derecha.insertar(nodo);
                        break;
                }
            }
            medio.setIzquierda(izquierda);
            medio.setDerecha(derecha);
            return medio;
        }

        /**
         *
         * Genera el contenido del archivo fuente para GraphViz
         * @return Un String con el contenido del archivo.
         */
        public String getDot()
        {
            String aux = "digraph lista{ \nnode [shape = record, style=filled];";
            aux += "splines=line; \n";
            getGrafNodos(raiz);
            aux += nodos;
            aux += "}";
            return aux;
        }

        private void getGrafNodos(RamaArbol raiz)
        {
            if (raiz == null)
            {
                return;
            }
            nodos += raiz.getGraphNodo();
            NodoRamaArbol aux = raiz.getPrimero();
            while (aux != null)
            {
                getGrafNodos(aux.getIzquierda());
                aux = aux.getSiguiente();
            }
            aux = raiz.getPrimero();
            while (aux.getSiguiente() != null)
            {
                aux = aux.getSiguiente();
            }
            getGrafNodos(aux.getDerecha());
        }

        public NodoRamaArbol busqueda(int numero)
        {
            if (!estaVacio())
            {
                return busca(numero, raiz);
            }
            else
            {
                return null;
            }
        }

        private NodoRamaArbol busca(int codDes, RamaArbol rama)
        {
            NodoRamaArbol nodo = rama.getPrimero();
            while (nodo != null)
            {
                if (codDes < nodo.getCodigoDestino())
                {
                    if (rama.esHoja())
                    {
                        return null;
                    }
                    else
                    {
                        return busca(codDes, nodo.getIzquierda());
                    }
                }
                else if (codDes == nodo.getCodigoDestino())
                {
                    return nodo;
                }
                else if (nodo.getSiguiente() == null)
                {
                    if (rama.esHoja())
                    {
                        return null;
                    }
                    else
                    {
                        return busca(codDes, nodo.getDerecha());
                    }
                }
                nodo = nodo.getSiguiente();
            }
            return null;
        }


        private void busca(int codDes, RamaArbol rama, RamaArbol salida)
        {
            if (rama == null)
            {
                return;
            }
            NodoRamaArbol nodo = rama.getPrimero();
            while (nodo != null)
            {
                if (!rama.esHoja())
                {
                    busca(codDes, nodo.getIzquierda(), salida);
                    busca(codDes, nodo.getDerecha(), salida);
                }
                if (nodo.getCodigoDestino() == codDes)
                {
                    salida.insertar(new NodoRamaArbol(nodo.getCodigoDestino(), nodo.getNombreDestino()));
                }
                nodo = nodo.getSiguiente();
            }
        }





        public void IngresarDatos(int filaCoordenada, int columnaCoordenada, float Costo, float Tiempo) {
            //agregado
            matrizcosto = false;
            matriztiempo = false;
            //agregado
                NodoRamaArbol Fila = busqueda(filaCoordenada);
                NodoRamaArbol Columna = busqueda(columnaCoordenada);
                 //Ya tenemos los nodos fila y columna del que vamos a insertar
                NodoMatriz Dato = new NodoMatriz(filaCoordenada,columnaCoordenada,Costo,Tiempo);
    if (Fila.getFilaPrimero() == null) {
        Fila.setFilaPrimero(Dato);
        Dato.setIzquierdaCabecera(Fila);
        Dato.setAnteriorMatriz(null);
        Dato.setSiguienteMatriz(null);
       
    } else {
        NodoMatriz auxiliar = Fila.getFilaPrimero();
        
        while (auxiliar != null) {
            if (auxiliar.getCodigosegundoPais() > columnaCoordenada) {//Principio
                auxiliar.setAnteriorMatriz(Dato);
                Dato.setSiguienteMatriz(auxiliar);
                Fila.setFilaPrimero(Dato);
                Dato.setIzquierdaCabecera(Fila);
                Dato.setAnteriorMatriz(null);
                auxiliar.setIzquierdaCabecera(null);
                break;
            } else {
                if (auxiliar.getSiguienteMatriz() != null) {
                    if (auxiliar.getSiguienteMatriz().getCodigosegundoPais() > columnaCoordenada) {//En Medio
                        Dato.setSiguienteMatriz(auxiliar.getSiguienteMatriz());
                        auxiliar.getSiguienteMatriz().setAnteriorMatriz(Dato);
                        Dato.setAnteriorMatriz(auxiliar);
                        auxiliar.setSiguienteMatriz(Dato);
                        Dato.setIzquierdaCabecera(null);
                        break;
                    }
                } else {
                    Dato.setAnteriorMatriz(auxiliar);
                    auxiliar.setSiguienteMatriz(Dato);
                    Dato.setSiguienteMatriz(null);
                    Dato.setIzquierdaCabecera(null);
                    break;
                }

            }
            auxiliar = auxiliar.getSiguienteMatriz();
        }
    }
    if (Columna.getColumnaPrimero() == null) {
        Columna.setColumnaPrimero(Dato);
        Dato.setArribaCabecera(Columna);
        Dato.setAribaMatriz(null);
        Dato.setAbajoMatriz(null);
    } else {
        NodoMatriz aux = Columna.getColumnaPrimero(); ;
        while (aux != null) {
            if (aux.getCodigoPrimerPais() > filaCoordenada) {//Principio
                aux.setAribaMatriz(Dato);
                Dato.setAbajoMatriz(aux);
                Columna.setColumnaPrimero(Dato);
                Dato.setArribaCabecera(Columna);
                Dato.setAribaMatriz(null);
                aux.setArribaCabecera(null);
                break;
            } else {
                if (aux.getAbajoMatriz() != null) {//en medio
                    if (aux.getAbajoMatriz().getCodigoPrimerPais() > filaCoordenada) {
                        Dato.setAbajoMatriz(aux.getAbajoMatriz());
                        aux.getAbajoMatriz().setAribaMatriz(Dato);
                        Dato.setAribaMatriz(aux);
                        aux.setAbajoMatriz(Dato);
                        Dato.setArribaCabecera(null);
                        break;
                    }
                } else {//Ultimo
                    Dato.setAribaMatriz(aux);
                    aux.setAbajoMatriz(Dato);
                    Dato.setAbajoMatriz(null);
                    Dato.setArribaCabecera(null);
                    break;
                }

            }
            aux = aux.getAbajoMatriz();
        }
    }
}
            public void rec2()
            {
            Contenido = "";
            Contenido2 = "";
            
                contadorcabeceras = 0;
                contadorcabeceras2 = 0;
                Graficar(raiz);
                Contenido += "}\n";
                contadorcabecerasfilasoriginal = 0;
                NumeroFilas(raiz);
                Graficar2(raiz);
                Contenido += "m";
                Graficar3(raiz);
                Contenido += Contenido2 + ";\n";
                contadorfilas = 0;
                listacabeceras.setPrimero(null);
                Graficar4Nuevo(raiz);
            if (listacabeceras.ListaVacia() == false) {
                Contenido += "m->F"+listacabeceras.getPrimero().getCodigo()+ "[rankdir=UD];\n";
            }
                Graficar4Viejo(raiz);
                Contenido += "\n";
                Graficar5(raiz);
                Contenido += "\n";
                Graficar6(raiz);
                graficaMatriz();
                Console.WriteLine(Contenido);
            }

        public void Graficar4Nuevo(RamaArbol raiz)
        {
            if (raiz == null)
            {
                return;
            }
            //  nodos += raiz.getGraphNodo();
            NodoRamaArbol aux = raiz.getPrimero();
            while (aux != null)
            {

                Graficar4Nuevo(aux.getIzquierda());
                Console.WriteLine(aux.getCodigoDestino());
               
                listacabeceras.Insertar(aux.getCodigoDestino(), aux.getNombreDestino());
                aux = aux.getSiguiente();
            }
            aux = raiz.getPrimero();
            while (aux.getSiguiente() != null)
            {
                aux = aux.getSiguiente();
            }
           Graficar4Nuevo(aux.getDerecha());

        }

        public void Graficar4Viejo(RamaArbol raiz)
        {
            
                NodoListaDoble auxiliarlista = listacabeceras.getPrimero();
                if (auxiliarlista.getSiguiente() == null)
                {

                }
                else
                {
                    while (auxiliarlista.getSiguiente() != null)
                    {
                        Contenido += "F" + auxiliarlista.getCodigo()+"->F"+auxiliarlista.getSiguiente().getCodigo()+ "[rankdir=UD];\n";

                        auxiliarlista = auxiliarlista.getSiguiente();
                    }
                }
                
        }

        public void NumeroFilas(RamaArbol raiz)
            {
                if (raiz == null)
                {
                    return;
                }
                //  nodos += raiz.getGraphNodo();
                NodoRamaArbol aux = raiz.getPrimero();
                while (aux != null)
                {

                    NumeroFilas(aux.getIzquierda());
                    Console.WriteLine(aux.getCodigoDestino());
                    ////////////////////////////////////////////////// aqui empieza la inserccion a la matriz

                    if (aux.getFilaPrimero() != null)
                    {
                        contadorcabecerasfilasoriginal++;

                    }
                    aux = aux.getSiguiente();
                }
                aux = raiz.getPrimero();
                while (aux.getSiguiente() != null)
                {
                    aux = aux.getSiguiente();
                }
                NumeroFilas(aux.getDerecha());

            }

            public void Graficar(RamaArbol raiz)
            {
                if (raiz == null)
                {
                    return;
                }
                //  nodos += raiz.getGraphNodo();
                NodoRamaArbol aux = raiz.getPrimero();
                while (aux != null)
                {

                   Graficar(aux.getIzquierda());
                    ////////////////////////////////////////////////// aqui empieza la inserccion a la matriz

                   
                        contadorcabeceras++;
                        Contenido += "C" + aux.getCodigoDestino() + "[label = \"" + aux.getNombreDestino() + "\"   ];\n ";
                        
                    
                    aux = aux.getSiguiente();
                }
                aux = raiz.getPrimero();
                while (aux.getSiguiente() != null)
                {
                    aux = aux.getSiguiente();
                }
                Graficar(aux.getDerecha());

               
            }
            public void Graficar3(RamaArbol raiz)
            {
                if (raiz == null)
                {
                    return;
                }
                //  nodos += raiz.getGraphNodo();
                NodoRamaArbol aux = raiz.getPrimero();
                while (aux != null)
                {

                    Graficar3(aux.getIzquierda());
                    ////////////////////////////////////////////////// aqui empieza la inserccion a la matriz

                    
                        Contenido += "->C" + aux.getCodigoDestino();
                        contadorcabeceras2++;
                        if (contadorcabeceras2  != contadorcabeceras)
                        {
                            Contenido2 = "->C" + aux.getCodigoDestino() + Contenido2;
                        }
                    
                    aux = aux.getSiguiente();
                }
                aux = raiz.getPrimero();
                while (aux.getSiguiente() != null)
                {
                    aux = aux.getSiguiente();
                }
                Graficar3(aux.getDerecha());


            }


        public void Graficar2(RamaArbol raiz){
            
            if (raiz == null)
            {
                return;
            }
            //  nodos += raiz.getGraphNodo();
            NodoRamaArbol aux = raiz.getPrimero();
                while (aux != null)
                {
                Boolean llave = false;
                    Graficar2(aux.getIzquierda());
                    Console.WriteLine(aux.getCodigoDestino());
                    ////////////////////////////////////////////////// aqui empieza la inserccion a la matriz

                    

                            Contenido += "{ \nrank=same;\n";
                        
                        
                        Contenido += "F" + aux.getCodigoDestino() + "[label = \"" + aux.getNombreDestino() + "\"   ];\n ";
                if (aux.getFilaPrimero() != null)
                {
                    NodoMatriz recorrido = aux.getFilaPrimero();
                        while(recorrido != null){

                            Contenido += "F" + recorrido.getCodigoPrimerPais() + "C" + recorrido.getCodigosegundoPais() + "[label = \"Costo: " + recorrido.getCosto() + ",Tiempo: " + recorrido.getTiempo() + "\"   ];\n ";
                            recorrido = recorrido.getSiguienteMatriz();
                        llave = true;
                            
                        }
                        Contenido += "} \n";

                    }
                if (!llave)
                {
                    Contenido += "} \n";
                }
                aux = aux.getSiguiente();
                }
                aux = raiz.getPrimero();
                while (aux.getSiguiente() != null)
                {
                    aux = aux.getSiguiente();
                }
                Graficar2(aux.getDerecha());

                
            }

       

        public void Graficar5(RamaArbol raiz)
        {
            if (raiz == null)
            {
                return;
            }
            //  nodos += raiz.getGraphNodo();
            NodoRamaArbol aux = raiz.getPrimero();
            while (aux != null)
            {

                Graficar5(aux.getIzquierda());
                Console.WriteLine(aux.getCodigoDestino());
                ////////////////////////////////////////////////// aqui empieza la inserccion a la matriz

                if (aux.getColumnaPrimero() != null)
                {
                    
                    
                    Contenido += "C" + aux.getCodigoDestino()+"->";
                    NodoMatriz recorrido = aux.getColumnaPrimero();
                    while (recorrido != null)
                    {
                        if (recorrido.getAbajoMatriz() != null)
                        {
                            Contenido += "F" + recorrido.getCodigoPrimerPais() + "C" + recorrido.getCodigosegundoPais() + "->";
                            
                        }
                        else {
                            Contenido += "F" + recorrido.getCodigoPrimerPais() + "C" + recorrido.getCodigosegundoPais() + ";\n";
                          
                            break;
                        }
                        recorrido = recorrido.getAbajoMatriz();

                    }
                    while (recorrido != null)
                    {
                        if (recorrido.getAribaMatriz() != null)
                        {
                            Contenido += "F" + recorrido.getCodigoPrimerPais() + "C" + recorrido.getCodigosegundoPais() + "->";
                        }
                        else
                        {
                            Contenido += "F" + recorrido.getCodigoPrimerPais() + "C" + recorrido.getCodigosegundoPais() + "->C" + aux.getCodigoDestino() + ";\n";
                            
                        }
                        recorrido = recorrido.getAribaMatriz();
                    }
                }
                aux = aux.getSiguiente();
            }
            aux = raiz.getPrimero();
            while (aux.getSiguiente() != null)
            {
                aux = aux.getSiguiente();
            }
            Graficar5(aux.getDerecha());
        }

        public void Graficar6(RamaArbol raiz)
        {
            if (raiz == null)
            {
                return;
            }
            //  nodos += raiz.getGraphNodo();
            NodoRamaArbol aux = raiz.getPrimero();
            while (aux != null)
            {

                Graficar6(aux.getIzquierda());
                Console.WriteLine(aux.getCodigoDestino());
                ////////////////////////////////////////////////// aqui empieza la inserccion a la matriz

                if (aux.getFilaPrimero() != null)
                {
                    

                    
                    if (aux.getFilaPrimero() != null)
                    {

                        NodoMatriz recorrido = aux.getFilaPrimero();
                        Contenido += "F" + aux.getCodigoDestino() + "->F" + recorrido.getCodigoPrimerPais() + "C" + recorrido.getCodigosegundoPais() + "[constraint=false];\n";
                        Contenido += "F" + recorrido.getCodigoPrimerPais() + "C" + recorrido.getCodigosegundoPais() + "->F" + aux.getCodigoDestino() + "[constraint=false];\n";
                        while (recorrido.getSiguienteMatriz() != null)
                        {

                            Contenido += "F" + recorrido.getCodigoPrimerPais() + "C" + recorrido.getCodigosegundoPais() + "->F" + recorrido.getSiguienteMatriz().getCodigoPrimerPais() + "C" + recorrido.getSiguienteMatriz().getCodigosegundoPais() + "[constraint=false];\n";
                            Contenido += "F" + recorrido.getSiguienteMatriz().getCodigoPrimerPais() + "C" + recorrido.getSiguienteMatriz().getCodigosegundoPais() + "->F" + recorrido.getCodigoPrimerPais() + "C" + recorrido.getCodigosegundoPais() + "[constraint=false];\n";
                            recorrido = recorrido.getSiguienteMatriz();

                        }
                        Contenido += "\n";
                    }
                }
                aux = aux.getSiguiente();
            }
            aux = raiz.getPrimero();
            while (aux.getSiguiente() != null)
            {
                aux = aux.getSiguiente();
            }
            Graficar6(aux.getDerecha());


        }

        static void graficaMatriz()
        {
            string Loqueenvio = "digraph matriz {\nrankdir=UD;\nnode[shape=box];\n\n{\nrank = min;\nm[label = \"Matriz\" ];\n" + Contenido;
            Loqueenvio += "}";
            StreamWriter fichero = null;
            try
            {
                fichero = new StreamWriter("arbolBDestino.dot");
                fichero.Write(Loqueenvio);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            finally
            {
                try
                {
                    if (null != fichero)
                        fichero.Close();
                }
                catch (Exception e2) { MessageBox.Show(e2.ToString()); }
            }
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Program Files (x86)\\graphviz-2.38\\release\\bin\\dot.exe");
            startInfo.Arguments = "-Tpng  arbolBDestino.dot  -o  arbolBDestino.png ";
            Process.Start(startInfo);
            Process.Start("arbolBDestino.png ");

        }

        public void ModificarRuta(int PrimerPais, int SegundoPais, float costo, float tiempo)
        {
            
            Boolean encontrado = false;
            if (PrimerPais != SegundoPais)
            {
                NodoRamaArbol modificado = busqueda(PrimerPais);

                NodoMatriz recorrido = modificado.getFilaPrimero();
                while (recorrido != null)
                {
                    if (recorrido.getCodigoPrimerPais() == SegundoPais || recorrido.getCodigosegundoPais() == SegundoPais)
                    {
                        //agregado
                        matrizcosto = false;
                        matriztiempo = false;
                        //agregado
                        encontrado = true;
                        recorrido.setCosto(costo);
                        recorrido.setTiempo(tiempo);

                    }

                    recorrido = recorrido.getSiguienteMatriz();
                }

                if (!encontrado)
                {
                    Console.WriteLine("Ruta no existente");
                }

            }
        }

        public void GraficarGrafo() {
            listacabeceras.setPrimero(null);
            Graficar4Nuevo(raiz);
            ContenidoGrafoPrimero();
            GraficarGrafo1(raiz);
            ContenidoGrafo += "}";
            CrearGrafoImagen();
        }

        public void CrearGrafoImagen() {
            StreamWriter fichero = null;
            try
            {
                fichero = new StreamWriter("Grafo.dot");
                fichero.Write(ContenidoGrafo);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            finally
            {
                try
                {
                    if (null != fichero)
                        fichero.Close();
                }
                catch (Exception e2) { MessageBox.Show(e2.ToString()); }
            }
            ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Program Files (x86)\\graphviz-2.38\\release\\bin\\dot.exe");
            startInfo.Arguments = "-Tpng  Grafo.dot  -o  Grafo.png ";
            Process.Start(startInfo);
            Process.Start("Grafo.png ");
        }

        public void ContenidoGrafoPrimero() {
            ContenidoGrafo = "graph grafo{\n";
            NodoListaDoble auxiliarlista = listacabeceras.getPrimero();
            
                while (auxiliarlista != null)
                {
                    ContenidoGrafo += "Grafo" + auxiliarlista.getCodigo()+ "[label = \""+auxiliarlista.getNombre() +"\" ];\n";
                    auxiliarlista = auxiliarlista.getSiguiente();
                }
            
        }

        public void GraficarGrafo1(RamaArbol raiz) {

            if (raiz == null)
            {
                return;
            }
            //  nodos += raiz.getGraphNodo();
            NodoRamaArbol aux = raiz.getPrimero();
            while (aux != null)
            {

                GraficarGrafo1(aux.getIzquierda());
                
                if (aux.getFilaPrimero() != null) {
                    NodoMatriz recorri = aux.getFilaPrimero();
                    while (recorri != null) {
                        ContenidoGrafo += "Grafo" + recorri.getCodigoPrimerPais() + "--Grafo" + recorri.getCodigosegundoPais()+"\n";
                        recorri = recorri.getSiguienteMatriz();
                    }
                }
            
                aux = aux.getSiguiente();
            }
            aux = raiz.getPrimero();
            while (aux.getSiguiente() != null)
            {
                aux = aux.getSiguiente();
            }
            GraficarGrafo1(aux.getDerecha());


        }

        public void ELiminarMatriz(int PrimerPais, int SegundoPais)
        {
            NodoMatriz eliminar = COnseguirNodoAEliminar(PrimerPais, SegundoPais);
            if (eliminar != null) {
                //agregado
                matrizcosto = false;
                matriztiempo = false;
                //agregado
                if (eliminar.getArribaCabecera() != null)
                 {
                if (eliminar.getAbajoMatriz() != null)
                {
                    eliminar.getArribaCabecera().setColumnaPrimero(eliminar.getAbajoMatriz());
                }
                else
                {
                    eliminar.getArribaCabecera().setColumnaPrimero(null);
                }
            }
            if (eliminar.getIzquierdaCabecera() != null)
            {
                if (eliminar.getSiguienteMatriz() != null)
                {
                    eliminar.getIzquierdaCabecera().setFilaPrimero(eliminar.getSiguienteMatriz());
                }
                else
                {
                    eliminar.getIzquierdaCabecera().setFilaPrimero(null);
                }
            }
            if (eliminar.getAnteriorMatriz() != null)
            {
                if (eliminar.getSiguienteMatriz() != null)
                {
                    eliminar.getSiguienteMatriz().setAnteriorMatriz(eliminar.getAnteriorMatriz());
                    eliminar.getAnteriorMatriz().setSiguienteMatriz(eliminar.getSiguienteMatriz());
                }
                else
                {
                    eliminar.getAnteriorMatriz().setSiguienteMatriz(null);
                }
            }
            if (eliminar.getSiguienteMatriz() != null)
            {
                if (eliminar.getAnteriorMatriz() != null)
                {
                    eliminar.getAnteriorMatriz().setSiguienteMatriz(eliminar.getSiguienteMatriz());
                    eliminar.getSiguienteMatriz().setAnteriorMatriz(eliminar.getAnteriorMatriz());
                }
                else
                {
                    eliminar.getSiguienteMatriz().setAnteriorMatriz(null);
                }
            }
                if (eliminar.getAribaMatriz() != null) {
                    if (eliminar.getAbajoMatriz() != null)
                    {
                        eliminar.getAbajoMatriz().setAribaMatriz(eliminar.getAribaMatriz());
                        eliminar.getAribaMatriz().setAbajoMatriz(eliminar.getAbajoMatriz());
                    }
                    else {
                        eliminar.getAribaMatriz().setAbajoMatriz(null);
                    }
                }
                if (eliminar.getAbajoMatriz() != null) {
                    if (eliminar.getAribaMatriz() != null)
                    {
                        eliminar.getAribaMatriz().setAbajoMatriz(eliminar.getAbajoMatriz());
                        eliminar.getAbajoMatriz().setAribaMatriz(eliminar.getAribaMatriz());
                    }
                    else {
                        eliminar.getAbajoMatriz().setAribaMatriz(null);
                    }
                }
        }

    }

        public NodoMatriz COnseguirNodoAEliminar(int PrimerPais, int SegundoPais)
        {
            
            Boolean encontrado = false;
            if (PrimerPais != SegundoPais)
            {
                NodoRamaArbol modificado = busqueda(PrimerPais);

                NodoMatriz recorrido = modificado.getFilaPrimero();
                while (recorrido != null)
                {
                    if (recorrido.getCodigoPrimerPais() == SegundoPais || recorrido.getCodigosegundoPais() == SegundoPais)
                    {
                        return recorrido;

                    }

                    recorrido = recorrido.getSiguienteMatriz();
                }

                if (!encontrado)
                {
                    Console.WriteLine("Ruta no existente");
                }

            }
            return null;
        }

        //agregado
        int contadorllenado = 0;

        string[] llenadoNombres;
        int[] llenado;

        public void llenar(RamaArbol raiz) {
          
            if (raiz == null)
            {
                return;
            }
            //  nodos += raiz.getGraphNodo();
            NodoRamaArbol aux = raiz.getPrimero();
            while (aux != null)
            {

                llenar(aux.getIzquierda());
                llenado[contadorllenado] = aux.getCodigoDestino();
                llenadoNombres[contadorllenado] = aux.getNombreDestino();
                contadorllenado++;
                aux = aux.getSiguiente();
            }
            aux = raiz.getPrimero();
            while (aux.getSiguiente() != null)
            {
                aux = aux.getSiguiente();
            }
            llenar(aux.getDerecha());


        

    }

        

        private float[,] p;
        private float[,] c;
        int tamaniodelascabeceras = 0;

        public void tamaniocabeceras(RamaArbol raiz)
        {

            if (raiz == null)
            {
                return;
            }
            //  nodos += raiz.getGraphNodo();
            NodoRamaArbol aux = raiz.getPrimero();
            while (aux != null)
            {

                tamaniocabeceras(aux.getIzquierda());

                tamaniodelascabeceras++;
                aux = aux.getSiguiente();
            }
            aux = raiz.getPrimero();
            while (aux.getSiguiente() != null)
            {
                aux = aux.getSiguiente();
            }
            tamaniocabeceras(aux.getDerecha());




        }

        public float[,] floydTiempo()
        {
           
            
            matriztiempo = true;
          
            tamaniodelascabeceras = 0;
            tamaniocabeceras(raiz);
            llenado = new int[tamaniodelascabeceras];
            llenadoNombres = new string[tamaniodelascabeceras];
            contadorllenado = 0;
            llenar(raiz);
            c = insmatrizTiempo(tamaniodelascabeceras);
            p = iniciar(tamaniodelascabeceras);
            camino();

            return c;
        }
        public float[,] floydCosto()
        {
            
            matrizcosto = true;
            
            
            tamaniodelascabeceras = 0;
            tamaniocabeceras(raiz);
            llenado = new int[tamaniodelascabeceras];
            llenadoNombres = new string[tamaniodelascabeceras];
            contadorllenado = 0;
            llenar(raiz);
            c = insmatrizCosto(tamaniodelascabeceras);
            p = iniciar(tamaniodelascabeceras);
            camino();

            return c;
        }
        public float cminimo(int i, int j)
        {
            int fila = 0;
            int columna =0;
            for (int f = 0; f < tamaniodelascabeceras; f++) {
                if (llenado[f] == i) {
                    fila = f;
                    break;
                }

            }
            for (int f = 0; f < tamaniodelascabeceras; f++)
            {
                if (llenado[f] == j)
                {
                    columna = f;
                    break;
                }

            }
            return c[fila, columna];
        }
        public void camino()
        {
            int n = tamaniodelascabeceras;
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (c[i, k] + c[k, j] < c[i, j] && c[i, k]  != 0 && c[k, j] != 0)
                        {
                            c[i, j] = c[i, k] + c[k, j];
                            p[i, j] = k;
                        }
                    }
                }
            }
        }
        public float[,] iniciar(int g)
        {
            int n = g;
            p = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    p[i, j] = -1;
                }
            }
            return p;
        }
        public float[,] insmatrizCosto(int g)
        {
            int n = g;
            c = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = getCosto(llenado[i], llenado[j]);
                }
            }
            return c;
        }

        public float[,] insmatrizTiempo(int g)
        {
            int n = g;
            c = new float[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c[i, j] = getTiempo(llenado[i], llenado[j]);
                }
            }
            return c;
        }

        public float getCosto(int primerpais, int segundopais) {
            if (primerpais != segundopais)
            {
                NodoRamaArbol modificado = busqueda(primerpais);

                NodoMatriz recorrido = modificado.getFilaPrimero();
                while (recorrido != null)
                {
                    if (recorrido.getCodigoPrimerPais() == segundopais || recorrido.getCodigosegundoPais() == segundopais)
                    {
                        return recorrido.getCosto();

                    }

                    recorrido = recorrido.getSiguienteMatriz();
                }
            }
            return 0;
        }

        public float getTiempo(int primerpais, int segundopais)
        {
            if (primerpais != segundopais)
            {
                NodoRamaArbol modificado = busqueda(primerpais);

                NodoMatriz recorrido = modificado.getFilaPrimero();
                while (recorrido != null)
                {
                    if (recorrido.getCodigoPrimerPais() == segundopais || recorrido.getCodigosegundoPais() == segundopais)
                    {
                        return recorrido.getTiempo();

                    }

                    recorrido = recorrido.getSiguienteMatriz();
                }
            }
            return 0;
        }

        public void GraficarRutaMenor(int primero, int segundo)
        {
            StreamWriter fichero = null;
            try
            {
                fichero = new StreamWriter("rutamenor.dot");
                fichero.Write(getDotMenor(primero, segundo));
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            finally
            {
                try
                {
                    if (null != fichero)
                        fichero.Close();
                }
                catch (Exception e2) { MessageBox.Show(e2.ToString()); }
            }
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("C:\\Program Files (x86)\\graphviz-2.38\\release\\bin\\dot.exe");
                startInfo.Arguments = "-Tpng  rutamenor.dot  -o  rutamenor.png ";
                Process.Start(startInfo);
                Process.Start("rutamenor.png ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en generar archivo dot " + ex.ToString());
            }

        }

        public string getDotMenor(int primerpais, int segundopais)
        {

            NodoRamaArbol primero = busqueda(primerpais);
            NodoRamaArbol segundo = busqueda(segundopais);
            string primernombre = primero.getNombreDestino();
            string segundonombre = segundo.getNombreDestino();
            if (primero.getNombreDestino().Contains(" "))
            {
                primernombre = primero.getNombreDestino().Replace(" ", "_");
            }
            if (segundo.getNombreDestino().Contains(" "))
            {
                segundonombre = segundo.getNombreDestino().Replace(" ", "_");
            }
            DotMenor = "digraph lista{\n" + primernombre;
            ruta(primerpais, segundopais, true);
            DotMenor += "->" + segundonombre +"->Total"+Convert.ToInt32(cminimo(primerpais, segundopais)) +"\n}";
            
            return DotMenor;
        }
        string DotMenor = "";

        public void ruta(int i, int j, bool primerpaso)
        {
            
            int fila = i;
            int columna = j;
            if (primerpaso)
            {
                for (int f = 0; f < tamaniodelascabeceras; f++)
                {
                    if (llenado[f] == i)
                    {
                        fila = f;
                        break;
                    }

                }
                for (int f = 0; f < tamaniodelascabeceras; f++)
                {
                    if (llenado[f] == j)
                    {
                        columna = f;
                        break;
                    }

                }
            }
            float k = p[fila, columna];
            if (k != -1)
            {
                ruta(fila, Convert.ToInt32(k), false);
                string nombre = llenadoNombres[Convert.ToInt32(k)].Replace(" ", "_");
                DotMenor += "->" + nombre;
                ruta(Convert.ToInt32(k), columna, false);
            }
        }

        //agregado

    }
}

