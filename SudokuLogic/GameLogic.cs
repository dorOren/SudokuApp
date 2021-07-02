using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    public class GameLogic
    {
        public Board GameBoard { get; }

        public GameLogic()
        {
            GameBoard = new Board();
        }

        public void StartGame()
        {
            GameBoard.SetBoardToStartPosition();
        }

    }
}
