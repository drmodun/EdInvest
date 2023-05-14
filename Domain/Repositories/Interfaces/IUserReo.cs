namespace Domain.Repositories.Interfaces
{
    public interface IUserRepo<TEntity, TGet, TOptions>
    {
        public Task<TEntity?> GetById(TGet id);
        public Task<List<TEntity>> GetAll(TOptions options);
    }
}
