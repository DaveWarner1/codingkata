namespace csharp.Specifications
{
    public class ItemQualityGreaterThan0Spec : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item entity)
        {
            return entity.Quality > 0;
        }
    }
}
