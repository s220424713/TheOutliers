using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outliers_E_Commerce.Models
{
    public class SalesOrder
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [DisplayName("Order Name")]
        public string? OrderName { get; set; }
        [Required]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayName("Payment Type")]
        public string?PaymentType { get; set; }

        [DisplayName("Order Status")]
        public string? OrderStatus { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("Customer")]
        public virtual Customer? Customer { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
