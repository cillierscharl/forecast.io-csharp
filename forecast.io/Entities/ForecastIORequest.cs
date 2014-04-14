using ForecastIO.Extensions;
using System;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
#if WITH_ASYNC
using System.Net;
using System.Threading;
using System.Threading.Tasks;
#endif

namespace ForecastIO
{
    public class ForecastIORequest
    {
        private readonly string _apiKey;
        private readonly string _latitude;
        private readonly string _longitude;
        private readonly string _unit;
        private readonly string _exclude;
        private readonly string _extend;
        private readonly string _time;
        //
        private string _apiCallsMade;
        private string _apiResponseTime;
        //

        private const string CurrentForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2}?units={3}&extend={4}&exclude={5}";
        private const string PeriodForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2},{3}?units={4}&extend={5}&exclude={6}";

#if WITH_ASYNC
        public async Task<ForecastIOResponse> GetAsync()
        {
            var url = (_time == null)
                ? String.Format(CurrentForecastUrl, _apiKey, _latitude, _longitude, _unit, _extend, _exclude)
                : String.Format(PeriodForecastUrl, _apiKey, _latitude, _longitude, _time, _unit, _extend, _exclude);

            using (var client = new CompressionEnabledWebClient { Encoding = Encoding.UTF8 })
            {
                var responseTask = client.DownloadStringTaskAsync(url);
                return await responseTask.ContinueWith((t) => HandleResponse(client.ResponseHeaders, t.Result));
            }
        }
#endif

        public ForecastIOResponse Get()
        {
            var url = (_time == null)
                ? String.Format(CurrentForecastUrl, _apiKey, _latitude, _longitude, _unit, _extend, _exclude)
                : String.Format(PeriodForecastUrl, _apiKey, _latitude, _longitude, _time, _unit, _extend, _exclude);

            using (var client = new CompressionEnabledWebClient { Encoding = Encoding.UTF8})
            {
                string result = client.DownloadString(url);
                return HandleResponse(client.ResponseHeaders, result);
            }
        }

        private ForecastIOResponse HandleResponse(WebHeaderCollection headers, string response)
        {
            string result = RequestHelpers.FormatResponse(response);

            // Set response values.
            _apiResponseTime = headers["X-Response-Time"];
            _apiCallsMade = headers["X-Forecast-API-Calls"];

            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<ForecastIOResponse>(result);
        }

        public ForecastIORequest(string apiKey, float latF, float longF, Unit unit, Extend[] extend = null, Exclude[] exclude = null)
        {
            _apiKey = apiKey;
            _latitude = latF.ToString(CultureInfo.InvariantCulture);
            _longitude = longF.ToString(CultureInfo.InvariantCulture);
            _unit = Enum.GetName(typeof(Unit), unit);
            _extend = (extend != null) ? RequestHelpers.FormatExtendString(extend) : "";
            _exclude = (exclude != null) ? RequestHelpers.FormatExcludeString(exclude) : "";
        }

        public ForecastIORequest(string apiKey, float latF, float longF, DateTime time, Unit unit, Extend[] extend = null, Exclude[] exclude = null)
        {
            _apiKey = apiKey;
            _latitude = latF.ToString(CultureInfo.InvariantCulture);
            _longitude = longF.ToString(CultureInfo.InvariantCulture);
            _time = time.ToUTCString();
            _unit = Enum.GetName(typeof(Unit), unit);
            _extend = (extend != null) ? RequestHelpers.FormatExtendString(extend) : "";
            _exclude = (exclude != null) ? RequestHelpers.FormatExcludeString(exclude) : "";
        }

        public string ApiCallsMade
        {
            get
            {
                if (_apiCallsMade != null)
                {
                    return _apiCallsMade;
                }
                throw new Exception("Cannot retrieve API Calls Made. No calls have been made to the API yet.");
            }
        }

        public string ApiResponseTime
        {
            get
            {
                if (_apiResponseTime != null)
                {
                    return _apiResponseTime;
                }
                throw new Exception("Cannot retrieve API Reponse Time. No calls have been made to the API yet.");
            }
        }
    }
}
