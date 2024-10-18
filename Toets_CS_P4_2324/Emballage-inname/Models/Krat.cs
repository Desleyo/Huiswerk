using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emballage_inname.Models
{
    public class Krat : Emballage
    {
        private ICollection<Fles> Flessen;
        public const decimal KratStatiegeld = 1.5M;

        public int AantalFlessen => Flessen.Count();

        public new decimal Statiegeld => KratStatiegeld + Flessen.Sum(f => f.Statiegeld);

        public Krat(string beschrijving)
        {
            Beschrijving = beschrijving;
            Flessen = new List<Fles>();
        }

        public void InPlaatsen(Fles fles)
        {
            if (fles is not null)
            {
                Flessen.Add(fles);
            }
        }

        public void Uitnemen(Fles fles)
        {
            try
            {
                if (Flessen.Contains(fles))
                {
                    Flessen.Remove(fles);
                }
                else
                {
                    throw new UitnameException(fles);
                }
            }
            catch (UitnameException ue)
            {
                Console.WriteLine(ue.Message);
            }
        }
    }
}
