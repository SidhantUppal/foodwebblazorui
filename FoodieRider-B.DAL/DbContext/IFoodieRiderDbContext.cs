using FoodieRider.DAL.Model.Food;
using Microsoft.EntityFrameworkCore;

namespace FoodieRider.DAL.DbContext
{
    public interface IFoodieRiderDbContext : IDisposable
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync();

    }
}
