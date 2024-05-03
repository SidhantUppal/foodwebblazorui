using FoodieRider.DAL.Model.Auth;
using FoodieRider.DAL.Model.Food;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FoodieRider.DAL.DbContext
{
    public class FoodieRiderDbContext(DbContextOptions<FoodieRiderDbContext> options) : IdentityDbContext<User>(options), IFoodieRiderDbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}

