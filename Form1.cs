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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Player player = new Player(this);

            Timer timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += SpawnAirplane;
            timer.Start();
        }
        private void SpawnAirplane(object sender, EventArgs e)
        {
            new Airplane(this);
        }

    }
}
