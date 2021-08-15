using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.ExecutionResults;
using Microservice.Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Commands
{
    public class AddEventCommad : Command<Event, EventId>
    {
        #region Constructors

        public AddEventCommad(
            EventId eventId,
            string eventName,
            int price,
            string artist,
            DateTime date,
            string description,
            string imageUrl,
            CategoryId categoryId)
            : base(eventId)
        {
            EventId = eventId;
            EventName = eventName;
            Price = price;
            Artist = artist;
            Date = date;
            Description = description;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
        }

        #endregion

        #region Properties

        public EventId EventId { get; set; }
        public string EventName { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public CategoryId CategoryId { get; set; }

        #endregion
    }

    public class AddEventCommadHandler : CommandHandler<Event, EventId, AddEventCommad>
    {
        public override Task<IExecutionResult> ExecuteAsync(
            Event aggregate, 
            AddEventCommad command, 
            CancellationToken cancellationToken)
        {
            aggregate.AddEvent(
                command.EventName,
                command.Price,
                command.Artist,
                command.Date,
                command.Description,
                command.ImageUrl,
                command.CategoryId);

            return Task.FromResult(ExecutionResult.Success());
        }
    }
}


