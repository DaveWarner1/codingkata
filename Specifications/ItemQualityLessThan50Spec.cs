namespace csharp.Specifications
{
    public class ItemQualityLessThan50Spec : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item entity)
        {
            return entity.Quality < 50; 
        }
    }
}
