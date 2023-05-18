using Shared.Enums;

namespace Shared.Contracts.Requests.Items.Item
{
    public class GetAllItemsRequest
    {
        public string? Name { get; set; }

        public Guid? SubcategoryId { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? OrganisationId;
    }
}
