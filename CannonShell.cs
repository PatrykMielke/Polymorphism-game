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
    internal class CannonShell : PictureBox
    {
        private Form form;
        Timer projectileTimer = new Timer();
        private Point startingPoint;
        private Point playerPos;

        public CannonShell(Form form, Point startingPoint, Point playerPos)
        {
            this.form = form;
            this.startingPoint = startingPoint;
            this.playerPos = playerPos;

            Location = startingPoint;
            BackColor = Color.Red;
            Size = new Size(20, 20);
            Tag = "RIP";

            form.Controls.Add(this);

            projectileTimer.Interval = 20;
            projectileTimer.Tick += AttackMove;
            projectileTimer.Start();
        }
        private void AttackMove(object sender, EventArgs e)
        {

            int stepX = ( playerPos.X - startingPoint.X ) / 30;
            int stepY = ( playerPos.Y - startingPoint.Y) / 30;

            Top += stepY;
            Left += stepX;

            if (Left < 0 || Left > 1000 || Top > 600 || Top < 0)
            {
                form.Controls.Remove(this);
                projectileTimer.Dispose();
            }
        }
    }
}
