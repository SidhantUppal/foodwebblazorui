using FoodieRider.BAL.Dto;
using FoodieRider_B.Data.ViewModels;

namespace FoodieRider_B.Data.Services
{
    public interface ICartServices
    {
        Task Add(CartDto dto);
        Task Remove(int itemId);
        Task Update(int itemId);
        Task<bool> IsItemExist(int itemId);
        Task<CartSearch> GetCart();
    }
    public class CartServices(HttpClient httpClient) : ICartServices
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task Add(CartDto dto)
        {

            await _httpClient.PostAsJsonAsync("/cart", dto);
        }

        public Task<bool> IsItemExist(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int itemId)
        {
            throw new NotImplementedException();
        }

        public Task Update(int itemId)
        {
            throw new NotImplementedException();
        }
        public async Task<CartViewModel> ShoppingCart()
        {
            var viewModel = new CartViewModel
            {
                Cart = await GetCart()
            };
            return viewModel;
        }

        public async Task<CartSearch> GetCart()
        {
            return await _httpClient.GetFromJsonAsync<CartSearch>("/cart/user");
        }
    }
}
