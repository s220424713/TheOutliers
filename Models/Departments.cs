using System.ComponentModel.DataAnnotations;

namespace Outliers_E_Commerce.Models
{
    public class Departments
    {
        [Key]
        public int DepartID { get; set; }
        public string? DepName { get; set; }
        public string? Description { get; set; }
    }
}
