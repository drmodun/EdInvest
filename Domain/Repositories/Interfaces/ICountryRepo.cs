using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Interfaces
{
    public interface ICountryRepo
    {
        public Task<Country?> GetById(Guid id);
        public Task<List<Country>> GetAll();
    }
}
