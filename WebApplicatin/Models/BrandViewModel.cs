using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicatin.Domain.Entities.Base.Interfaces;

namespace WebApplicatin.Models
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int ProductsCount { get; set; }
    }
}
