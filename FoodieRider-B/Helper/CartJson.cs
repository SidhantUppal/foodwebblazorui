using FoodieRider.BAL.Dto;
using Newtonsoft.Json;

namespace FoodieRider_B.Helper
{
    public static class CartJson
    {
        public static string MergeItems(List<ItemSearch> items, int itemId)
        {
            if (items is not null)
            {
                var existingItem = items.FirstOrDefault(x => x.Id == itemId);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                    items.Add(existingItem);
                }
                ItemSearch itemSearch = new()
                {
                    Id = itemId,
                    Quantity = 1,
                };
                items.Add(itemSearch);
            }
            else
            {
                items = [new() { Id = itemId, Quantity = 1 }];
            }

            // Serialize the list of items to JSON
            return JsonConvert.SerializeObject(items.ToDictionary(x => x.Id, x => x.Quantity));
        }

    }
}
