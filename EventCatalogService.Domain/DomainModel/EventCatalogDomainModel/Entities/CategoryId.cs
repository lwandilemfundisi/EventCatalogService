using Microservice.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCatalogService.Domain.DomainModel.EventCatalogDomainModel.Entities
{
    public class CategoryId : Identity<CategoryId>
    {
        public CategoryId(string value)
            : base(value)
        {
        }
    }
}
