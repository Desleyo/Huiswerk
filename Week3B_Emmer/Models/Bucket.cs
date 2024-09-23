using Week3A_Emmer;
using Week3B_Emmer.Exceptions;

namespace Week3B_Emmer.Models
{
    internal class Bucket : LiquidContainer
    {
        private const int DEFAULT_CAPACITY = 12;

        private int minCapacity = 10;
        private int maxCapacity = 2500;

        public Bucket() : this(DEFAULT_CAPACITY) { }

        public Bucket(int capacity)
        {
            try
            {
                if (capacity >= minCapacity && capacity <= maxCapacity)
                {
                    Capacity = capacity;
                }
                else
                {
                    throw new InvalidCapacityException(capacity, minCapacity, maxCapacity);
                }
            }
            catch (InvalidCapacityException ex)
            {
                Console.WriteLine(ex.Message);
                Capacity = DEFAULT_CAPACITY;
            }
        }

        public void CombineBucket(Bucket bucket)
        {
            if (Content + bucket.Content <= maxCapacity)
            {
                Fill(bucket.Content);
                bucket.Empty();
            }
        }
    }
}
