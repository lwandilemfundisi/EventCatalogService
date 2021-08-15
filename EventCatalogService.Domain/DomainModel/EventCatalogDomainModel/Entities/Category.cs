using Microservice.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities
{
    public class Category : Entity<CategoryId>
    {
        #region Properties

        public string CategoryName { get; set; }

        #endregion
    }
}
