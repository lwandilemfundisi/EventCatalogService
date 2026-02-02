using Newtonsoft.Json;
using XFrame.Ids;
using XFrame.ValueObjects.SingleValueObjects;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class EventId : Identity<EventId>
    {
        public EventId(string value)
            : base(value)
        {
        }
    }
}
