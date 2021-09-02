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
