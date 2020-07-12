using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CH10_DividendCalendar.Repository;
using CH10_DividendCalendar.Security.Authentication;
using CH10_DividendCalendar.Security.Authorisation;
using CH10_DividendCalendar.Swagger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CH10_DividendCalendar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(RAML.WebApiExplorer.ApiExplorerDataFilter));
               services.AddControllersWithViews(options => {
                   options.Filters.AddService(typeof(RAML.WebApiExplorer.ApiExplorerDataFilter));
                   options.Conventions.Add(new RAML.WebApiExplorer.ApiExplorerVisibilityEnabledConvention());
                   options.Conventions.Add(new RAML.WebApiExplorer.ApiExplorerVisibilityDisabledConvention(typeof(RAML.WebApiExplorer.RamlController)));
               });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
            }).AddApiKeySupport(options => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.Internal, policy => policy.Requirements.Add(new InternalRequirement()));
                options.AddPolicy(Policies.External, policy => policy.Requirements.Add(new ExternalRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, InternalAuthorisationHandler>();
            services.AddSingleton<IAuthorizationHandler, ExternalAuthorisationHandler>();

            services.AddSingleton<IRepository, InMemoryRepository>();

            services.AddRouting(x => x.LowercaseUrls = true);
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            //services.ConfigureSwaggerFeature();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "JOS.ApiKeyAuthentication");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}