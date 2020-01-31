using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicatin.Domain.Entities;
using WebApplicatin.Domain.Filter;

namespace WebApplicatin.Infrastructure.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();

        //получаем продукты по фильтру
        IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}
