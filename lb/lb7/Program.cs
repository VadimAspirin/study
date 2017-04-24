using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb7
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxBinaryHeap<double> maxBinaryHeap = new MaxBinaryHeap<double>();
            
            maxBinaryHeap.Insert(6);
            maxBinaryHeap.Insert(8);
            maxBinaryHeap.Insert(12);
            maxBinaryHeap.Insert(14);
            maxBinaryHeap.Insert(7);
            maxBinaryHeap.Insert(11);
            maxBinaryHeap.Insert(9);

            for (int i = 0; i < maxBinaryHeap.HeapSize; i++)
                Console.WriteLine(maxBinaryHeap.ValuesOfBinaryHeap[i]);

        }

    }
}
