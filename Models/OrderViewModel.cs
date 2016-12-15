using System;
namespace entityStore.Models
{
    public class OrderViewModel : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}