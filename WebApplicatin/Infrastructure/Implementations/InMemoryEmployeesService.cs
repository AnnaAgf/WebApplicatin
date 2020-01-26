using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicatin.Infrastructure.Interfaces;
using WebApplicatin.Models;

namespace WebApplicatin.Infrastructure.Implementations
{
    //реализация интерфейса
    public class InMemoryEmployeesService : IEmployeesService
    {
        private readonly List<EmployeeView> _employees;
        public InMemoryEmployeesService()
        {
            _employees = new List<EmployeeView>
            {
                new EmployeeView
                {
                    Id = 1,
                    FirstName = "Petr",
                    SurName = "Petrov",
                    Skill = "A",
                    Country = "Russia",
                    Age = 30,
                    Height = 180

                },
                new EmployeeView
                {
                    Id = 2,
                    FirstName = "Max",
                    SurName = "Black",
                    Skill = "B",
                    Country = "USA",
                    Age = 31,
                    Height = 185
                },
                new EmployeeView
                {
                    Id = 3,
                    FirstName = "Juan",
                    SurName = "Salvador",
                    Skill = "C",
                    Country = "Spain",
                    Age = 32,
                    Height = 175
                }
            };
        }
        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }
        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id.Equals(id));
        }
        public void Commit()
        {
           
        }
        public void AddNew(EmployeeView model)
        {
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
