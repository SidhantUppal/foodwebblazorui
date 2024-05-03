namespace FoodieRider_B.Data.Models
{
    public class CartState
    {
        public int? CartCount { get; set; }
        public bool IsUpdating { get; set; } = false;
        public bool IsItemExist { get; set; }
        public void SetCartCount(int count)
        {
            CartCount = count;
            NotifyStateChanged();
        }
        public void SetUpdate()
        {
            IsUpdating = !IsUpdating;
            NotifyStateChanged();
        }
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
