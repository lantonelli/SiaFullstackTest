using SiaFullstackTest.Back.Dtos;

namespace SiaFullstackTest.Back.Services
{
    public interface IProductRepository
    {
        Task<List<ProductResponse>> GetAllProductsAsync();
        Task<ProductResponse?> GetProductByIdAsync(int id);
        Task<ProductResponse> AddProductAsync(CreateProductRequest product);
        Task<bool> UpdateProductAsync(int id, UpdateProductRequest product);
        Task<bool> DeleteProductAsync(int id);


    }
}
