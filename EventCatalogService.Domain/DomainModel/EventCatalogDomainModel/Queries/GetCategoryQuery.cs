using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using System.Threading;
using System.Threading.Tasks;
using XFrame.Aggregates.Queries;
using XFrame.Persistence;
using XFrame.Persistence.EFCore.Queries.CriteriaQueries;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Queries
{
    public class GetCategoryQuery
        : EFCoreCriteriaDomainQuery<Category>, IQuery<Category>
    {
        public GetCategoryQuery(CategoryId categoryId)
        {
            Id = categoryId;
        }

        protected override bool FailOnNoCriteriaSpecified => true;
    }

    public class GetCategoryQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Category>, IQueryHandler<GetCategoryQuery, Category>
    {
        #region Constructors

        public GetCategoryQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        #endregion

        #region IQueryHandler Members

        public Task<Category> ExecuteQueryAsync(
            GetCategoryQuery query, 
            CancellationToken cancellationToken)
        {
            return Find(query);
        }

        #endregion
    }
}
