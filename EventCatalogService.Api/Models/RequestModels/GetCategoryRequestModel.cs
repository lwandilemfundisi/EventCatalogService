using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogService.Api.Models.RequestModels
{
    public class GetCategoryRequestModel
    {
        public CategoryId CategoryId { get; set; }
    }
}
