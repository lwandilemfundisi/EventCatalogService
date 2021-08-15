using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Queries;
using Microservice.Framework.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventCatalogService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;

        public CategoryController(
            IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet("getCategories")]
        public async Task<IActionResult> Get()
        {
            var result = await _queryProcessor
                .ProcessAsync(
                new GetCategoriesQuery(),
                CancellationToken.None);

            return Ok(result);
        }
    }
}
