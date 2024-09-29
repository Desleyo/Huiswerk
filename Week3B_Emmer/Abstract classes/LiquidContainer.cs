using Week3B_Emmer.EventArguments;

namespace Week3B_Emmer
{
    public delegate void Observer(Object sender, EventArgs args);

    public abstract class LiquidContainer
    {
        public event Observer? FullObserver;
        public event Observer? OverflowedObserver;

        private int capacity;
        private int content;

        public int Capacity 
        {
            get => capacity; 
            protected set
            {
                capacity = value;
            }
        }

        public int Content
        {
            get => content;
            set
            {
                if (value >= 0 && value < Capacity)
                {
                    content = value;
                    return;
                }

                if (value == Capacity)
                {
                    FullObserver?.Invoke(this, EventArgs.Empty);
                    content = value;
                }
                else if (value > Capacity)
                {
                    OverflowedObserver?.Invoke(this, new OverflowedEventArgs() { Amount = value - Capacity });
                    content = Capacity;
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

        public void AddObserver(Observer observer)
        {
            FullObserver += observer;
            OverflowedObserver += observer;
        }

        public void AddObserver(Observer observer, bool observeFull)
        {
            if (observeFull)
            {
                FullObserver += observer;
            }
            else
            {
                OverflowedObserver += observer;
            }
        }
    }
}
