using Microsoft.EntityFrameworkCore;
using CustomerManagementApi.Models;

namespace CustomerManagementApi.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerType> CustomerTypes { get; set; }
    public DbSet<CustomerStatus> CustomerStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Customer>()
        .HasIndex(c => c.CPF)
        .IsUnique();

      modelBuilder.Entity<Customer>()
        .Property(c => c.Gender)
        .HasMaxLength(1)
        .IsRequired();

      modelBuilder.Entity<Customer>()
        .HasCheckConstraint("CK_Customer_Gender", "Gender IN ('M', 'F')");

      modelBuilder.Entity<CustomerStatus>().HasData(
        new CustomerStatus { Id = 1, Description = "Active" },
        new CustomerStatus { Id = 2, Description = "Deactivated" }
      );

      modelBuilder.Entity<CustomerType>().HasData(
        new CustomerType { Id = 1, Description = "International" },
        new CustomerType { Id = 2, Description = "National" }
      );

      base.OnModelCreating(modelBuilder);
    }
  }
}
