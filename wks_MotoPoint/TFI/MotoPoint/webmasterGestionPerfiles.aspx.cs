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
        /// Instancio la clase de arquitectura base | MultiUsuario
        /// </summary>
        SIS.BUSINESS.INegMultiUsuario interfazNegocioUsuario = new SIS.BUSINESS.NegMultiUsuario();
        /// <summary>
        /// 
        /// </summary>
        String lockBusqueda = "0";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["habilitacionBusqueda"] = 0;
            Session["busquedaEstado"] = 0;

            if (User.IsInRole("Usuario"))
            {
                //SI EL USUARIO NO TIENE PERMISOS LO SACO DE LA WEBMASTER PAGE - GESTION DE PERFILES!
                Response.Redirect("home.aspx");
            }
            else
            {
                string habilitacionBusqueda = Session["habilitacionBusqueda"].ToString();

                if (habilitacionBusqueda == "0" && lockBusqueda == "0")
                {
                    string contenidoBusqueda = txtIdUsuario.Text;
                    if (contenidoBusqueda == "" || contenidoBusqueda == null)
                    {
                        txtIdUsuario.Enabled = false;
                        txtNombreApellido.Enabled = false;
                        txtFecNac.Enabled = false;
                        txtCatMoto.Enabled = false;
                        txtUsuario.Enabled = false;
                        txtPassword.Enabled = false;
                    }
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
            Session["clickHere"] = System.Convert.ToInt16(Session["clickHere"]) + 1;
            string contenidoBusqueda = txtIdUsuario.Text;
            var numero = System.Convert.ToInt16(Session["clickHere"]);
            var flag = 0;

            if (numero % 2 == 0 || numero == 1)
            {
                if (numero != 2)
                {
                    flag = 1;
                }
            }

            if (contenidoBusqueda == "" || contenidoBusqueda == null)
            {
                if (txtIdUsuario.Enabled == false && flag == 1)
                {
                    lockBusqueda = "1";
                    Session["habilitacionBusqueda"] = 1;
                    txtIdUsuario.Enabled = true;
                }
                else
                {
                    lockBusqueda = "0";
                    Session["habilitacionBusqueda"] = 2;
                    txtIdUsuario.Enabled = false;
                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            SIS.ENTIDAD.Usuario oUsuario = new SIS.ENTIDAD.Usuario();
            string idUsuario = txtIdUsuario.Text;

            HabilitarEdiciones();
            //ARQ.BASE MULTIUSUARIO | OBTNGO EL USUARIO A PARTIR DE SU ID
            oUsuario = interfazNegocioUsuario.ObtenerUsuario(System.Convert.ToInt16(idUsuario));

            if (oUsuario.IdUsuario != null)
            {
                txtIdUsuario.Text = oUsuario.IdUsuario;
                txtNombreApellido.Text = oUsuario.NombreApellido;

                //MUESTRO LA FECHA DE NACIMIENTO
                string dia = oUsuario.FechaNacimiento.Substring(0, 2);
                string mes = oUsuario.FechaNacimiento.Substring(2, 2);
                string año = oUsuario.FechaNacimiento.Substring(4, 2);
                txtFecNac.Text = dia + "-" + mes + "-" + año;
                //MUESTO LA CATEGORIA DE MOTO ASOCIADA AL USUARIO
                string catMoto = oUsuario.CategoriaMoto;
                switch (catMoto)
                {
                    case "1":
                        txtCatMoto.Text = "0cc - 150cc";
                        break;
                    case "2":
                        txtCatMoto.Text = "150cc - 250cc";
                        break;
                    case "3":
                        txtCatMoto.Text = "+300cc";
                        break;
                    default:
                        txtCatMoto.Text = "NO TIENE MOTO ASOCIADA";
                        break;
                }
                txtUsuario.Text = oUsuario.usuario;
                txtPassword.Text = oUsuario.Password;
                //SELECCIONO EL ESTADO DEL USUARIO SI ES ACTIVO O INACTIVO
                string estado = oUsuario.Estado;
                if (estado == "Activo")
                {
                    rdaActivo.Checked = true;
                    rdaInactivo.Checked = false;
                }
                else
                {
                    rdaActivo.Checked = false;
                    rdaInactivo.Checked = true;
                }
                //BUSQUEDA EXITOSA | EXISTE USUARIO
                Session["busquedaEstado"] = 0;
            }
            else
            {
                //BUSQUEDA FALLIDA | NO EXISTE USUARIO
                 Session["busquedaEstado"] = 1;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        private void HabilitarEdiciones()
        {
            txtIdUsuario.Enabled = true;
            txtNombreApellido.Enabled = true;
            txtFecNac.Enabled = true;
            txtCatMoto.Enabled = true;
            txtUsuario.Enabled = true;
            txtPassword.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("registro.aspx");
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