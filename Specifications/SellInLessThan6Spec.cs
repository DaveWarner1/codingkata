namespace csharp.Specifications
{
    public class SellInLessThan6Spec : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item entity)
        {
            return entity.SellIn < 6;
        }
    }
}
