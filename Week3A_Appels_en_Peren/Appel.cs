using System;

namespace Week3A_Appels_en_Peren
{
    internal class Appel : Fruit, IComparable<Appel>, IEquatable<Peer>
    {
        public Appel(Kleuren kleur) 
        { 
            Kleur = kleur;
        }

        public int CompareTo(Appel? other)
        {
            if(other == null) 
            {
                return 0;
            }

            return Kleur.CompareTo(other.Kleur);
        }

        public bool Equals(Peer? other)
        {
            return false;
        }
    }
}
