using System;

namespace ForecastIO.Extensions
{
    public static class Extensions
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTime(this Int64 _input)
        {
            return UnixEpoch.AddSeconds(_input);
        }

        public static string ToUTCString(this DateTime _input)
        {
            var milliseconds = _input.ToUniversalTime().Subtract(UnixEpoch).TotalSeconds;
            return Convert.ToInt64(milliseconds).ToString();
        }
    }
}
