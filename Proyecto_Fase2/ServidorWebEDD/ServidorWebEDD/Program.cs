using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolBDestino
{
    static class Program
    {

        [STAThread]
        static void Main()
        {

            ArbolDestinos aB = new ArbolDestinos();
            aB.insertar(7720, "Guatemala");
            aB.insertar(7721, "El Salvador");
            aB.insertar(7722, "Honduras");
            aB.insertar(7723, "Nicaragua");
            aB.insertar(7725, "Bosnia");
            aB.insertar(7728, "uno");
            aB.insertar(7729, "dos");
            aB.insertar(7730, "tres");
            aB.insertar(7735, "cuatr");
            aB.insertar(7715, "cinco");
            aB.insertar(7745, "seis");
            aB.insertar(7755, "siete");
            aB.insertar(7778, "ocho");
            aB.insertar(7789, "nueve");
            aB.insertar(7700, "diez");
            aB.insertar(77, "once");
            aB.IngresarDatos(7721, 7723, 15.3F, 110);
            aB.IngresarDatos(7721, 7722, 500.4F, 120);
            aB.IngresarDatos(7720, 7723, 4.35F, 160);
            aB.IngresarDatos(7723, 7722, 56, 160);
            aB.IngresarDatos(7722, 7720, 57, 180);
            aB.ModificarRuta(7723, 7720, 850, 690);
            aB.ELiminarMatriz(7723, 7725);



            aB.rec2();//GraficarMatriz

            aB.GraficarGrafo();
            //agregado
            //conseguir costo minimo
            if (aB.getMatrizCosto())
            {
                aB.GraficarRutaMenor(7721, 7722);
            }
            else {
                aB.floydCosto();
                aB.GraficarRutaMenor(7721, 7722);
            }
            

           
            //conseguir tiempo minimo
            if (aB.getMatriztiempo())
            {
                aB.GraficarRutaMenor(7721, 7722);
            }
            else
            {
                aB.floydTiempo();
                aB.GraficarRutaMenor(7721, 7722);
            }
        }
        //agregado

        static void graficaB(ArbolDestinos aB)
        {

             StreamWriter fichero = null;
            try
            {
                fichero = new StreamWriter("arbolBDestino.dot");
                fichero.Write(aB.getDot());
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
                startInfo.Arguments = "-Tpng  arbolBDestino.dot  -o  arbolBDestino.png ";
                Process.Start(startInfo);
                Process.Start("arbolBDestino.png ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en generar archivo dot "+ex.ToString());
            }




                       
    }
    }
}
