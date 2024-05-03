using FoodieRider.DAL.Model.Food;

namespace FoodieRider.BAL.Interfaces
{
    public interface IOrderService
    {
        Task<int> Add(Order cart);
        Task<int> Delete(int cartId);
        Task<int> Update(Order cart);
        Task<Order> Get(int cartId);
        Task<List<Order>> GetByUser(Guid userId);
        Task<List<Order>> GetAll();

    }
}
