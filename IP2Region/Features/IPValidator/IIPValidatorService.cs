namespace IP2Region.Features.IPValidator
{
    public interface IIpValidatorService
    {
        public bool IsPublicIp(string ip);

        public bool IsValidIp(string ip);
    }
}