using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DotnetRepositoryPattern.Repositories {
    public abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IModel<TId> {
        private readonly ProjectDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(string connectionString) {
            DbContextOptionsBuilder<ProjectDbContext> optionsBuilder = new DbContextOptionsBuilder<ProjectDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            _dbContext = new ProjectDbContext(optionsBuilder.Options);
            
            PropertyInfo[] properties = _dbContext.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties) {
                if (propertyInfo.PropertyType == typeof(DbSet<TEntity>))
                    _dbSet = (DbSet<TEntity>) propertyInfo.GetValue(_dbContext);
            }   
        }
        
        public TId Insert(TEntity entity) {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            _dbContext.DetachAll();
            return entity.Id;
        }

        public async Task<TId> InsertAsync(TEntity entity) {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            _dbContext.DetachAll();
            return entity.Id;
        }

        public void Update(TEntity entity) {
            TEntity databaseEntity = (from e in _dbSet where e.Id.Equals(entity.Id) select e).FirstOrDefault();
            TId originalId = databaseEntity.Id;
            EntityHelper.CopyProperties(entity, databaseEntity);
            databaseEntity.Id = originalId;
            _dbContext.Update(databaseEntity);
            _dbContext.SaveChanges();
            _dbContext.DetachAll();
        }

        public async Task UpdateAsync(TEntity entity) {
            TEntity databaseEntity = await (from e in _dbSet where e.Id.Equals(entity.Id) select e)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            TId originalId = databaseEntity.Id;
            EntityHelper.CopyProperties(entity, databaseEntity);
            databaseEntity.Id = originalId;
            _dbContext.Update(databaseEntity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            _dbContext.DetachAll();
        }

        public TEntity Get(TId id) {
            TEntity entity = (from e in _dbSet.AsNoTracking() where e.Id.Equals(id) select e).FirstOrDefault();
            return entity;
        }

        public async Task<TEntity> GetAsync(TId id) {
            TEntity entity = await (from e in _dbSet.AsNoTracking() where e.Id.Equals(id) select e)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            return entity;
        }

        public void Delete(TId id) {
            TEntity entity = (from e in _dbSet where e.Id.Equals(id) select e).FirstOrDefault();
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
            _dbContext.DetachAll();
        }

        public async Task DeleteAsync(TId id) {
            TEntity entity = await (from e in _dbSet where e.Id.Equals(id) select e).FirstOrDefaultAsync()
                .ConfigureAwait(false);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            _dbContext.DetachAll();
        }
    }
}