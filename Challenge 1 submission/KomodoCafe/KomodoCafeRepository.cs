using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public class KomodoCafeRepository
    {
        protected readonly List<Menu> _itemMenu = new List<Menu>();

        public bool AddItemToMenu(Menu item)
        {
            int startingCount = _itemMenu.Count;
            _itemMenu.Add(item);
            bool wasAdded = (_itemMenu.Count > startingCount);
            return wasAdded;
        }

        public List<Menu> GetContents()
        {
            return _itemMenu;
        }

        public bool DeleteMenuItem(int itemNumber)
        {
            int startingCount = _itemMenu.Count;
            int index = -1;
            foreach (Menu item in _itemMenu)
            {
                if (item.Number == itemNumber)
                {
                    index = _itemMenu.IndexOf(item);
                }
            }
            if (index != -1)
            {
                _itemMenu.RemoveAt(index);
            }

            bool wasRemoved = (_itemMenu.Count < startingCount);
            return wasRemoved;
        }
    }
}
