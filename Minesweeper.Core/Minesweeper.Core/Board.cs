namespace Minesweeper.Core
{
    public class Board
    {
        /// <summary>
        /// The cells on the board
        /// </summary>
        public Cell[,] Cells { get; set; }
        /// <summary>
        /// The size of the board (small 8x8, medium 12x12, or large 16x16)
        /// </summary>
        public Size Size { get; set; }
        /// <summary>
        /// The number of mines on the board (8x8 = 10, 12x12 = 25, 16x16 = 40)
        /// </summary>
        public int Mines { get; set; }
        /// <summary>
        /// The number that determines the mine placement
        /// </summary>
        public int Seed { get; set; } 
        /// <summary>
        /// Generates the board, taking in size, number of mines, and the seed
        /// </summary>
        /// <param name="size"></param>
        /// <param name="mines"></param>
        /// <param name="seed"></param>
        public void GenerateBoard(Size size, int mines, int seed)
        {
            if (size == Size.Small)
            {
                int ID = 0;
                for (int y = 0; y < 9; y++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        ID++;
                        Cell cell = new Cell(x, y, ID);
                    }
                }
            }
            if (size == Size.Medium)
            {
                Cell[,] Board = new Cell[12, 12];
                for (int y = 0; y < 13; y++)
                {
                    for (int x = 0; x < 13; x++)
                    {
                        //12x12
                    }
                }
            }
            if (size == Size.Large)
            {
                Cell[,] Board = new Cell[16, 16];
                for (int y = 0; y < 17; y++)
                {
                    for (int x = 0; x < 17; x++)
                    {
                        //16x16
                    }
                }
            }
        }
    }
}