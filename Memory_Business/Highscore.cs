namespace Memory_Business
{
    public class Highscore
    {
        public string? Name { get; set; }
        public int? Score { get; set; }
        public int? AmountOfCards { get; set; }

        public override string ToString()
        {
            return $"{Name} {Score} {AmountOfCards}";
        }
    }
}
