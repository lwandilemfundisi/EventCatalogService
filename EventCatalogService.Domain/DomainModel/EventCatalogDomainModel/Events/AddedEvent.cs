using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using Microservice.Framework.Domain.Events;
using Microservice.Framework.Domain.Events.AggregateEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Events
{
    [EventVersion("AddedEvent", 1)]
    public class AddedEvent : AggregateEvent<Event, EventId>
    {
        public AddedEvent(
            string eventName, 
            int price, 
            string artist, 
            DateTime date, 
            string description, 
            string imageUrl, 
            CategoryId categoryId)
        {
            EventName = eventName;
            Price = price;
            Artist = artist;
            Date = date;
            Description = description;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
        }

        public string EventName { get; }
        public int Price { get; }
        public string Artist { get; }
        public DateTime Date { get; }
        public string Description { get; }
        public string ImageUrl { get; }
        public CategoryId CategoryId { get; }
    }
}
