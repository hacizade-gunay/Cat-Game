
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp111
{
    partial class Form111
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;

        private Label lblScore;
        private Button btnNewGame;
        private Button btnExit;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.pictureBox3 = new PictureBox();
            this.pictureBox4 = new PictureBox();
            this.pictureBox5 = new PictureBox();
            this.pictureBox6 = new PictureBox();

            this.lblScore = new Label();
            this.btnNewGame = new Button();
            this.btnExit = new Button();
            this.lblTitle = new Label();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox1)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox2)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox3)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox4)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox5)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox6)).BeginInit();

            this.SuspendLayout();

            // Başlıq
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font =
                new Font("Segoe UI", 22F, FontStyle.Bold);

            this.lblTitle.ForeColor =
                Color.FromArgb(25, 43, 75);

            this.lblTitle.Location = new Point(245, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "Pişik və Bomba";

            // 6 PictureBox
            ConfigureCell(pictureBox1, "pictureBox1", 65, 95, 0);
            ConfigureCell(pictureBox2, "pictureBox2", 295, 95, 1);
            ConfigureCell(pictureBox3, "pictureBox3", 525, 95, 2);

            ConfigureCell(pictureBox4, "pictureBox4", 65, 315, 3);
            ConfigureCell(pictureBox5, "pictureBox5", 295, 315, 4);
            ConfigureCell(pictureBox6, "pictureBox6", 525, 315, 5);

            // Xal
            this.lblScore.AutoSize = true;
            this.lblScore.Font =
                new Font("Segoe UI", 18F, FontStyle.Bold);

            this.lblScore.ForeColor =
                Color.FromArgb(25, 43, 75);

            this.lblScore.Location = new Point(65, 555);
            this.lblScore.Name = "lblScore";
            this.lblScore.Text = "Xal: 0";

            // Yeni oyun düyməsi
            this.btnNewGame.Font =
                new Font("Segoe UI", 13F, FontStyle.Bold);

            this.btnNewGame.Location = new Point(280, 545);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new Size(190, 55);
            this.btnNewGame.Text = "Yeni oyun";

            this.btnNewGame.UseVisualStyleBackColor = true;

            this.btnNewGame.Click +=
                new System.EventHandler(this.btnNewGame_Click);

            // Çıxış düyməsi
            this.btnExit.Font =
                new Font("Segoe UI", 13F, FontStyle.Bold);

            this.btnExit.Location = new Point(535, 545);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(150, 55);
            this.btnExit.Text = "Çıxış";

            this.btnExit.UseVisualStyleBackColor = true;

            this.btnExit.Click +=
                new System.EventHandler(this.btnExit_Click);

            // Form
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;

            this.BackColor = Color.FromArgb(245, 248, 255);

            this.ClientSize = new Size(760, 635);

            this.Controls.Add(this.lblTitle);

            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);

            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox6);

            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnExit);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            this.Name = "Form111";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pişik və Bomba";

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox1)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox2)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox3)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox4)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox5)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox6)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // PictureBox parametrləri
        private void ConfigureCell(
            PictureBox pictureBox,
            string controlName,
            int x,
            int y,
            int tag)
        {
            pictureBox.BackColor = Color.White;

            pictureBox.BorderStyle =
                BorderStyle.FixedSingle;

            pictureBox.Location = new Point(x, y);
            pictureBox.Name = controlName;

            pictureBox.Size = new Size(190, 180);

            pictureBox.SizeMode =
                PictureBoxSizeMode.Zoom;

            pictureBox.TabIndex = tag;
            pictureBox.TabStop = false;
            pictureBox.Tag = tag;

            pictureBox.Cursor = Cursors.Hand;

            pictureBox.Click +=
                new System.EventHandler(this.Cell_Click);
        }
    }
}
