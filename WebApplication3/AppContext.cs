using System.Data.Entity;

namespace WebApplication3.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        // Assuming Person is an entity you want to include
        // This line is crucial if you're working with the Person type directly
        public DbSet<Person> People { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<FullAddress> FullAddresses { get; set; }
        public DbSet<FullName> FullNames { get; set; }

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

            // If you have specific configurations for Person, Customer, and Employee, add them here
            // For example, specifying table names or relationships if not following conventions

            base.OnModelCreating(modelBuilder);
        }
    }
}
