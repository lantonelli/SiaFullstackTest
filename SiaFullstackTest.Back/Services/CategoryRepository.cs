using SiaFullstackTest.Back.Data;
using SiaFullstackTest.Back.Data.Entities;
using SiaFullstackTest.Back.Dtos;

namespace SiaFullstackTest.Back.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<CategoryResponse> AddCategoryAsync(CreateCategoryRequest category)
        {
            var newCategory = new Category
            {
                Name = category.Name
            };
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return new CategoryResponse
            {
                CategoryId = newCategory.CategoryId,
                Name = newCategory.Name
            };
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var categoryToDelete = _context.Categories.Find(id);
                if (categoryToDelete != null)
                {
                    _context.Categories.Remove(categoryToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        public async Task<List<CategoryResponse>> GetAllCategoriesAsync()
        {

            return await Task.FromResult(_context.Categories
                .Select(c => new CategoryResponse
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                }).ToList());


        }

        public async Task<CategoryResponse?> GetCategoryByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            var categoryResponse = new CategoryResponse
            {
                CategoryId = category.CategoryId,
                Name = category.Name
            };
            return categoryResponse;

        }

        public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryRequest category)
        {
            var categoryToUpdate = _context.Categories.Find(id);
            if (categoryToUpdate == null)
            {
                return false;
            }
            categoryToUpdate.Name = category.Name;
            _context.Categories.Update(categoryToUpdate);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
