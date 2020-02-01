using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplicatin.Domain.Filter
{
    //класс для фильтрации товаров
    public class ProductFilter
    {
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
