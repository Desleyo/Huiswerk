using Week3B_Emmer.Enums;

namespace Week3B_Emmer.Exceptions
{
    internal class InvalidCapacityException : Exception
    {
        public InvalidCapacityException(int capacity, int min, int max)
            : base($"{capacity} is outside the range of {min} - {max}")
        {
            
        }

        public InvalidCapacityException(Capacities capacity)
            : base($"{(int)capacity} is not possible as a capacity, valid capacities are {(int)Capacities.SMALL}, {(int)Capacities.MEDIUM}, {(int)Capacities.LARGE}")
        {

        }
    }
}
