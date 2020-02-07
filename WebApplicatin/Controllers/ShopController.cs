using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicatin.Domain.Filter;
using WebApplicatin.Infrastructure;
using WebApplicatin.Infrastructure.Interfaces;
using WebApplicatin.Models;


namespace WebApplicatin.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int? categoryId, int? brandId)
        {
            // получаем список отфильтрованных продуктов
            // создаем экз. класса на осн. полученных параметров
            var products = _productService.GetProducts(
                new ProductFilter { BrandId = brandId, CategoryId = categoryId });

            // сконвертируем в ShopViewModel 
            var model = new ShopViewModel()
            {
                BrandId = brandId,
                CategoryId = categoryId,
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price
                }).OrderBy(p => p.Order).ToList()
            };
            //для передачи модели во view
            return View(model);
        }
        public IActionResult ProductDetails()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        
    }
}