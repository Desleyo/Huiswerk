namespace Memory_Business
{
    public class MemoryService
    {
        private IRepository repository;

        public MemoryService(IRepository repository)
        {
            this.repository = repository;
        }

        public ICollection<Highscore> GetHighscores()
        {
            return repository.GetAll();
        }

        public bool CheckIfNewHighscore(int currentScore)
        {
            List<Highscore> highscores = repository.GetAll().ToList();

            //Scores always get added if we don't have 10 highscores yet,
            //otherwise the currentscore has to atleast beat the number 10 score
            return highscores.Count < 10 || currentScore > highscores[highscores.Count - 1].Score;
        }

        public void InsertNewHighscore(Highscore highscore)
        {
            repository.Insert(highscore);
        }
    }
}
