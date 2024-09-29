namespace Week3B_Emmer.Models
{
    public class Oilbarrel : LiquidContainer
    {
        public const int DEFAULT_CAPACITY = 159;

        public Oilbarrel()
        {
            Capacity = DEFAULT_CAPACITY;
        }
    }
}
