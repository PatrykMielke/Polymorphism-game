using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruspki1
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal class Bomb : PictureBox
    {
        readonly Form form;
        Timer bombTimer = new Timer();
        public Bomb(Form form, Point startingPoint)
        {
            this.form = form;
            Location = startingPoint;
            BackColor = Color.Red;
            Size = new Size(40,40);
            Tag = "RIP";

            form.Controls.Add(this);

            bombTimer.Interval = 100;
            bombTimer.Tick += AttackMove;
            bombTimer.Start();

        }
        private void AttackMove(object sender, EventArgs e)
        {
            if (Top >= 440)
            {
                form.Controls.Remove(this);
                bombTimer.Dispose();
            }
            Top += 10;
        }
    }
}
