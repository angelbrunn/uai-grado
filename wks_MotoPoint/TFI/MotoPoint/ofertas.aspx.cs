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
    public partial class ofertas : System.Web.UI.Page
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

                CargarOfertas();

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
        protected void CargarOfertas()
        {

            List<Ofertas> listadoOfertas = new List<Ofertas>();
            listadoOfertas = interfazNegocio.ObtenerOfertas();

            IEnumerator<Ofertas> enu = listadoOfertas.GetEnumerator();
            while (enu.MoveNext())
            {
                switch (enu.Current.IdOfertas)
                {
                    case "1":
                        lblTituloOferta1.Text = enu.Current.TituloOferta.ToString();
                        lblDescOferta1.Text = enu.Current.Descripcion.ToString();
                        lblFechaOferta1.Text = enu.Current.Fecha.ToString();
                        break;
                    case "2":
                        lblTituloOferta2.Text = enu.Current.TituloOferta.ToString();
                        lblDescOferta2.Text = enu.Current.Descripcion.ToString();
                        lblFechaOferta2.Text = enu.Current.Fecha.ToString();
                        break;
                    case "3":
                        lblTituloOferta3.Text = enu.Current.TituloOferta.ToString();
                        lblDescOferta3.Text = enu.Current.Descripcion.ToString();
                        lblFechaOferta3.Text = enu.Current.Fecha.ToString();
                        break;
                    case "4":
                        lblTituloOferta4.Text = enu.Current.TituloOferta.ToString();
                        lblDescOferta4.Text = enu.Current.Descripcion.ToString();
                        lblFechaOferta4.Text = enu.Current.Fecha.ToString();
                        break;
                    case "5":
                        lblTituloOferta5.Text = enu.Current.TituloOferta.ToString();
                        lblDescOferta5.Text = enu.Current.Descripcion.ToString();
                        lblFechaOferta5.Text = enu.Current.Fecha.ToString();
                        break;
                    case "6":
                        lblTituloOferta6.Text = enu.Current.TituloOferta.ToString();
                        lblDescOferta6.Text = enu.Current.Descripcion.ToString();
                        lblFechaOferta6.Text = enu.Current.Fecha.ToString();
                        break;
                    case "7":
                        lblTituloOferta7.Text = enu.Current.TituloOferta.ToString();
                        lblDescOferta7.Text = enu.Current.Descripcion.ToString();
                        lblFechaOferta7.Text = enu.Current.Fecha.ToString();
                        break;
                    case "8":
                        lblTituloOferta8.Text = enu.Current.TituloOferta.ToString();
                        lblDescOferta8.Text = enu.Current.Descripcion.ToString();
                        lblFechaOferta8.Text = enu.Current.Fecha.ToString();
                        break;
                }
            }
        }
    }
}