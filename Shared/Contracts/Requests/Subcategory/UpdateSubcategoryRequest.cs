namespace Shared.Contracts.Requests.Subcategory
{
    public class UpdateSubcategoryRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        public string Description { get; set; }

    }
}
