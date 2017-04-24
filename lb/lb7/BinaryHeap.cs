using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb7
{
    public abstract class BinaryHeap<T>
        where T : IComparable
    {
        public readonly List<T> ValuesOfBinaryHeap = new List<T>();
                
        public int HeapSize
        {
            get
            {
                return ValuesOfBinaryHeap.Count();
            }
        }
        public void Insert(T value)
        {
            if (ValuesOfBinaryHeap.Contains(value))
            {
                throw new ArgumentException("Элемент уже имеется");
            }
            else
            {
                ValuesOfBinaryHeap.Add(value);
                int buf = HeapSize - 1;
                int parent = (buf - 1) / 2;
                while (buf > 0 && Compare(ValuesOfBinaryHeap[buf].CompareTo(ValuesOfBinaryHeap[parent]), 0))
                {
                    T tempValue = ValuesOfBinaryHeap[buf];
                    ValuesOfBinaryHeap[buf] = ValuesOfBinaryHeap[parent];
                    ValuesOfBinaryHeap[parent] = tempValue;

                    buf = parent;
                    parent = (buf - 1) / 2;
                }
            }
        }
        public virtual bool Compare(int numberA, int numberB)
        {
            return (numberA > numberB);
        }
        public T Extract()
        {
            T ExtractedValue = ValuesOfBinaryHeap[0];
            ValuesOfBinaryHeap[0] = ValuesOfBinaryHeap[HeapSize - 1];
            ValuesOfBinaryHeap.RemoveAt(HeapSize - 1);
            Streamline(0);
            return ExtractedValue;
        }
        public void Streamline(int vertex)
        {
            int LeftChild;
            int RightChild;
            int LargestChild;

            while (true)
            {
                LeftChild = 2 * vertex + 1;
                RightChild = 2 * vertex + 2;
                LargestChild = vertex;

                if (LeftChild < HeapSize && Compare(ValuesOfBinaryHeap[LeftChild].CompareTo(ValuesOfBinaryHeap[LargestChild]), 0))
                {
                    LargestChild = LeftChild;
                }

                if (RightChild < HeapSize && Compare(ValuesOfBinaryHeap[RightChild].CompareTo(ValuesOfBinaryHeap[LargestChild]), 0))
                {
                    LargestChild = RightChild;
                }

                if (LargestChild == vertex)
                {
                    break;
                }

                T ValueToSwap = ValuesOfBinaryHeap[vertex];
                ValuesOfBinaryHeap[vertex] = ValuesOfBinaryHeap[LargestChild];
                ValuesOfBinaryHeap[LargestChild] = ValueToSwap;
                vertex = LargestChild;
            }

        }
    }
}
