namespace Oefening_Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Model model = new Model();

            ThreeDimensionalViewer scherm1 = new ThreeDimensionalViewer(model) { Name = "scherm1"};
            ThreeDimensionalViewer scherm2 = new ThreeDimensionalViewer(model) { Name = "scherm2" };
            ThreeDimensionalViewer scherm3 = new ThreeDimensionalViewer(model) { Name = "scherm3" };

            model.Getal = 4;
        }
    }
}
