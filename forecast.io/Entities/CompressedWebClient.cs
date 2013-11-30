using System;
using System.Net;

namespace ForecastIO
{
    public class CompressionEnabledWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request == null) return null;
            request.Proxy = null; //Prevents a possible 10+ sec delay (See http://stackoverflow.com/questions/2519655/httpwebrequest-is-extremely-slow/3603413#3603413)
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
        
    }
}
