using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoOuttings
{
    public class OuttingRepo
    {
        protected readonly List<Outting> _outtingDirectory = new List<Outting>();

        public bool AddOutting(Outting outting)
        {
            int startingCount = _outtingDirectory.Count;
            _outtingDirectory.Add(outting);
            bool wasAdded = (_outtingDirectory.Count > startingCount);
            return wasAdded;
        }

        public List<Outting> GetContents()
        {
            return _outtingDirectory;
        }
    }
}
