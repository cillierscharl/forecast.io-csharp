using Newtonsoft.Json;
using System.Collections.Generic;

namespace ForecastIO
{
    public class ForecastIOResponse
    {
        [JsonProperty("latitude")]
        public float Latitude { get; set; }
        [JsonProperty("longitude")]
        public float Longitude { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("offset")]
        public float Offset { get; set; }
        [JsonProperty("currently")]
        public Currently Currently { get; set; }
        [JsonProperty("minutely")]
        public Minutely Minutely { get; set; }
        [JsonProperty("hourly")]
        public Hourly Hourly { get; set; }
        [JsonProperty("daily")]
        public Daily Daily { get; set; }
        [JsonProperty("alerts")]
        public List<Alert> Alerts { get; set; }
        [JsonProperty("flags")]
        public Flags Flags { get; set; }
    }

    public class Currently
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public float nearestStormDistance { get; set; }
        public float nearestStormBearing { get; set; }
        public float precipIntensity { get; set; }
        public float precipIntensityError { get; set; }
        public float precipProbability { get; set; }
        public string precipType { get; set; }
        public float temperature { get; set; }
        public float apparentTemperature { get; set; }
        public float dewPoint { get; set; }
        public float windSpeed { get; set; }
        public float windGust { get; set; }
        public float windBearing { get; set; }
        public float cloudCover { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public float visibility { get; set; }
        public float ozone { get; set; }
        public int uvIndex { get; set; }
    }

    public class MinuteForecast
    {
        public long time { get; set; }
        public float precipIntensity { get; set; }
        public float precipIntensityError { get; set; }
        public float precipProbability { get; set; }
        public string precipType { get; set; }
    }

    public class Minutely
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<MinuteForecast> data { get; set; }
    }

    public class HourForecast
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public float precipIntensity { get; set; }
        public float precipIntensityError { get; set; }
        public float precipProbability { get; set; }
        public string precipType { get; set; }
        public float temperature { get; set; }
        public float apparentTemperature { get; set; }
        public float dewPoint { get; set; }
        public float windSpeed { get; set; }
        public float windGust { get; set; }
        public float windBearing { get; set; }
        public float cloudCover { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public float visibility { get; set; }
        public float ozone { get; set; }
        public int uvIndex { get; set; }
    }

    public class Hourly
    {
        public string summary { get; set; }
        public string icon { get; set; }
        public List<HourForecast> data { get; set; }
    }

    public class DailyForecast
    {
        public long time { get; set; }
        public string summary { get; set; }
        public string icon { get; set; }
        public long sunriseTime { get; set; }
        public long sunsetTime { get; set; }
        public float moonPhase { get; set; }
        public float precipAccumulation { get; set; }
        public float precipIntensity { get; set; }
        public float precipIntensityError { get; set; }
        public float precipIntensityMax { get; set; }
        public long precipIntensityMaxTime { get; set; }
        public float precipProbability { get; set; }
        public string precipType { get; set; }
        public float temperatureLow { get; set; }
        public long temperatureLowTime { get; set; }
        public float temperatureHigh { get; set; }
        public long temperatureHighTime { get; set; }
        public float apparentTemperatureLow { get; set; }
        public long apparentTemperatureLowTime { get; set; }
        public float apparentTemperatureHigh { get; set; }
        public long apparentTemperatureHighTime { get; set; }
        public float dewPoint { get; set; }
        public float windSpeed { get; set; }
        public float windBearing { get; set; }
        public float windGust { get; set; }
        public long windGustTime { get; set; }
        public float cloudCover { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public float visibility { get; set; }
        public float ozone { get; set; }
        public int uvIndex { get; set; }
        public long uvIndexTime { get; set; }
        public float temperatureMin { get; set; }
        public float temperatureMinTime { get; set; }
        public float temperatureMax { get; set; }
        public float temperatureMaxTime { get; set; }

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
        public long expires { get; set; }
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
