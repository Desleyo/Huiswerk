namespace Memory_Business
{
    public interface IRepository
    {
        ICollection<Highscore> GetAll();
        void Insert(List<Highscore> tempScores);
    }
}
