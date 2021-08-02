namespace csharp
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
