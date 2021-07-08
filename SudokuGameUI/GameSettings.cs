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
    public partial class GameSettings : Form
    {
        public eAppState State { get; set; }

        public GameSettings()
        {
            InitializeComponent();
        }

        private void generateGameButton_Click(object sender, EventArgs e)
        {
            State = eAppState.SudokuGame;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SudokuSolverButton_Click(object sender, EventArgs e)
        {
            State = eAppState.SudokuSolver;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
