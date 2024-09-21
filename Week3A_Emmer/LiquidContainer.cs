﻿namespace Week3A_Emmer
{
    internal abstract class LiquidContainer
    {
        private int capacity;
        private int content;

        public int Capacity 
        {
            get => capacity; 
            protected set
            {
                if(value >= 0)
                {
                    capacity = value;
                }
            }
        }

        public int Content
        {
            get => content;
            set
            {
                if (value >= 0 && value <= Capacity)
                {
                    content = value;
                }
            }
        }

        public void Fill(int amount) 
        {
            Content += amount;
        }

        public void Empty() 
        {
            Content = 0;
        }

        public void Empty(int amount) 
        {
            Content -= amount;
        }
    }
}
