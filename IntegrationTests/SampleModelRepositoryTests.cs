using DotnetRepositoryPattern;
using DotnetRepositoryPattern.Repositories;
using IntegrationTests.FakeGenerators;

namespace IntegrationTests {
    public class SampleModelRepositoryTests : RepositoryTestsBase<SampleModel, long> {

        public SampleModelRepositoryTests() {
            string connectionString = "";
            
            BaseRepository = new SampleModelRepository(connectionString);
            FakeGenerator = new SampleModelFakeGenerator();
        }
    }
}