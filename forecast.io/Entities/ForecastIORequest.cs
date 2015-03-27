using ForecastIO.Extensions;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
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
        private readonly Language _lang;
        //
        private string _apiCallsMade;
        private string _apiResponseTime;
        //

        private const string CurrentForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2}?units={3}&lang={4}&extend={5}&exclude={6}";
        private const string PeriodForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2},{3}?units={4}&lang={5}&extend={6}&exclude={7}";

        public ForecastIOResponse Get()
        {
            try
            {
                var url = (_time == null)
                            ? String.Format(CurrentForecastUrl, _apiKey, _latitude, _longitude, _unit, _lang, _extend, _exclude)
                            : String.Format(PeriodForecastUrl, _apiKey, _latitude, _longitude, _time, _unit, _lang, _extend, _exclude);

                string result = null;
                using (var client = new CompressionEnabledWebClient())
                {
                    client.Encoding = Encoding.UTF8;

                    using (Stream s = client.OpenRead(url))
                    using (StreamReader sr = new StreamReader(s))
                    {
                        result = RequestHelpers.FormatResponse(sr.ReadToEnd());
                    }

                    // Set response values.
                    _apiResponseTime = client.ResponseHeaders["X-Response-Time"];
                    _apiCallsMade = client.ResponseHeaders["X-Forecast-API-Calls"];
                }

                var serializer = new JavaScriptSerializer();
                var dataObject = serializer.Deserialize<ForecastIOResponse>(result);

                return dataObject;
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(500);
                sb.AppendLine("Error while requesting weather from source!");

                WebException wex = ex as WebException;
                if (wex != null)
                {
                    HttpWebResponse httpResponse = wex.Response as HttpWebResponse;
                    if (httpResponse != null)
                    {
                        int statusCode = (int)httpResponse.StatusCode;
                        string statusDesc = httpResponse.StatusDescription;

                        sb.AppendLine(string.Format("Http Status Code: {0}", statusCode));
                        sb.AppendLine(string.Format("Http Status Desc: {0}", statusDesc));

                        if (httpResponse.Headers != null)
                        {
                            sb.AppendLine("All response header values:");
                            foreach (var key in httpResponse.Headers.AllKeys)
                            {
                                string value = httpResponse.Headers[key];
                                sb.AppendLine(string.Format("{0}: {1}", key, value));
                            }
                        }
                        else
                        {
                            sb.AppendLine("Unable to get response headers!");
                        }
                    }
                }
                throw new ForecastIOException(sb.ToString(), ex);
            }
        }

        public ForecastIORequest(string apiKey, float latF, float longF, Unit unit, Language? lang = null, Extend[] extend = null, Exclude[] exclude = null )
        {
            _apiKey = apiKey;
            _latitude = latF.ToString(CultureInfo.InvariantCulture);
            _longitude = longF.ToString(CultureInfo.InvariantCulture);
            _unit = Enum.GetName(typeof(Unit), unit);
            _extend = (extend != null) ? RequestHelpers.FormatExtendString(extend) : "";
            _exclude = (exclude != null) ? RequestHelpers.FormatExcludeString(exclude) : "";
            _lang = lang ?? Language.en;
        }

        public ForecastIORequest(string apiKey, float latF, float longF, DateTime time, Unit unit, Language? lang = null, Extend[] extend = null, Exclude[] exclude = null)
        {
            _apiKey = apiKey;
            _latitude = latF.ToString(CultureInfo.InvariantCulture);
            _longitude = longF.ToString(CultureInfo.InvariantCulture);
            _time = time.ToUTCString();
            _unit = Enum.GetName(typeof(Unit), unit);
            _extend = (extend != null) ? RequestHelpers.FormatExtendString(extend) : "";
            _exclude = (exclude != null) ? RequestHelpers.FormatExcludeString(exclude) : "";
            _lang = lang ?? Language.en;
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
