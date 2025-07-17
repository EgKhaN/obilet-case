using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using oBilet.Application.Abstractions;
using oBilet.Infrastructure.Common;
using oBilet.Infrastructure.OBiletAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace oBilet.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
          this IServiceCollection services,
          ConfigurationManager config,
          ILogger logger)
        {
            services.AddScoped<IOBiletService, OBiletService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISessionService, SessionService>(); //:TODO
            services.AddSingleton<IBrowserHelper, BrowserHelper>();
            services.AddScoped<IApiService, APIService>();


            services.AddHttpClient("oBilet", (serviceProvider, httpClient) =>
            {
                var oBiletSettings = serviceProvider.GetRequiredService<IConfiguration>().GetSection("oBiletAPI");

                try //:TODO: Handle exceptions more gracefully
                {
                    httpClient.BaseAddress = new Uri(oBiletSettings["BaseUrl"]);
                    httpClient.DefaultRequestHeaders.Add("Authorization", oBiletSettings["ApiKey"]);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            });


            //string? connectionString = config.GetConnectionString("SqliteConnection");
            //Guard.Against.Null(connectionString);
            //services.AddDbContext<AppDbContext>(options =>
            // options.UseSqlite(connectionString));

            //services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
            //       .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
            //       .AddScoped<IListContributorsQueryService, ListContributorsQueryService>()
            //       .AddScoped<IDeleteContributorService, DeleteContributorService>();


            //logger.LogInformation("{Project} services registered", "Infrastructure");

            return services;
        }
    }
}
