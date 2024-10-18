namespace Emballage_inname.Models
{
    public class Scherm
    {
        public enum Weergave
        {
            Informatie,
            Waarschuwing
        }
        public void Weergeven(Weergave meldingSoort, string melding) 
        {
            Console.WriteLine("################ BEGIN MELDING ################");
            switch (meldingSoort)
            {
                case Weergave.Informatie:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(melding);
                    break;
                case Weergave.Waarschuwing:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"***{melding.ToUpper()}-STORING***");
                    break;
            }
            Console.ResetColor();
            Console.WriteLine("################ EINDE MELDING ################");
        }
        public void Weergeven(Bon bon) 
        {
            Console.WriteLine("################ BEGIN BON ################");
            foreach (var regel in bon.Regels ?? new string[0])
            {
                Console.WriteLine(regel);
            }
            Console.WriteLine("################ EINDE BON ################");
        }
    }
}
