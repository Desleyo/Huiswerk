namespace HatanDenNartog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var menu = new List<MenuItem>()
            // {
            //    new MenuItem("Hamburger",  562,  9.4,   2.5, false, true),
            //    new MenuItem("Milkshake",  344,   54,  0.51, true,  false),
            //    new MenuItem("Patat",      330,  0.4,  0.53, true,  false),
            //    new MenuItem("Vegaburger", 421,    7,   2.2, true,  true),
            //    new MenuItem("Salade",     137,  7.4,  0.66, false, true),
            //    new MenuItem("Dikke stront", 137, 5, 65, false, true)
            //};

            //var s1 = from item in menu
            //         where item.Zout < 1
            //         select item.Omschrijving;

            //var s2 = menu.Where(i => i.Zout < 1).Select(i => i.Omschrijving);

            //var s3 = from item in menu
            //         where item.Omschrijving == "Hamburger"
            //         select item.Omschrijving;

            //var s4 = menu.Where(i => i.Omschrijving == "Hamburger").Select(i => i.Omschrijving);

            //var s5 = from item in menu
            //         orderby item.Omschrijving
            //         select item.Omschrijving.ToUpper();

            //var s6 = menu.OrderBy(i => i.Omschrijving).Select(i => i.Omschrijving.ToUpper());

            //var s7 = from item in menu
            //         orderby item.KCal descending, item.Omschrijving
            //         select item.Omschrijving;

            //var s8 = menu.OrderByDescending(i => i.KCal).ThenBy(i => i.Omschrijving).Select(i => i.Omschrijving);

            //var s9 = from item in menu
            //         where item.Zout == menu.Max(i => i.Zout)
            //         select item.Omschrijving;

            //var s10 = menu.Where(i => i.Zout == menu.Max(i => i.Zout)).Select(i => i.Omschrijving);

            //var s11 = from item in menu
            //          where item.KCal == menu.Min(i => i.KCal)
            //          select item.Omschrijving;

            //var s12 = menu.Where(i => i.KCal == menu.Min(i => i.KCal)).Select(i => i.Omschrijving);

            //var s13 = from item in menu
            //          where item.Omschrijving.ToLower().Contains("burger")
            //          select item.Omschrijving;

            //var s14 = menu.Where(i => i.Omschrijving.ToLower().Contains("burger")).Select(i => i.Omschrijving);

            //foreach (var item in s14)
            //{
            //    Console.WriteLine(item);
            //}

            var broodbelegKeuze = new List<string>() { "ham", "kaas", "boter", "ei", "rosbief", "pindakaas", "hagelslag", "hazelnootpasta", "jam" };

            var s15 = from item in broodbelegKeuze
                      select new { item, item.Length };

            foreach ( var item in s15 )
            {
                Console.WriteLine(item);
            }
        }
    }
}
