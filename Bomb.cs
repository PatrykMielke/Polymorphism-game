using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformGame;

namespace Kruspki1
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal class Bomb : Projectile
    {
        readonly Form form;
        public Bomb(Form form, Point startingPoint) : base()
        {
            this.form = form;
            Location = startingPoint;
            BackColor = Color.Red;
            Size = new Size(40,40);

            form.Controls.Add(this);

            projectileTimer.Interval = 100;
            projectileTimer.Start();

        }
        protected override void AttackMove(object sender, EventArgs e)
        {
            if (Top >= 440)
            {
                form.Controls.Remove(this);
                projectileTimer.Dispose();
            }
            Top += 10;
        }
    }
}
