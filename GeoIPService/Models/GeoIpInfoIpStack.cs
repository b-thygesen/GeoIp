using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoIPService.Models
{
    public class GeoIpInfoIpStack
    {
        [JsonProperty("ip")]
        public string Ip { get; internal set; }

        [JsonProperty("country_name")]
        public string Country { get; internal set; }

        [JsonProperty("region_code")]
        public string RegionCode { get; internal set; }

        [JsonProperty("city")]
        public string City { get; internal set; }

        [JsonProperty("zip")]
        public string ZipCode { get; internal set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; internal set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; internal set; }
    }
}
