using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class isError : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["registroEstado"] != null)
            {
                string loginEstado = Session["loginEstado"].ToString();
                string idUsuario = Session["UsuarioId"].ToString();

                if (loginEstado == "1" || idUsuario == null)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("login.aspx");
                }
            }
            else
            {
                string isCompraActividad = Session["CompraActividad"].ToString();
                if (isCompraActividad == "0")
                {
                    Response.Redirect("eventos.aspx");
                }
                else if (isCompraActividad == "1")
                {
                    Response.Redirect("actividades.aspx");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected override void InitializeCulture()
        {
            if (Session["lang"] != null)
            {
                SetCulture(Session["lang"].ToString());
                base.InitializeCulture();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        private void SetCulture(string lang)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            string isCompraActividad = Session["CompraActividad"].ToString();
            if (isCompraActividad == "0")
            {
                Response.Redirect("eventos.aspx");
            }
            else if (isCompraActividad == "1")
            {
                Response.Redirect("actividades.aspx");
            }
        }
    }
}