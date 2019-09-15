using SIS.ENTIDAD;
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
    public partial class expertos : System.Web.UI.Page
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

                ObtenerExpertos();

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
        protected void btnExperto1_Click(object sender, EventArgs e)
        {
            Session["codExp"] = "EXP01";
            //SHOW CONTACTO EXPERTO
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalExperto()", true);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExperto2_Click(object sender, EventArgs e)
        {
            Session["codExp"] = "EXP02";
            //SHOW CONTACTO EXPERTO
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalExperto()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExperto3_Click(object sender, EventArgs e)
        {
            Session["codExp"] = "EXP03";
            //SHOW CONTACTO EXPERTO
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalExperto()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExperto4_Click(object sender, EventArgs e)
        {
            Session["codExp"] = "EXP04";
            //SHOW CONTACTO EXPERTO
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallModal", "openModalExperto()", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Contactar(object sender, EventArgs e)
        {
            //SEND EMAIL TO EXPERT
            Experto detalleExperto = new Experto();
            string codExp = Session["codExp"].ToString();
            detalleExperto = interfazNegocio.ObtenerExperto(codExp);

            Boolean res = interfazNegocio.EnviarConsultaExperto(txtNombre.Text, detalleExperto.Email, txtEmail.Text, txtMensaje.Text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Cerrar(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtMensaje.Text = "";
            Session["codExp"] = "";

            ScriptManager.RegisterStartupScript(this, GetType(), "Close Modal", "closeModalExperto();", true);
        }
        /// <summary>
        /// 
        /// </summary>
        protected void ObtenerExpertos()
        {
            //OBTENER EXPERTOS
            List<Experto> listadoExpertos = new List<Experto>();
            listadoExpertos = interfazNegocio.ObtenerExpertoDisponibles();

            //EVALUO EL ESTADO DE LAS RUTAS
            IEnumerator<Experto> enu = listadoExpertos.GetEnumerator();
            while (enu.MoveNext())
            {
                switch (enu.Current.IdExperto)
                {
                    case "1":
                        lblExpertoName1.Text = enu.Current.Nombre.ToString();
                        lblExpertoDesc1.Text = enu.Current.Descripcion.ToString();
                        break;
                    case "2":
                        lblExpertoName2.Text = enu.Current.Nombre.ToString();
                        lblExpertoDesc2.Text = enu.Current.Descripcion.ToString();
                        break;
                    case "3":
                        lblExpertoName3.Text = enu.Current.Nombre.ToString();
                        lblExpertoDesc3.Text = enu.Current.Descripcion.ToString();
                        break;
                    case "4":
                        lblExpertoName4.Text = enu.Current.Nombre.ToString();
                        lblExpertoDesc4.Text = enu.Current.Descripcion.ToString();
                        break;
                }
            }
        }
    }
}