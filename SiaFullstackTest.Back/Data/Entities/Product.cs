using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiaFullstackTest.Back.Data.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public required string Description { get; set; }

        public string? Image { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

    }
}
