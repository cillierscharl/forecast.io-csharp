﻿using ForecastIO.Extensions;
using System;
using System.Globalization;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

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
            var url = (_time == null) ? string.Format(CurrentForecastUrl, _apiKey, _latitude, _longitude, _unit, _lang, _extend, _exclude) :
                string.Format(PeriodForecastUrl, _apiKey, _latitude, _longitude, _time, _unit, _lang, _extend, _exclude);

            string result;
            using (var client = new CompressionEnabledWebClient())
            {
#if !DNXCORE50
                client.Encoding = Encoding.UTF8;
                result = RequestHelpers.FormatResponse(client.DownloadString(url));
                // Set response values.
                _apiResponseTime = client.ResponseHeaders["X-Response-Time"];
                _apiCallsMade = client.ResponseHeaders["X-Forecast-API-Calls"];
#elif DNXCORE50
                var response = client.GetAsync(url).Result;
                var responseData = response.Content.ReadAsStringAsync().Result;
                result = RequestHelpers.FormatResponse(responseData);
                // Set response values.
                _apiResponseTime = (response.Headers.Where(x => x.Key == "X-Response-Time").FirstOrDefault().Value?.FirstOrDefault()) ?? string.Empty;
                _apiCallsMade = (response.Headers.Where(x => x.Key == "X-Forecast-API-Calls").FirstOrDefault().Value?.FirstOrDefault()) ?? string.Empty;
#endif

            }
            var dataObject = JsonConvert.DeserializeObject<ForecastIOResponse>(result);

            return dataObject;

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
