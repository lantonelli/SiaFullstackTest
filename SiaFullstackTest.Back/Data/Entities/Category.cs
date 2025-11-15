using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiaFullstackTest.Back.Data.Entities
{
    [Table("Category")]
    public class Category
    {
        private static readonly List<Product> products = new();

        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        public List<Product> Products { get; set; } = [];
    }
}
