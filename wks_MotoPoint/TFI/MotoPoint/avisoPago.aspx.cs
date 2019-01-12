using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class avisoPago : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginUsuario"] != null)
            {
                string usuarioEstado = Session["UsuarioEstado"].ToString();

                if (usuarioEstado != "Activo")
                {
                    string loginEstado = Session["loginEstado"].ToString();
                    string idUsuario = Session["UsuarioId"].ToString();

                    if (loginEstado == "1" || idUsuario == null)
                    {
                        Session.Clear();
                        FormsAuthentication.SignOut();
                        Response.Redirect("login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("eventos.aspx");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Response.Redirect("membresias.aspx");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            //ARQ.BASE - MOSTRAR PANTALLA LOGIN
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}