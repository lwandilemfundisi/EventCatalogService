using EventCatalogService.Api.Models.Dtos;
using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel;
using Microservice.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogService.Api.Mappers
{
    public class MapEventsToEventDtos
    {
        private readonly IReadOnlyCollection<Event> _events;

        public MapEventsToEventDtos(IReadOnlyCollection<Event> events)
        {
            _events = events;
        }

        public EventDtos Map()
        {
            if (_events.IsNull()) throw new ArgumentException($"Attempting to map null collection at {GetType().PrettyPrint()}");

            EventDtos eventDtos = new EventDtos();

            foreach (var evt in _events)
            {
                eventDtos.Events.Add(new MapEventToEventDto(evt).Map());
            }

            return eventDtos;
        }
    }

    public class MapEventToEventDto
    {
        private readonly Event _event;

        public MapEventToEventDto(Event evt)
        {
            _event = evt;
        }

        public EventDto Map()
        {
            if (_event.IsNull()) throw new ArgumentException($"Attempting to map null at {GetType().PrettyPrint()}");

            return new EventDto
            {
                Id = _event.Id.ToString(),
                EventName = _event.EventName,
                EventPrice = _event.Price,
                Artist = _event.Artist,
                Date = _event.Date,
                Description = _event.Description,
                ImageUrl = _event.ImageUrl,
                EventCategoryId = _event.CategoryId.ToString(),
                Show = false,
            };
        }
    }
}
