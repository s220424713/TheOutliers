using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Outliers_E_Commerce.Areas.Identity.Data;
using Outliers_E_Commerce.Models;

namespace Outliers_E_Commerce.Areas.Identity.Data;

public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
    {

    }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        builder.Entity<IdentityRole>().HasData(new IdentityRole

        {
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole
        {
            Name = "Customer",
            NormalizedName = "CUSTOMER"
        },
        new IdentityRole
        {
            Name = "DepartmentEmployee",
            NormalizedName = "DEPARTMENTEMPLOYEE"
        },
       
        new IdentityRole
        {
            Name = "SalesEmployee",
            NormalizedName = "SALESEMPLOYEE"
        }
        );

    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);

        }

    }
    public DbSet<Products> tblProduct { get; set; }
    public DbSet<Category> tblCategory { get; set; }
    public DbSet<SalesOrder> SaleOrders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
 
    public DbSet<Employee>? Employee { get; set; }
    public DbSet<PurchaseRequest>purchaseRequests { get; set; }
    public DbSet<Outliers_E_Commerce.Models.PurchaseRequest_VM>? PurchaseRequest_VM { get; set; }
    public DbSet<Outliers_E_Commerce.Models.Supplier>? Supplier { get; set; }
    public DbSet<Departments>? Departments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderViewModel> OrderViewmodels { get; set; }
   



}

