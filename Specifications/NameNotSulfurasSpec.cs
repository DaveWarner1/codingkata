namespace csharp.Specifications
{
    public class NameNotSulfurasSpec : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item entity)
        {
            return entity.Name != "Sulfuras, Hand of Ragnaros";
        }
    }
}
