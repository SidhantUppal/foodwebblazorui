using FoodieRider.API.Configuration;
using FoodieRider.API.Helper;
using FoodieRider.API.Routes;
using FoodieRider.BAL.Interfaces;
using FoodieRider.BAL.Services;
using FoodieRider.DAL.DbContext;
using FoodieRider.DAL.Model.Auth;
using FoodieRider_B.DAL.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//string currentDb = "MYSQL";
//string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//if (currentDb == "MYSQL")
//{
//    string connection = builder.Configuration.GetConnectionString("MySqlConnection");
//    builder.Services.AddDbContext<IFoodieRiderDbContext, FoodieRiderDbContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection), options => options.EnableRetryOnFailure()), ServiceLifetime.Transient);
//}
string currentDb = "InMemory";
string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

if (currentDb == "InMemory")
{
    builder.Services.AddDbContext<IFoodieRiderDbContext, FoodieRiderDbContext>(options => options.UseInMemoryDatabase("FoodieRiderDb"), ServiceLifetime.Transient);
}

// Add HttpClient for making external web API calls to the Backend server API
//builder.Services.AddHttpClient();

//// For prerendering purposes, register a named HttpClient for the app's
//// named client component example.
//builder.Services.AddHttpClient("WebAPI", client =>
//    client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5001"));

// For prerendering purposes, register the client app's typed HttpClient
// for the app's typed client component example.
//builder.Services.AddHttpClient<TodoHttpClient>(client => client.BaseAddress = new Uri(builder.Configuration["BackendUrl"] ?? "https://localhost:5002"));


builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<FoodieRiderDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .InstallServices(
        builder.Configuration,
        typeof(IServiceInstaller).Assembly);
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IRestaurantService, RestaurantService>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin();
                          builder.AllowAnyMethod();
                          builder.AllowAnyHeader();
                          //builder.WithOrigins("https://localhost:5173",
                          //                    "http://localhost:5173",
                          //                    "https://www.localhost:5173");
                      });
});


builder.Services.AddAuthentication().AddBearerToken();
builder.Services.AddAuthorization();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    // Used to insert static data 
    SeedData.Initialize(services);
}
app.CustomMapIdentityApi<User>();

app.MapGroup("/category").MapCategoryRoutes();
app.MapGroup("/restaurant").MapRestaurantRoutes();
app.MapGroup("/item").MapItemRoutes();
app.MapGroup("/cart").MapCartRoutes();
app.MapGroup("/order").MapOrderRoutes();
if (builder.Environment.IsDevelopment())
{
    //app.MapGroup("/cosmos/item").MapCosmosRoutes(scope.ServiceProvider.GetRequiredService<ICosmosItemService>());
}

app.UseStaticFiles();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
app.Run();