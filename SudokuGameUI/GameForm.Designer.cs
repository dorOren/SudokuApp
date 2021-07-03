
using System.Windows.Forms;

namespace SudokuUI
{
    public partial class GameForm
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

        private void InitializeComponent(int i_NumRows, int i_NumCols,int i_Height,int i_Width)
        {
            this.SuspendLayout();
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(i_Width, i_Height);
            this.Name = "GameForm";
            this.Text = "BoardForm";
            this.ResumeLayout(false);
            this.Load += new System.EventHandler(this.board_Load);
            generateTextBoxMatrix(i_NumRows, i_NumCols, i_Height, i_Width);
        }

        private void generateTextBoxMatrix(int i_NumRows, int i_NumCols, int i_Height, int i_Width)
        {
            m_TextBoxMatrix = new TextBox[i_NumRows, i_NumCols];
            int TextBoxNum = 0;
            for (int i = 0; i < i_NumRows; i++)
            {
                for (int j = 0; j < i_NumCols; j++)
                {
                    if (((i == 2) || (i == 5)) &&
                          i != 0 && j == 0)
                        generateHorizontalSeperator(i, j, i_Width);

                    if (((j == 3) || (j == 6)) &&
                          j != 0  &&  i == 0)
                        generateVerticalSeperator(i, j, i_Height);

                    m_TextBoxMatrix[i, j] = new TextBox();
                    TextBox textBox = m_TextBoxMatrix[i, j];
                    textBox.Location = new System.Drawing.Point(j * 42 + 10+40, i * 42 + 10);
                    textBox.Name = "button";
                    textBox.AutoSize = false;
                    textBox.Size = new System.Drawing.Size(40, 40);
                    textBox.Font = new System.Drawing.Font(textBox.Font.FontFamily, 23);
                    textBox.TabIndex = 0;
                    textBox.Tag = TextBoxNum;
                    textBox.TabStop = false;
                    textBox.MaxLength = 1;
                    textBox.Click += new System.EventHandler(this.textBox_Click);
                    textBox.TextChanged+= new System.EventHandler(this.textBox_TextChanged);
                    textBox.KeyDown+= new System.Windows.Forms.KeyEventHandler(this.textBox_KeyPressed);
                    TextBoxNum++;
                    this.Controls.Add(textBox);
                }
            }
        }

        private void generateHorizontalSeperator(int i_NumRows, int i_NumCols,int i_Width)
        {
            Label horizontalSeperator = new Label();
            horizontalSeperator.Text = "";
            horizontalSeperator.BackColor = System.Drawing.Color.DimGray;
            horizontalSeperator.Size = new System.Drawing.Size(i_Width - 102, 1);
            horizontalSeperator.Location = new System.Drawing.Point(i_NumCols * 42 + 10 + 40, i_NumRows * 42 + 51);
            this.Controls.Add(horizontalSeperator);
            Label horizontalSeperator2 = new Label();
            horizontalSeperator2.Text = "";
            horizontalSeperator2.BackColor = System.Drawing.Color.DimGray;
            horizontalSeperator2.Size = new System.Drawing.Size(i_Width - 102, 1);
            horizontalSeperator2.Location = new System.Drawing.Point(i_NumCols * 42 + 10 + 40, i_NumRows * 42 + 48);
            this.Controls.Add(horizontalSeperator2);
        }

        private void generateVerticalSeperator(int i_NumRows, int i_NumCols, int i_Height)
        {
            Label verticalSeperator = new Label();
            verticalSeperator.Text = "";
            verticalSeperator.BackColor = System.Drawing.Color.DimGray;
            verticalSeperator.Size = new System.Drawing.Size(1, i_Height - 32);
            verticalSeperator.Location = new System.Drawing.Point(i_NumCols * 42 + 10 + 41, i_NumRows * 42 + 10);
            this.Controls.Add(verticalSeperator);
            Label verticalSeperator2 = new Label();
            verticalSeperator2.Text = "";
            verticalSeperator2.BackColor = System.Drawing.Color.DimGray;
            verticalSeperator2.Size = new System.Drawing.Size(1, i_Height - 32);
            verticalSeperator2.Location = new System.Drawing.Point(i_NumCols * 42 + 10 + 38, i_NumRows * 42 + 10);
            this.Controls.Add(verticalSeperator2);
        }

        #endregion

    }
}