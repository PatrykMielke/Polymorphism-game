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
        public Soldier(Form form, bool isShootingLeft) : base(ConstructorProperties())
        {
            movementSpeed = 15;
            this.form = form;
            BackColor = Color.RosyBrown;
            form.Controls.Add(this);
            Size = new Size(40,60);
            this.isShootingLeft = isShootingLeft;
            moveForward = true;
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
        private static int[] ConstructorProperties()
        {
            Random random = new Random();
            top = 420;
            left = 780;
            movementInterval = random.Next(90,110);
            attackInterval = random.Next(2000, 2200);
            int[] result = new int[] { top, left, movementInterval, attackInterval };
            return result;
        }
    }
}
