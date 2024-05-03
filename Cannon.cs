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
        public Cannon(Form form) : base()
        {
            
            this.form = form;
            moveForward = true;
            movementSpeed = 5;


            BackColor = Color.Black;
            Size = new Size(90, 50);

            Top = 430;
            Left = 890;

            form.Controls.Add(this);

            movementTimer.Interval = 200;
            attackFrequencyTimer.Interval = random.Next(2900, 3000);

            movementTimer.Start();
            attackFrequencyTimer.Start();
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
            if (moveForward)
            {
                if (Left <= 880) moveForward = false;
                Left -= movementSpeed;
            }
            else
            {
                if (Left >= 890) moveForward = true;
                Left += movementSpeed;
            }
        }
    }
}
