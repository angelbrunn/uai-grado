using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class recordar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var loginEstado = Session["loginEstado"];
            var loginUsuario = Session["loginUsuario"];

            //SI ES UN USUARIO REGISTRADO O VALIDO LO SACO
            if (loginEstado.ToString() == "0" || loginUsuario.ToString() != "NuevoUsuario")
            {
                FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //RECUPERAR LA CONTRASEÑA DE USUARIO E ENVIARLA AL MAIL INDICADO
            //TODO . . . 

            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}