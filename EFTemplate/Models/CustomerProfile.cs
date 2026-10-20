namespace EFTemplate.Models
{
    public class CustomerProfile
    {
        public int Id { get; set; }
        public string DeliveryAddress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        //внешний ключ и навигационное свойство для связи со стороной покупателя
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
