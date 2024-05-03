using FoodieRider.BAL.Dto;
using FoodieRider.BAL.Interfaces;
using FoodieRider.DAL.Model.Food;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodieRider.API.Routes
{
    public static class CartRoutes
    {
        public static RouteGroupBuilder MapCartRoutes(this RouteGroupBuilder group)
        {
            group.MapGet("/{id}", async (int id, [FromServices] ICartService service) => await service.Get(id));
            group.MapGet("/user",
            async (HttpContext context, [FromServices] ICartService service, [FromServices] IAuthorizationService authorizationService) =>
            {
                //var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var userId = "9abb7bf6-93ba-4ef0-928a-5b99a39959b9";
                if (!string.IsNullOrEmpty(userId))
                {
                    Guid guid = Guid.Parse(userId);

                    var data = await service.GetByUser(guid);
                    if (data != null)
                    {
                        return Results.Ok(data); // Assuming `Ok` is a method that creates an OK (200) response with the provided data
                    }
                    else
                    {
                        return Results.NoContent(); // Assuming `NoContent` is a method that creates a No Content (204) response
                    }

                }
                return Results.Unauthorized();

            }).AddEndpointFilter(async (efiContext, next) => { return await next(efiContext); });
            //.RequireAuthorization();
            group.MapPost("/", async (CartDto dto, [FromServices] ICartService service, [FromServices] IAuthorizationService authorizationService, HttpContext context) =>
            {
                //if (context.User.Identities.Where(x => x.IsAuthenticated).Any())
                {
                    //var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    var userId = "9abb7bf6-93ba-4ef0-928a-5b99a39959b9";

                    Guid guid = Guid.Parse(userId);
                    var cart = new Cart
                    {

                        UserId = guid,
                        _cartItemsJson = dto._cartItemsJson

                    };
                    await service.Add(cart);
                }

            }).AddEndpointFilter(async (efiContext, next) => { return await next(efiContext); });
            //.RequireAuthorization();
            return group;
        }
    }
}
