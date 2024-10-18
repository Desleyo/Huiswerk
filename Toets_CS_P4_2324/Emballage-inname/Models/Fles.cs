using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emballage_inname.Models
{
    public class Fles : Emballage
    {
        public const decimal StandaardStatiegeld = 0.15M;
        public const int StandaardInhoud = 1000;

        public int InhoudMl { get; private set; }

        public Fles(string beschrijving, int inhoudMl, decimal statiegeld)
        {
            Beschrijving = beschrijving;
            InhoudMl = inhoudMl;
            Statiegeld = statiegeld;
        }

        public Fles(string omschrijving) 
            : this(omschrijving, StandaardInhoud, StandaardStatiegeld)
        {
        }
    }
}
