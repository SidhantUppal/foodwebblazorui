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
            return JsonConvert.SerializeObject(items.ToDictionary(x => x.Id, x => x.Quantity));
        }
        public static string UpdateQuantity(List<ItemSearch> items, int id, int quantity)
        {
            if (items is not null)
            {
                var itemsDictionary = items.ToDictionary(x => x.Id, x => x.Quantity);
                if (itemsDictionary.TryGetValue(id, out int value))
                {
                    itemsDictionary[id] = quantity;
                }
                return JsonConvert.SerializeObject(itemsDictionary);
            }
            return "";
        }
        public static string IncreaseQuantity(List<ItemSearch> items, int id)
        {
            if (items is not null)
            {
                var itemsDictionary = items.ToDictionary(x => x.Id, x => x.Quantity);
                if (itemsDictionary.TryGetValue(id, out int value))
                {
                    itemsDictionary[id] = value + 1;
                }
                return JsonConvert.SerializeObject(itemsDictionary);
            }
            return "";
        }
        public static string DecreaseQuantity(List<ItemSearch> items, int id)
        {
            if (items is not null)
            {
                var itemsDictionary = items.ToDictionary(x => x.Id, x => x.Quantity);
                if (itemsDictionary.TryGetValue(id, out int value))
                {
                    if (value == 1)
                    {
                        RemoveItem(itemsDictionary, id);
                    }
                    else
                    {
                        itemsDictionary[id] = value - 1;
                    }
                }
                return JsonConvert.SerializeObject(itemsDictionary);
            }
            return "";
        }

        public static void RemoveItem(Dictionary<int, int> items, int id)
        {
            items.Remove(id);
        }

    }
}
