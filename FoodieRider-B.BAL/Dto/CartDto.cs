namespace FoodieRider.BAL.Dto
{
    public class CartDto
    {
        public Guid UserId { get; set; }
        public string _cartItemsJson { get; set; }
    }
    public class CartSearch : CartDto
    {
        public List<ItemSearch> Items { get; set; }
    }
}
