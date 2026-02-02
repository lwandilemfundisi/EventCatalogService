using Duende.Bff;
using EventCatalogService.Api.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;
using EventCatalogService.Domain;
using EventCatalogService.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSpaYarp();
builder.Services.AddAuthorization();
builder.Services.AddBff(o => o.ManagementBasePath = "/account")
    .AddServerSideSessions();

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
}).AddCookie(o =>
{
    o.Cookie.Name = "__Host-spa";
    o.Cookie.SameSite = SameSiteMode.Strict;
    o.Events.OnRedirectToLogin = (ctx) =>
    {
        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
})
.AddOpenIdConnect(options =>
{
    options.Authority = "https://localhost:5001";
    options.ClientId = "react";
    options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
    options.ResponseType = "code";
});

builder.Services.AddLogging(l => l.AddConsole());
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventCatalogService.Api", Version = "v1" });
});

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services
    .ConfigureApplicationInfrastructure();

builder.Services
    .ConfigureEventCatalogServiceDomain()
    .ConfigureEventCatalogPersistence();

var app = builder.Build();
app.UseBff();

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllers();
app.MapBffManagementEndpoints();
app.UseSpaYarp();


app.Run();
