using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiaFullstackTest.Back.Data;
using SiaFullstackTest.Back.Data.Entities;
using SiaFullstackTest.Back.Dtos;
using SiaFullstackTest.Back.Services;

namespace SiaFullstackTest.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategories()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponse>> GetCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, UpdateCategoryRequest categoryRequest)
        {
            if (id != categoryRequest.CategoryId)
            {
                return BadRequest();
            }
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryRepository.UpdateCategoryAsync(id, categoryRequest);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> PostCategory(CreateCategoryRequest categoryRequest)
        {
            var category = new Category
            {
                Name = categoryRequest.Name,

            };

            await _categoryRepository.AddCategoryAsync(categoryRequest);

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryRepository.DeleteCategoryAsync(id);

            return NoContent();
        }

    }
}
