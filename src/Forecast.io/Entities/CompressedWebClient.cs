using System;
using System.Net;
#if DNXCORE50
using System.Net.Http;
using System.Collections.Generic;
#endif

namespace ForecastIO
{

#if !DNXCORE50
     public class CompressionEnabledWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request == null) return null;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }
#elif DNXCORE50
    public class CompressionEnabledWebClient : HttpClient
    {
    }
#endif
}
