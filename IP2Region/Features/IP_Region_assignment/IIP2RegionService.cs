namespace IP2Region.Features.IP_Region_assignment
{
    public interface IIp2RegionService
    {
        string GetCountryWhereIpisLocated(string Ip);
    }
}