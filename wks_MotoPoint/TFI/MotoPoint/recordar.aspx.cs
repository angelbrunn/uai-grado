using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIS.ENTIDAD;
using System.Net.Mail;

namespace MotoPoint
{
    public partial class recordar : System.Web.UI.Page
    {
        /// <summary>
        /// Instancio la clase de arquitectura base | MultiUsuario
        /// </summary>
        SIS.BUSINESS.INegMultiUsuario interfazNegocioUsuario = new SIS.BUSINESS.NegMultiUsuario();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuarioOk"] = 0;
            var loginEstado = Session["loginEstado"];
            var loginUsuario = Session["loginUsuario"];

            //SI ES UN USUARIO REGISTRADO O VALIDO LO SACO
            if (loginEstado.ToString() == "0" || loginUsuario.ToString() != "NuevoUsuario")
            {
                FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //RECUPERAR LA CONTRASEÑA DE USUARIO E ENVIARLA AL MAIL INDICADO
            var email = txtEmail.Text;
            var estado = false;
            var passwordDefault = "4gY7-k";
            //ACA YA TENEMOS EL USUARIO CON TODOS SUS DATOS
            SIS.ENTIDAD.Usuario oUsuario = new SIS.ENTIDAD.Usuario();
            oUsuario = interfazNegocioUsuario.ObtenerUsuarioPorEmail(email);

            if (oUsuario.IdUsuario != null)
            {
                Session["loginEstado"] = 0;
                Session["usuarioOk"] = 0;
                //0# - SETEO PASSWORD POR DEFECTO
                oUsuario.Password = passwordDefault;

                //1# - ACTUALIZO EL USUARIO EN LA DB
                interfazNegocioUsuario.ActualizarUsuario(oUsuario);

                //2# ENVIAR POR EMAIL EN UN EMAIL GENERICO
                estado = interfazNegocioUsuario.EnviarRecordatorioPassword(email, passwordDefault);

                FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
            else
            {
                Session["usuarioOk"] = 1;
            }

        }
    }
}