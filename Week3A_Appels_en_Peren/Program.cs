namespace Week3A_Appels_en_Peren
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Appel> appels = new() { new Appel(Kleuren.GROEN), new Appel(Kleuren.ROOD), new Appel(Kleuren.GEEL), new Appel(Kleuren.GEEL) };

            Console.WriteLine("Ongesorteerde appels:");
            foreach (Appel a in appels)
            {
                Console.WriteLine($"Appel met kleur: {a.Kleur}");
            }

            appels.Sort();
            Console.WriteLine("\nGesorteerde appels:");
            foreach (Appel a in appels)
            {
                Console.WriteLine($"Appel met kleur: {a.Kleur}");
            }

            Appel appel = new Appel(Kleuren.GROEN);
            Peer peer = new Peer(100);
            Console.WriteLine($"\nEen appel is {(appel.Equals(peer) ? "wel" : "niet")} te vergelijken met een peer");

            List<Peer> peren = new() { new Peer(200), new Peer(100), new Peer(500) };
            Console.WriteLine("\nOngesorteerde peren:");
            foreach (Peer p in peren)
            {
                Console.WriteLine($"Peer met gewicht: {p.Gewicht}");
            }

            peren.Sort(new GewichtVergelijker());
            Console.WriteLine("\nGesorteerde peren:");
            foreach (Peer p in peren)
            {
                Console.WriteLine($"Peer met gewicht: {p.Gewicht}");
            }
        }
    }
}
