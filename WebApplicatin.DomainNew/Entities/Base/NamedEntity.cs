using System;
using System.Collections.Generic;
using System.Text;
using WebApplicatin.Domain.Entities.Base.Interfaces;

namespace WebApplicatin.Domain.Entities.Base
{
    public class NamedEntity : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
