﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    /// <summary>
    /// NEGOCIO PAGO DE LA MEMBRESIA
    /// </summary>
    public partial class membresias : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //ESTAMOS DENTRO DEL PAGO DE LA MEMBRESIA
            var estado = 1;
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