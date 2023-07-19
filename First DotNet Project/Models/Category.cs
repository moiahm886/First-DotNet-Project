using System.ComponentModel.DataAnnotations;

namespace First_DotNet_Project.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? Order { get; set; }
        [Required]
        public DateTime Ordertime { get; set; }
    }
}
