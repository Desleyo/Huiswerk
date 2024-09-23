using Week3B_Emmer.Enums;
using Week3B_Emmer.Models;

namespace Week3A_Emmer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test for oilbarrel:");
            Oilbarrel oilbarrel = new Oilbarrel();
            Console.WriteLine($"Capacity = {oilbarrel.Capacity}");
            Console.WriteLine($"Content = {oilbarrel.Capacity}");

            oilbarrel.Fill(159);
            Console.WriteLine("Added 159 to oilbarrel content");
            Console.WriteLine($"Content = {oilbarrel.Content}");

            oilbarrel.Fill(1);
            Console.WriteLine("Added 1 to oilbarrel content");
            Console.WriteLine($"Content = {oilbarrel.Content}");

            oilbarrel.Empty(1);
            Console.WriteLine("Removed 1 from oilbarrel content");
            Console.WriteLine($"Content = {oilbarrel.Content}");

            oilbarrel.Empty();
            Console.WriteLine("Removed content of oilbarrel");
            Console.WriteLine($"Content = {oilbarrel.Content}");

            Console.WriteLine("\nTest for rainbarrel:");
            Rainbarrel rainbarrelSmall = new Rainbarrel(Capacities.SMALL);
            Rainbarrel rainbarrelMedium = new Rainbarrel(Capacities.MEDIUM);
            Rainbarrel rainbarrelLarge = new Rainbarrel(Capacities.LARGE);

            Console.WriteLine($"Capacity of small rainbarrel = {rainbarrelSmall.Capacity}");
            Console.WriteLine($"Capacity of medium rainbarrel = {rainbarrelMedium.Capacity}");
            Console.WriteLine($"Capacity of large rainbarrel = {rainbarrelLarge.Capacity}");

            Console.WriteLine("\nTest for bucket");
            Bucket bucket1 = new Bucket(1300);
            Bucket bucket2 = new Bucket(0);
            Console.WriteLine($"Capacity of bucket 1 = {bucket1.Capacity}");
            Console.WriteLine($"Capacity of bucket 2 = {bucket2.Capacity}");

            bucket1.Fill(10);
            bucket2.Fill(10);
            Console.WriteLine("Added 10 to both bucket's content");
            Console.WriteLine($"Content of bucket 1 = {bucket1.Content}");
            Console.WriteLine($"Content of bucket 2 = {bucket2.Content}");

            bucket1.CombineBucket(bucket2);
            Console.WriteLine("Combined both buckets into bucket 1");
            Console.WriteLine($"Content of bucket 1 = {bucket1.Content}");
            Console.WriteLine($"Content of bucket 2 = {bucket2.Content}");
        }
    }
}
