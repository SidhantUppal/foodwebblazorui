using FoodieRider.BAL.Dto;
using FoodieRider.BAL.Interfaces;
using FoodieRider.BAL.MapHelper;
using FoodieRider.DAL.DbContext;
using Microsoft.EntityFrameworkCore;

namespace FoodieRider.BAL.Services
{
    public class ItemService(IFoodieRiderDbContext dbContext) : IItemService
    {
        private readonly IFoodieRiderDbContext _dbContext = dbContext;

        public async Task<int> Add(ItemDto dto)
        {
            var result = await _dbContext.Items.AddAsync(ItemMapper.MapEntity(dto));
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;

        }

        public async Task<List<ItemSearch>> Get()
        {
            var result = await _dbContext.Items.Select(x => new ItemSearch
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Price = x.Price,
                Category = x.Category,
                CategoryId = x.CategoryId,
                IsAvailable = x.IsAvailable,
                IsDeleted = x.IsDeleted,
            }).ToListAsync();
            return result;
        }

        public async Task<bool> Update(ItemDto dto)
        {
            var category = ItemMapper.MapEntity(dto);
            _dbContext.Items.Update(category);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<ItemSearch?> Get(int id)
        {
            return await _dbContext.Items.Where(x => x.Id == id).Select(x => new ItemSearch
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image
            }).FirstOrDefaultAsync();
        }

        public async Task<List<ItemSearch>> GetByCategoryId(int id)
        {
            return await _dbContext.Items.Where(x => x.CategoryId == id).Select(x => new ItemSearch
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Price = x.Price
            }).ToListAsync();
        }

        public async Task<List<ItemSearch>> Get(List<int> ids)
        {
            return await _dbContext.Items.Where(x => ids.Contains(x.Id)).Select(x => new ItemSearch
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image,
                Price = x.Price
            }).ToListAsync();
        }
    }
}
