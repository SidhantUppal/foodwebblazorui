using FoodieRider.BAL.Dto;

namespace FoodieRider.BAL.Interfaces
{
    public interface ICategoryService
    {
        Task<int> Add(CategoryDto dto);
        Task<bool> Update(CategoryDto dto);
        Task<List<CategorySearch>> Get();
        Task<CategorySearch?> Get(int id);

    }
}
