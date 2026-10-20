using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EFTemplate.Data;
using EFTemplate.Models;

namespace EFTemplate.Demos
{
    public static class RelationshipsDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n    ДЕМОНСТРАЦИЯ 3: СВЯЗИ И КАСКАДНОЕ УДАЛЕНИЕ    ");

            using var db = new AppDbContext();
            var customer = new Customer
            {
                FullName = "Елена Соколова",
                Email = "elena@mail.ru",
                Profile = new CustomerProfile { DeliveryAddress = "ул. Ленина, д. 10", PhoneNumber = "+79991112233" },
                Orders = new()
                {
                    new Order { OrderDate = DateTime.Now, TotalAmount = 5500 },
                    new Order { OrderDate = DateTime.Now.AddDays(-1), TotalAmount = 12000 }
                }
            };
            db.Customers.Add(customer);
            db.SaveChanges();
            Console.WriteLine($"[СВЯЗИ] Создан главный покупатель, привязан 1 профиль и {customer.Orders.Count} заказа.");

            var profileCountBefore = db.CustomerProfiles.Count(p => p.CustomerId == customer.Id);
            var ordersCountBefore = db.Orders.Count(o => o.CustomerId == customer.Id);
            Console.WriteLine($"[БАЗА] Дочерних записей в БД перед удалением: Профилей: {profileCountBefore}, Заказов: {ordersCountBefore}");

            Console.WriteLine("[УДАЛЕНИЕ] Удаляем главного покупателя из базы...");
            db.Customers.Remove(customer);
            db.SaveChanges();

            var profileCountAfter = db.CustomerProfiles.Count(p => p.CustomerId == customer.Id);
            var ordersCountAfter = db.Orders.Count(o => o.CustomerId == customer.Id);
            Console.WriteLine($"[КАСКАДНОСТЬ] Дочерних записей после удаления: Профилей: {profileCountAfter}, Заказов: {ordersCountAfter}");
            Console.WriteLine("[РЕЗУЛЬТАТ] Каскадное удаление завершено — связанные профиль и заказы стерлись автоматически.");
        }
    }
}
