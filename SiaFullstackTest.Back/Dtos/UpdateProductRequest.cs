namespace SiaFullstackTest.Back.Dtos
{
    public class UpdateProductRequest
    {

        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Image { get; set; }

        public List<int>? CategoryIds { get; set; } = new();
    }
}
