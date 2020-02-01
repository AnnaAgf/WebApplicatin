using System;
using Microsoft.EntityFrameworkCore;
using WebApplicatin.Domain.Entities;

namespace WebApplicatin.DAL
{
    // класс, отвечающий за подключение к бд
    public class WebApplicatinContext : DbContext
    {
        //конструктор
        public WebApplicatinContext(DbContextOptions options) : base(options)
        {
            
        }
        // для создания таблиц для сущностей и связвание со списками этих сущностей
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }

    }
}
