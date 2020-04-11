using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoOuttings.Outting;

namespace KomodoOuttings
{
    class ProgramUI
    {
        private readonly OuttingRepo _repo = new OuttingRepo();
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
                Console.WriteLine("Hello! What would you like to do?\n\n" +
                    "1. Add an outting\n" +
                    "2. Display all outtings\n" +
                    "3. Total cost of all outtings\n" +
                    "4. Total cost by type\n\n" +
                    "5. Exit\n\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddOutting();
                        break;
                    case "2":
                        DisplayOuttings();
                        break;
                    case "3":
                        TotalAllOuttings();
                        break;
                    case "4":
                        TotalOuttingsByType();
                        break;
                    case "5":
                        Console.WriteLine("Have a great day!");
                        programIsRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddOutting()
        {
            Console.Clear();
            Console.WriteLine("You chose to add an outting.\n\n" +
                "What was the type of outting?\n\n" +
                "1. Golf\n" +
                "2. Bolwing\n" +
                "3. Amusement Park\n" +
                "4. Concert\n\n" +
                "5. Go back\n\n");
            string typeInputString = Console.ReadLine();
            OuttingType type = 0;
            switch (typeInputString)
            {
                case "1":
                    type = OuttingType.Golf;
                    break;
                case "2":
                    type = OuttingType.Bowling;
                    break;
                case "3":
                    type = OuttingType.AmusementPark;
                    break;
                case "4":
                    type = OuttingType.Concert;
                    break;
                case "5":
                    RunMenu();
                    break;
                default:
                    break;
            }

            Console.WriteLine("\nHow many people attended this event?\n\n");
            string attendanceString = Console.ReadLine();
            int numberOfPeople = Convert.ToInt32(attendanceString);

            Console.WriteLine("\nIn mm/dd/yyy, on what date did this event occur?\n\n");
            string dateString = Console.ReadLine();
            DateTime date = DateTime.Parse(dateString);

            Console.WriteLine("\nHow much did the event cost?");
            string totalCostString = Console.ReadLine();
            double totalCost = Convert.ToDouble(totalCostString);

            double costPerPerson = totalCost / numberOfPeople; 

            Outting newOutting = new Outting(type, numberOfPeople, date, costPerPerson, totalCost);
            bool wasAdded = _repo.AddOutting(newOutting);
            if (wasAdded)
            {
                Console.WriteLine("Your outting has been added!");
            }
            else
            {
                Console.WriteLine("Unfortunately there was an error. Please try again.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void DisplayOuttings()
        {
            Console.Clear();
            int index = 1;
            List<Outting> outtings = _repo.GetContents();
            Console.WriteLine("Here are all of the outtings:\n\n");
            foreach (Outting outting in outtings)
            {
                    Console.WriteLine($"{index++} - {outting.Date}\n" +
                    $"{outting.NumberOfPeople} of people attended who attended the {outting.Type}.\n" +
                    $"The total cost was ${outting.TotalCost}, which comes out to ${outting.CostPerPerson} per person.\n\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private void TotalAllOuttings()
        {
            Console.Clear();
            double totalPrice = 0;
            List<Outting> outtings = _repo.GetContents();
            foreach (Outting outting in outtings)
            {
                totalPrice += outting.TotalCost;
            }
            Console.WriteLine($"The total cost for all outting so far is ${totalPrice}.\n\n" +
                $"Press any key to continue...");
            Console.ReadLine();
        }

        private void TotalOuttingsByType()
        {
            Console.Clear();
            double golfPrice = 0;
            double parkPrice = 0;
            double concertPrice = 0;
            double bowlingPrice = 0;
            List<Outting> outtings = _repo.GetContents();
            foreach (Outting outting in outtings)
            {
                if (outting.Type == OuttingType.Golf)
                {
                    golfPrice += outting.TotalCost;
                }
                else if (outting.Type == OuttingType.Bowling)
                {
                    bowlingPrice += outting.TotalCost;
                }
                else if (outting.Type == OuttingType.AmusementPark)
                {
                    parkPrice += outting.TotalCost;
                }
                else if (outting.Type == OuttingType.Concert)
                {
                    concertPrice += outting.TotalCost;
                }
            }

            Console.WriteLine($"Here is the breakdown of costs by type of event:\n\n" +
                $"Golfing: ${golfPrice}\n" +
                $"Amusement Parks: ${parkPrice}\n" +
                $"Concerts: ${concertPrice}\n" +
                $"Bowling: ${bowlingPrice}\n\n" +
                $"Press any key to continue...");
            Console.ReadLine();
        }
    }
}
