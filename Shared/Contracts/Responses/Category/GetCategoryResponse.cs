using Shared.Contracts.Responses.Subcategory;

namespace Shared.Contracts.Responses.Category
{
    public class GetCategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<GetSubcategoryResponse> Subcategories { get; set; }
    }
}
