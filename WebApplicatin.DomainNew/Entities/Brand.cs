using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicatin.Domain.Entities.Base;
using WebApplicatin.Domain.Entities.Base.Interfaces;

namespace WebApplicatin.Domain.Entities
{
    [Table("Brands")]
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        // св-во. получение ссылки на товары без запросов к бд
        public virtual ICollection<Product> Product { get; set; }
    }
}
