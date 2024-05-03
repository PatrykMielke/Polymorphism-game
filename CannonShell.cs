using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using System.Reflection.Emit;

namespace WinformGame
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal class CannonShell : Projectile
    {
        private Form form;
        private Point startingPoint;
        private Point playerPos;

        int stepX;
        int stepY;

        public CannonShell(Form form, Point startingPoint, Point playerPos) : base()
        {
            this.form = form;
            this.startingPoint = startingPoint;
            this.playerPos = playerPos;

            stepY = (playerPos.Y - startingPoint.Y) / 30;

            Location = startingPoint;
            BackColor = Color.Red;
            Size = new Size(20, 20);
            form.Controls.Add(this);

            projectileTimer.Interval = 20;
            projectileTimer.Start();
        }
        protected override void AttackMove(object sender, EventArgs e)
        {
            Top += stepY;
            Left -= 30;

            if (Left < 0 || Left > 1000 || Top > 600 || Top < 0)
            {
                form.Controls.Remove(this);
                projectileTimer.Dispose();
            }
        }
    }
}
