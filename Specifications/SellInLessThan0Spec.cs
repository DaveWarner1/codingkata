namespace csharp.Specifications
{
    public class SellInLessThan0Spec : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item entity)
        {
            return entity.SellIn < 0;
        }
    }
}
