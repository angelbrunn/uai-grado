using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AdminGestionPerfiles : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["habilitacionBusqueda"] = 0;

            if (User.IsInRole("Usuario"))
            {
                //SI EL USUARIO NO TIENE PERMISOS LO SACO DE LA WEBMASTER PAGE - GESTION DE PERFILES!
                Response.Redirect("home.aspx");
            }
            else
            {
                string habilitacionBusqueda = Session["habilitacionBusqueda"].ToString();
                //.....
                if (habilitacionBusqueda != "0") {
                    txtIdUsuario.Enabled = false;
                    txtNombreApellido.Enabled = false;
                    txtFecNac.Enabled = false;
                    txtCatMoto.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtPassword.Enabled = false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnHabilitarBusqueda_Click(object sender, EventArgs e)
        {

            if (txtIdUsuario.Enabled == false)
            {
                Session["habilitacionBusqueda"] = 1;
                txtIdUsuario.Enabled = true;
            }
            else
            {
                Session["habilitacionBusqueda"] = 2;
                txtIdUsuario.Enabled = false;
            }
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("webmaster.aspx");
        }
    }
}