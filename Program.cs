using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<Item> items = MockData.GetItems();
            IGildedRose app = new GildedRose();

            Console.WriteLine("OMGHAI!");
                        
            UpdateQualities(items, app);

            Console.ReadLine();
        }

        private static void UpdateQualities(IList<Item> items, IGildedRose app)
        {            
            for (var i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("| name | sellIn | quality |");

                for (var j = 0; j < items.Count; j++)
                {
                    Console.WriteLine(items[j]);
                    app.UpdateQuality(items[j]);
                }

                Console.WriteLine("");
            }
        }
    }
}
