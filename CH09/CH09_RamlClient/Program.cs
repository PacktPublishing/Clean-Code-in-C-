using CH09_RamlClient.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace CH09_RamlClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var hwc = new v1HelloWorldController();
                var response = await hwc.Get() as OkNegotiatedContentResult<string>;
                if (response is OkNegotiatedContentResult<string>)
                {
                    var msg = response.Content;
                    Console.WriteLine($"Message: {msg}");
                }
            }).GetAwaiter().GetResult();
            Console.ReadKey();
        }
    }
}
