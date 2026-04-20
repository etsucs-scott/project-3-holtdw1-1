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
        public int Seed { get; set; }
        public Board(Size size, int seed)
        {
            Size = size;
            Seed = seed;
            Cells = new Cell[0, 0]; //just make something so I can change it later without blowing up
        }
        /// <summary>
        /// Generates the board, taking in size, number of mines, and the seed
        /// </summary>
        /// <param name="size"></param>
        /// <param name="mines"></param>
        /// <param name="seed"></param>
        public void GenerateBoard(Size size)
        {
            if (size == Size.Small) 
            {
                Cells = new Cell[8, 8];//makes a 2d array of cells
                int ID = 0;//reset the cell id's
                for (int y = 0; y < 8; y++) //increment y0 to y7 (8 total)
                {
                    for (int x = 0; x < 8; x++)//increment x0 to x7 (8 total)
                    {
                        ID++;//increment the cell id for each cell, starting at 1 for readability
                        Cell cell = new Cell(x, y, ID);//make a new cell with the coordinates and id
                        Cells[x, y] = cell; //at position x, y in the array, place the new cell
                        //I should be able to use this type of indexing to change cell states
                    }
                }
            }
            //for the other two sizes, the process is the same
            if (size == Size.Medium)
            {
                Cells = new Cell[12, 12];
                int ID = 0;
                for (int y = 0; y < 12; y++)
                {
                    for (int x = 0; x < 12; x++)
                    {
                        ID++;
                        Cell cell = new Cell(x, y, ID);
                        Cells[x, y] = cell;
                    }
                }
            }
            if (size == Size.Large)
            {
                Cells = new Cell[16, 16];
                int ID = 0;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16 ; x++)
                    {
                        ID++;
                        Cell cell = new Cell(x, y, ID);
                        Cells[x, y] = cell;
                    }
                }
            }
        }
        public void PlaceMines(Board board, int seed)
        {
            //this makes the random algorithim work the same with the given seed
            Random random = new Random(seed);
            /* I don't know what to do with it, though
            The mine count should be small = 10, medium = 25, large = 40

            */
        }
    }
}