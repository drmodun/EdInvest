namespace Shared.Contracts.Responses.Category
{
    public class CreateCategoryResponse
    {
        public bool Success { get; set; }
        public GetCategoryResponse? Category { get; set; }
    }
}
