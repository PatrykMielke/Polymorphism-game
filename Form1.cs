using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruspki1
{
    public partial class Form1 : Form
    {
        public static List<PictureBox> characters = new List<PictureBox>();
        private Timer spawnAirplaneTimer = new Timer();
        private Timer collisionTimer = new Timer();
        private bool isGameRunning = false;
        private Player player;

        public Form1()
        {
            InitializeComponent();

            KeyDown += KeyActions;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }
        private void SpawnAirplane(object sender, EventArgs e)
        {
            characters.Add(new Airplane(this));
        }
        
        private void StartGame()
        {
            isGameRunning = true;

            label1.Text = "Press Enter to reset";

            Player player = new Player(this);
            this.player = player;

            characters.Add(player);
            characters.Add(new Soldier(this, true));
            characters.Add(new Cannon(this));

            spawnAirplaneTimer.Interval = 3000;
            spawnAirplaneTimer.Tick += SpawnAirplane;
            spawnAirplaneTimer.Start();

            collisionTimer.Interval = 20;
            collisionTimer.Tick += CheckCollision;
            collisionTimer.Start();
        }

        private void CheckCollision(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is PictureBox && ctrl.Tag.Equals("RIP"))
                {
                    if (ctrl.Bounds.IntersectsWith(player.Bounds))
                    {
                        GameOver();
                    }
                }
            }
        }

        private void ResetGame()
        {
            ClearCharacters();
        }

        private void ClearCharacters()
        {
            label1.Text = "Press Enter to start";

            spawnAirplaneTimer.Dispose();
            collisionTimer.Dispose();

            isGameRunning = false;

            foreach (PictureBox character in characters)
            {
                Controls.Remove(character);
                character.Dispose();
            }
        }

        private void GameOver()
        {
            ResetGame();
            MessageBox.Show("Game over");
        }

        private void KeyActions(object sender, KeyEventArgs e)
        {
            if (isGameRunning)
            {
                if (e.KeyCode.Equals(Keys.Enter)) ResetGame();
            }
            else
            {
                if (e.KeyCode.Equals(Keys.Enter)) StartGame();
            }

        }
    }
}
