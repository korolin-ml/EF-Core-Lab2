using System.Collections.Generic;

namespace EFTemplate.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public CustomerProfile? Profile { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
