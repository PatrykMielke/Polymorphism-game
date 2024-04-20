using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruspki1
{
    internal interface IPlayerFunctions
    {
        void Move(object sender, KeyEventArgs args);
        void Attack(object sender, KeyEventArgs args);
    }
}
