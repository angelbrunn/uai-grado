using System;
using System.Collections.Generic;

namespace SIS.ENTIDAD
{
    /// <summary>
    /// 
    /// </summary>
    public class WeatherInfo
    {
        public City city { get; set; }
        public List<List> list { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class City
    {
        public string name { get; set; }
        public string country { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
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
    /// <summary>
    /// 
    /// </summary>
    public class Weather
    {
        public string description { get; set; }
        public string icon { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class List
    {
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
    }
}
