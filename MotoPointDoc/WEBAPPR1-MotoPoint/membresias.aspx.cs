using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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
        string precioBronce;
        /// <summary>
        /// 
        /// </summary>
        string precioPlata;
        /// <summary>
        /// 
        /// </summary>
        string precioOro;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //NEGOCIO: ACTUALIZO LOS VALORES DE LAS MEMBRESIAS
            if (Session["UsuarioId"].ToString() != null)
            {
                //NEGOCIO: VALIDO SI YA TIENE UNA MEMBRESIA DICHO USUARIO | SI TIENE UNA MEMBRESIA EN VEZ 
                string idUsuario = Session["UsuarioId"].ToString();
                precioBronce = System.Convert.ToString(interfazNegocio.ObtenerMembresiaPrecio("3"));
                precioPlata = System.Convert.ToString(interfazNegocio.ObtenerMembresiaPrecio("2"));
                precioOro = System.Convert.ToString(interfazNegocio.ObtenerMembresiaPrecio("1"));
                lblPrecioBronce.Text = "$ " + precioBronce;
                lblPrecioPlata.Text = "$ " + precioPlata;
                lblPrecioOro.Text = "$ " + precioOro;
                //ARQ.BASE MULTI-USUARIO | VALIDO USUARIO
                if (idUsuario == null || idUsuario == "")
                {
                    //ARQ.BASE LOGIN MOSTRAR PANTALLA LOGIN | AVISAR USER INVALIDO
                    Session["loginEstado"] = 1;
                    Response.Redirect("login.aspx");
                }
            }
            else
            {
                //ARQ.BASE LOGIN MOSTRAR PANTALLA LOGIN | NO EXISTE USUARIO VALIDO
                Session["loginEstado"] = 1;
                Response.Redirect("login.aspx");
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
        protected void btnSeleccionarBronce_Click(object sender, EventArgs e)
        {
            // NEGOCIO - BUSCO EL ID PARA LA MEMBRESIA TIPO BRONCE
            string idMembresia = interfazNegocio.ObtenerMembresiaSegunTipo("Bronce").ToString();
            string idUsuario = Session["UsuarioId"].ToString();
            // NEGOCIO - GUARDO LA MEMBRESIA SELECCIONADA PARA EL USUARIO O ACTUALIZO MEMBRESIA ACTUAL
            Session["IdMembresia"] = idMembresia;
            Session["UsuarioId"] = idUsuario;
            Session["valorMembresia"] = precioBronce;
            Session["codigoMembresia"] = "3";
            Session["tipoMembresia"] = "BRONCE";
            Session["registroEstado"] = 0;
            Session["CompraActividad"] = 0;
            Response.Redirect("membresiaspago.aspx");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeleccionarPlata_Click(object sender, EventArgs e)
        {
            // NEGOCIO - BUSCO EL ID PARA LA MEMBRESIA TIPO BRONCE
            string idMembresia = interfazNegocio.ObtenerMembresiaSegunTipo("Plata").ToString();
            string idUsuario = Session["UsuarioId"].ToString();
            // NEGOCIO - GUARDO LA MEMBRESIA SELECCIONADA PARA EL USUARIO O ACTUALIZO MEMBRESIA ACTUAL
            Session["IdMembresia"] = idMembresia;
            Session["UsuarioId"] = idUsuario;
            Session["valorMembresia"] = precioPlata;
            Session["tipoMembresia"] = "PLATA";
            Session["codigoMembresia"] = "2";
            Session["registroEstado"] = 0;
            Session["CompraActividad"] = 0;
            Response.Redirect("membresiaspago.aspx");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSeleccionarOro_Click(object sender, EventArgs e)
        {
            // NEGOCIO - BUSCO EL ID PARA LA MEMBRESIA TIPO BRONCE
            string idMembresia = interfazNegocio.ObtenerMembresiaSegunTipo("Oro").ToString();
            string idUsuario = Session["UsuarioId"].ToString();
            // NEGOCIO - GUARDO LA MEMBRESIA SELECCIONADA PARA EL USUARIO O ACTUALIZO MEMBRESIA ACTUAL
            Session["IdMembresia"] = idMembresia;
            Session["UsuarioId"] = idUsuario;
            Session["valorMembresia"] = precioOro;
            Session["tipoMembresia"] = "ORO";
            Session["codigoMembresia"] = "1";
            Session["registroEstado"] = 0;
            Session["CompraActividad"] = 0;
            Response.Redirect("membresiaspago.aspx");
        }
    }
}