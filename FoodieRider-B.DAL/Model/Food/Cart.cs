using FoodieRider.DAL.Model.Base;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodieRider.DAL.Model.Food
{
    [Index(nameof(UserId), IsUnique = true)]
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        [NotMapped]
        public Dictionary<int, int> CartItems
        {
            get => JsonConvert.DeserializeObject<Dictionary<int, int>>(_cartItemsJson);
            set => _cartItemsJson = JsonConvert.SerializeObject(value);
        }

        [Column("CartItems")]
        public string _cartItemsJson { get; set; }
        //public virtual List<Item> Items { get; set; }
    }

}
