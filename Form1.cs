using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kruspki1
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public static List<PictureBox> enemies = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();

            KeyDown += ResetGame;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartGame();
        }
        private void SpawnAirplane(object sender, EventArgs e)
        {
            enemies.Add(new Airplane(this));
        }
        
        private void StartGame()
        {
            Player player = new Player(this);

            Timer spawnAirplaneTimer = new Timer();
            spawnAirplaneTimer.Interval = 3000;
            spawnAirplaneTimer.Tick += SpawnAirplane;
            spawnAirplaneTimer.Start();
        }
        private void ResetGame(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                foreach (PictureBox enemy in enemies)
                {
                    Controls.Remove(enemy);
                }
            }

        }
        private void GameOver()
        {
            Timer collisionTimer = new Timer();
            collisionTimer.Interval = 20;

        }
    }
}
