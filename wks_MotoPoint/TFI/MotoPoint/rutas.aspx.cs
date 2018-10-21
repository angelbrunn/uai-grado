using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class rutas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var loginEstado = Session["loginEstado"];
            var loginUsuario = Session["loginUsuario"];

            if (loginEstado.ToString() == "1" || loginUsuario.ToString() == "NuevoUsuario")
            {
                Session["loginEstado"] = 1;
                FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
        }
    }
}