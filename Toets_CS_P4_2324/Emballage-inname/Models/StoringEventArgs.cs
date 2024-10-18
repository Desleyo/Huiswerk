namespace Emballage_inname.Models
{
    public class StoringEventArgs: EventArgs
    {
        public StoringEventArgs(string storing) 
        {
            Storing = storing;
        }

        public string Storing { get; set; }

    }
}