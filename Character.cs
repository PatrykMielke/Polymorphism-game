﻿using System;
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
    internal abstract class Character
    {
        protected Form form;
        protected PictureBox character = new PictureBox();

        protected int movementSpeed;
        protected int timerInterval;
        protected static int top, left, movementInterval, attackInterval;
    }
}