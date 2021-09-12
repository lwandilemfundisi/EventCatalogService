using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel;
using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using EventCatalogService.Persistence;
using Microservice.Framework.Common;
using Microservice.Framework.Domain.Aggregates;
using Microservice.Framework.Persistence.EFCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EventId = EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.EventId;

namespace EventCatalogService.Api
{
    public class Program
    {
        private static IAggregateStore _aggregateStore;

        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                _aggregateStore = scope.ServiceProvider.GetRequiredService<IAggregateStore>();

                var db = scope.ServiceProvider.GetRequiredService<IDbContextProvider<EventCatalogContext>>();
                db.CreateContext().Database.Migrate();

                //await Task.WhenAll(Events.GetEvents().Select(AddEventsAsync));
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private async static Task UpdateAsync<TAggregate, TIdentity>(TIdentity id, Action<TAggregate> action)
            where TAggregate : class, IAggregateRoot<TIdentity>
            where TIdentity : IIdentity
        {
            await _aggregateStore.UpdateAsync<TAggregate, TIdentity>(
                id,
                SourceId.New,
                (a, c) =>
                {
                    action(a);
                    return Task.FromResult(0);
                },
                CancellationToken.None);
        }

        public static Task AddEventsAsync(EventDto1 eventDto)
        {
            return UpdateAsync<Event, EventId>(EventId.New, a => a.AddEvent(
                eventDto.EventName,
                eventDto.Price,
                eventDto.Artist,
                eventDto.Date,
                eventDto.Description,
                eventDto.ImageUrl,
                eventDto.CategoryId));
        }
    }

    public class EventDto1
    {
        public string EventName { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public CategoryId CategoryId { get; set; }
    }

    public class Events
    {
        public static EventDto1 EventDto1 = new EventDto1
        {
            EventName = "John Egbert Live",
            Price = 65,
            Artist = "John Egbert",
            Date = new DateTime(2021, 3, 9, 17, 47, 1, 36, DateTimeKind.Local).AddTicks(9024),
            Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
            CategoryId = new CategoryId("category-6313179f-7837-473a-a4d5-a5571b43e6a6")
        };

        public static EventDto1 EventDto2 = new EventDto1
        {
            EventName = "The State of Affairs: Michael Live!",
            Price = 85,
            Artist = "Michael Johnson",
            Date = new DateTime(2021, 6, 9, 17, 47, 1, 40, DateTimeKind.Local).AddTicks(2916),
            Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
            CategoryId = new CategoryId("category-6313179f-7837-473a-a4d5-a5571b43e6a6")
        };

        public static EventDto1 EventDto3 = new EventDto1
        {
            EventName = "Clash of the DJs",
            Price = 85,
            Artist = "DJ 'The Mike'",
            Date = new DateTime(2021, 1, 9, 17, 47, 1, 40, DateTimeKind.Local).AddTicks(3072),
            Description = "DJs from all over the world will compete in this epic battle for eternal fame.",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
            CategoryId = new CategoryId("category-6313179f-7837-473a-a4d5-a5571b43e6a6")
        };

        public static EventDto1 EventDto4 = new EventDto1
        {
            EventName = "Spanish guitar hits with Manuel",
            Price = 25,
            Artist = "Manuel Santinonisi",
            Date = new DateTime(2021, 1, 9, 17, 47, 1, 40, DateTimeKind.Local).AddTicks(3112),
            Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
            CategoryId = new CategoryId("category-6313179f-7837-473a-a4d5-a5571b43e6a6")
        };

        public static EventDto1 EventDto5 = new EventDto1
        {
            EventName = "To the Moon and Back",
            Price = 135,
            Artist = "Nick Sailor",
            Date = new DateTime(2021, 5, 9, 17, 47, 1, 40, DateTimeKind.Local).AddTicks(3256),
            Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
            CategoryId = new CategoryId("category-6313179f-7837-473a-a4d5-a5571b43e6a6")
        };

        public static EventDto1 EventDto6 = new EventDto1
        {
            EventName = "Techorama 2021",
            Price = 400,
            Artist = "Many",
            Date = new DateTime(2021, 7, 9, 17, 47, 1, 40, DateTimeKind.Local).AddTicks(3208),
            Description = "The best tech conference in the world",
            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
            CategoryId = new CategoryId("category-6313179f-7837-473a-a4d5-a5571b43e6a6")
        };

        public static IEnumerable<EventDto1> GetEvents()
        {
            var fieldInfos = typeof(Events).GetFields(BindingFlags.Public | BindingFlags.Static);
            return fieldInfos.Select(fi => (EventDto1)fi.GetValue(null));
        }
    }
}