using System;
using System.Collections.Generic;

namespace EventCatalogService.Api.Models.Dtos
{
    public class EventDto
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public decimal EventPrice { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string EventCategoryId { get; set; }
        public bool Show { get; set; }
    }

    public class EventDtos
    {
        public EventDtos()
        {
            Events = new List<EventDto>();
        }

        public IList<EventDto> Events { get; set; }
    }
}
