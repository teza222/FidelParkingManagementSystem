using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FidelParkingManagementSystem
{
    public partial class ManageLotScreen : Form
    {
        private static ManageLotScreen _instance;
        public ManageLotScreen()
        {
            InitializeComponent();
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            tbCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //Singleton form
        public static ManageLotScreen Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new ManageLotScreen();
                }
                return _instance;
            }
        }

    }
}