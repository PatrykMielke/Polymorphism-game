using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kruspki1
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal class Player : Character, IPlayerFunctions
    {
        Timer jumpTimer = new Timer();
        static int jumpHeight = 200;
        static int defaultHeight = 420;
        static int upPerTick = 10;
        public Player(Form form)
        {
            this.form = form;
            movementSpeed = 15;
            movementInterval = 20;
            attackInterval = 200;
            jumpTimer.Interval = movementInterval;

            Top = defaultHeight;
            Left = 100;
            BackColor = Color.BlueViolet;
            Size = new Size(40,60);
            Tag = "Player";

            BringToFront();

            form.Controls.Add(this);
            form.KeyDown += Move;
            
        }

        public new void Move(object sender, KeyEventArgs args)
        {
            if(args.KeyCode == Keys.Right)
            {
                if (Left + Size.Width > 770) return;
                Left += movementSpeed;
            }
            else if (args.KeyCode == Keys.Left)
            {
                if (Left < 20) return;
                Left -= movementSpeed;
            }
            else if (args.KeyCode == Keys.Up)
            {
                if (jumpTimer.Enabled) return;

                jumpTimer.Tick += Jump;
                jumpTimer.Start();
            }
        }
        private void Jump(object sender, EventArgs args) {
            if (Top == jumpHeight)
            {
                jumpTimer.Tick -= Jump;
                jumpTimer.Tick += JumpDown;
            }
            else
            {
                Top -= upPerTick;
            }
            
        }
        private void JumpDown(object sender, EventArgs args)
        {
            if (Top == defaultHeight)
            {
                jumpTimer.Tick -= JumpDown;
                jumpTimer.Stop();
            }
            else
            {
                Top += upPerTick;
            }
        }
        public void Attack(object sender, KeyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
