namespace Week3A_Emmer
{
    internal abstract class LiquidContainer
    {
        protected int capacity;
        protected int content;

        protected int Capacity 
        {
            get => capacity; 
            set
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

        public int GetCapacity()
        {
            return capacity;
        }

        public int GetContent()
        {
            return content;
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
