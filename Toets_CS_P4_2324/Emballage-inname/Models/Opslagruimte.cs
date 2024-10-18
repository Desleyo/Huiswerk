using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emballage_inname.Models
{
    public delegate void Observer(Object sender, StoringEventArgs e);

    public class Opslagruimte
    {
        public event Observer? Storing;

        private readonly int FlessenCapaciteit;
        private readonly int KrattenCapaciteit;
        private List<Fles> flessen;
        private List<Krat> kratten;
        public IEnumerable<Fles> Flessen { get { return flessen; } }
        public IEnumerable<Krat> Kratten { get { return kratten; } }

        public Opslagruimte(int flessenCapaciteit, int krattenCapaciteit)
        {
            FlessenCapaciteit = flessenCapaciteit;
            KrattenCapaciteit = krattenCapaciteit;
            flessen = new List<Fles>();
            kratten = new List<Krat>();
        }

        public void Opslaan(Krat krat) 
        {
            if (kratten.Count < KrattenCapaciteit) 
            {
                kratten.Add(krat);            
            }
            else
            {
                Storing?.Invoke(this, new StoringEventArgs("kratten"));
            }
        }
        public void Opslaan(Fles fles) 
        {
            if (flessen.Count < FlessenCapaciteit)
            {
                flessen.Add(fles);
            }
            else
            {
                Storing?.Invoke(this, new StoringEventArgs("flessen"));
            }
        }

        public int TelLegeKratten => (from krat in Kratten
                                     where krat.AantalFlessen == 0
                                     select krat).Count();

        public IEnumerable<string> ZoekFlessen(string zoektekst) => (from fles in Flessen
                                                                    where fles.Beschrijving.ToLower().Contains(zoektekst.ToLower())
                                                                    orderby fles.Beschrijving
                                                                    select fles.Beschrijving).AsEnumerable().Take(3);

        public Func<Fles, string> BeschrijvingMetBedrag = delegate (Fles fles) { return $"{fles.Beschrijving} {string.Format("{0:C}", fles.Statiegeld)}"; };

        public IEnumerable<string> FlessenRapportage(Func<Fles, string> format) 
        {
            return Flessen.Select(format);
        }

        public void AddObserver(Observer observer)
        {
            Storing += observer;
        }
    }
}
