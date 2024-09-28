namespace Oefening_Events
{
    public delegate void Observer(Object sender, ModelChangedEventArgs args);

    public class Model
    {
        public event Observer? observer;

        private int getal;

        public int Getal
        {
            get
            {
                return getal;
            }
            set
            {
                var oudGetal = getal;
                getal = value;
                observer?.Invoke(this, new ModelChangedEventArgs { OudGetal = oudGetal, NieuwGetal = getal});
            }
        }

        public void AddObserver(Observer observer)
        {
            this.observer += observer;
        }
    }
}
