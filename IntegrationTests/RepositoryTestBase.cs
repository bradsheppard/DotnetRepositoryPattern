using System.Threading.Tasks;
using DotnetRepositoryPattern;
using DotnetRepositoryPattern.Repositories;
using IntegrationTests.FakeGenerators;
using Xunit;

namespace IntegrationTests {
    
    public abstract class RepositoryTestsBase<TEntity, TId> where TEntity : IModel<TId> {
        
        protected static IRepository<TEntity, TId> BaseRepository { get; set; }
        protected static IFakeGenerator<TEntity> FakeGenerator { get; set; }

        [Fact]
        public void Insert() {
            TEntity testEntity = FakeGenerator.GenerateFake();
            TId id = BaseRepository.Insert(testEntity);

            TEntity databaseRemoteSite = BaseRepository.Get(testEntity.Id);
            BaseRepository.Delete(id);

            Assert.Equal(testEntity, databaseRemoteSite);
        }

        [Fact]
        public async Task InsertAsync() {
            TEntity testEntity = FakeGenerator.GenerateFake();
            TId id = await BaseRepository.InsertAsync(testEntity);

            TEntity databaseRemoteSite = await BaseRepository.GetAsync(testEntity.Id);
            await BaseRepository.DeleteAsync(id);

            Assert.Equal(testEntity, databaseRemoteSite);
        }

        [Fact]
        public void Delete() {
            TEntity testEntity = FakeGenerator.GenerateFake();
            TId id = BaseRepository.Insert(testEntity);
            BaseRepository.Delete(id);

            TEntity databaseRemoteSite = BaseRepository.Get(testEntity.Id);

            Assert.Null(databaseRemoteSite);
        }

        [Fact]
        public async Task DeleteAsync() {
            TEntity testEntity = FakeGenerator.GenerateFake();
            TId id = await BaseRepository.InsertAsync(testEntity);
            await BaseRepository.DeleteAsync(id);

            TEntity databaseRemoteSite = await BaseRepository.GetAsync(testEntity.Id);

            Assert.Null(databaseRemoteSite);
        }

        [Fact]
        public void Update() {
            TEntity testEntity = FakeGenerator.GenerateFake();
            TId id = BaseRepository.Insert(testEntity);

            TEntity entity = BaseRepository.Get(id);
            EntityHelper.CopyProperties(testEntity, entity);
            entity.Id = id;
            BaseRepository.Update(entity);

            TEntity databaseEntity = BaseRepository.Get(id);
            BaseRepository.Delete(id);

            Assert.Equal(entity, databaseEntity);
        }

        [Fact]
        public async Task UpdateAsync() {
            TEntity testEntity = FakeGenerator.GenerateFake();
            TEntity updatedEntity = FakeGenerator.GenerateFake();
            
            TId id = await BaseRepository.InsertAsync(testEntity);

            TEntity entity = await BaseRepository.GetAsync(id);
            EntityHelper.CopyProperties(updatedEntity, entity);
            entity.Id = id;
            await BaseRepository.UpdateAsync(entity);

            TEntity databaseEntity = await BaseRepository.GetAsync(id);
            await BaseRepository.DeleteAsync(id);

            Assert.Equal(entity, databaseEntity);
        }
    }
}