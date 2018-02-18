namespace DotnetRepositoryPattern.Repositories {
    
    public class SampleModelRepository : RepositoryBase<SampleModel, long>, ISampleModelRepository {
        public SampleModelRepository(string connectionString) : base(connectionString) { }
    }
}