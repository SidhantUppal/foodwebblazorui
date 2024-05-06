using FoodieRider.BAL.Dto;
using FoodieRider_B.Data.Services;

namespace FoodieRider_B.Data.Models
{
    public class CartState(ICartServices services)
    {
        private readonly ICartServices _services = services;

        public int? CartCount { get; set; }
        public bool IsUpdating { get; set; } = false;
        public CartSearch? CartSearch { get; set; }

        public void SetUpdate()
        {
            IsUpdating = !IsUpdating;
            NotifyStateChanged();
        }
        public async Task IntializeCart()
        {
            CartSearch = await _services.GetCart();
            if (CartSearch is not null)
            {
                CartCount = CartSearch?.Items?.Count;
            }
            NotifyStateChanged();
        }
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
