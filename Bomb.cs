using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruspki1
{
    internal class Bomb
    {
        readonly Form form;
        readonly PictureBox bomb = new PictureBox();
        readonly Timer bombTimer = new Timer();
        public Bomb(Form form, Point startingPoint)
        {
            this.form = form;
            bomb.Location = startingPoint;
            bomb.BackColor = Color.Red;
            bomb.Size = new Size(48,48);
            bomb.Tag = "RIP";
            form.Controls.Add(bomb);

            bombTimer.Interval = 100;
            bombTimer.Tick += AttackMove;
            bombTimer.Start();

        }
        private void AttackMove(object sender, EventArgs e)
        {
            if (bomb.Top >= 440)
            {
                form.Controls.Remove(bomb);
                bombTimer.Dispose();
            }
            bomb.Top += 10;
        }
    }
}
