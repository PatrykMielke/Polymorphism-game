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
    internal class Soldier : Enemy
    {
        private bool isShootingLeft;
        private bool moveForward;
        public Soldier(Form form, bool isShootingLeft) : base()
        {
            this.form = form;
            this.isShootingLeft = isShootingLeft;
            movementSpeed = 15;

            Top = 420;
            Left = 780;

            BackColor = Color.RosyBrown;
            Size = new Size(40,60);

            form.Controls.Add(this);
            moveForward = true;


            movementTimer.Interval = random.Next(90, 110);
            attackFrequencyTimer.Interval = random.Next(2000, 2200);

            movementTimer.Start();
            attackFrequencyTimer.Start();

        }

        public override void Attack(object sender, EventArgs args)
        {
            Point startingPoint = new Point(Left, Top);

            if (form.Controls.Contains(this))
            {
                Form1.characters.Add(new Bullet(form, startingPoint, isShootingLeft));
            }
        }

        public override void Move(object sender, EventArgs args)
        {
            if (moveForward)
            {
                if (Left <= 760) moveForward = false;
                Left -= movementSpeed;
            }
            else
            {
                if(Left >= 780) moveForward = true;
                Left += movementSpeed;
            }
        }
    }
}
