namespace Minesweeper.Core
{
    public class Cell
    {
        /// <summary>
        /// If the cell contains a mine
        /// </summary>
        public bool isMine;
        /// <summary>
        /// If the cell has been revealed
        /// </summary>
        public bool isRevealed;
        /// <summary>
        /// If the cell has a flag on it
        /// </summary>
        public bool isFlagged;
        /// <summary>
        /// The number of mines adjacent to the cell
        /// </summary>
        public int adjacentMines;
        /// <summary>
        /// The x coodinate on the plane where the cell is
        /// </summary>
        public int X;
        /// <summary>
        /// The y coordinate on the plane where the cell is
        /// </summary>
        public int Y;
        public Cell(int x, int y, bool isMine, bool isRevealed, bool isFlagged, int adjacentMines)
        {
            X = x;
            Y = y;
            this.isMine = isMine;
            this.isRevealed = isRevealed;
            this.isFlagged = isFlagged;
            this.adjacentMines = adjacentMines;
        }
        /// <summary>
        /// Returns the actual representation of the cell's current state
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //pretty intuitive, if conditions show what the cell should display to the console
            if (isFlagged)
            {
                return "F"; //flag
            }
            if (!isRevealed)
            {
                return "#"; //not is revealed = hidden
            }
            if (isMine && isRevealed)
            {
                return "b"; //that means you hit a bomb
            }
            if (adjacentMines > 0)
            {
                return adjacentMines.ToString(); //should return the number of mines, showing the number
            }
            else return "."; //blank cell
        }
        /// <summary>
        /// Adds 1 to the adjacentMines count of all adjacent cells
        /// </summary>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Sweep(Board board, int x, int y)
        {
            //add 1 to all adjacent cells' mine counts
            if (x - 1 > 0 && y - 1 > 0 && x + 1 < (int)board.Size && y + 1 < (int)board.Size)
            {
                //if all adjacent cells are in bounds, add 1 to all of them
                board.Cells[x - 1, y].adjacentMines++; //left
                board.Cells[x - 1, y - 1].adjacentMines++; //down left
                board.Cells[x - 1, y + 1].adjacentMines++; //up left
                board.Cells[x, y - 1].adjacentMines++; //down
                board.Cells[x, y + 1].adjacentMines++; //up
                board.Cells[x + 1, y].adjacentMines++; //right
                board.Cells[x + 1, y - 1].adjacentMines++; //down right
                board.Cells[x + 1, y + 1].adjacentMines++; //up right
            }
            else
            {
                //if some adjacent cells are out of bounds, check each one and only add 1 if it's in bounds
                if (x - 1 > 0)
                {
                    board.Cells[x - 1, y].adjacentMines++; //left
                    if (y - 1 > 0)
                    {
                        board.Cells[x - 1, y - 1].adjacentMines++; //down left
                    }
                    if (y + 1 < (int)board.Size)
                    {
                        board.Cells[x - 1, y + 1].adjacentMines++; //up left
                    }
                }
                if (y - 1 > 0)
                {
                    board.Cells[x, y - 1].adjacentMines++; //down
                }
                if (y + 1 < (int)board.Size)
                {
                    board.Cells[x, y + 1].adjacentMines++; //up
                }
                if (x + 1 < (int)board.Size)
                {
                    board.Cells[x + 1, y].adjacentMines++; //right
                    if (y - 1 > 0)
                    {
                        board.Cells[x + 1, y - 1].adjacentMines++; //down right
                    }
                    if (y + 1 < (int)board.Size)
                    {
                        board.Cells[x + 1, y + 1].adjacentMines++; //up right
                    }
                }
            }
        }
    }
}

