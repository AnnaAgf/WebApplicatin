using System;
using System.Collections.Generic;
using System.Text;
using WebApplicatin.Domain.Entities.Base;
using WebApplicatin.Domain.Entities.Base.Interfaces;

namespace WebApplicatin.Domain.Entities
{
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
