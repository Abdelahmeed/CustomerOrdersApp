using System.ComponentModel.DataAnnotations;

namespace CustomerOrdersApp.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int OrderId { get; set; }
    }
}
