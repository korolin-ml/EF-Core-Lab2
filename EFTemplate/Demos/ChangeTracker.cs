using System;
using Microsoft.EntityFrameworkCore;
using EFTemplate.Data;
using EFTemplate.Models;

namespace EFTemplate.Demos
{
    public static class ChangeTrackerDemo
    {
        public static void RunDemo()
        {
            Console.WriteLine("\n--- ДЕМОНСТРАЦИЯ 2: CHANGE TRACKER ---");

            using var db = new AppDbContext();

            //Detached — контекст не знает про объект
            var customer = new Customer { FullName = "Дмитрий Кузнецов", Email = "dima@mail.ru" };
            Console.WriteLine($"1. Состояние после создания в памяти: {db.Entry(customer).State}");

            //Added — объект добавлен в контекст, но еще не сохранен в файл базы данных
            db.Customers.Add(customer);
            Console.WriteLine($"2. Состояние после выполнения db.Customers.Add: {db.Entry(customer).State}");

            //Unchanged — данные синхронизированы с базой данных, изменений нет
            db.SaveChanges();
            Console.WriteLine($"3. Состояние после выполнения db.SaveChanges: {db.Entry(customer).State}");

            //Modified — локальное свойство изменено, контекст зафиксировал разницу
            customer.FullName = "Дмитрий Модифицированный";
            Console.WriteLine($"4. Состояние после изменения свойства FullName: {db.Entry(customer).State}");

            //Deleted — объект запланирован на удаление из базы при следующем сохранении
            db.Customers.Remove(customer);
            Console.WriteLine($"5. Состояние после выполнения db.Customers.Remove: {db.Entry(customer).State}");

            db.SaveChanges();
        }
    }
}
