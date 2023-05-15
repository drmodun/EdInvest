namespace Domain.Repositories.Interfaces
{
    public interface IReadRepo<TEntity, TId, TOptions>
    {
        public Task<TEntity?> GetById(TId request);
        public Task<List<TEntity>> GetAll(TOptions options);
    }
}
