using oBilet.Infrastructure;

namespace oBilet.Presentation.Configs
{
    public static class ServiceConfigs
    {
        public static IServiceCollection AddServiceConfigs(this IServiceCollection services, Microsoft.Extensions.Logging.ILogger logger, WebApplicationBuilder builder)
        {
            services.AddInfrastructureServices(builder.Configuration, logger);

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true; // Ensures the session cookie is accessible only by the server
                options.Cookie.IsEssential = true; // Required for GDPR compliance
            });

            //if (builder.Environment.IsDevelopment())
            //{
            //    // Use a local test email server
            //    // See: https://ardalis.com/configuring-a-local-test-email-server/
            //    services.AddScoped<IEmailSender, MimeKitEmailSender>();

            //    // Otherwise use this:
            //    //builder.Services.AddScoped<IEmailSender, FakeEmailSender>();

            //}
            //else
            //{
            //    services.AddScoped<IEmailSender, MimeKitEmailSender>();
            //}

            //logger.LogInformation("{Project} services registered", "Mediatr and Email Sender");

            return services;
        }
    }
}
