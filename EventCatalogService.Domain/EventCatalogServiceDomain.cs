using Microservice.Framework.Domain;
using Microservice.Framework.Domain.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventCatalogService.Domain
{
    public static class EventCatalogServiceDomain
    {
        public static Assembly Assembly { get; } = typeof(EventCatalogServiceDomain).Assembly;

        public static IDomainContainer ConfigureEventCatalogServiceDomain(
            this IServiceCollection services)
        {
            return DomainContainer.New(services)
                .AddDefaults(Assembly);
        }
    }
}
