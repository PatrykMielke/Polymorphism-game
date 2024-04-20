using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruspki1
{
    internal class Soldier : Enemy
    {
        protected Soldier() : base(ReturnInts())
        {
        }

        public override void Attack(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        public override void Move(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }
        private static int[] ReturnInts()
        {
            top = 10;
            left = 800;
            movementInterval = 100;
            attackInterval = 1100;
            int[] result = new int[] { top, left, movementInterval, attackInterval };
            return result;
        }
    }
}
