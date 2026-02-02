using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XFrame.Aggregates.Queries;
using XFrame.Persistence;
using XFrame.Persistence.EFCore.Queries.CriteriaQueries;
using XFrame.Persistence.EFCore.Queries.Filtering;

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
