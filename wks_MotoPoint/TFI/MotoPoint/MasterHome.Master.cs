using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace MotoPoint
{
    public partial class MasterHome : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            var loginEstado = Session["loginEstado"];
            var loginUsuario = Session["loginUsuario"];

            if (loginEstado.ToString() == "0" && loginUsuario.ToString() != "NuevoUsuario")
            {
                Session["loginEstado"] = 0;
            }
            else if (loginEstado.ToString() == "1")
            {
                //SI ES UN USUARIO NUEVO O INVALIDO LO SACO
                Session["loginEstado"] = 1;
                FormsAuthentication.SignOut();
                Session.Clear();
                Response.Redirect("login.aspx");
            }



        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}