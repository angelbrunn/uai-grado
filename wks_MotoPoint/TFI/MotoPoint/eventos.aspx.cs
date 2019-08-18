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

        protected void GetWeatherInfo()
        {
            string city = "Buenos Aires,AR";
            string appId = "5171e1f430812085869f09a6b14b57b6";
            //string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt=1&APPID={1}", city.Trim(), appId);

            string url = "http://api.openweathermap.org/data/2.5/forecast?id=3435910&units=metric&cnt=1&APPID=5171e1f430812085869f09a6b14b57b6";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                WeatherInfo weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);
                
                lblCity_Country.Text = weatherInfo.city.name + "," + weatherInfo.city.country;
                imgCountryFlag.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfo.city.country.ToLower());
                lblDescription.Text = weatherInfo.list[0].weather[0].description;
                imgWeatherIcon.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfo.list[0].weather[0].icon);

                lblTempMin.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].main.temp_min, 1));
                lblTempDay.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].main.temp, 1));
                lblTempMax.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].main.temp_max, 1));
                lblHumidity.Text = weatherInfo.list[0].main.humidity.ToString();

            }
        }

        public class WeatherInfo
        {
            public City city { get; set; }
            public List<List> list { get; set; }
        }

        public class City
        {
            public string name { get; set; }
            public string country { get; set; }
        }

        public class Main
        {
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double pressure { get; set; }
            public double sea_level { get; set; }
            public double grnd_level { get; set; }
            public double humidity { get; set; }
        }

        public class Weather
        {
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class List
        {
            //public int humidity { get; set; }
            public Main main { get; set; }
            public List<Weather> weather { get; set; }
        }
    }
}