using FoodieRider.BAL.Dto;
using FoodieRider.DAL.Model.Food;

namespace FoodieRider.BAL.MapHelper
{
    public static class ItemMapper
    {
        public static ItemDto MapDto(Item entity)
        {
            return new ItemDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public static Item MapEntity(ItemDto dto)
        {
            return new Item
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Image = dto.Image,
                CategoryId = dto.CategoryId,
                IsAvailable = dto.IsAvailable,
                Price = dto.Price,
                IsDeleted = dto.IsDeleted,
                Restaurant = dto.Restaurant,
                RestaurantId = dto.RestaurantId
            };
        }
    }
}
