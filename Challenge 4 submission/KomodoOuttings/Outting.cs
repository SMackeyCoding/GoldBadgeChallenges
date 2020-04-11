using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOuttings
{
    public class Outting
    {
        public enum OuttingType
        {
            Golf=1, Bowling, AmusementPark, Concert
        }
        public OuttingType Type { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCost { get; set; }

        public Outting(
            OuttingType type,
            int numberOfPeople,
            DateTime date,
            double costPerPerson,
            double totalCost)
        {
            Type = type;
            NumberOfPeople = numberOfPeople;
            Date = date;
            CostPerPerson = costPerPerson;
            TotalCost = totalCost;
        }

        public Outting()
        {
        }
    }
}
