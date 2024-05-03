using FoodieRider.DAL.DbContext;
using FoodieRider.DAL.Model.Auth;
using FoodieRider.DAL.Model.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.Json;
namespace FoodieRider_B.DAL.DbContext
{

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new FoodieRiderDbContext(serviceProvider.GetRequiredService<DbContextOptions<FoodieRiderDbContext>>());
            var executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            var rootPath = Path.GetDirectoryName(executingAssemblyPath);
            while (rootPath != null && !Directory.Exists(Path.Combine(rootPath, "wwwroot")))
            {
                rootPath = Directory.GetParent(rootPath).FullName;
            }
            if (rootPath == null)
            {
                throw new Exception("wwwroot folder not found.");
            }
            var path = Path.Combine(rootPath, "wwwroot\\Data\\data.json");

            string jsonData = File.ReadAllText(path);

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var tableDataList = JsonConvert.DeserializeObject<List<TableData>>(jsonData);

            if (context.Users.Any())
            {
                return;
            }
            foreach (var tableData in tableDataList)
            {
                if (tableData.Table == "aspnetusers")
                {
                    foreach (var row in tableData.Rows)
                    {
                        var user = new User();
                        var properties = typeof(User).GetProperties();
                        foreach (var property in properties)
                        {
                            if (row.TryGetValue(property.Name, out var value))
                            {
                                if (value is long)
                                {
                                    value = Convert.ToInt32(value);
                                }

                                property.SetValue(user, value);
                            }
                        }
                        context.Users.Add(user);
                    }
                }
                else if (tableData.Table == "categories")
                {
                    foreach (var row in tableData.Rows)
                    {
                        var category = new Category();
                        var properties = typeof(Category).GetProperties();
                        foreach (var property in properties)
                        {
                            if (row.TryGetValue(property.Name, out var value))
                            {
                                if (value is long)
                                {
                                    value = Convert.ToInt32(value);
                                }
                                property.SetValue(category, value);
                            }
                        }
                        context.Categories.Add(category);
                    }
                }
                else if (tableData.Table == "items")
                {
                    foreach (var row in tableData.Rows)
                    {
                        var item = new Item();
                        var properties = typeof(Item).GetProperties();
                        foreach (var property in properties)
                        {
                            if (row.TryGetValue(property.Name, out var value))
                            {
                                if (value is long)
                                {
                                    value = Convert.ToInt32(value);
                                }
                                if (value is double)
                                {
                                    value = Convert.ToDecimal(value);
                                }
                                property.SetValue(item, value);
                            }
                        }
                        context.Items.Add(item);
                    }
                }
                else if (tableData.Table == "restaurants")
                {
                    foreach (var row in tableData.Rows)
                    {
                        var restaurant = new Restaurant();
                        var properties = typeof(Restaurant).GetProperties();
                        foreach (var property in properties)
                        {
                            if (row.TryGetValue(property.Name, out var value))
                            {
                                if (value is long)
                                {
                                    value = Convert.ToInt32(value);
                                }
                                property.SetValue(restaurant, value);
                            }
                        }
                        context.Restaurants.Add(restaurant);
                    }
                }
                var userId = "9abb7bf6-93ba-4ef0-928a-5b99a39959b9";

                Guid guid = Guid.Parse(userId);
                Cart cart = new()
                {
                    UserId = guid,
                    CartItems = new Dictionary<int, int>
                    {
                        { 2, 1 },
                    }
                };
                context.Carts.Add(cart);
            }
            context.SaveChanges();
        }
    }
    public class TableData
    {

        [JsonProperty("table")]
        public string Table { get; set; }
        [JsonProperty("rows")]
        public List<Dictionary<string, object>> Rows { get; set; }
    }

}

