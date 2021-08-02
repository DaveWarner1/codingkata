namespace csharp.Specifications
{
    public class SellInLessThan11Spec : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item entity)
        {
            return entity.SellIn < 11;
        }
    }
}
