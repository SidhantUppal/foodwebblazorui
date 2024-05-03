namespace FoodieRider.BAL.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
    public class CategorySearch : CategoryDto
    {
        public List<ItemSearch> Items { get; set; }

    }
    public class CategoryInput : CategoryDto
    {

    }
}
