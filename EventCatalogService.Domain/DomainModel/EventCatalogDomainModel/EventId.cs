using Microservice.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel
{
    public class EventId : Identity<EventId>
    {
        public EventId(string value)
            : base(value)
        {
        }
    }
}
