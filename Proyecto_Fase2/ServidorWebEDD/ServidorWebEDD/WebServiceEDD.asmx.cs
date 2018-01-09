using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServidorWebEDD
{
    /// <summary>
    /// Descripción breve de WebServiceEDD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceEDD : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public string arbolB()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public string arbolAVL()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public string Usuarios()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public string ListaJugadores()
        {
            return "Hola a todos";
        }
        [WebMethod]
        public string Tablahash()
        {
            return "Hola a todos";
        }


    }
}
