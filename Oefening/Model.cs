namespace Oefening_Events
{
    public delegate void Observer(Object sender, ModelChangedEventArgs args);

    public class Model
    {
        public event Observer? Observer;

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
                Observer?.Invoke(this, new ModelChangedEventArgs { OudGetal = oudGetal, NieuwGetal = getal});
            }
        }

        public void AddObserver(Observer observer)
        {
            this.Observer += observer;
        }
    }
}
