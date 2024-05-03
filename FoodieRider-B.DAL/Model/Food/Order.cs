using FoodieRider.DAL.Model.Base;

namespace FoodieRider.DAL.Model.Food
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
        public int AddressId { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
