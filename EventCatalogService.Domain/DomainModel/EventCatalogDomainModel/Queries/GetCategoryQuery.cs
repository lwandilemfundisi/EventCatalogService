using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using Microservice.Framework.Domain.Queries;
using Microservice.Framework.Persistence;
using Microservice.Framework.Persistence.EFCore.Queries.CriteriaQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
