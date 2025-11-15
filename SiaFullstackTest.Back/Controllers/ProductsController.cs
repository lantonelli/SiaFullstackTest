using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiaFullstackTest.Back.Data;
using SiaFullstackTest.Back.Data.Entities;
using SiaFullstackTest.Back.Dtos;
using SiaFullstackTest.Back.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiaFullstackTest.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
     
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductRequest request)
        {
            if (id != request.ProductId)
            {
                return BadRequest();
            }

            await _productRepository.UpdateProductAsync(id, request);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> PostProduct(CreateProductRequest request)
        {

            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var response = await _productRepository.AddProductAsync(request);

            return CreatedAtAction("GetProduct", new { id = response.ProductId }, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductAsync(id);

            return NoContent();
        }

        
    }
}
