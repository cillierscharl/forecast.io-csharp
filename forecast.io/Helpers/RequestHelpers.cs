using System;
using System.Linq;

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

        public static string FormatExcludeString(Exclude[] _input)
        {
            return string.Join(",", _input.Select(i => Enum.GetName(typeof(Exclude), i)));
        }

        public static string FormatExtendString(Extend[] _input)
        {
            return string.Join(",", _input.Select(i => Enum.GetName(typeof(Extend), i)));
        }
    }
}
