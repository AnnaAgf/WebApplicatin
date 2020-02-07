using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicatin.Models;
using WebApplicatin.Infrastructure;
using WebApplicatin.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicatin.Controllers
{
    [Route("users")]
    [Authorize]

    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;

        //внедрение зависимости - Depend.Injection
        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
       

        // GET: /home/index
        [Route("all")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_employeesService.GetAll());
        }

        // GET: /home/details/{id}
        [Route("{id}")]
        //[SimpleActionFilter]
        public IActionResult Details(int id)
        {
            var employee = _employeesService.GetById(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }
        [HttpGet]
        [Route("edit/{id?}")]
        [Authorize(Roles ="Admin")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new EmployeeView());

            EmployeeView model = _employeesService.GetById(id.Value);
            if (model == null)
                return NotFound();

            return View(model);
        }
        [HttpPost]
        [Route("edit/{id?}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(EmployeeView model)
        {
            //добавление своей валидации
            if (model.Age < 18 || model.Age > 50)
            {
                ModelState.AddModelError("Age", "Ошибка возраста");
            }

            //добавление валидации
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id > 0)
            {
                var dbItem = _employeesService.GetById(model.Id);
                
                if (ReferenceEquals(dbItem, null))
                    return NotFound();// возвращаем результат 404 Not Found

                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Country = model.Country;
                dbItem.Skill = model.Skill;
            }
            else // иначе добавляем модель в список
            {
                _employeesService.AddNew(model);
            }
            _employeesService.Commit(); // станет актуальным позднее (когда добавим БД)

            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _employeesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}