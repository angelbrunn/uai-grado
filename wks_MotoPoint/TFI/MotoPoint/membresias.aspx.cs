using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class membresias : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarBronce_Click(object sender, EventArgs e)
        {
            Response.Redirect("membresiaspago.aspx");
        }

        protected void btnSeleccionarPlata_Click(object sender, EventArgs e)
        {
            Response.Redirect("membresiaspago.aspx");
        }

        protected void btnSeleccionarOro_Click(object sender, EventArgs e)
        {
            Response.Redirect("membresiaspago.aspx");
        }
    }
}