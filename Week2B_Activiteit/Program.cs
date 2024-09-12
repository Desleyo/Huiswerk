namespace Week2B_Activiteit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uitnodiging uitnodiging = new Uitnodiging();

            uitnodiging.organisator = CreateOrganisator();

            uitnodiging.activiteit = CreateActiviteit();

            int aantalGenodigden = RequestAantalGenodigden();

            uitnodiging.SetAantalGenodigden(aantalGenodigden);

            for (int i = 0; i < aantalGenodigden; i++)
            {
                uitnodiging.AddGenodigden(CreateGenodigde(i));
            }

            SendUitnodigingen(uitnodiging);

            DebugInformation(uitnodiging);
        }

        private static Organisator CreateOrganisator()
        {
            string? organisatorNaam = null;
            string? organisatorEmail = null;

            Console.WriteLine("Wat is de naam van de organisator?");
            while (string.IsNullOrEmpty(organisatorNaam))
            {
                organisatorNaam = Console.ReadLine();
            }

            Console.Clear();

            Console.WriteLine("Wat is het e-mailadres van de organisator? (optioneel)");
            organisatorEmail = Console.ReadLine();

            Console.Clear();

            return new Organisator(organisatorNaam, organisatorEmail);
        }

        private static Activiteit CreateActiviteit()
        {
            string? activiteitTitel = null;
            DateTime? activiteitDatum = null;
            string? activiteitBeschrijving = null;

            Console.WriteLine("Wat is de titel van de activiteit?");
            while (string.IsNullOrEmpty(activiteitTitel))
            {
                activiteitTitel = Console.ReadLine();
            }

            Console.Clear();

            Console.WriteLine("Wat is de datum van de activiteit? (optioneel)");
            try
            {
                activiteitDatum = DateTime.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ongeldige invoer voor datum (enter om door te gaan)");
                Console.ReadLine();
            }

            Console.Clear();

            Console.WriteLine("Wat is de beschrijving van de activiteit? (optioneel)");
            activiteitBeschrijving = Console.ReadLine();

            Console.Clear();

            return new Activiteit(activiteitTitel, activiteitDatum, activiteitBeschrijving);
        }

        private static int RequestAantalGenodigden()
        {
            int aantalGenodigden = 0;

            Console.WriteLine("Hoeveel mensen wil je uitnodigen?");
            while (aantalGenodigden < 1)
            {
                try
                {
                    aantalGenodigden = int.Parse(Console.ReadLine());
                }
                catch
                {
                    aantalGenodigden = 0;
                }

                if (aantalGenodigden < 1)
                {
                    Console.WriteLine("Voer een geldig getal in. (het getal mag niet onder de 1 liggen)");
                }
            }

            Console.Clear();

            return aantalGenodigden;
        }

        private static Genodigde CreateGenodigde(int genodigdeIndex)
        {
            string? naam = null;
            string? email = null;

            Console.WriteLine($"Wat is de naam van de {genodigdeIndex + 1}e genodigde?");
            while (string.IsNullOrEmpty(naam))
            {
                naam = Console.ReadLine();
            }

            Console.Clear();

            Console.WriteLine($"Wat is het e-mailadres van de {genodigdeIndex + 1}e genodigde? (optioneel)");
            email = Console.ReadLine();

            Console.Clear();

            return new Genodigde(naam, email);
        }

        private static void SendUitnodigingen(Uitnodiging uitnodiging)
        {
            Genodigde[] genodigden = uitnodiging.GetGenodigden();

            for (int i = 0; i < genodigden.Length; i++)
            {
                Console.WriteLine($"Beste {genodigden[i].GetNaam()}, Op {uitnodiging.activiteit.GetDatum()} " +
                    $"ben je uitgenodigd voor een {uitnodiging.activiteit.GetTitel()}. {uitnodiging.activiteit.GetBeschrijving()}: Kom je ook?\n");
            }
        }

        private static void DebugInformation(Uitnodiging uitnodiging)
        {
            Console.WriteLine($"Naam organisator: {uitnodiging.organisator.GetNaam()}\n" +
                $"E-mail organisator: {uitnodiging.organisator.GetEmail()}\n" +
                $"Titel activiteit: {uitnodiging.activiteit.GetTitel()}\n" +
                $"Datum activiteit: {uitnodiging.activiteit.GetDatum()}\n" +
                $"Beschrijving activiteit: {uitnodiging.activiteit.GetBeschrijving()}");

            Genodigde[] genodigden = uitnodiging.GetGenodigden();

            for (int i = 0; i < genodigden.Length; i++)
            {
                Console.WriteLine($"Naam {i + 1}e genodigde: {genodigden[i].GetNaam()}\n" +
                    $"E-mail {i + 1}e genodigde: {genodigden[i].GetEmail()}");
            }
        }
    }
}
