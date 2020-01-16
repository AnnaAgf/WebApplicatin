using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<EmployeeView> _employees = new List<EmployeeView>
        {
            new EmployeeView
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Patronymic = "Иванович",
                Age = 22
            },
            new EmployeeView
            {
                Id = 2,
                FirstName = "Владислав",
                SurName = "Петров",
                Patronymic = "Иванович",
                Age = 35
            }
        };

        // GET: /
        // GET: /home/
        // GET: /home/index
        public IActionResult Index()
        {
            return View(_employees);
            //return Content("Hello from controller");
        }

        // GET: /home/details/{id}
        public IActionResult Details(int id)
        {
            var employee = _employees.FirstOrDefault(x => x.Id == id);

            //Если такого не существует
            if (employee == null)
                return NotFound(); // возвращаем результат 404 Not Found

            return View(employee);
        }

    }
}
