using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using XFrame.Aggregates.Commands.Extensions;
using XFrame.Aggregates.EventMetadata.Extentions;
using XFrame.Aggregates.Events.Extensions;
using XFrame.Aggregates.Queries.Extensions;
using XFrame.DomainContainers;

namespace EventCatalogService.Domain
{
    public static class EventCatalogServiceDomain
    {
        public static Assembly Assembly { get; } = typeof(EventCatalogServiceDomain).Assembly;

        public static IDomainContainer ConfigureEventCatalogServiceDomain(
            this IServiceCollection services)
        {
            return DomainContainer.New(services)
                .AddEvents(Assembly, null)
                .AddCommands(Assembly, null)
                .AddCommandHandlers(Assembly, null)
                .AddQueries(Assembly, null)
                .AddQueryHandlers(Assembly, null)
                .AddMetadataProviders(Assembly, null);
        }
    }
}
