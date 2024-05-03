using FoodieRider.BAL.Dto;
using FoodieRider.BAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieRider.API.Routes
{
    public static class CategoryRoutes
    {
        public static RouteGroupBuilder MapCategoryRoutes(this RouteGroupBuilder group)
        {
            group.MapGet("/", async ([FromServices] ICategoryService categoryService) => await categoryService.Get());
            group.MapGet("/{id}", async (int id, [FromServices] ICategoryService categoryService) => await categoryService.Get(id));
            group.MapPost("/", async (CategoryDto categoryDto, [FromServices] ICategoryService categoryService) => await categoryService.Add(categoryDto))
                .AddEndpointFilter(async (efiContext, next) =>
                {
                    return await next(efiContext);
                });
            return group;
        }
    }
}
