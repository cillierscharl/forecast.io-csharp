using ForecastIO.Extensions;
using System;
using System.Globalization;
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
        private string extend;
        private string time;

        private static string currentForecastURL = "https://api.forecast.io/forecast/{0}/{1},{2}?units={3}&extend={4}&exclude={5}";
        private static string periodForecastURL = "https://api.forecast.io/forecast/{0}/{1},{2},{3}?units={4}&extend={5}&exclude={6}";

        public ForecastIOResponse Get()
        {
            var url = (time == null) ? String.Format(currentForecastURL, apiKey, latitude, longitude, unit, extend, exclude) :
                String.Format(periodForecastURL, apiKey, latitude, longitude, time, unit, extend, exclude);

            string result;
            using (CompressionEnabledWebClient client = new CompressionEnabledWebClient())
            {
                result = RequestHelpers.FormatResponse(client.DownloadString(url));
            }

            var serializer = new JavaScriptSerializer();
            var dataObject = serializer.Deserialize<ForecastIOResponse>(result);

            return dataObject;

        }

        public ForecastIORequest(string _apiKey, float _lat, float _long, Unit _unit, Extend[] _extend = null, Exclude[] _exclude = null)
        {
            apiKey = _apiKey;
            latitude = _lat.ToString(CultureInfo.InvariantCulture);
            longitude = _long.ToString(CultureInfo.InvariantCulture);
            unit = Enum.GetName(typeof(Unit), _unit);
            extend = (_extend != null) ? RequestHelpers.FormatExtendString(_extend) : "";
            exclude = (_exclude != null) ? RequestHelpers.FormatExcludeString(_exclude) : "";
        }

        public ForecastIORequest(string _apiKey, float _lat, float _long, DateTime _time, Unit _unit, Extend[] _extend = null, Exclude[] _exclude = null)
        {
            apiKey = _apiKey;
            latitude = _lat.ToString(CultureInfo.InvariantCulture);
            longitude = _long.ToString(CultureInfo.InvariantCulture);
            time = _time.ToUTCString();
            unit = Enum.GetName(typeof(Unit), _unit);
            extend = (_extend != null) ? RequestHelpers.FormatExtendString(_extend) : "";
            exclude = (_exclude != null) ? RequestHelpers.FormatExcludeString(_exclude) : "";
        }
    }
}
