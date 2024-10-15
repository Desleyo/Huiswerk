namespace Memory_Business
{
    public class MemoryService
    {
        private const int MAX_HIGHSCORES = 10;

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
            return highscores.Count < MAX_HIGHSCORES || currentScore > highscores[highscores.Count - 1].Score;
        }

        public void InsertNewHighscore(Highscore highscore)
        {
            //Make sure the names aren't too long
            if(highscore.Name.Length > 15)
            {
                highscore.Name = highscore.Name.Substring(0, 15);
            }

            List<Highscore> tempScores = repository.GetAll().ToList();

            //If there are no highscores then we may skip the checks below
            if (tempScores.Count == 0)
            {
                tempScores.Insert(0, highscore);
                repository.Insert(tempScores);
                return;
            }

            for (int i = 0; i < tempScores.Count; i++)
            {
                //Insert into the correct position,
                if (highscore.Score > tempScores[i].Score)
                {
                    tempScores.Insert(i, highscore);
                    break;
                }
                //or insert into the bottom of the list
                else if (i == tempScores.Count - 1)
                {
                    tempScores.Insert(tempScores.Count, highscore);
                    break;
                }
            }

            //Make sure the highscores list doesn't exceed the limit of MAX_HIGHSCORES (probably 10)
            while (tempScores.Count > MAX_HIGHSCORES)
            {
                tempScores.RemoveAt(tempScores.Count - 1);
            }

            repository.Insert(tempScores);
        }
    }
}
