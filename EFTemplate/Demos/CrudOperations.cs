using System;
using System.Linq;
using EFTemplate.Data;
using EFTemplate.Models;

namespace EFTemplate.Demos
{
    public static class CrudOperations
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n--- ДЕМОНСТРАЦИЯ 1: CRUD ОПЕРАЦИИ ---");

            using var db = new AppDbContext();

            //Create
            var newCustomer = new Customer { FullName = "Сергей Сидоров", Email = "serega@mail.ru" };
            db.Customers.Add(newCustomer);
            db.SaveChanges();
            Console.WriteLine($"[CREATE] Новый покупатель добавлен с Id: {newCustomer.Id}");

            //Read
            var targetId = newCustomer.Id;
            var foundCustomer = db.Customers.Find(targetId);
            Console.WriteLine($"[READ] Найден покупатель: {foundCustomer?.FullName} ({foundCustomer?.Email})");

            //Update
            if (foundCustomer != null)
            {
                foundCustomer.Email = "sidorov_updated@mail.ru";
                db.SaveChanges();
                Console.WriteLine($"[UPDATE] Новый Email для покупателя: {foundCustomer.Email}");
            }

            //Delete
            if (foundCustomer != null)
            {
                db.Customers.Remove(foundCustomer);
                db.SaveChanges();
                Console.WriteLine("[DELETE] Покупатель успешно удален из базы данных");
            }
        }
    }
}
