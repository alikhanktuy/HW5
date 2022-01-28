using System;
namespace FinalWorkWithFiles
{
    public class RangeArray
    {
        int[] a;
        int upperbound;
        int lowerBound;

        public int Length
        {
            get;
            private set;
        }

        public bool Error
        {
            get; private set;
        }

        public RangeArray(int low, int high)
        {
            high++;
            if (high < low) { Console.WriteLine("Неверные индексы");
                high = 1; low = 0; }
            a = new int[high-low];
            Length = high - low;
            lowerBound = low;
            upperbound = --high;
        }
        public int this[int index]
        {
            get
            {
                if (ok(index))
                {
                    Error = false;
                    return a[index - lowerBound];
                } else { Error = true; return 0; }
            
                }
            set
            {
                if (ok(index))
                {
                    a[index - lowerBound] = value;
                    Error = false;
                }
                else { Error = true;  }
            }
        }

        private bool ok(int index)
        {
            if (index >= lowerBound && index <= upperbound) return true;        
            return false;
        }
    }
}
