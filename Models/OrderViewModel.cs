using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outliers_E_Commerce.Models
{
    public class OrderViewModel
    {
        
    
        public string? OrderName { get; set; }

        public DateTime OrderDate { get; set; }
       
        public string? PaymentType { get; set; }
        public string? OrderStatus { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("Customer")]
        //public virtual Customer? Customer { get; set; }
        public decimal TotalAmount { get; set; }

        //OrderDetail table
        public int OrderDetailID { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        //public virtual Customer? Customer { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("Products")]
        public Double Price { get; set; }
        public int Quantity { get; set; }

    }
}
