namespace Shared.Contracts.Responses.Category
{
    public class UpdateCategoryResponse
    {
        public bool Success { get; set; }
        public GetCategoryResponse? Category { get; set; }
    }
}
