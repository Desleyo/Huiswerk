namespace Week3A_Appels_en_Peren
{
    internal class GewichtVergelijker : IComparer<Peer>
    {
        public int Compare(Peer? x, Peer? y)
        {
            if(x == null || y == null) return 0;

            return x.Gewicht.CompareTo(y.Gewicht);
        }
    }
}
