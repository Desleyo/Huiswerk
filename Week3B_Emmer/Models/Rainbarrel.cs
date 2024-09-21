using Week3A_Emmer;
using Week3B_Emmer.Enums;
using Week3B_Emmer.Exceptions;

namespace Week3B_Emmer.Models
{
    internal class Rainbarrel : LiquidContainer
    {
        public Rainbarrel(Capacities chosenCapacity)
        {
            switch (chosenCapacity)
            {
                case Capacities.SMALL:
                    Capacity = (int)Capacities.SMALL;
                    break;
                case Capacities.MEDIUM:
                    Capacity = (int)Capacities.MEDIUM;
                    break;
                case Capacities.LARGE:
                    Capacity = (int)Capacities.LARGE;
                    break;
                default:
                    throw new InvalidCapacityException(chosenCapacity);
            }
        }
    }
}
