using FoodieRider.BAL.Dto;

namespace FoodieRider_B.Data.Services
{
    public interface IItemServices
    {
        Task<List<ItemSearch>> GetByCategory(string categoryId);
        Task<List<ItemSearch>> Get();
    }

    public class ItemServices(HttpClient httpClient) : IItemServices
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<ItemSearch>> GetByCategory(string categoryId)
        {
            return await _httpClient.GetFromJsonAsync<List<ItemSearch>>($"/item/category/{Convert.ToInt32(categoryId)}");
        }
        public async Task<List<ItemSearch>> Get()
        {
            return await _httpClient.GetFromJsonAsync<List<ItemSearch>>("/item");
        }
    }

}
