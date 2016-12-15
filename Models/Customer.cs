using System;
using System.Collections.Generic;
namespace entityStore.Models
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Orders = new List<Order>();
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Order> Orders;
    }
}