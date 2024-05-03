using FoodieRider.BAL.Dto;
using FoodieRider.BAL.Interfaces;
using FoodieRider.BAL.MapHelper;
using FoodieRider.DAL.DbContext;
using Microsoft.EntityFrameworkCore;

namespace FoodieRider.BAL.Services
{
    public class CategoryService(IFoodieRiderDbContext dbContext) : ICategoryService
    {
        private readonly IFoodieRiderDbContext _dbContext = dbContext;

        public async Task<int> Add(CategoryDto dto)
        {
            var result = await _dbContext.Categories.AddAsync(CategoryMapper.MapCategory(dto));
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;

        }

        public async Task<List<CategorySearch>> Get()
        {
            try
            {
                var result = await _dbContext.Categories.Include(x => x.Items).Select(x => new CategorySearch
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    Items = x.Items.Select(i => new ItemSearch
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Description = i.Description,
                        Image = i.Image,
                        Price = i.Price,
                        CategoryId = i.CategoryId
                    }).ToList()
                }).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());

            }

            return [];
        }

        public async Task<bool> Update(CategoryDto dto)
        {
            var category = CategoryMapper.MapCategory(dto);
            _dbContext.Categories.Update(category);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<CategorySearch?> Get(int id)
        {
            return await _dbContext.Categories.Where(x => x.Id == id).Select(x => new CategorySearch
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image
            }).FirstOrDefaultAsync();
        }
    }
}
