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

            character.Top = defaultHeight;
            character.Left = 100;
            character.BackColor = Color.Pink;
            character.Size = new Size(60,60);

            character.BringToFront();

            form.Controls.Add(character);
            form.KeyDown += Move;
            
        }

        public void Move(object sender, KeyEventArgs args)
        {
            if(args.KeyCode == Keys.Right)
            {
                if (character.Left + character.Size.Width > 770) return;
                character.Left += movementSpeed;
            }
            else if (args.KeyCode == Keys.Left)
            {
                if (character.Left < 20) return;
                character.Left -= movementSpeed;
            }
            else if (args.KeyCode == Keys.Up)
            {
                if (jumpTimer.Enabled) return;

                jumpTimer.Tick += Jump;
                jumpTimer.Start();
            }
        }
        private void Jump(object sender, EventArgs args) {
            if (character.Top == jumpHeight)
            {
                jumpTimer.Tick -= Jump;
                jumpTimer.Tick += JumpDown;
            }
            else
            {
                character.Top -= upPerTick;
            }
            
        }
        private void JumpDown(object sender, EventArgs args)
        {
            if (character.Top == defaultHeight)
            {
                jumpTimer.Tick -= JumpDown;
                jumpTimer.Stop();
                return;
            }
            else
            {
                character.Top += upPerTick;
            }
        }
        public void Attack(object sender, KeyEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
