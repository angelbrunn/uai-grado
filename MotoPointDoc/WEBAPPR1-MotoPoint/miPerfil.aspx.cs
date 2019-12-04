using SIS.BUSINESS;
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
    public partial class miPerfil : System.Web.UI.Page
    {
        /// <summary>
        /// Instancio la clase de arquitectura base | MultiUsuario
        /// </summary>
        SIS.BUSINESS.INegMultiUsuario interfazNegocioUsuario = new SIS.BUSINESS.NegMultiUsuario();
        /// <summary>
        /// Instancio la clase de arquitectura base | MultiUsuario
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();
        /// <summary>
        /// 
        /// </summary>
        private INegBitacora interfazNegocioBitacora = new NegBitacora();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginUsuario"] != null)
            {
                if (txtNombreApellido.Text == "")
                {
                    Session["guardadoEstado"] = 0;
                    string idUsuario = Session["UsuarioId"].ToString();
                    Session["guardadoPerfil"] = interfazNegocio.ObtenerCodigoMembresiaUsuario(idUsuario);
                    SIS.ENTIDAD.Usuario oUsuario = new SIS.ENTIDAD.Usuario();
                    oUsuario = interfazNegocioUsuario.ObtenerUsuario(System.Convert.ToInt16(idUsuario));
                    //GUARDO EL ESTADO DEL USUARIO
                    if (oUsuario.Estado == "Activo")
                    {
                        Session["estadoUsuario"] = 1;
                        Session["estadoUsuarioActual"] = oUsuario.Estado;
                    }
                    else
                    {
                        Session["estadoUsuario"] = 0;
                        Session["estadoUsuarioActual"] = oUsuario.Estado;
                    }
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
                }
            }
            else
            {
                Session.Clear();
                FormsAuthentication.SignOut();
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
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventos.aspx");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            SIS.ENTIDAD.Usuario oUsuario = new SIS.ENTIDAD.Usuario();
            oUsuario.IdUsuario = Session["UsuarioId"].ToString();
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
                oUsuario.Estado = Session["estadoUsuarioActual"].ToString();
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
        protected void btnMembresia_Click(object sender, EventArgs e)
        {
            Response.Redirect("membresias.aspx");
        }
    }
}