using System.ComponentModel.DataAnnotations;
namespace entityStore.Models
{
    public class CustomerViewModel : BaseEntity
    {
        [Required]
        [MinLength(3)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string Name { get; set; }
    }
}