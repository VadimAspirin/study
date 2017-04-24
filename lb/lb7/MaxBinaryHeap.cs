using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb7
{
    class MaxBinaryHeap<T> : BinaryHeap<T>
        where T: IComparable
    {                       
        public override bool Compare(int numberA, int numberB)
        {
            return base.Compare(numberA, numberB);
        }
    }
}
