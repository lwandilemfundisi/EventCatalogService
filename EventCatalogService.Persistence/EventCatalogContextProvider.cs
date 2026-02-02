using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using XFrame.Persistence.EFCore;

namespace EventCatalogService.Persistence
{
    public class EventCatalogContextProvider : IDbContextProvider<EventCatalogContext>, IDisposable
    {
        private readonly DbContextOptions<EventCatalogContext> _options;

        public EventCatalogContextProvider(IConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<EventCatalogContext>()
                .UseSqlServer(configuration["DataConnection:Database"])
                .Options;
        }

        public EventCatalogContext CreateContext()
        {
            return new EventCatalogContext(_options);
        }

        public void Dispose()
        {
        }
    }
}
