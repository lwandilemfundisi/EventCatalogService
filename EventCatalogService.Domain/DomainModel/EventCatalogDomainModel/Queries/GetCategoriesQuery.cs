using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XFrame.Aggregates.Queries;
using XFrame.Persistence;
using XFrame.Persistence.EFCore.Queries.CriteriaQueries;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Queries
{
    public class GetCategoriesQuery
        : EFCoreCriteriaDomainQuery<Category>, IQuery<IEnumerable<Category>>
    {
    }

    public class GetCategoriesQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Category>, IQueryHandler<GetCategoriesQuery, IEnumerable<Category>>
    {
        #region Constructors

        public GetCategoriesQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        #endregion

        #region IQueryHandler Members

        public Task<IEnumerable<Category>> ExecuteQueryAsync(
            GetCategoriesQuery query,
            CancellationToken cancellationToken)
        {
            return FindAll(query);
        }

        #endregion
    }
}
