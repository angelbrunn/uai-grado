﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIS.ENTIDAD;
using System.Net.Mail;
using System.Threading;
using System.Globalization;

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
            if (Session["loginUsuario"] != null)
            {
                string loginUsuario = Session["loginUsuario"].ToString();

                //SI ES UN USUARIO NUEVO O INVALIDO LO SACO
                if (loginUsuario != "UsuarioRecordar")
                {
                    Response.Redirect("eventos.aspx");
                }
                else
                {
                    Session["usuarioOk"] = 0;
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
            //RECUPERAR LA CONTRASEÑA DE USUARIO E ENVIARLA AL MAIL INDICADO
            var email = txtEmail.Text;
            var estado = false;
            var passwordDefault = "4gY7-k";
            //ARQ.BASE - ACA YA TENEMOS EL USUARIO CON TODOS SUS DATOS
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

                Session.Clear();
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