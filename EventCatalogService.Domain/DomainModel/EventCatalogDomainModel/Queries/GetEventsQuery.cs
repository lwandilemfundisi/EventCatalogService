using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using Microservice.Framework.Domain.Queries;
using Microservice.Framework.Persistence.EFCore.Queries.CriteriaQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Queries
{
    public class GetEventsQuery
        : EFCoreCriteriaDomainQuery<Event>, IQuery<IEnumerable<Event>>
    {
        public GetEventsQuery(CategoryId categoryId)
        {
            CategoryId = categoryId;
        }

        public CategoryId CategoryId { get; }
    }

    public class GetEventsQueryHandler 
    {

    }
}
