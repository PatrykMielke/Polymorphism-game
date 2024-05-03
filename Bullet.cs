using System;
using System.Drawing;
using System.Windows.Forms;
using WinformGame;

namespace Kruspki1
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal class Bullet : Projectile
    {
        private Form form;
        private Point startingPoint;
        private bool isShootingDirectionLeft;

        public Bullet(Form form, Point startingPoint, bool isDirectionLeft) : base()
        {
            this.form = form;
            this.startingPoint = startingPoint;
            isShootingDirectionLeft = isDirectionLeft;

            Location = startingPoint;
            BackColor = Color.Red;
            Size = new Size(20,10);

            form.Controls.Add(this);

            projectileTimer.Interval = 10;
            projectileTimer.Start();
        }
        protected override void AttackMove(object sender, EventArgs e)
        {
            if (isShootingDirectionLeft)
            {
                if (Left <= 0)
                {
                    form.Controls.Remove(this);
                    projectileTimer.Dispose();
                }
                Left -= 10;
            }
            else
            {
                if (Left >= 800)
                {
                    form.Controls.Remove(this);
                    projectileTimer.Dispose();
                }
                Left += 10;
            }
        }
    }
}