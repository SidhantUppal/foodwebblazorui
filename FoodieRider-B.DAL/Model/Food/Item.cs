using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodieRider.DAL.Model.Food
{
    public class Item
    {
        [Key]
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
}
