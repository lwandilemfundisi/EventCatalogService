using System.Threading;
using System.Threading.Tasks;
using XFrame.Aggregates.Queries;
using XFrame.Persistence;
using XFrame.Persistence.EFCore.Queries.CriteriaQueries;

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
