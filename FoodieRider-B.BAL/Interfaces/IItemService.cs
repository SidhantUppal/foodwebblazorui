using FoodieRider.BAL.Dto;

namespace FoodieRider.BAL.Interfaces
{
    public interface IItemService
    {
        Task<int> Add(ItemDto dto);
        Task<bool> Update(ItemDto dto);
        Task<List<ItemSearch>> Get();
        Task<ItemSearch?> Get(int id);
        Task<List<ItemSearch>> GetByCategoryId(int id);
        Task<List<ItemSearch>> Get(List<int> ids);
    }
}
