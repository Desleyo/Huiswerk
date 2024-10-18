namespace Emballage_inname.Models
{
    public class GeneriekeOpslagruimte<T>
    {
        public List<T> Opslag { get; private set; } = new List<T>();

        public void Opslaan(T item)
        {
            Opslag.Add(item);
        }
    }
}
