using Shared.Contracts.Requests.Subcategory;
using Shared.Models;

namespace Domain.Repositories.Interfaces
{
    public interface ISubcategoryRepo
    {
        public Task<Subcategory?> GetById(GetSubcategoryRequest request);
        public Task<List<Subcategory>> GetAll(GetAllSubcategoriesRequest options);

    }
}
