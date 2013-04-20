using System;
using System.Globalization;
using System.Net;
using System.Web.Script.Serialization;

namespace ForecastIO
{
    public class ForecastIORequest
    {
        private string apiKey;
        private string latitude;
        private string longitude;
        private string unit;
        private string exclude;
        private string time;

        private string currentForecastURL = "https://api.forecast.io/forecast/{0}/{1},{2}?units={3}&exclude={4}";
        private string periodForecastURL = "https://api.forecast.io/forecast/{0}/{1},{2},{3}?units={4}&exclude={5}";

        public ForecastIOReponse Get()
        {
            var client = new WebClient();
            var url = "";
            if (time == null)
            {
                url = String.Format(currentForecastURL, apiKey, latitude, longitude, unit, exclude);
            }
            else
            {
                url = String.Format(periodForecastURL, apiKey, latitude, longitude, time, unit, exclude);
            }

            var stringResult = FormatResponse(client.DownloadString(url));
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ForecastIOReponse dataObject = serializer.Deserialize<ForecastIOReponse>(stringResult);

            return dataObject;
            
        }

        private string FormatResponse(string _input)
        {
            _input = _input.Replace("isd-stations", "isd_stations");
            _input = _input.Replace("lamp-stations", "lamp_stations");
            _input = _input.Replace("metar-stations", "metar_stations");
            _input = _input.Replace("darksky-stations", "darksky_stations");
            return _input;
        }

        public ForecastIORequest(string _apiKey, float _lat, float _long, string _unit, params string[] _exclude)
        {
            apiKey = _apiKey;
            latitude = _lat.ToString(CultureInfo.InvariantCulture);
            longitude = _long.ToString(CultureInfo.InvariantCulture);
            unit = _unit;
            if (_exclude.Length > 0)
            {
                foreach (string excludeBlock in _exclude)
                {
                    exclude += excludeBlock + ",";
                }
                exclude = exclude.TrimEnd(',');
            }
            else
            {
                exclude = "";
            }
        }

        public ForecastIORequest(string _apiKey, float _lat, float _long, DateTime _time, string _unit, params string[] _exclude)
        {
            apiKey = _apiKey;
            latitude = _lat.ToString(CultureInfo.InvariantCulture);
            longitude = _long.ToString(CultureInfo.InvariantCulture);
            var milliseconds = _time.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            time = Convert.ToInt64(milliseconds).ToString();
            unit = _unit;
            if (_exclude.Length > 0)
            {
                foreach (string excludeBlock in _exclude)
                {
                    exclude += excludeBlock + ",";
                }
                exclude = exclude.TrimEnd(',');
            }
            else
            {
                exclude = "";
            }
        }
    }
}
