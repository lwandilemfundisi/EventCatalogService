using Microservice.Framework.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
