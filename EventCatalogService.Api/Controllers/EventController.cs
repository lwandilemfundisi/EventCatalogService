using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Queries;
using Microservice.Framework.Domain.Commands;
using Microservice.Framework.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventDomain = EventCatalogService.Domain.DomainModel.EventCatalogDomainModel;

namespace EventCatalogService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryProcessor _queryProcessor;

        public EventController(
            ICommandBus commandBus,
            IQueryProcessor queryProcessor)
        {
            _commandBus = commandBus;
            _queryProcessor = queryProcessor;
        }

        [HttpGet("getEvents/{categoryId}")]
        public async Task<IActionResult> GetEvents(string categoryId)
        {
            var result = await _queryProcessor
                .ProcessAsync(
                new GetEventsQuery(new CategoryId(categoryId)), 
                CancellationToken.None);

            return Ok(result);
        }

        [HttpGet("getEvent/{eventId}")]
        public async Task<IActionResult> GetEventsById(string eventId)
        {
            var result = await _queryProcessor
                .ProcessAsync(
                new GetEventQuery(new EventDomain.EventId(eventId)),
                CancellationToken.None);

            return Ok(result);
        }
    }
}
