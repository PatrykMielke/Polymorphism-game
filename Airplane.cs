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
    internal class Airplane : Enemy
    {
        public Airplane(Form form) : base()
        {
            movementSpeed = 20;
            this.form = form;

            Top = 10;
            Left = 1000;

            BackColor = Color.Gray;
            form.Controls.Add(this);

            movementTimer.Interval = random.Next(90, 110);
            attackFrequencyTimer.Interval = random.Next(1100, 1300);

            movementTimer.Start();
            attackFrequencyTimer.Start();
        }

        public override void Attack(object sender, EventArgs args)
        {
            Point startingPoint = new Point(Left, Top);

            if (form.Controls.Contains(this))
            {
                Form1.characters.Add(new Bomb(form, startingPoint));
            }
        }

        public override void Move(object sender, EventArgs args)
        {
            if (Left < -40) form.Controls.Remove(this);
            Left -= movementSpeed;
        }
    }
}
