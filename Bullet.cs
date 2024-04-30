using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kruspki1
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal class Bullet : PictureBox
    {
        private Form form;
        Timer bulletTimer = new Timer();
        private Point startingPoint;
        private bool isShootingDirectionLeft;

        public Bullet(Form form, Point startingPoint, bool isDirectionLeft)
        {
            this.form = form;
            this.startingPoint = startingPoint;
            this.isShootingDirectionLeft = isDirectionLeft;

            Location = startingPoint;
            BackColor = Color.Red;
            Size = new Size(20,10);
            Tag = "RIP";

            form.Controls.Add(this);

            bulletTimer.Interval = 10;
            bulletTimer.Tick += AttackMove;
            bulletTimer.Start();
        }
        private void AttackMove(object sender, EventArgs e)
        {
            if (isShootingDirectionLeft)
            {
                if (Left <= 0)
                {
                    form.Controls.Remove(this);
                    bulletTimer.Dispose();
                }
                Left -= 10;
            }
            else
            {
                if (Left >= 800)
                {
                    form.Controls.Remove(this);
                    bulletTimer.Dispose();
                }
                Left += 10;
            }
        }
    }
}