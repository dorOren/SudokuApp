using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLogic
{
    public class Board
    {
        public int[,] GameBoard { get; }
        public int[,] CollisionBoard { get; }
        public DefaultBoards BoardsSets { get; }
        public int BoardSideSize { get; }
        public int BlockSideSize { get; }
        public int EmptyCells { get; set; }
        public int CollisionCases { get; set; }

        public Board()
        {
            BoardsSets = new DefaultBoards();
            EmptyCells = 81;
            CollisionCases = 0;
            BoardSideSize = 9;
            BlockSideSize = 3;
            GameBoard = new int[BoardSideSize, BoardSideSize];
            CollisionBoard = new int[BoardSideSize, BoardSideSize];
        }


        public void InitializeGameBoard()
        {
            // Initialize the board cells to empty state
            // A cell equals to 0 is considered empty, Sudoku game values goes from 1-9
            for (int i = 0; i < BoardSideSize; i++)
            {
                for (int j = 0; j < BoardSideSize; j++)
                {
                    GameBoard[i, j] = 0;
                    CollisionBoard[i, j] = 0;
                }
            }
        }

        public void SetBoardToStartPosition()
        {
            // Sets all cells to 0 (empty state),
            // Then takes a random game start set from "memory" -> and initiate starting cells with their values
            InitializeGameBoard();
            int randomIndex = BoardsSets.rand.Next(0, BoardsSets.BoardSetting.Count());
            List<MemoryCell> RandomSet = BoardsSets.BoardSetting[randomIndex];
            foreach(MemoryCell cell in RandomSet)
            {
                int RowIndex = cell.RowIndex;
                int ColIndex = cell.colIndex;
                MarkCell(RowIndex, ColIndex, cell.Value);
            }
        }

        public void ClearCell(int i_RowNum, int i_ColNum)
        {
            GameBoard[i_RowNum, i_ColNum] = 0;
            CollisionBoard[i_RowNum, i_ColNum] = 0;
            EmptyCells++;
        }

        public void MarkCell(int i_RowNum, int i_ColNum, int i_Value)
        {
            // If the cell is empty, the value is valid and the move is llegal,
            // Put requested value in cell
            if (IsEmpty(i_RowNum, i_ColNum) &&
                1 <= i_Value && i_Value <= BoardSideSize)
            {
                GameBoard[i_RowNum, i_ColNum] = i_Value;
                EmptyCells--;
            }
            //TODO:: ELSE ERROR
        }

        public bool IsEmpty(int i_RowNum, int i_ColNum)
        {
            if (GameBoard[i_RowNum, i_ColNum] == 0)
                return true;
            else return false;
        }

    }
}
