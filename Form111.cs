using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace WindowsFormsApp111
{
    public partial class Form111 : Form
    {
        private readonly Random random = new Random();
        private readonly Button[] cells;
        private int bombIndex;
        private int score;
        private bool gameOver;

        public Form111()
        {
            InitializeComponent();

            cells = new Button[]
            {
                buttonCell1, buttonCell2, buttonCell3,
                buttonCell4, buttonCell5, buttonCell6
            };

            StartNewGame();
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            if (gameOver) return;

            Button clickedCell = sender as Button;
            if (clickedCell == null || !clickedCell.Enabled) return;

            int index = Convert.ToInt32(clickedCell.Tag);
            clickedCell.Enabled = false;

            if (index == bombIndex)
            {
                clickedCell.Text = "💣";
                clickedCell.BackColor = Color.LightCoral;
                gameOver = true;

                SystemSounds.Exclamation.Play();

                MessageBox.Show(
                    "Oyun bitdi",
                    "Pişik və Bomba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            clickedCell.Text = "🐱";
            clickedCell.BackColor = Color.LightYellow;
            score++;
            lblScore.Text = "Xal: " + score;

            if (score == 5)
            {
                gameOver = true;

                MessageBox.Show(
                    "Oyunu qazandınız, Yeni oyun üçün ok düyməsinə basın",
                    "Təbriklər!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                StartNewGame();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartNewGame()
        {
            bombIndex = random.Next(0, 6);
            score = 0;
            gameOver = false;

            lblScore.Text = "Xal: 0";

            foreach (Button cell in cells)
            {
                cell.Text = "?";
                cell.Enabled = true;
                cell.BackColor = Color.White;
            }
        }
    }
}