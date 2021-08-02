using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void CheckOldMethod()
        {            
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        /* New Example Tests, testing new UpdateQuality method*/

        [Test]
        public void CheckNameNotBrieOrBackstagePassesOrSulfurasAndQualityGreaterThan0()
        {
            //Arrange
            Item Item = new Item { Name = "foo", SellIn = 0, Quality = 0 };
            GildedRose app = new GildedRose();

            //Act
            app.UpdateQuality(Item);

            //Assert
            Assert.AreEqual(1, Item.Quality);
        }
        [Test]
        public void CheckNameNotBrieOrBackstagePassesOrSulfurasAndQualityNotGreaterThan0()
        {
            //Arrange
            Item Item = new Item { Name = "foo", SellIn = 0, Quality = 0 };
            GildedRose app = new GildedRose();

            //Act
            app.UpdateQuality(Item);

            //Assert
            Assert.AreEqual(1, Item.Quality);
        }
    }
}
