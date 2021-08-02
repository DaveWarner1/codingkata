using csharp.Specifications;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose : IGildedRose
    {
        IList<Item> Items;
        NameNotAgedBrie NameNotAgedBrieSpec = new NameNotAgedBrie();
        NameNotBackstagePassesSpec NameNotBackstagePasses = new NameNotBackstagePassesSpec();
        NameNotSulfurasSpec NameNotSulfurasSpec = new NameNotSulfurasSpec();
        ItemQualityGreaterThan0Spec ItemQualityGreaterThan0Spec = new ItemQualityGreaterThan0Spec();
        ItemQualityLessThan50Spec ItemQualityLessThan50Spec = new ItemQualityLessThan50Spec();
        SellInLessThan11Spec SellInLessThan11Spec = new SellInLessThan11Spec();
        SellInLessThan6Spec SellInLessThan6Spec = new SellInLessThan6Spec();
        SellInLessThan0Spec SellInLessThan0Spec = new SellInLessThan0Spec();

        ISpecification<Item> NameMatchSpec = null;
        ISpecification<Item> NameNotMatchSellingLess11QualityLess50 = null;
        ISpecification<Item> NameNotBackstageOrSulfurasAndQualityGreaterThan0Spec = null;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public GildedRose() 
        {
            NameMatchSpec = NameNotAgedBrieSpec
                .And(NameNotBackstagePasses)
                .And(NameNotSulfurasSpec)
                .And(ItemQualityGreaterThan0Spec);

            NameNotMatchSellingLess11QualityLess50 = NameNotBackstagePasses
                .And(SellInLessThan11Spec)
                .And(ItemQualityLessThan50Spec);

            NameNotBackstageOrSulfurasAndQualityGreaterThan0Spec = NameNotBackstagePasses
                .And(NameNotSulfurasSpec)
                .And(ItemQualityGreaterThan0Spec);

        }


        public void UpdateQuality(Item item)
        {
            if(NameMatchSpec.IsSatisfiedBy(item)) 
                item.Quality = item.Quality - 1;
            else
            {
                if(ItemQualityLessThan50Spec.IsSatisfiedBy(item))
                {
                    item.Quality = item.Quality + 1;

                    if(NameNotMatchSellingLess11QualityLess50.IsSatisfiedBy(item))
                    {                      
                        item.Quality = item.Quality + 1;                       
                    }
                }
            }

            if(NameNotSulfurasSpec.IsSatisfiedBy(item))
                item.SellIn = item.SellIn - 1;

            if(SellInLessThan0Spec.IsSatisfiedBy(item))
            {
                if (NameNotAgedBrieSpec.IsSatisfiedBy(item))
                {
                    if(NameNotBackstageOrSulfurasAndQualityGreaterThan0Spec.IsSatisfiedBy(item))
                        item.Quality = item.Quality - 1;
                    else
                        item.Quality = item.Quality - item.Quality;
                }
                else if(ItemQualityLessThan50Spec.IsSatisfiedBy(item))
                    item.Quality = item.Quality + 1;                                    

            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
