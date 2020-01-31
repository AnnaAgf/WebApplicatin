using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicatin.Controllers
{
    public class NotFoundErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}