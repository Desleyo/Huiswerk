namespace Week2B_Activiteit
{
    internal class Organisator(string naam, string email)
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
