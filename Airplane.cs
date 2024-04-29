using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruspki1
{
    internal class Airplane : Enemy
    {
        public Airplane(Form form) : base(GetAirplaneProperties())
        {
            movementSpeed = 20;
            this.form = form;
            BackColor = Color.Gray;
            form.Controls.Add(this);
        }

        public override void Attack(object sender, EventArgs args)
        {
            Point startingPoint = new Point(Left, Top);
            // form.Controls.Add( new Bomb(form,startingPoint) );
            Form1.enemies.Add(new Bomb(form, startingPoint));
        }

        public override void Move(object sender, EventArgs args)
        {
            if (Left < -40) form.Controls.Remove(this);
            Left -= movementSpeed;
        }

        private static int[] GetAirplaneProperties()
        {
            Random random = new Random();
            top = 10;
            left = 800;
            movementInterval = random.Next(90,110);
            attackInterval = random.Next(1100,1300);
            int[] result = new int[] {top,left,movementInterval,attackInterval };
            return result;
        }
    }
}
