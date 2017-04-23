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
                throw new ArgumentException("Вставляемый элемент уже имеется");
            }
            else
            {
                ValuesOfBinaryHeap.Add(value);
                int i = HeapSize - 1;
                int parent = (i - 1) / 2;
                while (i > 0 && Compare(ValuesOfBinaryHeap[i].CompareTo(ValuesOfBinaryHeap[parent]), 0))
                {
                    T tempValue = ValuesOfBinaryHeap[i];
                    ValuesOfBinaryHeap[i] = ValuesOfBinaryHeap[parent];
                    ValuesOfBinaryHeap[parent] = tempValue;

                    i = parent;
                    parent = (i - 1) / 2;
                }
            }
        }
        public virtual bool Compare(int a, int b)
        {
            return (a > b);
        }
        public T Extract()
        {
            T ExtractedValue = ValuesOfBinaryHeap[0];
            ValuesOfBinaryHeap[0] = ValuesOfBinaryHeap[HeapSize - 1];
            ValuesOfBinaryHeap.RemoveAt(HeapSize - 1);
            Streamline(0);
            return ExtractedValue;
        }
        public void Streamline(int i)
        {
            int LeftChild;
            int RightChild;
            int LargestChild;

            while (true)
            {
                LeftChild = 2 * i + 1;
                RightChild = 2 * i + 2;
                LargestChild = i;

                if (LeftChild < HeapSize && Compare(ValuesOfBinaryHeap[LeftChild].CompareTo(ValuesOfBinaryHeap[LargestChild]), 0))
                {
                    LargestChild = LeftChild;
                }

                if (RightChild < HeapSize && Compare(ValuesOfBinaryHeap[RightChild].CompareTo(ValuesOfBinaryHeap[LargestChild]), 0))
                {
                    LargestChild = RightChild;
                }

                if (LargestChild == i)
                {
                    break;
                }

                T ValueToSwap = ValuesOfBinaryHeap[i];
                ValuesOfBinaryHeap[i] = ValuesOfBinaryHeap[LargestChild];
                ValuesOfBinaryHeap[LargestChild] = ValueToSwap;
                i = LargestChild;
            }

        }
    }
}
