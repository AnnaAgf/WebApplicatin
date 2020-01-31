using System;
using System.Collections.Generic;
using System.Text;
using WebApplicatin.Domain.Entities.Base.Interfaces;

namespace WebApplicatin.Domain.Entities.Base
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
