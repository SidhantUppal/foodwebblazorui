using FoodieRider.API.Dto.Auth;

namespace FoodieRider_B.Data.Services
{
    public interface IAuthServices
    {
        Task<HttpResponseMessage> Register(UserDto user);
        Task<HttpResponseMessage> Login(LoginDto login);
    }
    public class AuthServices(HttpClient httpClient) : IAuthServices
    {
        private readonly HttpClient _httpClient = httpClient;
        public async Task<HttpResponseMessage> Register(UserDto user)
        {
            return await _httpClient.PostAsJsonAsync("/register", user);
        }
        public async Task<HttpResponseMessage> Login(LoginDto user)
        {
            return await _httpClient.PostAsJsonAsync("/login", user);
        }
    }
}
