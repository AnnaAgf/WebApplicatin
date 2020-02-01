using System;
using System.Collections.Generic;
using System.Text;
using WebApplicatin.Domain.Entities.Base;
using WebApplicatin.Domain.Entities.Base.Interfaces;

namespace WebApplicatin.Domain.Entities
{
    public class Category : NamedEntity, IOrderedEntity
    {
        //Родительская секция (при наличии)
        public int? ParentId { get; set; }

        public int Order { get; set; }
    }
}
