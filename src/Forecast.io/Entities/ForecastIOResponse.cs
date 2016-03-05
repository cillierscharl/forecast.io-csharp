using System;
using System.Collections.Generic;

namespace ForecastIO
{
    public class ForecastIOResponse
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string timezone { get; set; }
        public float offset { get; set; }
        public Currently currently { get; set; }
        public Minutely minutely { get; set; }
        public Hourly hourly { get; set; }
        public Daily daily { get; set; }
        public List<Alert> alerts { get; set; }
        public Flags flags { get; set; }
    }

    public class Currently
    {
        public Int64 time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public float nearestStormDistance { get; set; }
        public float nearestStormBearing { get; set; }
        public float precipIntensity { get; set; }
        public float precipProbability { get; set; }
        public string precipType { get; set; }
        public float temperature { get; set; }
        public float apparentTemperature { get; set; }
        public float dewPoint { get; set; }
        public float windSpeed { get; set; }
        public float windBearing { get; set; }
        public float cloudCover { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public float visibility { get; set; }
        public float ozone { get; set; }
    }

    public class MinuteForecast
    {
        public Int64 time { get; set; }
        public float precipIntensity { get; set; }
    }

    public class Minutely
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<MinuteForecast> data { get; set; }
    }

    public class HourForecast
    {
        public Int64 time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public float precipIntensity { get; set; }
        public float precipProbability { get; set; }
        public string precipType { get; set; }
        public float temperature { get; set; }
        public float apparentTemperature { get; set; }
        public float dewPoint { get; set; }
        public float windSpeed { get; set; }
        public float windBearing { get; set; }
        public float cloudCover { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public float visibility { get; set; }
        public float ozone { get; set; }
    }

    public class Hourly
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<HourForecast> data { get; set; }
    }

    public class DailyForecast
    {
        public Int64 time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public Int64 sunriseTime { get; set; }
        public Int64 sunsetTime { get; set; }
        public float moonPhase { get; set; }
        public float precipAccumulation { get; set; }
        public float precipIntensity { get; set; }
        public float precipIntensityMax { get; set; }
        public Int64 precipIntensityMaxTime { get; set; }
        public float precipProbability { get; set; }
        public string precipType { get; set; }
        public float temperatureMin { get; set; }
        public Int64 temperatureMinTime { get; set; }
        public float temperatureMax { get; set; }
        public Int64 temperatureMaxTime { get; set; }
        public float apparentTemperatureMin { get; set; }
        public Int64 apparentTemperatureMinTime { get; set; }
        public float apparentTemperatureMax { get; set; }
        public Int64 apparentTemperatureMaxTime { get; set; }
        public float dewPoint { get; set; }
        public float windSpeed { get; set; }
        public float windBearing { get; set; }
        public float cloudCover { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public float visibility { get; set; }
        public float ozone { get; set; }
    }

    public class Daily
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<DailyForecast> data { get; set; }
    }

    public class Alert
    {
        public string title { get; set; }
        public Int64 expires { get; set; }
        public string uri { get; set; }
        public string description { get; set; }
    }

    public class Flags
    {
        public List<string> sources { get; set; }
        public List<string> isd_stations { get; set; }
        public List<string> lamp_stations { get; set; }
        public List<string> metar_stations { get; set; }
        public List<string> darksky_stations { get; set; }
        public string units { get; set; }
    }
}