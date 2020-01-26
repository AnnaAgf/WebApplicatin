using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicatin.Infrastructure.Interfaces;
using WebApplicatin.Models;

namespace WebApplicatin.Infrastructure.Implementations
{
    public class InMemorySkiResortService : ISkiResortService
    {
        public readonly List<SkiResortView> _skiResort;
        public InMemorySkiResortService()
        {
            _skiResort = new List<SkiResortView>
            {
                new SkiResortView
                {
                    Id = 1,
                    Name = "BigWood",
                    Country = "Russia",
                    Height = 1100,
                    PathLenght = 30
                },
                new SkiResortView
                {
                    Id = 2,
                    Name = "Gesh",
                    Country = "Russia",
                    Height = 1500,
                    PathLenght = 15
                },
                new SkiResortView
                {
                    Id = 3,
                    Name = "Elbrus",
                    Country = "Russia",
                    Height = 3800,
                    PathLenght = 10
                }
            };
        }

            public IEnumerable<SkiResortView> GetAll()
            {
                return _skiResort;
            }
            public SkiResortView GetById(int id)
            {
                return _skiResort.FirstOrDefault(e => e.Id.Equals(id));
            }
            public void Commit()
            {

            }
            public void AddNew(SkiResortView model)
            {
                model.Id = _skiResort.Max(e => e.Id) + 1;
                _skiResort.Add(model);
            }
            public void Delete(int id)
            {
                var skiResort = GetById(id);
                if (skiResort != null)
                {
                    _skiResort.Remove(skiResort);
                }
            }
    }
}
