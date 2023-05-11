using Shared.Models;
using Shared.Contracts.Requests.Category;
using Shared.Contracts.Requests.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface ICategoryRepo
    {
        Task<Category> GetById(Guid id);
        Task<List<Category>> GetAll(GetAllCategoriesRequest options);
        
    }
}
