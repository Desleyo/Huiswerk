namespace HatanDenNartog
{
    internal class MenuItem
    {
        public string Omschrijving { get; set; }
        public int KCal { get; set; }
        public double Suikers { get; set; }
        public double Zout { get; set; }
        public bool Vegetarisch { get; set; }
        public bool BevatGluten { get; set; }
        public MenuItem(string omschrijving, int kCal, double suikers, double zout, bool vegetarisch, bool bevatGluten)
        {
            Omschrijving = omschrijving;
            KCal = kCal;
            Suikers = suikers;
            Zout = zout;
            Vegetarisch = vegetarisch;
            BevatGluten = bevatGluten;
        }
    }
}
