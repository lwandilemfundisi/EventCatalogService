using XFrame.Aggregates.Entities;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities
{
    public class Category : Entity<CategoryId>
    {
        #region Properties

        public string CategoryName { get; set; }

        #endregion
    }
}
