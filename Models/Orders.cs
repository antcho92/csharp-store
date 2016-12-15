using System;
namespace entityStore.Models
{
    public class Order : BaseEntity
    {  
       public int OrderId { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}