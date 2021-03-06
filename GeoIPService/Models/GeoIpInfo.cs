﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeoIPService.Models
{
    public class GeoIpInfo
    {
        public bool Success { get; internal set; }
        public string Ip { get; internal set; }
        public string TimeZone { get; internal set; }
        public string Country { get; internal set; }
        public string RegionCode { get; internal set; }
        public string City { get; internal set; }
        public string ZipCode { get; internal set; }
        public double? Latitude { get; internal set; }
        public double? Longitude { get; internal set; }
    }
}
