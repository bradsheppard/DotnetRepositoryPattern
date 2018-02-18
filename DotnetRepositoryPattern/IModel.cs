namespace DotnetRepositoryPattern {
    
    public interface IModel<T> {
        T Id { get; set; }
    }
}