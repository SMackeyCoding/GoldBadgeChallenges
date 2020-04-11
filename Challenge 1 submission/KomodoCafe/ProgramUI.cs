using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class ProgramUI
    {
        private readonly KomodoCafeRepository _repo = new KomodoCafeRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool programIsRunning = true;
            while (programIsRunning)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option that you'd like to select:\n\n" +
                    "1. Add new menu item\n" +
                    "2. See all menu items\n" +
                    "3. Delete a menu item\n" +
                    "4. Exit\n\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        ShowAllMenuItems();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Thank you, and have a great day!");
                        Console.ReadLine();
                        programIsRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddNewMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Add new menu name:\n");
            string itemName = Console.ReadLine();
            Console.WriteLine("\nWhat is the menu number for this item?\n");
            string itemNumberAsString = Console.ReadLine();
            int itemNumber = Convert.ToInt32(itemNumberAsString);
            Console.WriteLine("\nGive a description for this item:\n");
            string itemDescription = Console.ReadLine();
            Console.WriteLine("\nPlease list the ingredients:\n");
            string ingredients = Console.ReadLine();
            Console.WriteLine("\nHow much does this item cost?\n");
            string priceAsString = Console.ReadLine();
            decimal price = Convert.ToDecimal(priceAsString);

            Menu newItem = new Menu(itemName, itemNumber, itemDescription, ingredients, price);

            bool itemWasAdded = _repo.AddItemToMenu(newItem);
            if (itemWasAdded)
            {
                Console.WriteLine("Thank you, the item has been added to the menu.\n\n");
            }
            else
            {
                Console.WriteLine("I'm sorry, there was an error. Please try to add the item again.\n\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void ShowAllMenuItems()
        {
            Console.Clear();

            List<Menu> items = _repo.GetContents();
            foreach (Menu item in items)
            {
                Console.WriteLine($"#{item.Number} - {item.Name}\n" +
                    $"{item.Description}\n" +
                    $"{item.Ingredients}\n" +
                    $"${item.Price}\n\n");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter the number of the item you would like to delete from the menu:\n\n");
            string itemNumberAsString = Console.ReadLine();
            int itemNumber = Convert.ToInt32(itemNumberAsString);

            bool wasRemoved = _repo.DeleteMenuItem(itemNumber);
            if (wasRemoved)
            {
                Console.WriteLine("The item has been removed from the menu.");
            }
            else
            {
                Console.WriteLine("There was an error in removing the item. Please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();


        }
    }
}
