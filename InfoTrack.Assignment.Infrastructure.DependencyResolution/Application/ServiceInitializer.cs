using System.Reflection;
using InfoTrack.Assignment.Application.Services.SearchEngineOptimizationDomain;
using InfoTrack.Assignment.Application.ServicesAbstraction.SearchEngineOptimization;
using InfoTrack.Assignment.Core.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.Assignment.Infrastructure.DependencyResolution
{
    public static class ServiceInitializer
    {
        public static IConfiguration RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterCustomDependencies(services);

            // Load HttpClient configuration from appsettings.json 
            var httpClientConfig = new HttpClientConfiguration();
            configuration.GetSection("HttpClientConfiguration").Bind(httpClientConfig);

            services.AddHttpClient<ISeoService, SeoService>(client =>
            {
                foreach (var header in httpClientConfig.DefaultRequestHeaders)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            });


            return configuration;
        }

        private static void RegisterCustomDependencies(IServiceCollection services)
        {
            services.AddScoped<ISeoService, SeoService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}