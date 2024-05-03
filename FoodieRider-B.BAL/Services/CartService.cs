using FoodieRider.BAL.Dto;
using FoodieRider.BAL.Interfaces;
using FoodieRider.DAL.DbContext;
using FoodieRider.DAL.Model.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodieRider.BAL.Services
{
    public class CartService(IFoodieRiderDbContext FoodieRiderDbContext) : ICartService
    {
        private readonly IFoodieRiderDbContext _FoodieRiderDbContext = FoodieRiderDbContext;
        public async Task<int> Add(Cart cart)
        {
            try
            {
                var existingCart = await _FoodieRiderDbContext.Carts.FirstOrDefaultAsync(x => x.UserId == cart.UserId);

                if (existingCart == null)
                {
                    _FoodieRiderDbContext.Carts.Add(cart);
                }
                else
                {
                    existingCart._cartItemsJson = cart._cartItemsJson;
                }

                await _FoodieRiderDbContext.SaveChangesAsync();
                return cart.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Task<int> Delete(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Get(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cart>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CartSearch> GetByUser(Guid userId)
        {
            try
            {
                var result = await _FoodieRiderDbContext.Carts.FirstOrDefaultAsync((x => x.UserId == userId));
                if (result != null)
                {
                    var items = await _FoodieRiderDbContext.Items.Where(x => result.CartItems.Keys.Contains(x.Id)).ToListAsync();

                    CartSearch cartSearch = new()
                    {
                        UserId = result.UserId,
                        Items = !items.IsNullOrEmpty() ? items.Select((x) => new ItemSearch
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Description = x.Description,
                            Image = x.Image,
                            Price = x.Price,
                            IsDeleted = x.IsDeleted,
                            IsAvailable = x.IsAvailable,
                            Quantity = result.CartItems.Where(y => y.Key == x.Id).FirstOrDefault().Value
                        }).ToList() : null
                    };
                    return cartSearch;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> Update(Cart cart)
        {
            try
            {
                var result = _FoodieRiderDbContext.Carts.Update(cart);
                await _FoodieRiderDbContext.SaveChangesAsync();
                return cart.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
