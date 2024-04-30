using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Kruspki1
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal abstract class Character : PictureBox
    {
        protected Form form;

        protected int movementSpeed;
        protected int timerInterval;
        protected static int top, left, movementInterval, attackInterval;
    }
}
