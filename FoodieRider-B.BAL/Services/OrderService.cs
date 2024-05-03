using FoodieRider.BAL.Interfaces;
using FoodieRider.DAL.DbContext;
using FoodieRider.DAL.Model.Food;
using Microsoft.EntityFrameworkCore;

namespace FoodieRider.BAL.Services
{
    public class OrderService(IFoodieRiderDbContext dbContext) : IOrderService
    {
        private readonly IFoodieRiderDbContext _dbContext = dbContext;
        public async Task<int> Add(Order dto)
        {
            var result = await _dbContext.Orders.AddAsync(dto);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<int> Delete(int entityId)
        {
            var result = await _dbContext.Orders.FindAsync(entityId);

            if (result != null)
            {
                result.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return 1; // Indicate successful deletion
            }

            return 0; // Indicate that no entity was found with the given ID
        }


        public async Task<Order> Get(int entityId)
        {
            var result = await _dbContext.Orders.FindAsync(entityId);
            return result;
        }

        public async Task<List<Order>> GetAll()
        {
            var result = await _dbContext.Orders.ToListAsync();
            return result;
        }

        public async Task<List<Order>> GetByUser(Guid userId)
        {
            var result = await _dbContext.Orders.Where(x => x.UserId == userId).ToListAsync();
            return result;
        }

        public async Task<int> Update(Order cart)
        {
            throw new NotImplementedException();
        }
    }
}
