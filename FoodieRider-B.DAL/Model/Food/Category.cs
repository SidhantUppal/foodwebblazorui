namespace FoodieRider.DAL.Model.Food
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public List<Item> Items { get; set; }
    }
}
