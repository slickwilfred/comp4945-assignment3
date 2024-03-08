using System.Data.Entity;

namespace WebApplication3.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // many-to-many relationship between Service and Customer
            modelBuilder.Entity<Service>()
                .HasMany<Customer>(s => s.Customers)
                .WithMany(c => c.Services)
                .Map(cs =>
                {
                    cs.MapLeftKey("ServiceId");
                    cs.MapRightKey("CustomerId");
                    cs.ToTable("ServiceCustomer");
                });
                
            base.OnModelCreating(modelBuilder);
        }
    }
}