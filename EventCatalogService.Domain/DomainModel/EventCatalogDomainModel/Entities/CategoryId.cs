using Newtonsoft.Json;
using XFrame.Ids;
using XFrame.ValueObjects.SingleValueObjects;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class CategoryId : Identity<CategoryId>
    {
        public CategoryId(string value)
            : base(value)
        {
        }
    }
}
