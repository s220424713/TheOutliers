using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Outliers_E_Commerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [DisplayName("Customer Address")]
        public string CustomerAddress { get; set; }
        [Required]
        [DisplayName("Email Address")]
        public string CustomerEmail { get; set; }

    }
}
