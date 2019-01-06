using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Xml;

namespace MotoPoint
{
    /// <summary>
    /// 
    /// </summary>
    public partial class membresiaspago : System.Web.UI.Page
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
            string idUsuario = Session["IdMembresia"].ToString();
            string idMembresia = Session["UsuarioId"].ToString();
            string precioMembresia = Session["valorMembresia"].ToString();

            txtMontoPagar.Text = precioMembresia;

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            //VALIDO EL PAGO VIA WEBSERVICES
            var operacion = new localhost.Service();

            string numeroTarjeta = txtNumeroTarjeta.Text;
            string numeroSeguridad = txtCvc.Text;
            string fechaValidez = txtFecha.Text;
            string nombreTitular = txtTitularTarjeta.Text;

            Boolean resultadoPago = false;

            resultadoPago = operacion.PagoMembresia(numeroTarjeta, numeroSeguridad, fechaValidez, nombreTitular);

            if (resultadoPago == true)
            {
                //ACTIVAR USUARIO
                //ENVIAR FACTURA
                resultadoPago = false;
                Response.Redirect("isOk.aspx");
            }
            else
            {
                resultadoPago = false;
                Response.Redirect("isError.aspx");
            }

        }
    }
}