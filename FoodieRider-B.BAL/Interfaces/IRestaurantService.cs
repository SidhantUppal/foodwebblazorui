using FoodieRider.DAL.Model.Food;

namespace FoodieRider.BAL.Interfaces
{
    public interface IRestaurantService
    {
        Task<Restaurant?> Get();
    }
}
