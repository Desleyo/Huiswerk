using Memory_Business;

namespace Memory_DataAccess
{
    public class MemoryRepository : IRepository
    {
        private const string HIGHSCORES_DATA_PATH = "D:\\GitHub\\Huiswerk\\Memory_DataAccess\\HighscoresData.txt";
        private const int MAX_HIGHSCORES = 10;

        private ICollection<Highscore> highscores;

        public MemoryRepository()
        {
            highscores = new List<Highscore>();

            foreach (string line in File.ReadLines(HIGHSCORES_DATA_PATH))
            {
                string[] segments = line.Split(' ');

                highscores.Add(new Highscore() { Name = segments[0], Score = int.Parse(segments[1]), AmountOfCards = int.Parse(segments[2]) });
            }
        }

        public ICollection<Highscore> GetAll()
        {
            return highscores;
        }

        public void Insert(Highscore highscore)
        {
            List<Highscore> tempScores = highscores.ToList();

            //If there are no highscores then we may skip the checks below
            if(tempScores.Count == 0)
            {
                tempScores.Insert(0, highscore);
                highscores = tempScores;
                UpdateDatabase();
                return;
            }

            for (int i = 0; i < tempScores.Count; i++)
            {
                //Insert into the correct position,
                if(highscore.Score > tempScores[i].Score)
                {
                    tempScores.Insert(i, highscore);
                    break;
                }        
                //or insert into the bottom of the list
                else if(i == tempScores.Count - 1)
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

            highscores = tempScores;
            UpdateDatabase();
        }

        private void UpdateDatabase()
        {
            List<Highscore> tempScores = highscores.ToList();
            string[] lines = new string[highscores.Count];

            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = tempScores[i].ToString();
            }

            File.WriteAllLines(HIGHSCORES_DATA_PATH, lines);
        }
    }
}
