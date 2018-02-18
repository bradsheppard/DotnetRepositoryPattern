using DotnetRepositoryPattern;
using DotnetRepositoryPattern.Repositories;
using IntegrationTests.FakeGenerators;

namespace IntegrationTests {
    public class SampleModelRepositoryTests : RepositoryTestsBase<SampleModel, long> {

        public SampleModelRepositoryTests() {
            string test = "Server=tcp:bradtestserver.database.windows.net,1433;Initial Catalog=bradtestdatabase;Persist Security Info=False;User ID=brad;Password=SQLPass7;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
            BaseRepository = new SampleModelRepository(test);
            FakeGenerator = new SampleModelFakeGenerator();
        }
    }
}