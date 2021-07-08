using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SudokuLogic;


namespace SudokuUI
{
    public class GameManager
    {
        public GameLogic Game { get; }
        public eAppState State { get; set; }

        public GameManager()
        {
            Game = new GameLogic(9);
            State = eAppState.Setting;
        }

        public void ShowSettingsForm()
        {
            GameSettings gameSettings = new GameSettings();
            gameSettings.ShowDialog();
            if (gameSettings.DialogResult == DialogResult.OK)
            {
                if (gameSettings.State.Equals(eAppState.SudokuGame))
                    ShowGameForm();
                else //gameSettings.State.Equals(eAppState.SudokuSolver)
                    ShowSolverForm();
            }
        }

        public void ShowGameForm()
        {
            GameForm gameForm = new GameForm();
            DialogResult res= gameForm.ShowDialog();
            if (res.Equals(DialogResult.Retry))
            {
                ShowSettingsForm();
            }
        }

        public void ShowSolverForm()
        {
            SolverForm solverForm = new SolverForm();
            DialogResult res = solverForm.ShowDialog();
            if (res.Equals(DialogResult.Retry))
                ShowSettingsForm();
        }
    }
}
