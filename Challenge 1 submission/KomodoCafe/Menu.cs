using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class Menu
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        public Menu(
            string itemName,
            int itemNumber,
            string itemDescription,
            string ingredients,
            decimal price)
        {
            Name = itemName;
            Number = itemNumber;
            Description = itemDescription;
            Ingredients = ingredients;
            Price = price;
        }

        public Menu()
        {
        }
    }
}
