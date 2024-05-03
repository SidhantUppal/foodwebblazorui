using FoodieRider.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieRider.API.Routes
{
    public static class RestaurantRoutes
    {
        public static RouteGroupBuilder MapRestaurantRoutes(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] IItemService service) => await service.Get());
            return group;
        }
    }
}
