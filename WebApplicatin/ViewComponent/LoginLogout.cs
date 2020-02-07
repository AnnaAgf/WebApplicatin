using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicatin.ViewComponents
{
    //компонент нужен для отображения кнопок входа/выхода
    public class LoginLogout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
