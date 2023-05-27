using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outliers_E_Commerce.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Customer? Customer { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("Products")]
        public Double Price { get; set; }
        public int Quantity { get; set; }





    }
}
