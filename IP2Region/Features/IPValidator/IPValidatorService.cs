namespace IP2Region.Features.IPValidator
{
    using System.Linq;
    using System.Net;
    /// <summary>
    /// Service to Confirm a valid IP adress because MaxMind Api is Crashing if its not 
    /// </summary>
    public class IpValidatorService : IIpValidatorService
    {
        public bool IsPublicIp(string ip)
        {
            var IpParts = ip.Split('.').ToList().Select(int.Parse).ToArray();
            return IpParts[0] != 10 && (IpParts[0] != 172 || IpParts[1] > 31 || IpParts[1] < 16) && (IpParts[0] != 192 && IpParts[1] != 168);
        }

        public bool IsValidIp(string ipadress)
        {
            IPAddress ip;
            var isValid = IPAddress.TryParse(ipadress, out ip);
            return isValid && !IPAddress.IsLoopback(ip);
        }
    }
}