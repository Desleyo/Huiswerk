using Week3B_Emmer.Exceptions;

namespace Week3B_Emmer.Models
{
    public class Bucket : LiquidContainer
    {
        public const int MIN_CAPACITY = 10;
        public const int MAX_CAPACITY = 2500;
        public const int DEFAULT_CAPACITY = 12;


        public Bucket() : this(DEFAULT_CAPACITY) { }

        public Bucket(int capacity)
        {
            try
            {
                if (capacity >= MIN_CAPACITY && capacity <= MAX_CAPACITY)
                {
                    Capacity = capacity;
                }
                else
                {
                    throw new InvalidCapacityException(capacity, MIN_CAPACITY, MAX_CAPACITY);
                }
            }
            catch (InvalidCapacityException ex)
            {
                Console.WriteLine(ex.Message);
                Capacity = DEFAULT_CAPACITY;
            }
        }

        public void CombineBuckets(Bucket bucket)
        {
            Fill(bucket.Content);
            bucket.Empty();
        }
    }
}
