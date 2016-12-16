using System.ComponentModel.DataAnnotations;
using System;
namespace entityStore.Models
{
    public class ProductViewModel : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [RegularExpression(@"^\w+[\s-]?\w+$")]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}