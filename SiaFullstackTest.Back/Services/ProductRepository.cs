using Microsoft.EntityFrameworkCore;
using SiaFullstackTest.Back.Data;
using SiaFullstackTest.Back.Data.Entities;
using SiaFullstackTest.Back.Dtos;

namespace SiaFullstackTest.Back.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<ProductResponse> AddProductAsync(CreateProductRequest product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
            };
            if(product.CategoryIds != null)
            {
                for (int i = 0; i < product.CategoryIds.Count; i++)
                {
                    var category = await _context.Categories.FindAsync(product.CategoryIds[i]);
                    if (category != null)
                    {
                        newProduct.Categories.Add(category);
                    }
                }
            }

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return new ProductResponse
            {
                ProductId = newProduct.ProductId,
                Name = newProduct.Name,
                Description = newProduct.Description,
                Image = newProduct.Image,
                Categories = newProduct.Categories.Select(c => new CategoryResponse
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                }).ToList()

            };

        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var productToDelete = _context.Products.Find(id);
                if (productToDelete != null)
                {
                    _context.Products.Remove(productToDelete);
                }

                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<ProductResponse>> GetAllProductsAsync()
        {
            return await _context.Products.Select(p => new ProductResponse
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                Image = p.Image,
                Categories = p.Categories.Select(c => new CategoryResponse
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name
                }).ToList()
            }).ToListAsync();
        }

        public async Task<ProductResponse?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Where(p => p.ProductId == id)
                .Select(p => new ProductResponse
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Image = p.Image,
                    Categories = p.Categories.Select(c => new CategoryResponse
                    {
                        CategoryId = c.CategoryId,
                        Name = c.Name
                    }).ToList()
                }).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductRequest product)
        {
            var productToUpdate = await _context.Products.FindAsync(id);
            if (productToUpdate == null)
            {
                return false;
            }
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Image = product.Image;
            productToUpdate.Categories.Clear();

            if (product.CategoryIds != null)
            {
                for (int i = 0; i < product.CategoryIds.Count; i++)
                {
                    var category = await _context.Categories.FindAsync(product.CategoryIds[i]);
                    if (category != null)
                    {
                        productToUpdate.Categories.Add(category);
                    }
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
