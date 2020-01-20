using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicatin.Models;

namespace WebApplicatin.Controllers
{
    public class SkiResortController : Controller
    {
        private readonly List<SkiResortView> _skiResorts = new List<SkiResortView>
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

        // GET: /home/index
        public IActionResult Index()
        {
            return View(_skiResorts);
        }

        // GET: /home/details/{id}
        public IActionResult Details(int id)
        {
            var skiResort = _skiResorts.FirstOrDefault(x => x.Id == id);
            if (skiResort == null)
                return NotFound();

            return View(skiResort);
        }
    }
}