using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicatin.Domain.Entities.Base;
using WebApplicatin.Domain.Entities.Base.Interfaces;

namespace WebApplicatin.Domain.Entities
{
    [Table("Categories")]
    public class Category : NamedEntity, IOrderedEntity
    {
        //Родительская секция (при наличии)
        public int? ParentId { get; set; }

        public int Order { get; set; }

        // атрибут для назначения ParentId внешний ключом
        // св-во для получения по ParentId родительскую категорию
        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
