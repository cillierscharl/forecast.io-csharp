using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Forecastio
{
    [DataContract]
    public class ForecastioReponse
    {
        [DataMember]
        public float latitude { get; set; }
        [DataMember]
        public float longitude { get; set; }
        [DataMember]
        public string timezone { get; set; }
        [DataMember]
        public int offset { get; set; }
        [DataMember]
        public Currently currently { get; set; }
        [DataMember]
        public Minutely minutely { get; set; }
        [DataMember]
        public Hourly hourly { get; set; }
        [DataMember]
        public Daily daily { get; set; }
        [DataMember]
        public Flags flags { get; set; }
    }
    [DataContract]
    public class Currently
    {
        [DataMember]
        public int time { get; set; }
        [DataMember]
        public string summary { get; set; }
        [DataMember]
        public string icon { get; set; }
        [DataMember]
        public float precipIntensity { get; set; }
        [DataMember]
        public float temperature { get; set; }
        [DataMember]
        public float dewPoint { get; set; }
        [DataMember]
        public float windSpeed { get; set; }
        [DataMember]
        public float windBearing { get; set; }
        [DataMember]
        public float cloudCover { get; set; }
        [DataMember]
        public float humidity { get; set; }
        [DataMember]
        public float pressure { get; set; }
        [DataMember]
        public float visibility { get; set; }
        [DataMember]
        public float ozone { get; set; }
    }
    [DataContract]
    public class MinuteForecast
    {
        [DataMember]
        public int time { get; set; }
        [DataMember]
        public float precipIntensity { get; set; }
    }
    [DataContract]
    public class Minutely
    {
        [DataMember]
        public string summary { get; set; }
        [DataMember]
        public string icon { get; set; }
        [DataMember]
        public List<MinuteForecast> data { get; set; }
    }
    [DataContract]
    public class HourForecast
    {
        [DataMember]
        public int time { get; set; }
        [DataMember]
        public string summary { get; set; }
        [DataMember]
        public string icon { get; set; }
        [DataMember]
        public float precipIntensity { get; set; }
        [DataMember]
        public float temperature { get; set; }
        [DataMember]
        public float dewPoint { get; set; }
        [DataMember]
        public float windSpeed { get; set; }
        [DataMember]
        public float windBearing { get; set; }
        [DataMember]
        public float cloudCover { get; set; }
        [DataMember]
        public float humidity { get; set; }
        [DataMember]
        public float pressure { get; set; }
        [DataMember]
        public float visibility { get; set; }
        [DataMember]
        public float ozone { get; set; }
    }
    [DataContract]
    public class Hourly
    {
        [DataMember]
        public string summary { get; set; }
        [DataMember]
        public string icon { get; set; }
        [DataMember]
        public List<HourForecast> data { get; set; }
    }
    [DataContract]
    public class DailyForecast
    {
        [DataMember]
        public int time { get; set; }
        [DataMember]
        public string summary { get; set; }
        [DataMember]
        public string icon { get; set; }
        [DataMember]
        public int sunriseTime { get; set; }
        [DataMember]
        public int sunsetTime { get; set; }
        [DataMember]
        public float precipIntensity { get; set; }
        [DataMember]
        public float precipIntensityMax { get; set; }
        [DataMember]
        public float temperatureMin { get; set; }
        [DataMember]
        public int temperatureMinTime { get; set; }
        [DataMember]
        public float temperatureMax { get; set; }
        [DataMember]
        public int temperatureMaxTime { get; set; }
        [DataMember]
        public float dewPoint { get; set; }
        [DataMember]
        public float windSpeed { get; set; }
        [DataMember]
        public float windBearing { get; set; }
        [DataMember]
        public float cloudCover { get; set; }
        [DataMember]
        public float humidity { get; set; }
        [DataMember]
        public float pressure { get; set; }
        [DataMember]
        public float visibility { get; set; }
        [DataMember]
        public float ozone { get; set; }
    }
    [DataContract]
    public class Daily
    {
        [DataMember]
        public string summary { get; set; }
        [DataMember]
        public string icon { get; set; }
        [DataMember]
        public List<DailyForecast> data { get; set; }
    }
    [DataContract]
    public class Flags
    {
        [DataMember]
        public List<string> sources { get; set; }
        [DataMember]
        public List<string> isd_stations { get; set; }
        [DataMember]
        public List<string> lamp_stations { get; set; }
        [DataMember]
        public List<string> metar_stations { get; set; }
        [DataMember]
        public List<string> darksky_stations { get; set; }
        [DataMember]
        public string units { get; set; }
    }
}
