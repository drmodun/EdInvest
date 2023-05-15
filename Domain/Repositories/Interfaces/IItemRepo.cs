namespace Domain.Repositories.Interfaces
{
    public interface IItemRepo<TEntity, TGet, TOptions>
    {
        public Task<TEntity?> GetById(TGet request);
        public Task<List<TEntity>> GetAll(TOptions options);
    }
}
