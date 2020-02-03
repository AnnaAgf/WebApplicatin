using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicatin.Infrastructure.Interfaces;
using WebApplicatin.Models;

namespace WebApplicatin.ViewComponents
{
    //[ViewComponent(Name = "Brands")]
    public class BrandsViewComponent : ViewComponent
    {
        // 1.наследование от ViewComponent
        // 2. метод Invoke()
        // атрибут с именем для обращения к этому компоненту в разметке

        private readonly IProductService _productService;
        public BrandsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = GetBrands();
            return View(brands);
        }

        private List<BrandViewModel> GetBrands()
        {
            //получение бренда из сервиса
            var brands = _productService.GetBrands();
            return brands.Select(b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Order = b.Order,
                ProductsCount = 0
            }).OrderBy(b => b.Order).ToList();
        }
    }
}
