using System.Threading.Tasks;

namespace DotnetRepositoryPattern.Repositories {
    
    public interface IRepository<TEntity, TId> where TEntity : IModel<TId> {
        TId Insert(TEntity entity);
        Task<TId> InsertAsync(TEntity entity);

        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);

        TEntity Get(TId id);
        Task<TEntity> GetAsync(TId id);

        void Delete(TId id);
        Task DeleteAsync(TId id);
    }
}