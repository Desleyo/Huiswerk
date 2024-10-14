using Memory_Business;

namespace Memory_DataAccess
{
    public class MemoryRepository : IRepository
    {
        private const string HIGHSCORES_DATA_PATH = @"Memory_DataAccess\HighscoresData.txt";
        private const int MAX_HIGHSCORES = 10;

        private ICollection<Highscore> highscores;

        public MemoryRepository()
        {
            highscores = new List<Highscore>();

            foreach (string line in File.ReadLines(GetPathToDatabase()))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] segments = line.Split(' ');

                highscores.Add(new Highscore() { Name = segments[0], Score = int.Parse(segments[1]), AmountOfCards = int.Parse(segments[2]) });
            }
        }

        //Uses the current directory to find the solution,
        //which is then used to find the database in the project
        private string GetPathToDatabase()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            List<string> directories = new List<string>(currentDirectory.Split('\\'));

            bool foundPath = false;
            while (!foundPath)
            {
                if (directories.Last().Contains("Memory"))
                {
                    foundPath = true;
                }

                directories.Remove(directories.Last());
            }

            string solutionPath = "";
            foreach (string directory in directories)
            {
                solutionPath += directory + @"\";
            }

            solutionPath += HIGHSCORES_DATA_PATH;

            return solutionPath;
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

            File.WriteAllLines(GetPathToDatabase(), lines);
        }
    }
}
