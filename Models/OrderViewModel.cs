using System.ComponentModel.DataAnnotations;
using System;
namespace entityStore.Models
{
    public class OrderViewModel : BaseEntity
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
    }
}