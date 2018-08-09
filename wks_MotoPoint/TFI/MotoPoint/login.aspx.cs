using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SIS.DATOS.DALUsuario oDALUsuario = new SIS.DATOS.DALUsuario();

            List<SIS.ENTIDAD.Usuario> listadoUsuarios = new List<SIS.ENTIDAD.Usuario>();

            SIS.ENTIDAD.Usuario oUsuario1 = new SIS.ENTIDAD.Usuario();
            SIS.ENTIDAD.Usuario oUsuario2 = new SIS.ENTIDAD.Usuario();
            SIS.ENTIDAD.Usuario oUsuario3 = new SIS.ENTIDAD.Usuario();
            SIS.ENTIDAD.Usuario oUsuario4 = new SIS.ENTIDAD.Usuario();
            SIS.ENTIDAD.Usuario oUsuario5 = new SIS.ENTIDAD.Usuario();
            SIS.ENTIDAD.Usuario oUsuario6 = new SIS.ENTIDAD.Usuario();

            oUsuario1.IdUsuario = "1";
            oUsuario1.usuario = "+pCr84LA6YzI49XHi6Z3aID/igc86RNu8kIV3sFuYzs=";
            oUsuario1.Password = "rjl7a+wlWfAg8uV9HiYogB1HlCw/FMSxnFnpnamqXrQ=";
            oUsuario1.Legajo = "XiSmwn6eMrLBmqWle4U97lLUoOdDI/Ng3Z95R1TUlFg=";
            oUsuario1.Idioma = "T2XhhHaD5t/hUY1hZr3ChBZBmLTmZsFD6ARDaD3ldsU=";
            oUsuario1.DigitoVerificador = "LpRiDD/17BvU8U4B5n0pFutLwxflc9YnpdI83U5uDho=";

            oUsuario2.IdUsuario = "2";
            oUsuario2.usuario = "WebMaster";
            oUsuario2.Password = "AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=";
            oUsuario2.Legajo = "1";
            oUsuario2.Idioma = "es";
            oUsuario2.DigitoVerificador = "1hvfNVZ8jonw6yNdwzDXzvjgeEo2ekXOCF30Of85Gtc=";

            oUsuario3.IdUsuario = "3";
            oUsuario3.usuario = "Usuario";
            oUsuario3.Password = "AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=";
            oUsuario3.Legajo = "2";
            oUsuario3.Idioma = "es";
            oUsuario3.DigitoVerificador = "1hvfNVZ8jonw6yNdwzDXzvjgeEo2ekXOCF30Of85Gtc=";

            oUsuario4.IdUsuario = "4";
            oUsuario4.usuario = "UsuarioJer";
            oUsuario4.Password = "AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=";
            oUsuario4.Legajo = "3";
            oUsuario4.Idioma = "es";
            oUsuario4.DigitoVerificador = "1hvfNVZ8jonw6yNdwzDXzvjgeEo2ekXOCF30Of85Gtc=";

            oUsuario5.IdUsuario = "5";
            oUsuario5.usuario = "UsuarioIngles";
            oUsuario5.Password = "AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=";
            oUsuario5.Legajo = "4";
            oUsuario5.Idioma = "en";
            oUsuario5.DigitoVerificador = "1hvfNVZ8jonw6yNdwzDXzvjgeEo2ekXOCF30Of85Gtc=";

            oUsuario6.IdUsuario = "6";
            oUsuario6.usuario = "usuariolalala";
            oUsuario6.Password = "AmgfenQMf2A1DCMQTXBWsWg3hTbdnsgUNpsa2oYHgWw=";
            oUsuario6.Legajo = "5";
            oUsuario6.Idioma = "en";
            oUsuario6.DigitoVerificador = "1hvfNVZ8jonw6yNdwzDXzvjgeEo2ekXOCF30Of85Gtc=";

            listadoUsuarios.Add(oUsuario1);
            listadoUsuarios.Add(oUsuario2);
            listadoUsuarios.Add(oUsuario3);
            listadoUsuarios.Add(oUsuario4);
            listadoUsuarios.Add(oUsuario5);
            listadoUsuarios.Add(oUsuario6);


            oDALUsuario.InsertarUsuario(listadoUsuarios);

        }
    }
}