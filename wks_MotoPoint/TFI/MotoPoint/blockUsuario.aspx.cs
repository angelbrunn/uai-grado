using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace MotoPoint
{
    public partial class blockUsuario : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginEstado = Session["loginEstado"].ToString();
            string idUsuario = Session["UsuarioId"].ToString();

            if (loginEstado == "1" || idUsuario == null)
            {
                Session["loginEstado"] = 1;
                FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            //MOSTRAR PANTALLA LOGIN | AVISAR USER INVALIDO
            Session["loginEstado"] = 1;
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}