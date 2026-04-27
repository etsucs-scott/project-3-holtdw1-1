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
        /// The number that determines the mine placement
        /// </summary>
        public int? Seed { get; set; }
        /// <summary>
        /// The amount of moves used
        /// </summary>
        public int Moves { get; set; }
        public string HighScoreScore { get; set; }
        public string HighScoreMoves { get; set; }
        public string HighScoreSeed { get; set; }
        //make an array of the past 5 highscores
        //new highscore class

        public Board(Size size, int? seed)
        {
            Size = size;
            Seed = seed;
            Cells = new Cell[0, 0]; //just make something so I can change it later without blowing up
        }
        /// <summary>
        /// Generates the board, taking in size, number of mines, and the seed
        /// </summary>
        public void GenerateBoard(Size Size)
        {
            int size = (int)Size;
            Cells = new Cell[size, size];//makes a 2d array of cells
            for (int y = 0; y < size; y++) //increment y0 to y7 (8 total)
            {
                for (int x = 0; x < size; x++)//increment x0 to x7 (8 total)
                {
                    Cell cell = new Cell(x, y, false, false, false, 0);//make a new cell with the coordinates and id
                    Cells[x, y] = cell; //at position x, y in the array, place the new cell
                                        //I should be able to use this type of indexing to change cell states
                }
            }
        }
        /// <summary>
        /// Places mines at random
        /// </summary>
        /// <param name="size"></param>
        /// <param name="seed"></param>
        public void PlaceMines(int size, int? seed)
        {
            int minesPlaced = 0;
            if (seed == null)
            {
                seed = DateTime.Now.Millisecond; //if the seed is null, just make something up
            }
            //this makes the random algorithim work the same with the given seed
            Random random = new Random((int)seed);

            if (size == 8)//small
            {
                while (minesPlaced < 11)//less than 11 is 10
                {
                    int x = random.Next(0, size);//a number from 0 to whatever size is
                    int y = random.Next(0, size);
                    while (Cells[x, y].isMine == true)//if the cell we check is a mine, go again until it ain't
                    {
                        x = random.Next(0, size);
                        y = random.Next(0, size);
                    }
                    Cells[x, y] = new Cell(x, y, true, false, false, 0);//make a new cell with isMine set to true
                    minesPlaced++;//increment
                }
            }
            if (size == 12)
            {
                while (minesPlaced < 26)
                {
                    int x = random.Next(0, size);
                    int y = random.Next(0, size);
                    while (Cells[x, y].isMine == true)
                    {
                        x = random.Next(0, size);
                        y = random.Next(0, size);
                    }
                    Cells[x, y] = new Cell(x, y, true, false, false, 0);
                    minesPlaced++;
                }
            }
            if (size == 16)
            {
                while (minesPlaced < 41)
                {
                    int x = random.Next(0, size);
                    int y = random.Next(0, size);
                    while (Cells[x, y].isMine == true)//if the cell we check is a mine, go again until it ain't
                    {
                        x = random.Next(0, size);
                        y = random.Next(0, size);
                    }
                    Cells[x, y] = new Cell(x, y, true, false, false, 0);
                    minesPlaced++;
                }
            }
        }

        public void ShowBoard()
        {
            int display = 0;
            while (display <= (int)Size)
            {
                Console.Write($"{display}");
                display++;
            }
            Console.WriteLine();
            display = 1;
            for (int y = 0; y < (int)Size; y++)
            {
                Console.Write($"{display}");
                display++;
                for (int x = 0; x < (int)Size; x++)
                {
                    Console.Write(Cells[x, y].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}