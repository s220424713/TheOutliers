using System.ComponentModel.DataAnnotations;

namespace Outliers_E_Commerce.Models
{
    public class Category
    {
        [Key]
        public int Categoryid { get; set; }
        public string? CategoryName { get; set; }
        
    }
}
