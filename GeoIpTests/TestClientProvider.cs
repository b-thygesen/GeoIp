using GeoIPService.Services;
using System.Threading.Tasks;
using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using GeoIPService;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace GeoIpTests
{

    public class TestClientProvider
    {
        // Does not work!

        public HttpClient Client { get; private set; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = server.CreateClient();
        }



    }
}
