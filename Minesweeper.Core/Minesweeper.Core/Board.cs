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
                    Cells[x, y].Sweep(this, x, y);//add 1 to all adjacent cells' mine counts
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
                    Cells[x, y].Sweep(this, x, y);//add 1 to all adjacent cells' mine counts
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
                    Cells[x, y].Sweep(this, x, y);//add 1 to all adjacent cells' mine counts
                }
            }
        }
        /// <summary>
        /// Displays the board and all cells
        /// </summary>
        public void ShowBoard()
        {
            int display = 0;//set the top left number to 0
            while (display <= (int)Size)
            {
                if (display == 1)
                {
                    Console.Write("| ");//formatting
                }
                Console.Write($"{display}");//print each number on the top row
                display++;
            }
            Console.WriteLine();//formatting

            display = 1;
            for (int y = 0; y < (int)Size; y++)
            {
                Console.Write($"{display}| "); //make sure to print a number on each row before showing the cells
                if (display < 10)
                {
                    Console.Write(" ");
                } //formatting for double digit numbers
                display++;
                for (int x = 0; x < (int)Size; x++)
                {
                    Console.Write(Cells[x, y].ToString());//makes sure to show the cell's current state
                }
                Console.WriteLine();//make a new line after each row
            }
        }
        /// <summary>
        /// Search all adjacent spots around a mine
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Search(Board board, int x, int y)
        {
            if (board.Cells[x, y].isRevealed || board.Cells[x, y].isFlagged || board.Cells[x, y].isMine)
            {
                //if the cell is already revealed or flagged, don't touch it
                return;
            }

            board.Cells[x, y].isRevealed = true;

            if (board.Cells[x, y].adjacentMines > 0)
            {
                //if the cell has mines next to it, don't kill the player
                return;
            }

            //disclaimer: AI helped with this section. I was struggling to find a way to do it nicely without 
            //manually writing each x+1 and the like
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0)
                    {
                        continue; // don't search self
                    }

                    int nx = x + dx; //calculate the new x and y coordinates for the adjacent cell
                    int ny = y + dy; //and make sure to search it

                    if (nx >= 0 && nx < (int)board.Size && ny >= 0 && ny < (int)board.Size)
                    {
                        //stay in bounds
                        Search(board, nx, ny); // recursive call to find all of them
                    }
                }
            }
        }
    }
}