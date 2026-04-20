using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core
{
    internal class File
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
        public string SaveGame(int highScore, int moves, int seed, Size size)
        {
            return SaveData = $"hs_{highScore}:mvs_{moves}:sd_{seed}:sz_{size}"; 
        }
        public void LoadGame()
        {

        }
    }
}
