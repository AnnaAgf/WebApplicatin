using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicatin.Models;
using WebApplicatin.Infrastructure;

namespace WebApplicatin.Controllers
{
    [Route("users")]

    public class EmployeesController : Controller
    {
        private readonly List<EmployeeView> _employees = new List<EmployeeView>
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

        // GET: /home/index
        [Route("all")]
        public IActionResult Index()
        {
            return View(_employees);
        }

        // GET: /home/details/{id}
        [Route("{id}")]
        [SimpleActionFilter]
        public IActionResult Details(int id)
        {
            var employee = _employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }
    }
}