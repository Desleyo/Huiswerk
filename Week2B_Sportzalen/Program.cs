namespace Week2B_Sportzalen
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] aantallen =
            {
                {1, 2, 14 },
                {5, 3, 44 },
                {1, 1, 18 }
            };

            Console.WriteLine($"In Mercurius zijn {aantallen[0, 0]} scheidsrechter(s), {aantallen[0, 1]} sportarts(en) en {aantallen[0, 2]} sporter(s) aanwezig. " +
                $"In Jupiter zijn {aantallen[1, 0]} scheidsrechter(s), {aantallen[1, 1]} sportarts(en) en {aantallen[1, 2]} sporter(s) aanwezig. " +
                $"In Mars zijn {aantallen[2, 0]} scheidsrechter(s), {aantallen[2, 1]} sportarts(en) en {aantallen[2, 2]} sporter(s) aanwezig.\n");

            aantallen[1, 1] -= 1;
            aantallen[1, 2] -= 2;

            Console.WriteLine("Uit Jupiter vertrekt 1 sportarts met 2 sporters.\n");

            Console.WriteLine($"In Mercurius zijn {aantallen[0, 0]} scheidsrechter(s), {aantallen[0, 1]} sportarts(en) en {aantallen[0, 2]} sporter(s) aanwezig. " +
                $"In Jupiter zijn {aantallen[1, 0]} scheidsrechter(s), {aantallen[1, 1]} sportarts(en) en {aantallen[1, 2]} sporter(s) aanwezig. " +
                $"In Mars zijn {aantallen[2, 0]} scheidsrechter(s), {aantallen[2, 1]} sportarts(en) en {aantallen[2, 2]} sporter(s) aanwezig.");
        }
    }
}
