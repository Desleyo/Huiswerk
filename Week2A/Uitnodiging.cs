namespace Week2A
{
    internal class Uitnodiging
    {
        public static void Main(string[] args)
        {
            //Eigen gegevens
            string? organisatorNaam = null;
            string? organisatorEmail = null;

            //Activiteit
            string? activiteitTitel = null;
            DateTime? activiteitDatum = null;
            string? activiteitBeschrijving = null;

            //Genodigde
            int aantalGenodigden = 0;
            string[] namenGenodigden;
            string[] emailsGenodigden;

            Console.WriteLine("Wat is de naam van de organisator?");
            while (string.IsNullOrEmpty(organisatorNaam))
            {
                organisatorNaam = Console.ReadLine();
            }

            Console.Clear();

            Console.WriteLine("Wat is het e-mailadres van de organisator? (optioneel)");
            organisatorEmail = Console.ReadLine();

            Console.Clear();

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

            Console.WriteLine("Hoeveel mensen wil je uitnodigen?");
            while(aantalGenodigden < 1)
            {
                try
                {
                    aantalGenodigden = int.Parse(Console.ReadLine());
                }
                catch
                {
                    aantalGenodigden = 0;
                }

                if(aantalGenodigden < 1)
                {
                    Console.WriteLine("Voer een geldig getal in. (het getal mag niet onder de 1 liggen)");
                }
            }

            Console.Clear();

            namenGenodigden = new string[aantalGenodigden];
            emailsGenodigden = new string[aantalGenodigden];

            for (int i = 0; i < aantalGenodigden; i++)
            {
                Console.WriteLine($"Wat is de naam van de {i+1}e genodigde?");
                while (string.IsNullOrEmpty(namenGenodigden[i]))
                {
                    namenGenodigden[i] = Console.ReadLine();
                }

                Console.Clear();

                Console.WriteLine($"Wat is het e-mailadres van de {i+1}e genodigde? (optioneel)");
                emailsGenodigden[i] = Console.ReadLine();

                Console.Clear();
            }

            Console.Clear();

            for(int i = 0; i < aantalGenodigden; i++)
            {
                Console.WriteLine($"Beste {namenGenodigden[i]}, Op {activiteitDatum} ben je uitgenodigd voor een {activiteitTitel}. " +
                $"{activiteitBeschrijving}: Kom je ook?\n");
            }

            Console.WriteLine($"Naam organisator: {organisatorNaam}\n" +
                $"E-mail organisator: {organisatorEmail}\n" +
                $"Titel activiteit: {activiteitTitel}\n" +
                $"Datum activiteit: {activiteitDatum}\n" +
                $"Beschrijving activiteit: {activiteitBeschrijving}");

            for (int i = 0; i < aantalGenodigden; i++)
            {
                Console.WriteLine($"Naam {i + 1}e genodigde: {namenGenodigden[i]}\n" +
                    $"E-mail {i + 1}e genodigde: {emailsGenodigden[i]}");
            }
        }
    }
}
