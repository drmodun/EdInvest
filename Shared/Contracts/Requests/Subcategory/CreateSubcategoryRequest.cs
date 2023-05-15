namespace Shared.Contracts.Requests.Subcategory
{
    public class CreateSubcategoryRequest
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }

        public string Description { get; set; }

    }
}
