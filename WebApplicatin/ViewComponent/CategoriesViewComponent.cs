using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicatin.Infrastructure.Interfaces;
using WebApplicatin.Models;

namespace WebApplicatin.ViewComponents
{
    // 1.наследование от ViewComponent
    // 2. метод Invoke()
    // атрибут с именем для обращения к этому компоненту в разметке
    [ViewComponent(Name ="Cats")]
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        //конструктор
        public CategoriesViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = GetCategories();
            return View(categories);
        }
        private List<CategoryViewModel> GetCategories()
        {
            //получение категорий из сервиса
            var categories = _productService.GetCategories();

            var parentSections = categories.Where(p => !p.ParentId.HasValue).ToArray();
            var parentCategories = new List<CategoryViewModel>();
            // получим и заполним родительские категории
            foreach (var parentCategory in parentSections)
            {
                parentCategories.Add(new CategoryViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentCategory = null
                });
            }
            // получим и заполним дочерние категории
            foreach (var CategoryViewModel in parentCategories)
            {
                var childCategories = categories.Where(c => c.ParentId == CategoryViewModel.Id);
                foreach (var childCategory in childCategories)
                {
                    CategoryViewModel.ChildCategories.Add(new CategoryViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentCategory = CategoryViewModel
                    });
                }
                CategoryViewModel.ChildCategories = CategoryViewModel.ChildCategories.OrderBy(c => c.Order).ToList();
            }

            parentCategories = parentCategories.OrderBy(c => c.Order).ToList();
            return parentCategories;
        }
    }
}
