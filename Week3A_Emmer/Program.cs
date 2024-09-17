namespace Week3A_Emmer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test for oilbarrel:");
            Oilbarrel oilbarrel = new Oilbarrel();
            Console.WriteLine($"Capacity = {oilbarrel.GetCapacity()}");
            Console.WriteLine($"Content = {oilbarrel.GetContent()}");

            oilbarrel.Fill(159);
            Console.WriteLine("Added 159 to oilbarrel content");
            Console.WriteLine($"Content = {oilbarrel.GetContent()}");

            oilbarrel.Fill(1);
            Console.WriteLine("Added 1 to oilbarrel content");
            Console.WriteLine($"Content = {oilbarrel.GetContent()}");

            oilbarrel.Empty(1);
            Console.WriteLine("Removed 1 from oilbarrel content");
            Console.WriteLine($"Content = {oilbarrel.GetContent()}");

            oilbarrel.Empty();
            Console.WriteLine("Removed content of oilbarrel");
            Console.WriteLine($"Content = {oilbarrel.GetContent()}");

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Test for rainbarrel:");
            Rainbarrel rainbarrelSmall = new Rainbarrel(Capacities.SMALL);
            Rainbarrel rainbarrelMedium = new Rainbarrel(Capacities.MEDIUM);
            Rainbarrel rainbarrelLarge = new Rainbarrel(Capacities.LARGE);

            Console.WriteLine($"Capacity of small rainbarrel = {rainbarrelSmall.GetCapacity()}");
            Console.WriteLine($"Capacity of medium rainbarrel = {rainbarrelMedium.GetCapacity()}");
            Console.WriteLine($"Capacity of large rainbarrel = {rainbarrelLarge.GetCapacity()}");

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Test for bucket");
            Bucket bucket1 = new Bucket(1300);
            Bucket bucket2 = new Bucket(2501);
            Console.WriteLine($"Capacity of bucket 1 = {bucket1.GetCapacity()}");
            Console.WriteLine($"Capacity of bucket 2 = {bucket2.GetCapacity()}");

            bucket1.Fill(10);
            bucket2.Fill(10);
            Console.WriteLine("Added 10 to both bucket's content");
            Console.WriteLine($"Content of bucket 1 = {bucket1.GetContent()}");
            Console.WriteLine($"Content of bucket 2 = {bucket2.GetContent()}");

            bucket1.CombineBucket(bucket2);
            Console.WriteLine("Combined both buckets into bucket 1");
            Console.WriteLine($"Content of bucket 1 = {bucket1.GetContent()}");
            Console.WriteLine($"Content of bucket 2 = {bucket2.GetContent()}");
        }
    }
}
