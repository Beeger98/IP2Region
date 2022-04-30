namespace IP2Region.Infrastructure.ExtensionMethods
{
    using Features.IP_Region_assignment;
    using Features.IPValidator;
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IIp2RegionService, Ip2RegionService>();
            services.AddScoped<IIpValidatorService, IpValidatorService>();
            return services;
        }
    }
}