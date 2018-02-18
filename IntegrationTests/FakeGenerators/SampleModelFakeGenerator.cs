
using DotnetRepositoryPattern;

namespace IntegrationTests.FakeGenerators {
    
    public class SampleModelFakeGenerator : IFakeGenerator<SampleModel> {
        
        public SampleModel GenerateFake() {
            return new SampleModel {
                Address = RandomizationHelper.GenerateString(),
                Name = RandomizationHelper.GenerateString()
            };
        }
    }
}