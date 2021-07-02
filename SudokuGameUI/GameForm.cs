using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SudokuLogic;

namespace SudokuUI
{
    public partial class GameForm : Form
    {
        public GameLogic Game { get; }
        public Board GameBoard { get; }
        public int BoardSideSize { get; }

        private TextBox[,] m_TextBoxMatrix;

        public GameForm()
        {
            Game = new GameLogic();
            GameBoard = new Board();
            BoardSideSize = 9;
            int height = BoardSideSize * 42 + 30;
            int width = BoardSideSize * 42 + 100;
            InitializeComponent(BoardSideSize, BoardSideSize, height, width);
        }

        private void textBox_Click(object sender, EventArgs args)
        {
            
        }

        private void board_Load(object sender, EventArgs e)
        {
            GameBoard.SetBoardToStartPosition();
            for(int i=0;i< BoardSideSize; i++)
            {
                for(int j=0;j< BoardSideSize; j++)
                {
                    if (GameBoard.GameBoard[i, j] != 0)
                        m_TextBoxMatrix[i,j].Text = $"{GameBoard.GameBoard[i, j]}";
                }
            }
        }

        private void textBox_TextChanged(object sender, EventArgs args)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length <= 1)
            {
                if (int.TryParse(textBox.Text, out int res))
                {
                    //TODO:: need to check if valid
                    textBox.Text = textBox.Text.Insert(0, " ");
                }
                else
                {
                    textBox.Clear();
                }
            }
        }
    }
}
