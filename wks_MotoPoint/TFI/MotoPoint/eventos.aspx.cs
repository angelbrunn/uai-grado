using SIS.ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;

namespace MotoPoint
{
    public partial class Eventos : System.Web.UI.Page
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

                //OBTENGO EVENTOS ACTIVOS
                OtenerDatosEventos();

                GetWeatherInfo();

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
        protected void OtenerDatosEventos()
        {
            List<Evento> listadoDatosEvento = new List<Evento>();
            listadoDatosEvento = interfazNegocio.DatosEventos();
            int i = 1;

            IEnumerator<Evento> enu = listadoDatosEvento.GetEnumerator();
            while (enu.MoveNext())
            {
                string origen = "map" + i + "Origen";
                string destino = "map" + i + "Destino";
                string show = "map" + i + "Show";
                switch (i)
                {
                    case 1:
                        lblCodigoEvento1.Text = "Evento " + enu.Current.CodEvento.ToString();
                        lblDetalleEvento1.Text = enu.Current.DetalleEvento.ToString();
                        lblFechaEvento1.Text = enu.Current.Fecha.ToString();
                        break;
                    case 2:
                        lblCodigoEvento2.Text = "Evento " + enu.Current.CodEvento.ToString();
                        lblDetalleEvento2.Text = enu.Current.DetalleEvento.ToString();
                        lblFechaEvento2.Text = enu.Current.Fecha.ToString();
                        break;
                    case 3:
                        lblCodigoEvento3.Text = "Evento " + enu.Current.CodEvento.ToString();
                        lblDetalleEvento3.Text = enu.Current.DetalleEvento.ToString();
                        lblFechaEvento3.Text = enu.Current.Fecha.ToString();
                        break;
                    case 4:
                        lblCodigoEvento4.Text = "Evento " + enu.Current.CodEvento.ToString();
                        lblDetalleEvento4.Text = enu.Current.DetalleEvento.ToString();
                        lblFechaEvento4.Text = enu.Current.Fecha.ToString();
                        break;
                    case 5:
                        lblCodigoEvento5.Text = "Evento " + enu.Current.CodEvento.ToString();
                        lblDetalleEvento5.Text = enu.Current.DetalleEvento.ToString();
                        lblFechaEvento5.Text = enu.Current.Fecha.ToString();
                        break;
                    case 6:
                        lblCodigoEvento6.Text = "Evento " + enu.Current.CodEvento.ToString();
                        lblDetalleEvento6.Text = enu.Current.DetalleEvento.ToString();
                        lblFechaEvento6.Text = enu.Current.Fecha.ToString();
                        break;
                }
                Session[origen] = enu.Current.Desde.ToString();
                Session[destino] = enu.Current.Hasta.ToString();
                Session[show] = 1;
                i++;
            }

            if (i < 6)
            {
                for (int j = i; j <= 6; j++)
                {
                    string origen = "map" + j + "Origen";
                    string destino = "map" + j + "Destino";
                    string show = "map" + j + "Show";
                    Session[origen] = "Buenos Aires";
                    Session[destino] = "Buenos Aires";
                    Session[show] = 0;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected void GetWeatherInfo()
        {
            string urlbue = "http://api.openweathermap.org/data/2.5/forecast?id=3435910&units=metric&cnt=1&APPID=5171e1f430812085869f09a6b14b57b6";
            string urlmen = "http://api.openweathermap.org/data/2.5/forecast?id=3844421&units=metric&cnt=1&APPID=5171e1f430812085869f09a6b14b57b6";
            string urlros = "http://api.openweathermap.org/data/2.5/forecast?id=3838583&units=metric&cnt=1&APPID=5171e1f430812085869f09a6b14b57b6";

            using (WebClient client = new WebClient())
            {
                string jsonBUE = client.DownloadString(urlbue);
                string jsonMEN = client.DownloadString(urlmen);
                string jsonROS = client.DownloadString(urlros);

                WeatherInfo weatherInfoBUE = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(jsonBUE);
                WeatherInfo weatherInfoMEN = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(jsonMEN);
                WeatherInfo weatherInfoROS = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(jsonROS);

                //BUENOS AIRES
                imgCountryFlagBue.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfoBUE.city.country.ToLower());
                lblCityBue.Text = weatherInfoBUE.city.name;
                lblBueTempMin.Text = string.Format("{0}°С", Math.Round(weatherInfoBUE.list[0].main.temp_min, 1));
                lblBueTempDay.Text = string.Format("{0}°С", Math.Round(weatherInfoBUE.list[0].main.temp, 1));
                lblBueTempMax.Text = string.Format("{0}°С", Math.Round(weatherInfoBUE.list[0].main.temp_max, 1));
                lblBueHumidity.Text = weatherInfoBUE.list[0].main.humidity.ToString();
                imgWeatherIconBue.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfoBUE.list[0].weather[0].icon);
                //MENDOZA
                imgCountryFlagMen.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfoMEN.city.country.ToLower());
                lblCityCMen.Text = weatherInfoMEN.city.name;
                lblMenTempMin.Text = string.Format("{0}°С", Math.Round(weatherInfoMEN.list[0].main.temp_min, 1));
                lblMenTempDay.Text = string.Format("{0}°С", Math.Round(weatherInfoMEN.list[0].main.temp, 1));
                lblMenTempMax.Text = string.Format("{0}°С", Math.Round(weatherInfoMEN.list[0].main.temp_max, 1));
                lblMenHumidity.Text = weatherInfoMEN.list[0].main.humidity.ToString();
                imgWeatherIconMen.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfoMEN.list[0].weather[0].icon);
                //ROSARIO
                imgCountryFlagRos.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfoROS.city.country.ToLower());
                lblCityRos.Text = weatherInfoROS.city.name;
                lblRosTempMin.Text = string.Format("{0}°С", Math.Round(weatherInfoROS.list[0].main.temp_min, 1));
                lblRosTempDay.Text = string.Format("{0}°С", Math.Round(weatherInfoROS.list[0].main.temp, 1));
                lblRosTempMax.Text = string.Format("{0}°С", Math.Round(weatherInfoROS.list[0].main.temp_max, 1));
                lblRosHumidity.Text = weatherInfoROS.list[0].main.humidity.ToString();
                imgWeatherIconRos.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfoROS.list[0].weather[0].icon);
            }
        }
    }
}