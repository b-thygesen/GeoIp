using GeoIPService.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GeoIPService.Services
{
    public class GeoIpService : IGeoIpService
    {
        private IConfiguration _config;
        private static readonly HttpClient client = new HttpClient();

        public GeoIpService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<GeoIpInfo> GetGeoIp(string ipOrHostname, bool isIpStack)
        {
            var url = isIpStack ? _config["IpStackUrl"] + ipOrHostname + _config["IpStackKeyUrl"] : _config["IpApiUrl"] + ipOrHostname;
            var responseObject = await client.GetAsync(url);
            var responseContent = await responseObject.Content.ReadAsStringAsync();
            var responseStatusCode = responseObject.StatusCode;

            if (responseStatusCode == HttpStatusCode.OK)
            {
                return DeserializeResponseObject(isIpStack, responseContent);
            }

            return new GeoIpInfo
            {
                Success = false
            };
        }

        private GeoIpInfo DeserializeResponseObject(bool isIpStack, string resContent)
        {
            if (isIpStack)
            {
                GeoIpInfoIpStack geoIpInfoIpStack = JsonConvert.DeserializeObject<GeoIpInfoIpStack>(resContent);

                if (!string.IsNullOrEmpty(geoIpInfoIpStack.Country))
                {
                    return new GeoIpInfo
                    {
                        Success = true,
                        Ip = geoIpInfoIpStack.Ip,
                        Country = geoIpInfoIpStack.Country,
                        RegionCode = geoIpInfoIpStack.RegionCode,
                        City = geoIpInfoIpStack.City,
                        ZipCode = geoIpInfoIpStack.ZipCode,
                        Longitude = geoIpInfoIpStack.Longitude,
                        Latitude = geoIpInfoIpStack.Latitude,
                        TimeZone = null
                    };
                }

            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(GeoIpInfoIpApi));
                StringReader rdr = new StringReader(resContent);
                GeoIpInfoIpApi geoIpInfoIpApi = (GeoIpInfoIpApi)serializer.Deserialize(rdr);

                if (geoIpInfoIpApi.Status == "success")
                {
                    return new GeoIpInfo
                    {
                        Success = true,
                        Ip = geoIpInfoIpApi.Ip,
                        Country = geoIpInfoIpApi.Country,
                        RegionCode = geoIpInfoIpApi.RegionCode,
                        City = geoIpInfoIpApi.City,
                        ZipCode = geoIpInfoIpApi.ZipCode,
                        Longitude = geoIpInfoIpApi.Longitude,
                        Latitude = geoIpInfoIpApi.Latitude,
                        TimeZone = geoIpInfoIpApi.TimeZone
                    };
                }

            }

            return new GeoIpInfo
            {
                Success = false
            };
        }
    }
}
