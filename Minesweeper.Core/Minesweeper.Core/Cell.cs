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
        /// <summary>
        /// The ID, that tells the GenerateBoard function how to build the board
        /// </summary>
        public int ID;
        public Cell(int x, int y, int id)
        {
            X = x;
            Y = y;
            ID = id;
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
        public int Search()
        {
            
            //do something to look for mines in the adjacent cells, and return adjacent mines
        }
        
    }
}
