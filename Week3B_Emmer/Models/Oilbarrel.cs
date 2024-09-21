using Week3A_Emmer;

namespace Week3B_Emmer.Models
{
    internal class Oilbarrel : LiquidContainer
    {
        private const int DEFAULT_CAPACITY = 159;

        public Oilbarrel()
        {
            Capacity = DEFAULT_CAPACITY;
        }
    }
}
