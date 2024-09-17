namespace Week3A_Emmer
{
    internal class Bucket : LiquidContainer
    {
        private const int DEFAULT_CAPACITY = 12;

        private int minCapacity = 10;
        private int maxCapacity = 2500;

        public Bucket(): this(DEFAULT_CAPACITY) { }

        public Bucket(int capacity)
        {
            if (capacity >= minCapacity && capacity <= maxCapacity)
            {
                Capacity = capacity;
            }
            else
            {
                Capacity = DEFAULT_CAPACITY;
            }
        }

        public void CombineBucket(Bucket bucket) 
        {
            if(this.Content + bucket.Content <= maxCapacity)
            {
                Fill(bucket.Content);
                bucket.Empty();
            }
        }
    }
}
