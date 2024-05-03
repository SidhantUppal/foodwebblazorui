using FoodieRider.BAL.Dto;
using FoodieRider.DAL.Model.Food;

namespace FoodieRider.BAL.MapHelper
{
    public static class CategoryMapper
    {
        public static CategoryDto MapCategoryDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public static Category MapCategory(CategoryDto categoryDto)
        {
            return new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
        }
    }
}
