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
        public Airplane(Form form) : base(ConstructorProperties())
        {
            movementSpeed = 20;
            this.form = form;
            BackColor = Color.Gray;
            form.Controls.Add(this);
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

        private static int[] ConstructorProperties()
        {
            Random random = new Random();
            top = 10;
            left = 1000;
            movementInterval = random.Next(90,110);
            attackInterval = random.Next(1100,1300);
            return new int[] {top,left,movementInterval,attackInterval };
        }
    }
}
