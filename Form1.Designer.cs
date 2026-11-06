using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button buttonCell1;
        private Button buttonCell2;
        private Button buttonCell3;
        private Button buttonCell4;
        private Button buttonCell5;
        private Button buttonCell6;
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
            this.buttonCell1 = new Button();
            this.buttonCell2 = new Button();
            this.buttonCell3 = new Button();
            this.buttonCell4 = new Button();
            this.buttonCell5 = new Button();
            this.buttonCell6 = new Button();
            this.lblScore = new Label();
            this.btnNewGame = new Button();
            this.btnExit = new Button();
            this.lblTitle = new Label();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.Location = new Point(300, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "🐱 Pişik və Bomba 💣";

            ConfigureCell(this.buttonCell1, "buttonCell1", 70, 100, 0);
            ConfigureCell(this.buttonCell2, "buttonCell2", 290, 100, 1);
            ConfigureCell(this.buttonCell3, "buttonCell3", 510, 100, 2);
            ConfigureCell(this.buttonCell4, "buttonCell4", 70, 320, 3);
            ConfigureCell(this.buttonCell5, "buttonCell5", 290, 320, 4);
            ConfigureCell(this.buttonCell6, "buttonCell6", 510, 320, 5);

            this.lblScore.AutoSize = true;
            this.lblScore.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblScore.Location = new Point(75, 565);
            this.lblScore.Name = "lblScore";
            this.lblScore.Text = "Xal: 0";

            this.btnNewGame.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnNewGame.Location = new Point(270, 550);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new Size(190, 55);
            this.btnNewGame.Text = "Yeni oyun";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);

            this.btnExit.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnExit.Location = new Point(540, 550);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(150, 55);
            this.btnExit.Text = "Çıxış";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 248, 255);
            this.ClientSize = new Size(780, 650);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.buttonCell1);
            this.Controls.Add(this.buttonCell2);
            this.Controls.Add(this.buttonCell3);
            this.Controls.Add(this.buttonCell4);
            this.Controls.Add(this.buttonCell5);
            this.Controls.Add(this.buttonCell6);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Pişik və Bomba";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ConfigureCell(Button button, string controlName, int x, int y, int tag)
        {
            button.BackColor = Color.White;
            button.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            button.Location = new Point(x, y);
            button.Name = controlName;
            button.Size = new Size(190, 180);
            button.TabIndex = tag;
            button.Tag = tag;
            button.Text = "?";
            button.UseVisualStyleBackColor = false;
            button.Click += new System.EventHandler(this.Cell_Click);
        }
    }
}
