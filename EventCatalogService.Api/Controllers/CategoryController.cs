using EventCatalogService.Api.Models.RequestModels;
using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
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
        public async Task<IActionResult> GetCategories()
        {
            var result = await _queryProcessor
                .ProcessAsync(
                new GetCategoriesQuery(),
                CancellationToken.None);

            return Ok(result);
        }

        [HttpGet("getCategory/{categoryId}")]
        public async Task<IActionResult> GetCategory(string categoryId)
        {
            if (ModelState.IsValid)
            {
                var result = await _queryProcessor
                    .ProcessAsync(
                    new GetCategoryQuery(new CategoryId(categoryId)),
                    CancellationToken.None);

                return Ok(result);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
