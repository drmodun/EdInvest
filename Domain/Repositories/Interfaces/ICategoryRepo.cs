using Data.Entities.Models;
using Domain.Contracts.Requests.Category;
using Domain.Contracts.Requests.Items.Item;
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
