using FoodieRider.BAL.Dto;
using FoodieRider.DAL.Model.Food;

namespace FoodieRider.BAL.Interfaces
{
    public interface ICartService
    {
        Task<int> Add(Cart cart);
        Task<int> Delete(int cartId);
        Task<int> Update(Cart cart);
        Task<Cart> Get(int cartId);
        Task<CartSearch> GetByUser(Guid userId);
        Task<List<Cart>> GetAll();
    }
}
