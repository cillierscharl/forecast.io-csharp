using ForecastIO.Extensions;
using System;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;

namespace ForecastIO
{
    /// <summary>
    /// The forecast IO request.
    /// </summary>
    public class ForecastIORequest : IForecastIORequest
    {
        /// <summary>
        /// The current forecast url.
        /// </summary>
        private const string CurrentForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2}?units={3}&extend={4}&exclude={5}";

        /// <summary>
        /// The period forecast url.
        /// </summary>
        private const string PeriodForecastUrl = "https://api.forecast.io/forecast/{0}/{1},{2},{3}?units={4}&extend={5}&exclude={6}";
        
        /// <summary>
        /// The API key.
        /// </summary>
        private readonly string apiKey;

        /// <summary>
        /// The API calls made.
        /// </summary>
        private string apiCallsMade;

        /// <summary>
        /// The API response time.
        /// </summary>
        private string apiResponseTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForecastIORequest"/> class.
        /// </summary>
        public ForecastIORequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ForecastIORequest"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The API key.
        /// </param>
        public ForecastIORequest(string apiKey)
        {
            // ensure args
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException("apiKey", "API key must be provided.");
            }

            // set api key
            this.apiKey = apiKey;
        }

        /// <summary>
        /// Gets the API calls made.
        /// </summary>
        public string ApiCallsMade
        {
            get
            {
                if (this.apiCallsMade != null)
                {
                    return this.apiCallsMade;
                }

                throw new Exception("Cannot retrieve API Calls Made. No calls have been made to the API yet.");
            }
        }

        /// <summary>
        /// Gets the API response time.
        /// </summary>
        public string ApiResponseTime
        {
            get
            {
                if (this.apiResponseTime != null)
                {
                    return this.apiResponseTime;
                }

                throw new Exception("Cannot retrieve API Reponse Time. No calls have been made to the API yet.");
            }
        }

        /// <summary>
        /// Retrieves the forecast for the give latitude, longitude and unit.
        /// </summary>
        /// <param name="latitude">
        /// The latitude.
        /// </param>
        /// <param name="longitude">
        /// The longitude.
        /// </param>
        /// <param name="unit">
        /// The unit (i.e, US).
        /// </param>
        /// <param name="extend">
        /// Extended options.
        /// </param>
        /// <param name="exclude">
        /// All exclusions.
        /// </param>
        /// <returns>
        /// The <see cref="ForecastIOResponse"/>.
        /// </returns>
        public ForecastIOResponse Get(
            float latitude,
            float longitude,
            Unit unit,
            Extend[] extend = null,
            Exclude[] exclude = null)
        {
            return this.Get(latitude, longitude, null, unit);
        }

        /// <summary>
        /// Retrieves the forecast for the give latitude, longitude and unit.
        /// </summary>
        /// <param name="latitude">
        /// The latitude.
        /// </param>
        /// <param name="longitude">
        /// The longitude.
        /// </param>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <param name="unit">
        /// The unit (i.e, US).
        /// </param>
        /// <param name="extend">
        /// Extended options.
        /// </param>
        /// <param name="exclude">
        /// All exclusions.
        /// </param>
        /// <returns>
        /// The <see cref="ForecastIOResponse"/>.
        /// </returns>
        public ForecastIOResponse Get(
            float latitude,
            float longitude,
            DateTime? time,
            Unit unit,
            Extend[] extend = null,
            Exclude[] exclude = null)
        {
            var latitudeOption = latitude.ToString(CultureInfo.InvariantCulture);
            var longitudeOption = longitude.ToString(CultureInfo.InvariantCulture);
            var timeOption = time.HasValue ? time.Value.ToUTCString() : string.Empty;
            var unitOption = Enum.GetName(typeof(Unit), unit);
            var extendOption = (extend != null) ? RequestHelpers.FormatExtendString(extend) : string.Empty;
            var excludeOption = (exclude != null) ? RequestHelpers.FormatExcludeString(exclude) : string.Empty;

            // create url
            var url = string.IsNullOrWhiteSpace(timeOption) ? string.Format(CurrentForecastUrl, this.apiKey, latitudeOption, longitudeOption, unitOption, extendOption, excludeOption) :
                string.Format(PeriodForecastUrl, this.apiKey, latitudeOption, longitudeOption, timeOption, unitOption, extendOption, excludeOption);

            // placeholder for result
            var result = default(string);

            // initiate the call to the API
            using (var client = new CompressionEnabledWebClient())
            {
                client.Encoding = Encoding.UTF8;
                result = RequestHelpers.FormatResponse(client.DownloadString(url));

                // Set response values.
                this.apiResponseTime = client.ResponseHeaders["X-Response-Time"];
                this.apiCallsMade = client.ResponseHeaders["X-Forecast-API-Calls"];
            }

            var serializer = new JavaScriptSerializer();
            var dataObject = serializer.Deserialize<ForecastIOResponse>(result);

            return dataObject;
        }
    }
}
