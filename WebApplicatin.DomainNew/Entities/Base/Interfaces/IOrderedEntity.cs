using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicatin.Domain.Entities.Base.Interfaces
{
    //порядок
    public interface IOrderedEntity
    {
        int Order { get; set; }
    }
}
