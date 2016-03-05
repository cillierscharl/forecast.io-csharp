using ForecastIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var request = new ForecastIORequest("a617f7c8f59bc8913fd12e62af642f90", 37.8267f, -122.423f, Unit.si);
            var response = request.Get();
            
            Console.Write(Newtonsoft.Json.JsonConvert.SerializeObject(response));
            Console.Read();
        }
    }
}
