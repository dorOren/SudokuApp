using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    public class SudokuSolver
    {
        public GameLogic Game { get; }
        public Board GameBoard { get; }

        public SudokuSolver(int i_BoardSideSize)
        {
            Game = new GameLogic(i_BoardSideSize);
            GameBoard = Game.GameBoard;
        }

        public bool solve()
        {
            for (int i = 0; i < GameBoard.BoardSideSize; i++)
            {
                for (int j = 0; j < GameBoard.BoardSideSize; j++)
                {
                    if (GameBoard.GameBoard[i, j] == 0)
                    {
                        for (int val = 1; val <= 9; val++)
                        {
                            if (!Game.IsThereCollisions(i, j, val))
                            {
                                GameBoard.GameBoard[i, j] = val;

                                if (solve())
                                    return true;
                                else
                                    GameBoard.GameBoard[i, j] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
