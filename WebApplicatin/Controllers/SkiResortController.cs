using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicatin.Models;
using WebApplicatin.Infrastructure;
using WebApplicatin.Infrastructure.Interfaces;

namespace WebApplicatin.Controllers
{
    [Route("skiresort")]
    public class SkiResortController : Controller
    {
        private readonly ISkiResortService _skiResortService;
        
        //внедрение зависимости - Depend.Injection
        public SkiResortController(ISkiResortService skiResortService)
        {
            _skiResortService = skiResortService;
        }


        // GET: /home/index
        [Route("all")]
        public IActionResult Index()
        {
            return View(_skiResortService.GetAll());
        }

        // GET: /home/details/{id}
        [Route("{id}")]
        public IActionResult Details(int id)
        {
            var skiResort = _skiResortService.GetById(id);
            if (skiResort == null)
                return NotFound();

            return View(skiResort);
        }

        [HttpGet]
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new SkiResortView());

            SkiResortView model = _skiResortService.GetById(id.Value);
            if (model == null)
                return NotFound();

            return View(model);
        }
        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(SkiResortView model)
        {
            if (model.Id > 0)
            {
                var dbItem = _skiResortService.GetById(model.Id);

                if (ReferenceEquals(dbItem, null))
                    return NotFound();

                dbItem.Name = model.Name;
                dbItem.PathLenght = model.PathLenght;
                dbItem.Height = model.Height;
                dbItem.Country = model.Country;
            }
            else
            {
                _skiResortService.AddNew(model);
            }
            _skiResortService.Commit();

            return RedirectToAction(nameof(Index));
        }

        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _skiResortService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}