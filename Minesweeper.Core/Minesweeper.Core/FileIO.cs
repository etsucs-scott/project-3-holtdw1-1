namespace Minesweeper.Core
{
    public class FileIO
    {
        /// <summary>
        /// The entire data string, delineated by a colon
        /// </summary>
        public string SaveData;
        /// <summary>
        /// The fastest completion time in seconds
        /// </summary>
        public int HighScore;
        /// <summary>
        /// Moves used during the run
        /// </summary>
        public int Moves;
        /// <summary>
        /// The seed that determined the mine placement
        /// </summary>
        public int Seed;
        /// <summary>
        /// The size of board used
        /// </summary>
        public Size Size;
        /// <summary>
        /// The relative file path of the save file 
        /// </summary>
        public string FilePath;
        /// <summary>
        /// Saves the game with data
        /// </summary>
        /// <param name="highScore"></param>
        /// <param name="moves"></param>
        /// <param name="seed"></param>
        /// <param name="size"></param>
        public void SaveGame(int highScore, int moves, int seed, Size size)
        {
            SaveData = $"hs_{highScore}:moves_{moves}:seed_{seed}:size_{size}";
            FilePath = "./Minesweeper_Save.txt";
            File.WriteAllText(FilePath, SaveData);
        }
        /// <summary>
        /// Loads the save file stored, if any
        /// </summary>
        /// <exception cref="InvalidDataException"></exception>
        public void LoadGame()
        {
            // Make sure the file exists
            if (string.IsNullOrEmpty(FilePath) || !File.Exists(FilePath))
            {
                return; // nothing to load, do nothing
            }

            string content = File.ReadAllText(FilePath);
            var parts = content.Split(':');//find the delimeter, and split

            if (parts.Length != 4)//if we don't get all the data, something is wrong
            {
                throw new InvalidDataException("Save file is invalid.");
            }

            try
            {
                HighScore = int.Parse(parts[0].Replace("hs_", ""));
                Moves = int.Parse(parts[1].Replace("moves_", ""));
                Seed = int.Parse(parts[2].Replace("seed_", ""));
                Size = (Size)Enum.Parse(typeof(Size), parts[3].Replace("size_", ""));
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Save file contains invalid data.", ex);
            }
        }
    }
}
