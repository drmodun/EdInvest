using Data.Entities.Models;
using Domain.Contracts.Requests.Subcategory;
using Domain.Contracts.Responses.Subcategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface ISubcategoryRepo
    {
        public Task<Subcategory> GetById(Guid id);
        public Task<List<Subcategory>> GetAll(GetAllSubcategoriesRequest options);

    }
}
