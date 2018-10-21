using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class membresiaspago : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            //VALIDO EL PAGO VIA WEBSERVICES

        }
    }
}