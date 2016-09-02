using ForecastIO;

namespace Forecast.io.test
{
    class Program
    {
        static void Main(string[] args)
        {
            var request = new ForecastIORequest("Insert Your API Key", 43.4499376f, -79.7880999f, Unit.si);
            var response = request.Get();
        }
    }
}
