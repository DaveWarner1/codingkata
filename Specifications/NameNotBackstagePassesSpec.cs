namespace csharp.Specifications
{
    public class NameNotBackstagePassesSpec : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item entity)
        {
            return entity.Name != "Backstage passes to a TAFKAL80ETC concert";
        }
    }
}
