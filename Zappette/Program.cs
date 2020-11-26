using System;
using ScanningTool.Models;
using System.Net.Http;
using System.Collections.Generic;
using System.Net.Http.Headers;
using EntrepotService;

namespace ScanningTool
{
    class Program
    {
        private static EntrepotClient _entrepotClient;
        static void Main()
        {
             var httpClientHandler = new HttpClientHandler();
           // Create WeatherClient.
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            var httpClient = new HttpClient(httpClientHandler);


            _entrepotClient = new EntrepotClient("http://93.11.120.71:3769/", httpClient);

            ICollection<EntrepotService.Product> result= _entrepotClient.ProductsAllAsync().Result;

            EntrepotService.Product banane = null;
            EntrepotService.Product pomme = null;
            EntrepotService.Product kiwi = null;

            foreach (EntrepotService.Product r in result)
            {
                Console.WriteLine(r.Name + ", id: " + r.Id + " en stock: " + r.Quantity);

                if (r.Name == "Banane")
                {
                    banane = r;
                }
                else if (r.Name == "Pomme")
                {
                    pomme = r;
                }
                else if (r.Name == "Kiwi")
                {
                    kiwi = r;
                }
            }

            Zappette zappette = new Zappette();

            zappette.entrepot = _entrepotClient;

            zappette.Scan(pomme);
            zappette.Scan(kiwi);
            zappette.AddProduct(kiwi);
            zappette.Scan(kiwi);

        }
    }
}
