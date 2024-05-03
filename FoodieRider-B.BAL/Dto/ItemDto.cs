using FoodieRider.DAL.Model.Food;
using System.ComponentModel;

namespace FoodieRider.BAL.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DefaultValue(1)]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ItemSearch : ItemDto
    {
        public int Quantity { get; set; }
    }
    public class ItemInputDto : ItemDto
    {

    }
}
