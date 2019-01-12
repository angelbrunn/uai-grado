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
            var loginEstado = Session["loginEstado"];
            var loginUsuario = Session["loginUsuario"];
            Session["registroEstado"] = 0;
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
            //MOSTRAR PANTALLA LOGIN | AVISAR USER INVALIDO
            Session["loginEstado"] = 1;
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }
    }
}