namespace Emballage_inname.Models
{
    public class Bon
    {
        private string[] regels;

        public string[] Regels { get { return regels; } }
        public string Locatie { get; private set; }

        public string Totaalbedrag { get; set; } 
        
        public Bon(string locatie)
        {
            Locatie = locatie;
            regels = [locatie];
        }

        public void RegelToevoegen(string regel) 
        {
            //Als regels maar 1 element heeft, dan moet totaalbedrag ook nog toegevoegd worden
            int nieuweRegels = regels.Length == 1 ? 2 : 1;
            string[] tempRegels = new string[regels.Length + nieuweRegels];

            for (int i = 0; i < regels.Length; i++)
            {
                tempRegels[i] = regels[i];
            }

            tempRegels[tempRegels.Length - 2] = regel;
            tempRegels[tempRegels.Length - 1] = Totaalbedrag;

            regels = tempRegels;
        }
    }
}