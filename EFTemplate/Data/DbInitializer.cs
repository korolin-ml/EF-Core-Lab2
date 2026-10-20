using System;
using System.Collections.Generic;
using EFTemplate.Models;

namespace EFTemplate.Data
{
    public static class DbInitializer
    {
        public static void ResetAndSeed(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var customers = new List<Customer>
            {
                new() { FullName = "Иван Иванов", Email = "ivan@mail.ru" },
                new() { FullName = "Анна Анновна", Email = "anna@mail.ru" }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
