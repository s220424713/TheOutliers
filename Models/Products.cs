using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outliers_E_Commerce.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? Discription { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public int Categoryid { get; set; }
        [ForeignKey("Categoryid")]
        public virtual Category? Category { get; set; }
        public double Price { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageType { get; set; }
        public int Supplierid { get; set; }
        [ForeignKey("Supplierid")]
        public virtual Supplier? Supplier { get; set; }

    }
}
        