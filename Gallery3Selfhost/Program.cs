using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Gallery3Selfhost
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = GetSelfHostConfiguration();

            StartSelfHost(config);
        }

        private static HttpSelfHostConfiguration GetSelfHostConfiguration()
        {
            var _baseAddress = new Uri("http://localhost:60065/");

            var config = new HttpSelfHostConfiguration(_baseAddress);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            return config;
        }

        private static void StartSelfHost(HttpSelfHostConfiguration config)
        {
            var server = new HttpSelfHostServer(config);

            // Start listening
            server.OpenAsync().Wait();

            Console.WriteLine("Gallery Web-API Self hosted on " + config.BaseAddress);
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();

            server.CloseAsync().Wait();
        }
    }
}