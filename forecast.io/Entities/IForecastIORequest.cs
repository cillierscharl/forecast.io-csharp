namespace ForecastIO
{
    using System;

    /// <summary>
    /// The ForecastIORequest interface.
    /// </summary>
    public interface IForecastIORequest
    {
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
        ForecastIOResponse Get(
            float latitude,
            float longitude,
            Unit unit,
            Extend[] extend = null,
            Exclude[] exclude = null);

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
        ForecastIOResponse Get(
            float latitude,
            float longitude,
            DateTime? time,
            Unit unit,
            Extend[] extend = null,
            Exclude[] exclude = null);

        /// <summary>
        /// Gets the API calls made.
        /// </summary>
        string ApiCallsMade { get; }

        /// <summary>
        /// Gets the API response time.
        /// </summary>
        string ApiResponseTime { get; }
    }
}