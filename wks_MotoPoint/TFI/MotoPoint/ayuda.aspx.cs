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
    /// <summary>
    /// 
    /// </summary>
    public partial class ayuda : System.Web.UI.Page
    {
        /// <summary>
        /// Instancio la clase de arquitectura base | MultiUsuario
        /// </summary>
        SIS.BUSINESS.INegMultiUsuario interfazNegocioUsuario = new SIS.BUSINESS.NegMultiUsuario();
        /// <summary>
        /// 
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();
        /// <summary>
        /// 
        /// </summary>
        string idUsuario;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginUsuario"] != null)
            {
                Session["usuarioOk"] = 0;
                string loginEstado = Session["loginEstado"].ToString();
                string loginUsuario = Session["loginUsuario"].ToString();
                idUsuario = Session["UsuarioId"].ToString();

                //SI ES UN USUARIO NUEVO O INVALIDO LO SACO
                if (loginEstado == "1" || (loginUsuario == "NuevoUsuario"))
                {
                    Session["loginEstado"] = 1;
                    FormsAuthentication.SignOut();
                    Response.Redirect("login.aspx");
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
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            bool estado = false;
            string tipoConsulta = "";
            //ARQ.BASE - ACA YA TENEMOS EL USUARIO CON TODOS SUS DATOS
            SIS.ENTIDAD.Usuario oUsuario = new SIS.ENTIDAD.Usuario();
            oUsuario = interfazNegocioUsuario.ObtenerUsuario(System.Convert.ToInt16(idUsuario));
            if (oUsuario.IdUsuario != null)
            {
                if (rdaTecnica.Checked == true)
                {
                    tipoConsulta = "CONSULTA TECNICA";
                }
                else if (rdaAdministrativa.Checked == true)
                {
                    tipoConsulta = "CONSULTA ADMINISTRATIVA";
                }
                else if (rdaSugerencia.Checked == true)
                {
                    tipoConsulta = "CONSULTA SUGERENCIA";
                }
                //ARQ.BASE - SETEO ESTADOS PARA USUARIO
                Session["loginEstado"] = 0;
                Session["usuarioOk"] = 0;
                Session["ayudaEmail"] = 0;
                //ARQ.BASE - ENVIAR POR EMAIL LA CONSULTA DEL USUARIO
                estado = interfazNegocio.EnviarConsulta(nombre, oUsuario.Email, tipoConsulta, descripcion);
                //ARQ.BASE - FEEDBACK POSITIVO
                Response.Redirect("isOk.aspx");
            }
            else
            {
                //ARQ.BASE - FEEDBACK NEGATIVO
                Session["usuarioOk"] = 1;
                Session["ayudaEmail"] = 1;
                Response.Redirect("isError.aspx");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventos.aspx");
        }
    }
}