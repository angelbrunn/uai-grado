using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class Eventos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var loginEstado = Session["loginEstado"];
            var loginUsuario = Session["loginUsuario"];

            //SI ES UN USUARIO NUEVO O INVALIDO LO SACO
            if (loginEstado.ToString() == "1" || loginUsuario.ToString() == "NuevoUsuario")
            {
                Session["loginEstado"] = 1;
                FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
        }
    }
}