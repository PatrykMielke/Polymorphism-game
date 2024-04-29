using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Kruspki1
{
    internal class Enemy : Character, IEnemyFunctions
    {
        protected Timer attackFrequencyTimer = new Timer();
        protected Timer movementTimer = new Timer();
        protected Random randomNumber = new Random();

        protected Enemy(int[] ints)
        {
            Top = ints[0];
            Left = ints[1];
            Tag = "RIP";

            movementTimer.Interval = ints[2];
            movementTimer.Tick += Move;
            movementTimer.Start();

            attackFrequencyTimer.Interval = ints[3];
            attackFrequencyTimer.Tick += Attack;
            attackFrequencyTimer.Start();
        }


        public virtual void Attack(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        public virtual void Move(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
