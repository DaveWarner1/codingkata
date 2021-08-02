namespace csharp.Specifications
{
    public class NameNotAgedBrie : ISpecification<Item>
    {
        public bool IsSatisfiedBy(Item item)
        {
            return item.Name != "Aged Brie";
        }
    }
}
