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
        private DateTime time;

        private string currentForecastURL = "https://api.forecast.io/forecast/{0}/{1},{2}";
        private string periodForecastURL = "https://api.forecast.io/forecast/{0}/{1},{2},{3}";

        public ForecastIORequest(string _apiKey, float _lat, float _long)
        {
            apiKey = _apiKey;
            latitude = _lat.ToString(CultureInfo.InvariantCulture);
            longitude = _long.ToString(CultureInfo.InvariantCulture);
        }

        public ForecastIORequest(string _apiKey, float _lat, float _long, DateTime _time)
        {
            apiKey = _apiKey;
            latitude = _lat.ToString(CultureInfo.InvariantCulture);
            longitude = _long.ToString(CultureInfo.InvariantCulture);
            time = _time;
        }

        public ForecastIOReponse Get()
        {
            var client = new WebClient();
            var url = "";
            if (time == DateTime.MinValue)
            {
                url = String.Format(currentForecastURL, apiKey, latitude, longitude);
            }
            else
            {
                url = String.Format(periodForecastURL, apiKey, latitude, longitude, time);
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
    }
}
