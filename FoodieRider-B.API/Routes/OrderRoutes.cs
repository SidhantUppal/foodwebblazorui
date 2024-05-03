using FoodieRider.BAL.Dto;
using FoodieRider.BAL.Interfaces;
using FoodieRider.DAL.Model.Food;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodieRider.API.Routes
{
    public static class OrderRoutes
    {
        public static RouteGroupBuilder MapOrderRoutes(this RouteGroupBuilder group)
        {

            group.MapGet("/{id}", async (int id, [FromServices] IOrderService service) => await service.Get(id));
            group.MapPost("/", async (OrderDto dto, HttpContext context, [FromServices] IOrderService orderService, [FromServices] ICartService cartService) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    Guid guid = Guid.Parse(userId);
                    var cart = await cartService.GetByUser(guid);
                    if (cart is not null)
                    {
                        Order order = new()
                        {
                            AddressId = dto.AddressId,
                            CreatedBy = userId,
                            UserId = guid,
                            OrderItems = cart.Items.Select(i => new OrderItem
                            {
                                ItemId = i.Id,
                                ItemQuanitity = i.Quantity,
                                Price = i.Price,
                                PriceTotal = i.Price * i.Quantity,
                            }).ToList(),
                        };
                        var result = await orderService.Add(order);
                        return Results.Ok(result);
                    }
                }
                return Results.Unauthorized();
            }).AddEndpointFilter(async (efiContext, next) =>
                {
                    return await next(efiContext);
                }).RequireAuthorization();
            group.MapGet("/user", async (HttpContext context, [FromServices] IOrderService orderService) =>
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                Guid guid = Guid.Parse(userId);
                // Retrieve user information using the provided userId
                var user = await orderService.GetByUser(guid);

                if (user != null)
                {
                    // If user is found, return it as JSON
                    return Results.Ok(user);
                }
                else
                {
                    // If user is not found, return 404 Not Found
                    return Results.NotFound();
                }
            });
            return group;
        }

    }
}
