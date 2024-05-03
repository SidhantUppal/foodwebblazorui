using FoodieRider.BAL.Dto;

namespace FoodieRider_B.Services
{
    public interface ICategoryServices
    {
        Task<List<CategorySearch>> GetCategories();

    }

    public class CategoryServices(HttpClient httpClient) : ICategoryServices
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<CategorySearch>> GetCategories()
        {
            return await _httpClient.GetFromJsonAsync<List<CategorySearch>>("/category");
        }
    }
}
