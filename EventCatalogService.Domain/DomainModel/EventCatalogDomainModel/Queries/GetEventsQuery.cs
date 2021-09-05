using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using Microservice.Framework.Domain.Queries;
using Microservice.Framework.Persistence;
using Microservice.Framework.Persistence.EFCore.Queries.CriteriaQueries;
using Microservice.Framework.Persistence.EFCore.Queries.Filtering;
using Microservice.Framework.Persistence.Extensions;
using Microservice.Framework.Persistence.Queries.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        protected override void OnBuildDomainCriteria(EFCoreDomainCriteria domainCriteria)
        {
        }
    }

    public class GetEventsQueryHandler 
        : EFCoreCriteriaDomainQueryHandler<Event>, IQueryHandler<GetEventsQuery, IEnumerable<Event>>
    {
        #region Constructors

        public GetEventsQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        #endregion

        #region IQueryHandler Members

        public Task<IEnumerable<Event>> ExecuteQueryAsync(
            GetEventsQuery query,
            CancellationToken cancellationToken)
        {
            return FindAll(query);
        }

        #endregion
    }
}
