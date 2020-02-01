using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicatin.Models;

namespace WebApplicatin.Infrastructure.Interfaces
{
    public interface ISkiResortService
    {
        IEnumerable<SkiResortView> GetAll();
        SkiResortView GetById(int id);
        void Commit();
        void AddNew(SkiResortView model);
        void Delete(int id);
    }
}
