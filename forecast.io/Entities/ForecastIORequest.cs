using ForecastIO.Extensions;
using System;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

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
        private readonly string _lang;
        //
        private string _apiCallsMade;
        private string _apiResponseTime;
        //

        private const string CurrentForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2}?units={3}&lang={4}&extend={5}&exclude={6}";
        private const string PeriodForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2},{3}?units={4}&lang={5}&extend={6}&exclude={7}";

        public ForecastIOResponse Get()
        {
            var url = GetUrl();

            string result;
            using (var client = new CompressionEnabledWebClient { Encoding = Encoding.UTF8 })
            {
                result = RequestHelpers.FormatResponse(client.DownloadString(url));
                // Set response values.
                _apiResponseTime = client.ResponseHeaders["X-Response-Time"];
                _apiCallsMade = client.ResponseHeaders["X-Forecast-API-Calls"];
            }

            var serializer = new JavaScriptSerializer();
            var dataObject = serializer.Deserialize<ForecastIOResponse>(result);

            return dataObject;

        }

#if !NET_40
        public async Task<ForecastIOResponse> GetAsync()
        {
            var url = GetUrl();

            string result;
            using (var client = new CompressionEnabledWebClient { Encoding = Encoding.UTF8 })
            {
                var response = await client.DownloadStringTaskAsync(url);
                result = RequestHelpers.FormatResponse(response);
                // Set response values.
                _apiResponseTime = client.ResponseHeaders["X-Response-Time"];
                _apiCallsMade = client.ResponseHeaders["X-Forecast-API-Calls"];
            }

            var serializer = new JavaScriptSerializer();
            var dataObject = serializer.Deserialize<ForecastIOResponse>(result);

            return dataObject;
        }
#endif

        public ForecastIORequest(string apiKey, float latF, float longF, Unit unit, Language? lang = null, Extend[] extend = null, Exclude[] exclude = null)
        {
            _apiKey = apiKey;
            _latitude = latF.ToString(CultureInfo.InvariantCulture);
            _longitude = longF.ToString(CultureInfo.InvariantCulture);
            _unit = Enum.GetName(typeof(Unit), unit);
            _extend = extend != null ? RequestHelpers.FormatExtendString(extend) : string.Empty;
            _exclude = exclude != null ? RequestHelpers.FormatExcludeString(exclude) : string.Empty;
            _lang = lang != null ? RequestHelpers.FormatLanguageEnum(lang) : Language.en.ToString();
        }

        public ForecastIORequest(string apiKey, float latF, float longF, DateTime time, Unit unit, Language? lang = null, Extend[] extend = null, Exclude[] exclude = null)
        {
            _apiKey = apiKey;
            _latitude = latF.ToString(CultureInfo.InvariantCulture);
            _longitude = longF.ToString(CultureInfo.InvariantCulture);
            _time = time.ToUTCString();
            _unit = Enum.GetName(typeof(Unit), unit);
            _extend = extend != null ? RequestHelpers.FormatExtendString(extend) : string.Empty;
            _exclude = exclude != null ? RequestHelpers.FormatExcludeString(exclude) : string.Empty;
            _lang = lang != null ? RequestHelpers.FormatLanguageEnum(lang) : Language.en.ToString();
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
                throw new Exception("Cannot retrieve API Response Time. No calls have been made to the API yet.");
            }
        }

        private string GetUrl()
        {
            var url = _time == null 
                ? string.Format(CurrentForecastUrl, _apiKey, _latitude, _longitude, _unit, _lang, _extend, _exclude) 
                : string.Format(PeriodForecastUrl, _apiKey, _latitude, _longitude, _time, _unit, _lang, _extend, _exclude);

            return url;
        }
    }
}