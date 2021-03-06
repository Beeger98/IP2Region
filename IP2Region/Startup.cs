namespace IP2Region
{
    using Infrastructure.ExtensionMethods;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.RegisterServices()
                .AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "IP2Region", Version = "v1"}); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                        .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IP2Region v1"));
            }

            app.UseHttpsRedirection()
                .UseRouting()
                    .UseAuthorization()
                        .UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}