namespace SiaFullstackTest.Back.Dtos
{
    public class UpdateCategoryRequest
    {
        public int CategoryId { get; set; }
        public required string Name { get; set; }

    }
}
