using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoIPService.Models;
using GeoIPService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeoIPService.Controllers
{
    [Route("geoip/")]
    [ApiController]
    public class GeoIpController : ControllerBase
    {
        private readonly IGeoIpService _geoIpService;

        public GeoIpController(IGeoIpService geoIpService)
        {
            _geoIpService = geoIpService;
        }

        [HttpGet]
        [Route("IpStack/{ipOrHostName}")]
        public async Task<ActionResult<GeoIpInfo>> GetInfoFromIpStack(string ipOrHostname)
        {
            if (string.IsNullOrEmpty(ipOrHostname))
            {
                return new GeoIpInfo
                {
                    Success = false
                };
            }

            var geoIpInfo = await _geoIpService.GetGeoIp(ipOrHostname, true);

            return geoIpInfo;
        }

        [HttpGet]
        [Route("IpApi/{ipOrHostName}")]
        public async Task<ActionResult<GeoIpInfo>> GetInfoFromIpApi(string ipOrHostname)
        {
            if (string.IsNullOrEmpty(ipOrHostname))
            {
                return new GeoIpInfo
                {
                    Success = false
                };
            }

            var geoIpInfo = await _geoIpService.GetGeoIp(ipOrHostname, false);

            return geoIpInfo;
        }

    }
}
