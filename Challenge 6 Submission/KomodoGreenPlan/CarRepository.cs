using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoGreenPlan.Car;

namespace KomodoGreenPlan
{
    public class CarRepository
    {
        protected readonly List<Car> _carDirectory = new List<Car>();

        public bool EnterNewCar(Car car)
        {
            int startingCount = _carDirectory.Count;
            _carDirectory.Add(car);
            bool wasAdded = (_carDirectory.Count > startingCount);
            return wasAdded;
        }

        public List<Car> GetContents()
        {
            return _carDirectory;
        }

        public Car GetCarByVIN(int vin)
        {
            foreach (Car car in _carDirectory)
            {
                if (car.VIN == vin)
                {
                    return car;
                }
            }
            return null;
        }

        public bool UpdateCar(int vin, Car newCar)
        {
            Car oldCar = GetCarByVIN(vin);

            if (oldCar != null)
            {
                oldCar.Type = newCar.Type;
                oldCar.Make = newCar.Make;
                oldCar.Model = newCar.Model;
                oldCar.YearOfMake = newCar.YearOfMake;
                oldCar.Color = newCar.Color;
                oldCar.VIN = newCar.VIN;

                return true;
            }
            else
            {
                return false;
            }
        }

       public bool DeleteCar(int index)
        {
            int startingCount = _carDirectory.Count;
            _carDirectory.RemoveAt(index);
            bool wasRemoved = (_carDirectory.Count < startingCount);
            return wasRemoved;
        }
    }
}
