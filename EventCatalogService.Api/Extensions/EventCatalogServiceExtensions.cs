using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using XFrame.AggregateEventPublisher;
using XFrame.Aggregates;
using XFrame.Aggregates.Commands;
using XFrame.Aggregates.Events;
using XFrame.Aggregates.Events.Serializers;
using XFrame.Aggregates.Queries;
using XFrame.AggregateStores;
using XFrame.Jobs;

namespace EventCatalogService.Api.Extensions
{
    public static class EventCatalogServiceExtensions
    {
        public static void ConfigureApplicationInfrastructure(this IServiceCollection services)
        {
            services.TryAddTransient<ICommandBus, CommandBus>();
            services.TryAddSingleton<ICommandDefinitionService, CommandDefinitionService>();
            services.TryAddTransient<IAggregateStore, AggregateStore>();
            services.TryAddTransient<IAggregateFactory, AggregateFactory>();
            services.TryAddTransient<IQueryProcessor, QueryProcessor>();
            services.TryAddSingleton<IEventDefinitionService, EventDefinitionService>();
            services.TryAddSingleton<IJobDefinitionService, JobDefinitionService>();
            services.TryAddTransient<IEventJsonSerializer, EventJsonSerializer>();
            services.TryAddTransient<IJobScheduler, InstantJobScheduler>();
            services.TryAddTransient<IJobRunner, JobRunner>();
            services.TryAddTransient<IDomainEventPublisher, DomainEventPublisher>();
            services.TryAddTransient<IDispatchToEventSubscribers, DispatchToEventSubscribers>();
            services.TryAddSingleton<IDomainEventFactory, DomainEventFactory>();
        }
    }
}
