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
                Session["avisoModal01"] = "0";
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
            string currentLang;
            List<Ofertas> listadoOfertas = new List<Ofertas>();
            listadoOfertas = interfazNegocio.ObtenerOfertas();

            if (Session["lang"] == null)
            {
                currentLang = "es-ES";
            }
            else
            {
                currentLang = Session["lang"].ToString();

            }

            IEnumerator<Ofertas> enu = listadoOfertas.GetEnumerator();
            while (enu.MoveNext())
            {
                switch (enu.Current.IdOfertas)
                {
                    case "1":
                        if (currentLang == "en-US")
                        {
                            string TituloEn = GetLocalResourceObject("lblTituloOferta1Resource1.Text") as string;
                            lblTituloOferta1.Text = TituloEn.ToString();

                            string DescEn = GetLocalResourceObject("lblDescOferta1Resource1.Text") as string;
                            lblDescOferta1.Text = DescEn.ToString();
                        }
                        else
                        {
                            lblTituloOferta1.Text = enu.Current.TituloOferta.ToString();
                            lblDescOferta1.Text = enu.Current.Descripcion.ToString();
                        }
                        lblFechaOferta1.Text = enu.Current.Fecha.ToString();
                        break;
                    case "2":
                        if (currentLang == "en-US")
                        {
                            string TituloEn = GetLocalResourceObject("lblTituloOferta2Resource1.Text") as string;
                            lblTituloOferta2.Text = TituloEn.ToString();

                            string DescEn = GetLocalResourceObject("lblDescOferta2Resource1.Text") as string;
                            lblDescOferta2.Text = DescEn.ToString();
                        }
                        else
                        {
                            lblTituloOferta2.Text = enu.Current.TituloOferta.ToString();
                            lblDescOferta2.Text = enu.Current.Descripcion.ToString();
                        }
                        lblFechaOferta2.Text = enu.Current.Fecha.ToString();
                        break;
                    case "3":
                        if (currentLang == "en-US")
                        {
                            string TituloEn = GetLocalResourceObject("lblTituloOferta3Resource1.Text") as string;
                            lblTituloOferta3.Text = TituloEn.ToString();

                            string DescEn = GetLocalResourceObject("lblDescOferta3Resource1.Text") as string;
                            lblDescOferta3.Text = DescEn.ToString();
                        }
                        else
                        {
                            lblTituloOferta3.Text = enu.Current.TituloOferta.ToString();
                            lblDescOferta3.Text = enu.Current.Descripcion.ToString();
                        }
                        lblFechaOferta3.Text = enu.Current.Fecha.ToString();
                        break;
                    case "4":
                        if (currentLang == "en-US")
                        {
                            string TituloEn = GetLocalResourceObject("lblTituloOferta4Resource1.Text") as string;
                            lblTituloOferta4.Text = TituloEn.ToString();

                            string DescEn = GetLocalResourceObject("lblDescOferta4Resource1.Text") as string;
                            lblDescOferta4.Text = DescEn.ToString();
                        }
                        else
                        {
                            lblTituloOferta4.Text = enu.Current.TituloOferta.ToString();
                            lblDescOferta4.Text = enu.Current.Descripcion.ToString();
                        }
                        lblFechaOferta4.Text = enu.Current.Fecha.ToString();
                        break;
                    case "5":
                        if (currentLang == "en-US")
                        {
                            string TituloEn = GetLocalResourceObject("lblTituloOferta5Resource1.Text") as string;
                            lblTituloOferta5.Text = TituloEn.ToString();

                            string DescEn = GetLocalResourceObject("lblDescOferta5Resource1.Text") as string;
                            lblDescOferta5.Text = DescEn.ToString();
                        }
                        else
                        {
                            lblTituloOferta5.Text = enu.Current.TituloOferta.ToString();
                            lblDescOferta5.Text = enu.Current.Descripcion.ToString();
                        }
                        lblFechaOferta5.Text = enu.Current.Fecha.ToString();
                        break;
                    case "6":
                        if (currentLang == "en-US")
                        {
                            string TituloEn = GetLocalResourceObject("lblTituloOferta6Resource1.Text") as string;
                            lblTituloOferta6.Text = TituloEn.ToString();

                            string DescEn = GetLocalResourceObject("lblDescOferta6Resource1.Text") as string;
                            lblDescOferta6.Text = DescEn.ToString();
                        }
                        else
                        {
                            lblTituloOferta6.Text = enu.Current.TituloOferta.ToString();
                            lblDescOferta6.Text = enu.Current.Descripcion.ToString();
                        }
                        lblFechaOferta6.Text = enu.Current.Fecha.ToString();
                        break;
                    case "7":
                        if (currentLang == "en-US")
                        {
                            string TituloEn = GetLocalResourceObject("lblTituloOferta7Resource1.Text") as string;
                            lblTituloOferta7.Text = TituloEn.ToString();

                            string DescEn = GetLocalResourceObject("lblDescOferta7Resource1.Text") as string;
                            lblDescOferta7.Text = DescEn.ToString();
                        }
                        else
                        {
                            lblTituloOferta7.Text = enu.Current.TituloOferta.ToString();
                            lblDescOferta7.Text = enu.Current.Descripcion.ToString();
                        }
                        lblFechaOferta7.Text = enu.Current.Fecha.ToString();
                        break;
                    case "8":
                        if (currentLang == "en-US")
                        {
                            string TituloEn = GetLocalResourceObject("lblTituloOferta8Resource1.Text") as string;
                            lblTituloOferta8.Text = TituloEn.ToString();

                            string DescEn = GetLocalResourceObject("lblDescOferta8Resource1.Text") as string;
                            lblDescOferta8.Text = DescEn.ToString();
                        }
                        else
                        {
                            lblTituloOferta8.Text = enu.Current.TituloOferta.ToString();
                            lblDescOferta8.Text = enu.Current.Descripcion.ToString();
                        }
                        lblFechaOferta8.Text = enu.Current.Fecha.ToString();
                        break;
                }
            }
        }
    }
}