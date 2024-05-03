using FoodieRider.Cosmos.CosmosServices;

namespace FoodieRider.API.Routes
{
    public static class CosmosRoutes
    {
        public static RouteGroupBuilder MapCosmosRoutes(this RouteGroupBuilder group, ICosmosItemService service)
        {
            group.MapGet("/", async () => await service.Get("Select * from c"));
            //group.MapGet("/{id}", async (int id) => await categoryService.Get(id));
            //group.MapPost("/", async (CategoryDto categoryDto) => await categoryService.Add(categoryDto))
            //    .AddEndpointFilter(async (efiContext, next) =>
            //    {
            //        //var param = efiContext.GetArgument<TodoDto>(0);

            //        //var validationErrors = Utilities.IsValid(param);

            //        //if (validationErrors.Any())
            //        //{
            //        //    return Results.ValidationProblem(validationErrors);
            //        //}

            //        return await next(efiContext);
            //    });
            return group;
        }
    }
}
