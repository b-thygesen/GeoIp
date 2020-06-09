using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GeoIPService.Models
{
    [XmlRoot(ElementName = "query")]
    public class GeoIpInfoIpApi
    {
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "query")]
        public string Ip { get; set; }

        [XmlElement(ElementName = "timezone")]
        public string TimeZone { get; set; }

        [XmlElement(ElementName = "country")]
        public string Country { get; set; }

        [XmlElement(ElementName = "region")]
        public string RegionCode { get; set; }

        [XmlElement(ElementName = "city")]
        public string City { get; set; }

        [XmlElement(ElementName = "zip")]
        public string ZipCode { get; set; }

        [XmlElement(ElementName = "lat")]
        public double? Latitude { get; set; }

        [XmlElement(ElementName = "lon")]
        public double? Longitude { get; set; }
    }
}
