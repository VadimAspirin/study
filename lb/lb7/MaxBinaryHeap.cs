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
        public override bool Compare(int a, int b)
        {
            return base.Compare(a, b);
        }
    }
}
