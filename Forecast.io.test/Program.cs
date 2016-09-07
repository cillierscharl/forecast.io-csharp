using ForecastIO;
using System;

namespace Forecast.io.test
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();
            test.TestSync();
            test.TestAsync();
            Console.ReadKey(true);
        }
    }

    class Test
    {
        private static string key = "88a72dce2fbdc69e3ad0a3db5481e7e3";
        public void TestSync()
        {
            var request = new ForecastIORequest(key, 43.4499376f, -79.7880999f, Unit.si);
            var response = request.Get();
            Console.WriteLine(string.Format("Sync Response: {0}", response.currently.apparentTemperature));
        }

        public async void TestAsync()
        {
            var request = new ForecastIORequest(key, 43.4499376f, -79.7880999f, Unit.si);
            var response = await request.GetAsync();
            Console.WriteLine(string.Format("Async Response: {0}", response.currently.apparentTemperature));
        }
    }
}
