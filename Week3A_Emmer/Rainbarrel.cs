﻿namespace Week3A_Emmer
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
                    Capacity = (int)Capacities.SMALL;
                    break;
            }
        }
    }
}
