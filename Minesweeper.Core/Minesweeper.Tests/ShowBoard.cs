using Minesweeper.Core;
using Xunit;
using System.IO;

namespace Minesweeper.Tests
{
    public class ShowBoard
    {
        [Fact]
        public void ShowBoard_Test()
        {
            //
            var board = new Board(Size.Small, 1);
            board.GenerateBoard(Size.Small);

            var exception = Record.Exception(() => board.ShowBoard());

            Assert.Null(exception);
        }
    }
}