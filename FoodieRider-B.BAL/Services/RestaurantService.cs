using FoodieRider.BAL.Interfaces;
using FoodieRider.DAL.DbContext;
using FoodieRider.DAL.Model.Food;

namespace FoodieRider.BAL.Services
{
    public class RestaurantService(IFoodieRiderDbContext dbContext) : IRestaurantService
    {
        private readonly IFoodieRiderDbContext _dbContext = dbContext;

        public async Task<Restaurant?> Get()
        {
            var result = await _dbContext.Restaurants.FindAsync(1);
            return result;
        }
    }
}
