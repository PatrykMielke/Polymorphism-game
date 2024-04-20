using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruspki1
{
    public interface IEnemyFunctions
    {
        void Move(object sender, EventArgs args);
        void Attack(object sender, EventArgs args);
    }
}
