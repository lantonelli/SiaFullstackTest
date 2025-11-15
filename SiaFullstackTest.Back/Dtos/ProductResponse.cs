namespace SiaFullstackTest.Back.Dtos
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Image{ get; set; }
        public List<CategoryResponse> Categories { get; set; } = new();
    }
}
