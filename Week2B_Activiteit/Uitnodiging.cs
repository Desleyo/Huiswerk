namespace Week2B_Activiteit
{
    internal class Uitnodiging
    {
        public Organisator organisator;
        public Activiteit activiteit;
        private Genodigde[] genodigden;

        public void SetAantalGenodigden(int aantalGenodigden)
        {
            genodigden = new Genodigde[aantalGenodigden];
        }

        public Genodigde[] GetGenodigden()
        {
            return genodigden;
        }

        public void AddGenodigden(Genodigde genodigde)
        {
            for (int i = 0; i < genodigden.Length; i++)
            {
                if (genodigden[i] == null)
                {
                    genodigden[i] = genodigde;
                    return;
                }
            }
        }
    }
}
