using System;

namespace ForecastIO
{
    public static class RequestHelpers
    {
        public static string FormatResponse(string _input)
        {
            _input = _input.Replace("isd-stations", "isd_stations");
            _input = _input.Replace("lamp-stations", "lamp_stations");
            _input = _input.Replace("metar-stations", "metar_stations");
            _input = _input.Replace("darksky-stations", "darksky_stations");
            return _input;
        }

        public static string FormatExcludeString(string[] _input)
        {
            var output = "";
            if (_input.Length > 0)
            {
                foreach (string excludeBlock in _input)
                {
                    output += excludeBlock + ",";
                }
                output = output.TrimEnd(',');
            }
            else
            {
                output = "";
            }

            return output;
        }

        public static string FormatUTCString(DateTime _input)
        {
            var milliseconds = _input.ToUniversalTime().Subtract(
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            return Convert.ToInt64(milliseconds).ToString();
        }
    }
}
