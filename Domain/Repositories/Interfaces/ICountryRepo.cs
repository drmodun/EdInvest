using Shared.Models;

namespace Domain.Repositories.Interfaces
{
    public interface ICountryRepo
    {
        public Task<Country?> GetById(Guid id);
        public Task<List<Country>> GetAll();
    }
}
