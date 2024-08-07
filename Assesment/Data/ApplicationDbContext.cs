using Assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products {  get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product{ Id=1, Name = "Home Insurance Policies"}, 
                new Product { Id = 2, Name = "Motor Insurance Policies" }, 
                new Product { Id = 3, Name = "Health Insurance Policies" });
        }
    }
}
