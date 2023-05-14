using Shared.Contracts.Requests.Category;
using Shared.Models;

namespace Domain.Repositories.Interfaces
{
    public interface ICategoryRepo
    {
        Task<Category> GetById(GetCategoryRequest request);
        Task<List<Category>> GetAll(GetAllCategoriesRequest options);

    }
}
