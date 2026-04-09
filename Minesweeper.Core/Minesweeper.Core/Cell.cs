namespace Minesweeper.Core
{
    internal class Cell
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
        public override string ToString()
        {
            if (isFlagged)
            {
                return "F";
            }
            if (!isRevealed)
            {
                return "#";
            }
            if (isMine)
            {
                return "b";
            }
            else return ".";
        }
    }
}
