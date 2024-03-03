using FoodAppDALLayer.Models;
using System.Data.Entity;

namespace FoodAppDALLayer
{
    public class FoodAppDbContext : DbContext
    {
        public FoodAppDbContext() : base("name=FoodAppDb")
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; } 
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasRequired(p => p.Order);
            // Assuming Payment is required for an Order


              
        }
    }
}
