using SIS.BUSINESS;
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
        private INegBitacora interfazNegocioBitacora = new NegBitacora();
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
            Session["guardadoEstado"] = 0;

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
                        txtEmail.Enabled = false;
                    }
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
                string año = oUsuario.FechaNacimiento.Substring(4, 4);
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
                Session["passwowrdOld"] = oUsuario.Password;
                txtPassword.Text = oUsuario.Password;
                txtEmail.Text = oUsuario.Email;
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
            txtEmail.Enabled = true;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SIS.ENTIDAD.Usuario oUsuario = new SIS.ENTIDAD.Usuario();
            oUsuario.IdUsuario = txtIdUsuario.Text;
            string passwordDefualt = "4gY7-k";
            if (oUsuario.IdUsuario != "")
            {
                oUsuario.NombreApellido = txtNombreApellido.Text;
                //SETEAMOS LA FECHA
                string fechaNacimiento = txtFecNac.Text;
                string dia = fechaNacimiento.Substring(0, 2);
                string mes = fechaNacimiento.Substring(3, 2);
                string año = fechaNacimiento.Substring(6, 4);
                oUsuario.FechaNacimiento = dia + mes + año;
                //SETEAMOS LA CATEGORIA 
                string catMoto = txtCatMoto.Text;
                switch (catMoto)
                {
                    case "0cc - 150cc":
                        oUsuario.CategoriaMoto = "1";
                        break;
                    case "150cc - 250cc":
                        oUsuario.CategoriaMoto = "2";
                        break;
                    case "+300cc":
                        oUsuario.CategoriaMoto = "3";
                        break;
                    default:
                        oUsuario.CategoriaMoto = "999";
                        break;
                }

                oUsuario.usuario = txtUsuario.Text;
                string passwordOld = Session["passwowrdOld"].ToString();
                if (passwordOld != txtPassword.Text)
                {
                    oUsuario.Password = txtPassword.Text;
                }
                else
                {
                    oUsuario.Password = passwordDefualt;
                }
                oUsuario.Email = txtEmail.Text;
                //SETEAMOS EL ESTADO
                if (rdaActivo.Checked)
                {
                    oUsuario.Estado = "Activo";
                }
                else
                {
                    oUsuario.Estado = "Inactivo";
                }
                try
                {
                    Session["guardadoEstado"] = 1;
                    //ARQ.BASE MULTIUSUARIO | ACTUALIZAMOS EL USUARIO
                    interfazNegocioUsuario.ActualizarUsuario(oUsuario);
                }
                catch (Exception ex)
                {
                    Session["guardadoEstado"] = 2;
                    SIS.EXCEPCIONES.UIExcepcion oExUI = new SIS.EXCEPCIONES.UIExcepcion(ex.Message);
                    interfazNegocioBitacora.RegistrarEnBitacora_UI(oUsuario.IdUsuario, oExUI);
                }
            }
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