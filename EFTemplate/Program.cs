using System;
using System.Globalization;
using System.Threading;
using EFTemplate.Data;
using EFTemplate.Demos;

namespace EFTemplate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Исключаем региональные ошибки формата дробных чисел в SQLite
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using (var db = new AppDbContext())
            {
                Console.WriteLine("Инициализация локальной базы данных Интернет-магазина...");
                DbInitializer.ResetAndSeed(db);
                Console.WriteLine("База данных 'ef_shop.db' успешно подготовлена!\n");

                // Запуск трех демонстрационных сценариев работы с EF Core
                CrudOperations.RunDemo();
                ChangeTrackerDemo.RunDemo();
                RelationshipsDemo.RunDemo();
            }

            Console.WriteLine("\nВсе демонстрационные сценарии выполнены. Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
