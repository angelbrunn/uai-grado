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
            var loginEstado = Session["loginEstado"];
            var loginUsuario = Session["loginUsuario"];

            //SI ES UN USUARIO REGISTRADO O VALIDO LO SACO
            if (loginEstado.ToString() == "0" || loginUsuario.ToString() != "NuevoUsuario")
            {
                FormsAuthentication.SignOut();
                Response.Redirect("login.aspx");
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //RECUPERAR LA CONTRASEÑA DE USUARIO E ENVIARLA AL MAIL INDICADO
            var email = txtEmail.Text;
            //ACA YA TENEMOS EL USUARIO CON TODOS SUS DATOS
            SIS.ENTIDAD.Usuario oUsuario = new SIS.ENTIDAD.Usuario();
            oUsuario = interfazNegocioUsuario.ObtenerUsuarioPorEmail(email);
            //1# OBTENER EL PASSWORD PERO DES-ENCRIPTARLO

            //2# ENVIAR POR EMAIL EN UN EMAIL GENERICO
            //sendMessage("angelbrunn@gmail.com","123321");

            SendEmail();

            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");
        }

        protected void sendMessage(string toEmail,string password)
        {
            //domain.a2hosted.com
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("motopointserviciocontacto@gmail.com", "Motopoint1#_");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mailMessage = new MailMessage("motopointserviciocontacto@gmail.com", toEmail);
            mailMessage.Subject = "Su contraseña es:";
            mailMessage.Body = password;

            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {

            }
        }

        public void SendEmail()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("motopointserviciocontactoa@gmail.com");
            mail.From = new MailAddress("motopointserviciocontacto@gmail.com");
            mail.Subject = "Email using Gmail";


            mail.Body = "Hi, this mail is to test sending mail using Gmail in ASP.NET";

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("motopointserviciocontacto@gmail.com", "Motopoint1#_");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}