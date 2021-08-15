using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel;
using EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities;
using EventCatalogService.Persistence.ValueObjectConverters;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogService.Persistence.Mappings
{
    public static class EventCatalogModelMapping
    {
        public static ModelBuilder EventCatalogModelMap(this ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<Event>()
            .Property(o => o.Id)
            .HasConversion(new SingleValueObjectIdentityValueConverter<EventId>());

            modelBuilder
            .Entity<Event>()
            .Property(o => o.CategoryId)
            .HasConversion(new SingleValueObjectIdentityValueConverter<CategoryId>());

            modelBuilder
            .Entity<Category>()
            .Property(o => o.Id)
            .HasConversion(new SingleValueObjectIdentityValueConverter<CategoryId>());

            modelBuilder
                .Entity<Event>()
                .HasOne<Category>()
                .WithMany();

            return modelBuilder;
        }
    }
}
