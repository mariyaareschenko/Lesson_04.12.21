using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    class ArrayBuliding
    {
        Building [] buildings = new Building[10];
        public Building this[int index]
        {
            get
            {
                return buildings[index];
            }
            set
            {
                buildings[index] = value;
            }
        }
    }
}
