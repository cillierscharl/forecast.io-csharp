using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastIO
{
    public class ForecastIOException : Exception
    {
        public ForecastIOException(string message)
            : base(message)
        {
        }

        public ForecastIOException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
