using System;

namespace EFTemplate.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // внешний ключ и навигационное свойство для связи с покупателем
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
