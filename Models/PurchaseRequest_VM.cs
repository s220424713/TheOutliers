using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outliers_E_Commerce.Models
{
    public class PurchaseRequest_VM
    {
        [Key]


        public int RequestID { get; set; }
        public DateTime RequestDate { get; set; }
        public int Employeeid { get; set; }
        [ForeignKey("Employeeid")]
        public virtual Employee? Employee { get; set; }
        public decimal TotalAmount { get; set; }
        public bool status { get; set; }

        public int PurchaseRID { get; set; }
      
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Products? Products { get; set; }
        public int Quantity { get; set; }
    }
}
