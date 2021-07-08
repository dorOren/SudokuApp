using SudokuLogic;
using System;
using System.Windows.Forms;

namespace SudokuUI
{
    public partial class SolverForm : Form
    {
        public SudokuSolver Solver { get; }
        public GameLogic Game { get; }
        public Board GameBoard { get; }
        public int BoardSideSize { get; }

        private bool m_BackPressed;
        private int m_DeletedValue;
        private bool m_Solved;

        private TextBox[,] m_TextBoxMatrix;

        public SolverForm()
        {
            Solver = new SudokuSolver(9);
            Game = Solver.Game;
            GameBoard = Game.GameBoard;
            BoardSideSize = Game.GameBoard.BoardSideSize;
            m_Solved = false;
            int height = BoardSideSize * 42 + 70;
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
            if (!isBoardValid())
            {
                m_Solved = true;
                errorForm();
            }
            if (!m_Solved && Solver.solve())
            {
                m_Solved = true;
                showSolvedBoard();
            }
            else if (m_Solved)
            {
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }
        }

        private bool isBoardValid()
        {
            foreach(TextBox textBox in m_TextBoxMatrix)
            {
                if (textBox.Text != "")
                {
                    (int rowNum, int colNum) = tagToIndexesHashFunction((int)textBox.Tag);
                    if (Game.IsThereCollisions(rowNum, colNum, int.Parse(textBox.Text.Remove(0, 1))))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void errorForm()
        {
            DialogResult result;
            string msg = "This Sudoku board is unsolvable!";
            string caption = $"ERROR!";
            result = MessageBox.Show(msg, caption, MessageBoxButtons.OK);
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
    }
}
