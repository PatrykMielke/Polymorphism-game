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
    internal class Cannon : Enemy
    {
        private bool moveForward;
        public Cannon(Form form) : base(ReturnInts())
        {
            movementSpeed = 15;
            this.form = form;
            moveForward = true;

            BackColor = Color.Black;
            Size = new Size(90, 50);

            form.Controls.Add(this);
        }

        public override void Attack(object sender, EventArgs args)
        {
            Point startingPoint = new Point(Left, Top);
            Point playerPos = TrackPlayersPosition();


            if (form.Controls.Contains(this))
            {
                Form1.characters.Add(new CannonShell(form, startingPoint, playerPos));
            }
        }
        public Point TrackPlayersPosition()
        {
            foreach (Control control in form.Controls)
            {
                if (control.Tag == "Player")
                {
                    return new Point(control.Location.X, control.Location.Y);
                }
            }
            return new Point(0, 0);
        }

        public override void Move(object sender, EventArgs args)
        {
            //throw new NotImplementedException();
        }
        private static int[] ReturnInts()
        {
            top = 430;
            left = 890;
            movementInterval = 100;
            attackInterval = 3000;
            int[] result = new int[] { top, left, movementInterval, attackInterval };
            return result;
        }
    }
}
