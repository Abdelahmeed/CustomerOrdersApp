using System.ComponentModel.DataAnnotations;

namespace CustomerOrdersApp.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public string CustomerId { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}
