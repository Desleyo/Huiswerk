using Emballage_inname.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

#region Initialisatie Flessen en Kratten

var flessen = new List<Fles>() {
    new Fles("Bron's Water"),
    new Fles("Mineraalwater"),
    new Fles("Bietensap", 500, 0.25M),
    new Fles("Bronwater met bubbels")
};


var perensapKrat = new Krat("Perensap");
for (int i = 0; i < 8; i++)
{
    perensapKrat.InPlaatsen(new Fles("Perensap", 300, 0.50M));
}

var kersensapKrat = new Krat("Kersensap");
for (int i = 0; i < 12; i++)
{
    kersensapKrat.InPlaatsen(new Fles("Kersensap"));
}
var kratten = new List<Krat>() {
    new Krat("Appelsap"),
    perensapKrat,
    new Krat("Appelsap met kiwi"),
    kersensapKrat,
    new Krat("Appelsap")
};

#endregion

#region Opgave 1

var nieuweStandaard1000mlFles = new Fles("Nieuwe fles");
var nieuwe300mlFles = new Fles("Nieuwe fles", 300, 0.50M);
var nieuwKrat = new Krat("Nieuw krat");

#endregion

#region Opgave 2

Console.WriteLine("\nOpgave 2:");

var limoensapKrat = new Krat("Limoensap");
limoensapKrat.Uitnemen(new Fles("..."));

#endregion

#region Opgave 3
Console.WriteLine("\nOpgave 3:");

var bon = new Bon("Supermarkt de buurt");
bon.Totaalbedrag = "\t€0.45";
bon.RegelToevoegen("Ranja\t€0.15");
bon.RegelToevoegen("Stroop\t€0.15");
bon.RegelToevoegen("Siroop\t€0.15");
new Scherm().Weergeven(bon);

#endregion

#region Opgave 4
Console.WriteLine("\nOpgave 4:");

var opslagruimte = new Opslagruimte(flessenCapaciteit: 15, krattenCapaciteit: 5);
var inleverAutomaat = new Inleverautomaat("Stadsboerderij 'duurzaam duurt'", opslagruimte);
kratten.ForEach(k => inleverAutomaat.Inleveren(k));
inleverAutomaat.Inleveren(new Krat("Krat te veel"));

#endregion

#region Opgave 5
Console.WriteLine("\nOpgave 5:");

var generiekeOpslagruimte = new GeneriekeOpslagruimte<Fles>();
generiekeOpslagruimte.Opslaan(new Fles("Mooie fles"));
generiekeOpslagruimte.Opslaan(new Fles("Een mooie flesje"));
generiekeOpslagruimte.Opslaan(new Fles("Niet zo'n mooie fles"));
generiekeOpslagruimte.Opslag.ForEach(k => Console.WriteLine(k.Beschrijving));
#endregion


#region Opgave 6
Console.WriteLine("\nOpgave 6:");

int aantalLegeKratten = opslagruimte.TelLegeKratten;
Console.WriteLine($"Aantal lege kratten: {aantalLegeKratten}");

#endregion


#region Opgave 7
Console.WriteLine("\nOpgave 7:");

flessen.ForEach(f => inleverAutomaat.Inleveren(f));
IEnumerable<string> waterFlessen = opslagruimte.ZoekFlessen("WaTeR");
Console.WriteLine("Gevonden flessen met de beschrijving 'WaTeR':");
foreach (string s in waterFlessen)
{
    Console.WriteLine($"- {s}");
}

#endregion

#region Opgave 8
Console.WriteLine("\nOpgave 8:");
Console.WriteLine("Rapportage flessen: ");

foreach (string s in opslagruimte.FlessenRapportage(opslagruimte.BeschrijvingMetBedrag))
{
    Console.WriteLine(s);
}

#endregion

Console.WriteLine("\nEINDE PROGRAMMA\n");