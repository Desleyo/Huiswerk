using Week3B_Emmer.Enums;
using Week3B_Emmer.EventArguments;
using Week3B_Emmer.Models;

namespace Week3B_Emmer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test for oilbarrel:");
            Oilbarrel oilbarrel = new Oilbarrel();
            oilbarrel.AddObserver(ReadContainerEvent);
            Console.WriteLine($"Capacity = {oilbarrel.Capacity}");
            Console.WriteLine($"Content = {oilbarrel.Content}");

            Console.WriteLine("Added 159 to oilbarrel content");
            oilbarrel.Fill(159);
            Console.WriteLine($"Content = {oilbarrel.Content}");

            Console.WriteLine("Added 1 to oilbarrel content");
            oilbarrel.Fill(1);
            Console.WriteLine($"Content = {oilbarrel.Content}");

            Console.WriteLine("Removed 1 from oilbarrel content");
            oilbarrel.Empty(1);
            Console.WriteLine($"Content = {oilbarrel.Content}");

            Console.WriteLine("Removed content of oilbarrel");
            oilbarrel.Empty();
            Console.WriteLine($"Content = {oilbarrel.Content}");


            Console.WriteLine("\nTest for rainbarrel:");
            Rainbarrel rainbarrelSmall = new Rainbarrel(Capacities.SMALL);
            Rainbarrel rainbarrelMedium = new Rainbarrel(Capacities.MEDIUM);
            Rainbarrel rainbarrelLarge = new Rainbarrel(Capacities.LARGE);

            Console.WriteLine($"Capacity of small rainbarrel = {rainbarrelSmall.Capacity}");
            Console.WriteLine($"Capacity of medium rainbarrel = {rainbarrelMedium.Capacity}");
            Console.WriteLine($"Capacity of large rainbarrel = {rainbarrelLarge.Capacity}");

            Console.WriteLine($"Content of large rainbarrel = {rainbarrelLarge.Content}");
            rainbarrelLarge.Content = 100;
            Console.WriteLine("Added 100 to large rainbarrel content");
            Console.WriteLine($"Content of large rainbarrel = {rainbarrelLarge.Content}");


            Console.WriteLine("\nTest for bucket:");
            Bucket bucket1 = new Bucket(2501);
            Bucket bucket2 = new Bucket(- 1);
            bucket1.AddObserver(ReadContainerEvent);
            bucket2.AddObserver(ReadContainerEvent);
            Console.WriteLine($"Capacity of bucket 1 = {bucket1.Capacity}");
            Console.WriteLine($"Capacity of bucket 2 = {bucket2.Capacity}");

            Console.WriteLine("Added 6 to both bucket's content");
            bucket1.Fill(6);
            bucket2.Fill(6);
            Console.WriteLine($"Content of bucket 1 = {bucket1.Content}");
            Console.WriteLine($"Content of bucket 2 = {bucket2.Content}");

            Console.WriteLine("Combined both buckets into bucket 1");
            bucket1.CombineBuckets(bucket2);
            Console.WriteLine($"Content of bucket 1 = {bucket1.Content}");
            Console.WriteLine($"Content of bucket 2 = {bucket2.Content}");


            Console.WriteLine("\nTests for Events:");
            Bucket bucket3 = new Bucket();
            Bucket bucket4 = new Bucket();
            bucket3.AddObserver(ReadContainerEvent);
            bucket4.AddObserver(ReadContainerEvent);
            Console.WriteLine($"Capacity of bucket 3 = {bucket3.Capacity}");
            Console.WriteLine($"Capacity of bucket 4 = {bucket4.Capacity}");

            Console.WriteLine("Adding 12 to content of bucket 3");
            bucket3.Fill(12);
            Console.WriteLine("Adding 10 to content of bucket 3");
            bucket3.Fill(10);
            Console.WriteLine("Adding 15 to content of bucket 4");
            bucket4.Content = 15;

            Console.WriteLine("Setting both buckets content to 10");
            bucket3.Content = 10;
            bucket4.Content = 10;
            Console.WriteLine($"Content of bucket 3 = {bucket3.Content}");
            Console.WriteLine($"Content of bucket 4 = {bucket4.Content}");
            Console.WriteLine($"Combining both buckets into bucket 3");
            bucket3.CombineBuckets(bucket4);
            Console.WriteLine($"Content of bucket 3 = {bucket3.Content}");
            Console.WriteLine($"Content of bucket 4 = {bucket4.Content}");
        }

        public static void ReadContainerEvent(Object sender, EventArgs args)
        {
            if(args is OverflowedEventArgs overflowArgs)
            {
                Console.WriteLine($"Object of type {sender.GetType().Name} is overflowing with an amount of {overflowArgs.Amount}!");
            }
            else
            {
                Console.WriteLine($"Object of type {sender.GetType().Name} is full!");
            }
        }
    }
}
