using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformGame
{
    internal abstract class Projectile : PictureBox
    {
        protected Timer projectileTimer = new Timer();

        protected Projectile()
        {
            Tag = "RIP";

            projectileTimer.Tick += AttackMove;
        }

        protected abstract void AttackMove(object sender, EventArgs e);
    }
}
