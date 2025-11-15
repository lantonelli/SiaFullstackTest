namespace SiaFullstackTest.Back.Dtos
{
    public class CreateProductRequest
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? Image { get; set; }
        public List<int>? CategoryIds { get; set; } = [];
    }
}
