namespace Week2B_Activiteit
{
    internal class Activiteit(string titel, DateTime? datum, string beschrijving)
    {
        private string titel = titel;
        private DateTime? datum = datum;
        private string beschrijving = beschrijving;

        public string GetTitel()
        {
            return titel;
        }

        public DateTime? GetDatum()
        {
            return datum;
        }

        public string GetBeschrijving()
        {
            return beschrijving;
        }
    }
}
