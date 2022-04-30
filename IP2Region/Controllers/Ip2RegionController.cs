namespace IP2Region.Controllers
{
    using Features.IP_Region_assignment;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class Ip2RegionController : ControllerBase
    {
        private readonly IIp2RegionService _ip2RegionService;

        public Ip2RegionController(IIp2RegionService ip2RegionService)
        {
            _ip2RegionService = ip2RegionService;
        }

        /// <summary>
        ///     Get the Country Code from an given Ip Adress
        /// </summary>
        /// <param name="ipAdress"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCountry(string ipAdress)
        {
            var response = _ip2RegionService.GetCountryWhereIpisLocated(ipAdress);
            return response switch
            {
                "NotValid" => BadRequest("No Valid Ip adress"),
                "priv" => BadRequest("This is an private Ip adress so its propably in your network"),
                _ => Ok(response)
            };
        }
    }
}