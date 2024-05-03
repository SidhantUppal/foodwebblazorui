using FoodieRider.BAL.Dto;
using FoodieRider.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieRider.API.Routes
{
    public static class ItemRoutes
    {
        public static RouteGroupBuilder MapItemRoutes(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] IItemService service) => await service.Get());
            group.MapGet("/{id}", async (int id, [FromServices] IItemService service) => await service.Get(id));
            group.MapGet("/category/{id}", async (int id, [FromServices] IItemService service) => await service.GetByCategoryId(id));
            group.MapPost("/", async (ItemDto dto, [FromServices] IItemService service) => await service.Add(dto))
                .AddEndpointFilter(async (efiContext, next) =>
                {
                    //var param = efiContext.GetArgument<TodoDto>(0);

                    //var validationErrors = Utilities.IsValid(param);

                    //if (validationErrors.Any())
                    //{
                    //    return Results.ValidationProblem(validationErrors);
                    //}

                    return await next(efiContext);
                });
            return group;
        }
    }
}
