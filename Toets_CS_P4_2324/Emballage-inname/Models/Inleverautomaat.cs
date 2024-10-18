using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Emballage_inname.Models
{
    public class Inleverautomaat
    {
        public Scherm Scherm { get; private set; }
        private Opslagruimte _opslagruimte;
        private decimal totaalbedrag;
        private Bon bon;
        public string Locatie { get; private set; }

        public Inleverautomaat(string locatie, Opslagruimte opslagruimte)
        {
            Locatie = locatie;
            Scherm = new Scherm();
            bon = MaakNieuweBon();
            _opslagruimte = opslagruimte;
            opslagruimte.AddObserver(opslagruimte_Storing);
        }

        private Bon MaakNieuweBon()
        {
            totaalbedrag = 0;
            return new Bon(this.Locatie);
        }

        private void opslagruimte_Storing(object? sender, EventArgs e)
        {
            StoringEventArgs args = (StoringEventArgs)e;
            string melding = args.Storing;

            Scherm.Weergeven(Scherm.Weergave.Waarschuwing, melding);
        }

        public void Inleveren(Fles fles) 
        {
            _opslagruimte.Opslaan(fles);
            bon.RegelToevoegen($"{fles.Beschrijving}\t{string.Format("{0:C}", fles.Statiegeld)}");
            totaalbedrag += fles.Statiegeld;
            bon.Totaalbedrag = "\t" + string.Format("{0:C}", totaalbedrag);
        }
        public void Inleveren(Krat krat) 
        {
            _opslagruimte.Opslaan(krat);
            bon.RegelToevoegen($"{krat.Beschrijving}\t{string.Format("{0:C}", krat.Statiegeld)}");
            totaalbedrag += krat.Statiegeld;
            bon.Totaalbedrag = "\t" + string.Format("{0:C}", totaalbedrag);
        }

        public void PrintBon() 
        {
            Scherm.Weergeven(bon);
            bon = MaakNieuweBon();
        }

    }
}
