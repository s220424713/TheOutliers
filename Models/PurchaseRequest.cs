using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outliers_E_Commerce.Models
{
    public class PurchaseRequest
    {
        [Key]
        public int RequestID { get; set; }
        public DateTime RequestDate { get; set; }
        public int Employeeid { get; set; }
        [ForeignKey("Employeeid")]
        public virtual Employee? Employee { get; set; }
        public decimal TotalAmount { get; set; }
        public string status { get; set; }
       
      

        



    }
}
