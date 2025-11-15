using SiaFullstackTest.Back.Dtos;

namespace SiaFullstackTest.Back.Services
{
    public interface ICategoryRepository
    {
        Task<List<CategoryResponse>> GetAllCategoriesAsync();
        Task<CategoryResponse?> GetCategoryByIdAsync(int id);
        
        Task<CategoryResponse> AddCategoryAsync(CreateCategoryRequest category);

        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryRequest category);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
