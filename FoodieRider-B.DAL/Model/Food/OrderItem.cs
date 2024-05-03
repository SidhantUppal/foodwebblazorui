using FoodieRider.DAL.Model.Base;

namespace FoodieRider.DAL.Model.Food
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ItemQuanitity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceTotal { get; set; }
    }
}
