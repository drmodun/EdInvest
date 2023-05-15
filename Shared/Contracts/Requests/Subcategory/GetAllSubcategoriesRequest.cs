namespace Shared.Contracts.Requests.Subcategory
{
    public class GetAllSubcategoriesRequest
    {
        public Guid? CategoryId { get; set; }
        public string? Name { get; set; }
    }
}
