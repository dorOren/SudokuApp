
namespace SudokuUI
{
    public partial class GameSettings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.GenerateGameButton = new System.Windows.Forms.Button();
            this.SudokuSolverButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sudoku Game / Solver";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GenerateGameButton
            // 
            this.GenerateGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.GenerateGameButton.Location = new System.Drawing.Point(31, 93);
            this.GenerateGameButton.Name = "GenerateGameButton";
            this.GenerateGameButton.Size = new System.Drawing.Size(378, 56);
            this.GenerateGameButton.TabIndex = 1;
            this.GenerateGameButton.Text = "Generate Sudoku Board";
            this.GenerateGameButton.UseVisualStyleBackColor = true;
            this.GenerateGameButton.TabStop = false;
            this.GenerateGameButton.Click += new System.EventHandler(this.generateGameButton_Click);
            // 
            // SudokuSolverButton
            // 
            this.SudokuSolverButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SudokuSolverButton.Location = new System.Drawing.Point(31, 171);
            this.SudokuSolverButton.Name = "SudokuSolverButton";
            this.SudokuSolverButton.Size = new System.Drawing.Size(378, 56);
            this.SudokuSolverButton.TabIndex = 1;
            this.SudokuSolverButton.Text = "Sudoku Solver";
            this.SudokuSolverButton.UseVisualStyleBackColor = true;
            this.SudokuSolverButton.TabStop = false;
            this.SudokuSolverButton.Click += new System.EventHandler(this.SudokuSolverButton_Click);
            // 
            // GameSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 294);
            this.Controls.Add(this.SudokuSolverButton);
            this.Controls.Add(this.GenerateGameButton);
            this.Controls.Add(this.label1);
            this.Name = "GameSetting";
            this.Text = "Sudoku Madness";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GenerateGameButton;
        private System.Windows.Forms.Button SudokuSolverButton;
    }
}