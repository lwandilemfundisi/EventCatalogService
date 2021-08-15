using EventCatalogService.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogService.Persistence
{
    public class EventCatalogContext : DbContext
    {
        public EventCatalogContext(DbContextOptions<EventCatalogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.EventCatalogModelMap();
        }
    }
}
