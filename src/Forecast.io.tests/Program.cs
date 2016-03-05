using ForecastIO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forecast.io.tests
{
    public class Test
    {
        public ForecastIORequest Test1()
        {
            var request = new ForecastIORequest("a617f7c8f59bc8913fd12e62af642f90", 37.8267f, -122.423f, Unit.si);
            var response = await request.Get();
            return response;
        }
    }
}
