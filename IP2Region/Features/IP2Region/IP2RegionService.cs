namespace IP2Region.Features.IP_Region_assignment
{
    using Infrastructure.Options;
    using IPValidator;
    using MaxMind.GeoIP2;
    using Microsoft.Extensions.Configuration;

    public class Ip2RegionService : IIp2RegionService
    {
        private readonly IIpValidatorService _ipValidator;
        private readonly IConfiguration _configuration;

        public Ip2RegionService(IIpValidatorService ipValidator, IConfiguration configuration)
        {
            _ipValidator = ipValidator;
            _configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public string GetCountryWhereIpisLocated(string ip)
        {
            var maxMindsOptions = new MaxMindsOptions();
            _configuration.GetSection("Api").Bind(maxMindsOptions);
            var isValid = _ipValidator.IsValidIp(ip);
            if (!isValid) return "NotValid";
            var isPublic = _ipValidator.IsPublicIp(ip);
            if (!isPublic) return "priv";

            using var client = new WebServiceClient(maxMindsOptions.AccountId, maxMindsOptions.ApiKey, host: "geolite.info");
            var response = client.Country(ip);
            return response.Country.Name;
        }
    }
}