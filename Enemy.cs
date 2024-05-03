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
    [System.ComponentModel.DesignerCategory("Code")]
    internal abstract class Enemy : Character, IEnemyFunctions
    {
        protected Timer attackFrequencyTimer = new Timer();
        protected Timer movementTimer = new Timer();
        protected Random random = new Random();

        protected Enemy()
        {
            Tag = "RIP";

            movementTimer.Tick += Move;
            attackFrequencyTimer.Tick += Attack;
        }


        public abstract void Attack(object sender, EventArgs args);

        public abstract new void Move(object sender, EventArgs args);
    }
}
