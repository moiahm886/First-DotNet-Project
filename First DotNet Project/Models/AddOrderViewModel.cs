using System.ComponentModel.DataAnnotations;

namespace First_DotNet_Project.Models
{
    public class AddOrderViewModel
    {
        public string? Name { get; set; }
        public int? Order { get; set; }
        public DateTime Ordertime { get; set; } = DateTime.Now;
    }
}
