using GeoIPService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoIPService.Services
{
    public interface IGeoIpService
    {
        Task<GeoIpInfo> GetGeoIp(string ipOrHostname, bool isIpStack);
    }
}
