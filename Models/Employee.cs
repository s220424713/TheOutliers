using Outliers_E_Commerce.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Outliers_E_Commerce.Models
{
    public class Employee
    {
        [Key]
        public int Employeeid { get; set; }
        public string? ID { get; set; }
        [ForeignKey("ID")]
        public virtual ApplicationUser? ApplicationUser { get; set; }
        public int DepartID { get; set; }
        [ForeignKey("DepartID")]
        public virtual Departments? Departments { get; set; }

    }


}
