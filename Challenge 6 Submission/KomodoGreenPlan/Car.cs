using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreenPlan
{
    public class Car
    {
        public enum CarType
        {
            Gas, Electric, Hybrid
        }
        public CarType Type { get; set; }
        public enum MakeType
        {
            Toyota=1, Honda, Chevrolet, Ford, MercedesBenz, Jeep, BMW, Subaru, Nissan, Volkswagen
        }
        public MakeType Make { get; set; }
        public string Model { get; set; }
        public int YearOfMake { get; set; }
        public string Color { get; set; }
        public int VIN { get; set; }

        public Car(
            CarType type,
            MakeType make,
            string model,
            int yearOfMake,
            string color,
            int vin)
        {
            Type = type;
            Make = make;
            Model = model;
            YearOfMake = yearOfMake;
            Color = color;
            VIN = vin;
        }

        public Car()
        {
        }
    }
}
