using EventCatalogService.Api.Extensions;
using EventCatalogService.Domain;
using EventCatalogService.Persistence.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace EventCatalogService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "enableCors",
                    builder =>
                    {
                        builder
                        .WithOrigins("http://localhost:8081")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });

            services.AddSingleton(_ => Configuration);
            services.AddLogging(l => l.AddConsole());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventCatalogService.Api", Version = "v1" });
            });

            //services
            //    .AddControllers(configure => 
            //    {
            //        configure.Filters.Add(
            //            new AuthorizeFilter(
            //                new AuthorizationPolicyBuilder()
            //                .RequireAuthenticatedUser()
            //                .Build()));
            //    })
            services
                .AddControllers()
                .AddNewtonsoftJson();

            services
                .ConfigureApplicationInfrastructure();

            services
                .ConfigureEventCatalogServiceDomain()
                .ConfigureEventCatalogPersistence();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(opts =>
            //    {
            //        opts.Authority = Configuration["Auth:Authority"];
            //        opts.Audience = Configuration["Auth:Audience"];
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventCatalogService.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("enableCors");

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
