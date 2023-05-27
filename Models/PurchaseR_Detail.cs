using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outliers_E_Commerce.Models
{
    public class PurchaseR_Detail
    {
        [Key]

        public int PurchaseRID { get; set; }
        public int RequestID { get; set; }
        [ForeignKey("RequestID")]
        public virtual PurchaseRequest? PurchaseRequest { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Products? Products { get; set; }
        public int Quantity { get; set; }
    }
}
