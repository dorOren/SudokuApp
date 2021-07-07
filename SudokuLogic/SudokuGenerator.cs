using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    public class SudokuGenerator
    {
        public SudokuSolver Solver { get; }
        public GameLogic Game { get; }
        public Board GameBoard { get; }
        public Random rand { get; }
        public int BoardSideSize { get; }
        public int BlockSideSize { get; }

        public SudokuGenerator(int i_BoardSideSize)
        {
            rand = new Random();
            Solver = new SudokuSolver(i_BoardSideSize);
            Game = Solver.Game;
            GameBoard = Game.GameBoard;
            BoardSideSize = Game.GameBoard.BoardSideSize;
            BlockSideSize = (int)Math.Sqrt((double)BoardSideSize);
        }

        public int[,] GenerateRandomBoard()
        {
            // Fill 3 blocks of the main diagonal with valid values in random order
            // Then fill all cells in the Sudoku board (=solve the game)
            // Delete k values to leave a solvable board
            for (int i = 0; i < BoardSideSize; i++)
            {
                int tempRow = i;                                                      // In a 9x9 board will get values of 1-9
                for (int j=0; j < 3; j++)
                {
                    int tempCol = (tempRow/3)*BlockSideSize+j;                        // In a 9x9 board will get value sets of 0-2, 3-5, 6-8
                    int randomVal = rand.Next(1, BoardSideSize + 1);
                    while (Game.IsThereCollisions(tempRow, tempCol, randomVal))
                    {
                        randomVal = rand.Next(1, BoardSideSize + 1);
                    }
                    GameBoard.GameBoard[tempRow, tempCol] = randomVal;
                }
            }

            if (Solver.solve())
            {
                int numberToBeDeleted = BoardSideSize * 5 + rand.Next(0, BoardSideSize) + rand.Next(BlockSideSize, BoardSideSize);
                for (int k = 0; k < numberToBeDeleted; k++)
                {
                    int randomColIndex = rand.Next(0, BoardSideSize);
                    int randomRowIndex = rand.Next(0, BoardSideSize);
                    while (GameBoard.IsEmpty(randomRowIndex, randomColIndex))   // If already been deleted-> look for another
                    {
                        randomColIndex = rand.Next(0, BoardSideSize);
                        randomRowIndex = rand.Next(0, BoardSideSize);
                    }
                    GameBoard.GameBoard[randomRowIndex, randomColIndex] = 0;
                }
            }
            else
            {
                //ERROR
            }


            return GameBoard.GameBoard;
        }
    }
}
