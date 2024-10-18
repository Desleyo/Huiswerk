namespace Emballage_inname.Models
{
    public class UitnameException : Exception
    {
        private const string message = "Fles kan niet uitgenomen worden!";

        public Fles fles;

        public UitnameException(Fles fles) : base(message)
        {
            this.fles = fles;
        }
    }
}
