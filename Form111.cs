
using System;
using System.Drawing;
using System.Media;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp111
{
    public partial class Form111 : Form
    {
        private readonly Random random = new Random();
        private PictureBox[] cells;

        private int bombIndex;
        private int score;
        private bool gameOver;

        private Bitmap questionImage;
        private Bitmap catImage;
        private Bitmap bombImage;

        private SoundPlayer explosionPlayer;

        public Form111()
        {
            InitializeComponent();

            cells = new PictureBox[]
            {
                pictureBox1, pictureBox2, pictureBox3,
                pictureBox4, pictureBox5, pictureBox6
            };

            questionImage = CreateImage("?");
            catImage = CreateImage("CAT");
            bombImage = CreateImage("BOMB");

            string soundPath = Path.Combine(
                Application.StartupPath, "boom.wav");

            if (File.Exists(soundPath))
            {
                try
                {
                    explosionPlayer = new SoundPlayer(soundPath);
                    explosionPlayer.Load();
                }
                catch
                {
                    explosionPlayer = null;
                }
            }

            StartNewGame();
        }

        // Sual işarəsi, pişik və bomba şəkillərinin yaradılması
        private Bitmap CreateImage(string type)
        {
            Bitmap bmp = new Bitmap(190, 180);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode =
                    System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                g.Clear(Color.White);

                if (type == "?")
                {
                    using (Font f = new Font(
                        "Segoe UI", 100, FontStyle.Bold))
                    using (Brush b = new SolidBrush(Color.RoyalBlue))
                    {
                        g.DrawString("?", f, b, 48, 5);
                    }
                }

                else if (type == "CAT")
                {
                    using (Brush fur =
                        new SolidBrush(Color.Orange))
                    using (Brush innerEar =
                        new SolidBrush(Color.LightPink))
                    using (Brush eyes =
                        new SolidBrush(Color.Black))
                    using (Pen outline =
                        new Pen(Color.SaddleBrown, 4))
                    {
                        Point[] leftEar =
                        {
                            new Point(48, 65),
                            new Point(52, 18),
                            new Point(88, 48)
                        };

                        Point[] rightEar =
                        {
                            new Point(102, 48),
                            new Point(138, 18),
                            new Point(142, 65)
                        };

                        g.FillPolygon(fur, leftEar);
                        g.FillPolygon(fur, rightEar);

                        g.DrawPolygon(outline, leftEar);
                        g.DrawPolygon(outline, rightEar);

                        g.FillEllipse(fur, 40, 40, 110, 110);
                        g.DrawEllipse(outline, 40, 40, 110, 110);

                        g.FillEllipse(innerEar, 58, 35, 17, 25);
                        g.FillEllipse(innerEar, 115, 35, 17, 25);

                        g.FillEllipse(eyes, 68, 83, 12, 16);
                        g.FillEllipse(eyes, 110, 83, 12, 16);

                        Point[] nose =
                        {
                            new Point(91, 108),
                            new Point(101, 108),
                            new Point(96, 116)
                        };

                        g.FillPolygon(Brushes.HotPink, nose);

                        g.DrawArc(outline, 78, 108, 18, 20, 0, 90);
                        g.DrawArc(outline, 96, 108, 18, 20, 90, 90);
                    }
                }

                else if (type == "BOMB")
                {
                    using (Brush black =
                        new SolidBrush(Color.FromArgb(35, 35, 45)))
                    using (Brush shine =
                        new SolidBrush(Color.Gray))
                    using (Pen fuse =
                        new Pen(Color.SaddleBrown, 9))
                    {
                        g.FillEllipse(black, 43, 48, 105, 105);

                        g.DrawLine(fuse, 115, 54, 139, 25);

                        g.FillEllipse(shine, 65, 68, 25, 15);

                        g.FillEllipse(
                            Brushes.OrangeRed, 132, 12, 22, 22);

                        g.FillEllipse(
                            Brushes.Gold, 138, 18, 10, 10);
                    }
                }
            }

            return bmp;
        }

        // Xana klikləndikdə
        private void Cell_Click(object sender, EventArgs e)
        {
            if (gameOver) return;

            PictureBox clickedCell = sender as PictureBox;

            if (clickedCell == null || !clickedCell.Enabled)
                return;

            int index = Convert.ToInt32(clickedCell.Tag);

            // Bomba tapıldıqda
            if (index == bombIndex)
            {
                clickedCell.Image = bombImage;
                clickedCell.BackColor = Color.LightCoral;

                gameOver = true;

                DisableAllCells();

                PlayExplosionSound();

                MessageBox.Show(
                    "Oyun bitdi",
                    "Pişik və Bomba",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                StartNewGame();
                return;
            }

            // Pişik tapıldıqda
            clickedCell.Image = catImage;
            clickedCell.BackColor = Color.LightYellow;
            clickedCell.Enabled = false;

            score++;

            lblScore.Text = "Xal: " + score;

            // 5 pişik tapıldıqda qələbə
            if (score == 5)
            {
                gameOver = true;

                DisableAllCells();

                MessageBox.Show(
                    "Oyunu qazandınız, Yeni oyun üçün ok düyməsinə basın",
                    "Təbriklər!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                StartNewGame();
                return;
            }

            // Hər təhlükəsiz klikdən sonra bomba yerini dəyişir
            MoveBomb();
        }

        // Bombanın yerini dəyişmək
        private void MoveBomb()
        {
            int[] available = Array.FindAll(
                new int[] { 0, 1, 2, 3, 4, 5 },
                i => cells[i].Enabled
            );

            if (available.Length > 0)
            {
                bombIndex = available[
                    random.Next(available.Length)];
            }
        }

        // Bütün xanaları deaktiv etmək
        private void DisableAllCells()
        {
            foreach (PictureBox cell in cells)
            {
                cell.Enabled = false;
                cell.BackColor = Color.LightGray;
            }
        }

        // Partlayış səsi
        private void PlayExplosionSound()
        {
            if (explosionPlayer != null)
            {
                try
                {
                    explosionPlayer.Play();
                }
                catch
                {
                    SystemSounds.Exclamation.Play();
                }
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }

        // Yeni oyun
        private void StartNewGame()
        {
            bombIndex = random.Next(0, 6);

            score = 0;
            gameOver = false;

            lblScore.Text = "Xal: 0";

            foreach (PictureBox cell in cells)
            {
                cell.Image = questionImage;
                cell.Enabled = true;
                cell.BackColor = Color.White;
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

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (explosionPlayer != null)
                explosionPlayer.Dispose();

            if (questionImage != null)
                questionImage.Dispose();

            if (catImage != null)
                catImage.Dispose();

            if (bombImage != null)
                bombImage.Dispose();

            base.OnFormClosed(e);
        }
    }
}
