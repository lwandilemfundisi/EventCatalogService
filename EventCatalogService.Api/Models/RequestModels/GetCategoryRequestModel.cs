using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;

namespace EventCatalogService.Api.Models.RequestModels
{
    public class GetCategoryRequestModel
    {
        public CategoryId CategoryId { get; set; }
    }
}
