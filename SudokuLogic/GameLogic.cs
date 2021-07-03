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

        public bool AddCollisions(int i_RowNum, int i_ColNum, int i_Value)
        {
            // Count collision of given cell in board with its neighbors from the same row/column/block
            // Number of collisions is stored in all cells affected from the new cell in GameBoard.CollisionBoard
            // Function returs true if any collision was found, else returns false
            int blockSideSize =GameBoard.BlockSideSize;
            return RowCollisions(i_RowNum, i_ColNum, i_Value, eCollisionAction.Add) ||
                   ColCollisions(i_RowNum,i_ColNum, i_Value, eCollisionAction.Add) ||
                   BlockCollisions(i_RowNum - i_RowNum % blockSideSize, i_ColNum - i_ColNum % blockSideSize, i_RowNum,i_ColNum, i_Value, eCollisionAction.Add);
        }

        public bool DeleteCollisions(int i_RowNum, int i_ColNum, int i_Value)
        {
            // Decrease collision count of all cells that were affected from the cell to be removed
            // The count decreases from each affected cell in GameBoard.CollisionBoard
            // Function returs true if a decrement action was done, else returns false
            int blockSideSize = GameBoard.BlockSideSize;
            return RowCollisions(i_RowNum, i_ColNum, i_Value, eCollisionAction.Delete) ||
                   ColCollisions(i_RowNum, i_ColNum, i_Value, eCollisionAction.Delete) ||
                   BlockCollisions(i_RowNum - i_RowNum % blockSideSize, i_ColNum - i_ColNum % blockSideSize, i_RowNum, i_ColNum, i_Value, eCollisionAction.Delete);
        }

        private bool RowCollisions(int i_RowNum, int i_ColNum, int i_Value, eCollisionAction i_Action)
        {
            bool collisions = false;
            int boardSideSize = GameBoard.BoardSideSize;
            for (int i = 0; i < boardSideSize; i++)
            {
                if (GameBoard.GameBoard[i_RowNum, i] == i_Value &&i!=i_ColNum)
                {
                    if (i_Action.Equals(eCollisionAction.Add))
                    {
                        GameBoard.CollisionBoard[i_RowNum, i] += 1;
                        GameBoard.CollisionBoard[i_RowNum, i_ColNum] += 1;
                    }
                    else //i_Action.Equals(eCollisionAction.Delete
                    {
                        GameBoard.CollisionBoard[i_RowNum, i] -= 1;
                        GameBoard.CollisionBoard[i_RowNum, i_ColNum] -= 1;
                    }
                    collisions = true;
                }
            }
            return collisions;
        }

        private bool ColCollisions(int i_RowNum, int i_ColNum, int i_Value, eCollisionAction i_Action)
        {
            bool collisions = false;
            int boardSideSize = GameBoard.BoardSideSize;
            for (int i = 0; i < boardSideSize; i++)
            {
                if (GameBoard.GameBoard[i, i_ColNum] == i_Value && i!=i_RowNum)
                {
                    if (i_Action.Equals(eCollisionAction.Add))
                    {
                        GameBoard.CollisionBoard[i, i_ColNum] += 1;
                        GameBoard.CollisionBoard[i_RowNum, i_ColNum] += 1;
                    }
                    else //i_Action.Equals(eCollisionAction.Delete
                    {
                        GameBoard.CollisionBoard[i, i_ColNum] -= 1;
                        GameBoard.CollisionBoard[i_RowNum, i_ColNum] -= 1;
                    }
                    collisions = true;
                }
            }
            return collisions;
        }

        private bool BlockCollisions(int i_RowStart, int i_ColStart, int i_RowNum, int i_ColNum, int i_Value, eCollisionAction i_Action)
        {
            bool collisions = false;
            int blockSideSize = GameBoard.BlockSideSize;
            for (int i = 0; i < blockSideSize; i++)
            {
                for (int j = 0; j < blockSideSize; j++)
                {
                    if (GameBoard.GameBoard[i_RowStart + i, i_ColStart + j] == i_Value &&
                        (i_RowStart + i) != i_RowNum && 
                        (i_ColStart + j) != i_ColNum)
                    {
                        if (i_Action.Equals(eCollisionAction.Add))
                        {
                            GameBoard.CollisionBoard[i_RowStart + i, i_ColStart + j] += 1;
                            GameBoard.CollisionBoard[i_RowNum, i_ColNum] += 1;
                        }
                        else //i_Action.Equals(eCollisionAction.Delete
                        {
                            GameBoard.CollisionBoard[i_RowStart + i, i_ColStart + j] -= 1;
                            GameBoard.CollisionBoard[i_RowNum, i_ColNum] -= 1;
                        }
                        collisions = true;
                    }
                }
            }
            return collisions;
        }

        private enum eCollisionAction
        {
            Add,
            Delete
        }
    }
}
