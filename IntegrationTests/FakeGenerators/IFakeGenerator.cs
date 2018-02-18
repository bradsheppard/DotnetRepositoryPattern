namespace IntegrationTests.FakeGenerators {
    
    public interface IFakeGenerator<out T> {
        T GenerateFake();
    }
}