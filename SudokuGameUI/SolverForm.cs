using SudokuLogic;
using System;
using System.Windows.Forms;

namespace SudokuUI
{
    public partial class SolverForm : Form
    {
        public GameLogic Game { get; }
        public Board GameBoard { get; }
        public int BoardSideSize { get; }

        private bool m_BackPressed;
        private int m_DeletedValue;
        private bool m_Solved;

        private TextBox[,] m_TextBoxMatrix;

        public SolverForm()
        {
            Game = new GameLogic();
            GameBoard = Game.GameBoard;
            BoardSideSize = 9;
            m_Solved = false;
            int height = BoardSideSize * 42 + 30;
            int width = BoardSideSize * 42 + 230;
            InitializeComponent(BoardSideSize, BoardSideSize, height, width);
        }

        // events
        private void textBox_Click(object sender, EventArgs args)
        {
            TextBox textBox = (TextBox)sender;
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void board_Load(object sender, EventArgs e)
        {
            startNewSolve();
        }

        private void startNewSolve()
        {
            GameBoard.InitializeGameBoard();
            foreach (TextBox textBox in m_TextBoxMatrix)
                textBox.Text = "";
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = $"{Environment.NewLine}Back to menu?";
            if (!m_Solved && Game.solve())
            {
                m_Solved = true;
                showSolvedBoard();
            }
            else if (m_Solved)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void showSolvedBoard()
        {
            foreach (TextBox textBox in m_TextBoxMatrix)
            {
                (int rowNum, int colNum) = tagToIndexesHashFunction((int)textBox.Tag);
                if (textBox.Text == "")
                {
                    textBox.Text = GameBoard.GameBoard[rowNum, colNum].ToString();
                    textBox.ForeColor = System.Drawing.Color.Maroon;
                }
            }
        }

        private (int rowNum, int colNum) tagToIndexesHashFunction(int i_Tag)
        {
            int colNum = i_Tag % GameBoard.BoardSideSize;
            int rowNum = i_Tag / GameBoard.BoardSideSize;
            return (rowNum, colNum);
        }

        private void textBox_TextChanged(object sender, EventArgs args)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length <= 1) //if only 1 digit entered
            {
                (int rowNum, int colNum) = tagToIndexesHashFunction((int)(textBox.Tag));
                bool isNumber = int.TryParse(textBox.Text, out int res);
                if (isNumber && res != 0)
                {
                    Game.MarkCell(rowNum, colNum, res);
                    textBox.Text = textBox.Text.Insert(0, " ");
                }
                else
                {
                    if (m_BackPressed)
                    {
                        Game.ClearCell(rowNum, colNum, m_DeletedValue);
                        m_BackPressed = false;
                    }
                    textBox.Clear();
                }
            }
        }

        private void textBox_KeyPressed(object sender, EventArgs args)
        {
            TextBox textBox = (TextBox)sender;
            KeyEventArgs keyPressed = (KeyEventArgs)args;
            if (keyPressed.KeyData == Keys.Back)
                textBox_DeleteText(textBox, keyPressed);
        }

        private void textBox_DeleteText(TextBox i_TextBox, KeyEventArgs i_KeyPressed)
        {
            if (i_TextBox.Text != "")
            {
                m_BackPressed = true;
                if (i_KeyPressed.KeyData == Keys.Back)
                {
                    m_DeletedValue = int.Parse(i_TextBox.Text.Remove(0, 1));
                }
            }
        }

        //

        // may delete

        //
        private bool solve(int[,] i_Board)
        {
            for (int i = 0; i < i_Board.GetLength(0); i++)
            {
                for (int j = 0; j < i_Board.GetLength(1); j++)
                {
                    if (i_Board[i, j] == 0)
                    {
                        for (int val = 1; val <= 9; val++)
                        {
                            if (isValid(i_Board, i, j, val))
                            {
                                i_Board[i, j] = val;

                                if (solve(i_Board))
                                    return true;
                                else
                                    i_Board[i, j] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isValid(int[,] i_Board, int i_RowNum, int i_ColNum, int i_Val)
        {
            for (int i = 0; i < 9; i++)
            {
                    //check row  
                if (i_Board[i, i_ColNum] != 0 && i_Board[i, i_ColNum] == i_Val)
                    return false;
                    //check column  
                if (i_Board[i_RowNum, i] != 0 && i_Board[i_RowNum, i] == i_Val)
                    return false;
                    //check 3*3 block  
                if (i_Board[3 * (i_RowNum / 3) + i / 3, 3 * (i_ColNum / 3) + i % 3] != 0 &&
                    i_Board[3 * (i_RowNum / 3) + i / 3, 3 * (i_ColNum / 3) + i % 3] == i_Val)
                    return false;
            }
            return true;
        }
    }
}
