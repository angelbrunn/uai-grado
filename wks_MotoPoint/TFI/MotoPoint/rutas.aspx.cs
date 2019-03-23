using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotoPoint
{
    public partial class rutas : System.Web.UI.Page
    {
        /// <summary>
        /// Instancio la clase de negocio motopoint | interfazNegocio
        /// </summary>
        SIS.BUSINESS.INegNegocio interfazNegocio = new SIS.BUSINESS.NegNegocio();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginUsuario"] != null)
            {
                string loginEstado = Session["loginEstado"].ToString();
                string loginUsuario = Session["loginUsuario"].ToString();

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLikeMDQ_Click(object sender, EventArgs e)
        {
            EvaluarLike(sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLikeATA01_Click(object sender, EventArgs e)
        {
            EvaluarLike(sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLikeCOD01_Click(object sender, EventArgs e)
        {
            EvaluarLike(sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLikeROS01_Click(object sender, EventArgs e)
        {
            EvaluarLike(sender);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        protected void EvaluarLike(object sender)
        {
            //RESULTADO POR DEFAULT | TRUE YA EXISTE LIKE OR FALSE AUN NO TIENE LIKE
            Boolean resultado = true;

            //OBTENGO USUARIO LOGEADO
            string usuario = Session["loginUsuario"].ToString();

            //OBTENGO LA RUTA SELECCIONADA
            string codRuta = ((((Button)sender).ID).ToString()).Substring(7, 5);

            //CONSULTO LIKE DE USUARIO CORRIENTE
            resultado = interfazNegocio.ConsultarLikeUsuario(codRuta, usuario);

            //REGISTRO LIKE PARA ESTE USUARIO
            if (resultado == false)
            {
                //OBTENGO FECHA DEL EVENTO
                string fechaRuta = interfazNegocio.ObtenerFechaRuta(codRuta);

                //OBTENER ULTIMO ID RUTASUSUARIO
                int idRutaLikeUsuario = interfazNegocio.ObtenerIdLikeUsuario();

                //REGISTRO LIKE DEL USUARIO
                interfazNegocio.RegistrarLikeUsuario(idRutaLikeUsuario, codRuta, usuario, fechaRuta);

                //REGISTRO VOTACION DEL USUARIO
                interfazNegocio.RegistrarVotacionRuta(codRuta);
            }
            else
            {
                //USUARIO YA VOTO ESTA RUTA
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModal()", true);

            }
        }
    }
}