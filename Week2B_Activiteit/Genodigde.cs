namespace Week2B_Activiteit
{
    internal class Genodigde(string naam, string email)
    {
        private string naam = naam;
        private string email = email;

        public string GetNaam()
        {
            return naam;
        }

        public string GetEmail()
        {
            return email;
        }
    }
}
