using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GeoIpTests
{
    public class GeoIpControllerTests
    {
        // Does not work!

        [Fact]
        public async Task SomeTest()
        {
            var client = new TestClientProvider().Client;

            var response = await client.GetAsync("https://localhost:44389/geoip/IpApi/xd");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
