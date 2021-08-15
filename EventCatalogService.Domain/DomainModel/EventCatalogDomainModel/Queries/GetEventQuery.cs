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
    public class GetEventQuery 
        : EFCoreCriteriaDomainQuery<Event>, IQuery<Event>
    {
        public GetEventQuery(EventId eventId)
        {
            Id = eventId;
        }

        protected override bool FailOnNoCriteriaSpecified => true;
    }

    public class GetEventQueryHandler
        : EFCoreCriteriaDomainQueryHandler<Event>, IQueryHandler<GetEventQuery, Event>
    {
        #region Constructors

        public GetEventQueryHandler(IPersistenceFactory persistenceFactory)
            : base(persistenceFactory)
        {
        }

        #endregion

        #region IQueryHandler Members

        public Task<Event> ExecuteQueryAsync(
            GetEventQuery query, 
            CancellationToken cancellationToken)
        {
            return Find(query);
        }

        #endregion
    }
}
