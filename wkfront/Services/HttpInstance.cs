using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace wkfront.Services
{
    public class HttpInstance
    {

        private static HttpClient httpClientInstance;

        private HttpInstance()
        {
        }


        public static HttpClient GetHttpClientInstance()
        {
            if (httpClientInstance == null)
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                httpClientInstance = new HttpClient(clientHandler);
                httpClientInstance.DefaultRequestHeaders.ConnectionClose = false;
            }
            return httpClientInstance;
        }
    }
}
