using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoGreenPlan.Car;

namespace KomodoGreenPlan
{
    class ProgramUI
    {
        private readonly CarRepository _repo = new CarRepository();
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
                    "1. Enter new car data\n" +
                    "2. Review listed cars\n" +
                    "3. Update car info\n" +
                    "4. Delete car info\n\n" +
                    "5. Exit\n\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        EnterNewCar();
                        break;
                    case "2":
                        ReviewCars();
                        break;
                    case "3":
                        UpdateCar();
                        break;
                    case "4":
                        DeleteCar();
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

        private void EnterNewCar()
        {
            Console.Clear();
            Console.WriteLine("You have chosen to create a new car entry.\n\n" +
                "What is the make of the car?\n\n" +
                "1. Toyota\n" +
                "2. Honda\n" +
                "3. Chevrolet\n" +
                "4. Ford\n" +
                "5. Mercedes-Benz\n" +
                "6. Jeep\n" +
                "7. BMW\n" +
                "8. Subaru\n" +
                "9. Nissan\n" +
                "10. Volkswagen\n\n");
            string makeInput = Console.ReadLine();
            MakeType make = 0;
            switch (makeInput)
            {
                case "1":
                    make = MakeType.Toyota;
                    break;
                case "2":
                    make = MakeType.Honda;
                    break;
                case "3":
                    make = MakeType.Chevrolet;
                    break;
                case "4":
                    make = MakeType.Ford;
                    break;
                case "5":
                    make = MakeType.MercedesBenz;
                    break;
                case "6":
                    make = MakeType.Jeep;
                    break;
                case "7":
                    make = MakeType.BMW;
                    break;
                case "8":
                    make = MakeType.Subaru;
                    break;
                case "9":
                    make = MakeType.Nissan;
                    break;
                case "10":
                    make = MakeType.Volkswagen;
                    break;
                default:
                    break;
            }

            Console.WriteLine("What is the model of the car?\n");
            string model = Console.ReadLine();

            Console.WriteLine("What year was the car made?\n");
            string yearInputString = Console.ReadLine();
            int yearOfMake = Convert.ToInt32(yearInputString);

            Console.WriteLine("What is the type of car?\n\n" +
                "1. Gas\n" +
                "2. Electric\n" +
                "3. Hybrid\n\n");
            string typeInput = Console.ReadLine();
            CarType type = 0;
            switch (typeInput)
            {
                case "1":
                    type = CarType.Gas;
                    break;
                case "2":
                    type = CarType.Electric;
                    break;
                case "3":
                    type = CarType.Hybrid;
                    break;
                default:
                    break;
            }

            Console.WriteLine("What is the color of the car?\n");
            string color = Console.ReadLine();

            Console.WriteLine("What is the car's VIN?\n\n");
            int vin = Convert.ToInt32(Console.ReadLine());

            Car newCar = new Car(type, make, model, yearOfMake, color, vin);
            bool wasAdded = _repo.EnterNewCar(newCar);
            if (wasAdded)
            {
                Console.WriteLine("The car was added!");
            }
            else
            {
                Console.WriteLine("There was an error adding the car. Please try again.");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

        }

        private void ReviewCars()
        {
            Console.Clear();
            Console.WriteLine("Which cars would you like to review?\n\n" +
                "1. Gas Cars\n" +
                "2. Electric Cars\n" +
                "3. Hybrid Cars\n" +
                "4. All Cars\n\n");
            string reviewResponse = Console.ReadLine();
            switch (reviewResponse)
            {
                case "1":
                    GetGasCars();
                    break;
                case "2":
                    GetElectricCars();
                    break;
                case "3":
                    GetHybridCars();
                    break;
                case "4":
                    GetAllCars();
                    break;
                default:
                    break;
            }
        }

        private void GetGasCars()
        {
            Console.Clear();

            int index = 1;
            List<Car> cars = _repo.GetContents();
            foreach (Car car in cars)
            {
                if (car.Type == Car.CarType.Gas)
                {
                    Console.WriteLine($"{index++}. {car.Make} {car.Model} - {car.YearOfMake} - {car.Color} (VIN {car.VIN})");
                }
            }

            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
            ReviewCars();
        }

        private void GetElectricCars()
        {
            Console.Clear();

            int index = 1;
            List<Car> cars = _repo.GetContents();
            foreach (Car car in cars)
            {
                if (car.Type == Car.CarType.Electric)
                {
                    Console.WriteLine($"{index++}. {car.Make} {car.Model} - {car.YearOfMake} - {car.Color} (VIN {car.VIN})");
                }
            }

            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
            ReviewCars();
        }

        private void GetHybridCars()
        {
            Console.Clear();

            int index = 1;
            List<Car> cars = _repo.GetContents();
            foreach (Car car in cars)
            {
                if (car.Type == Car.CarType.Hybrid)
                {
                    Console.WriteLine($"{index++}. {car.Make} {car.Model} - {car.YearOfMake} - {car.Color} (VIN {car.VIN})");
                }
            }

            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
            ReviewCars();
        }

        private void GetAllCars()
        {
            Console.Clear();

            int index = 1;
            List<Car> cars = _repo.GetContents();
            foreach (Car car in cars)
            {
                Console.WriteLine($"{index++}. {car.Make} {car.Model} - {car.YearOfMake} - {car.Color} (VIN {car.VIN})");
            }

            Console.WriteLine("Press any button to continue...");
            Console.ReadLine();
            ReviewCars();
        }

        private void UpdateCar()
        {
            Console.Clear();

            int index = 1;
            List<Car> cars = _repo.GetContents();
            foreach (Car car in cars)
            {
                Console.WriteLine($"{index++}. {car.Make} {car.Model} - {car.YearOfMake} - {car.Color} (VIN {car.VIN})");
            }

            Console.WriteLine("Which VIN would you like to update?\n\n");
            int oldVIN = Convert.ToInt32(Console.ReadLine());

            Car oldCar = new Car();

            Console.WriteLine("You have chosen to update a car entry.\n\n" +
                "What is the make of the car?\n\n" +
                "1. Toyota\n" +
                "2. Honda\n" +
                "3. Chevrolet\n" +
                "4. Ford\n" +
                "5. Mercedes-Benz\n" +
                "6. Jeep\n" +
                "7. BMW\n" +
                "8. Subaru\n" +
                "9. Nissan\n" +
                "10. Volkswagen\n\n");
            string makeInput = Console.ReadLine();
            MakeType make = 0;
            switch (makeInput)
            {
                case "1":
                    make = MakeType.Toyota;
                    break;
                case "2":
                    make = MakeType.Honda;
                    break;
                case "3":
                    make = MakeType.Chevrolet;
                    break;
                case "4":
                    make = MakeType.Ford;
                    break;
                case "5":
                    make = MakeType.MercedesBenz;
                    break;
                case "6":
                    make = MakeType.Jeep;
                    break;
                case "7":
                    make = MakeType.BMW;
                    break;
                case "8":
                    make = MakeType.Subaru;
                    break;
                case "9":
                    make = MakeType.Nissan;
                    break;
                case "10":
                    make = MakeType.Volkswagen;
                    break;
                default:
                    break;
            }

            Console.WriteLine("What is the model of the car?\n");
            string model = Console.ReadLine();

            Console.WriteLine("What year was the car made?\n");
            string yearInputString = Console.ReadLine();
            int yearOfMake = Convert.ToInt32(yearInputString);

            Console.WriteLine("What is the type of car?\n\n" +
                "1. Gas\n" +
                "2. Electric\n" +
                "3. Hybrid\n\n");
            string typeInput = Console.ReadLine();
            CarType type = 0;
            switch (typeInput)
            {
                case "1":
                    type = CarType.Gas;
                    break;
                case "2":
                    type = CarType.Electric;
                    break;
                case "3":
                    type = CarType.Hybrid;
                    break;
                default:
                    break;
            }

            Console.WriteLine("What is the color of the car?\n");
            string color = Console.ReadLine();

            Console.WriteLine("What is the car's VIN?\n\n");
            int vin = Convert.ToInt32(Console.ReadLine());

            Car newCar = new Car(type, make, model, yearOfMake, color, vin);

            _repo.UpdateCar(oldVIN, newCar);
        }

        private void DeleteCar()
        {
            Console.Clear();

            int index = 1;
            List<Car> cars = _repo.GetContents();
            foreach (Car car in cars)
            {
                Console.WriteLine($"{index++}. {car.Make} {car.Model} - {car.YearOfMake} - {car.Color} (VIN {car.VIN})");
            }

            Console.WriteLine("List the VIN of the car you'd like to delete.\n\n");
            int deletionChoice = Convert.ToInt32(Console.ReadLine());

            if (deletionChoice == index)
            {
                _repo.DeleteCar(index);
                Console.WriteLine("Your entry has been deleted!");
            }
        }
    }
}
