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
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }


        private void MainScreen_Load(object sender, EventArgs e)
        {
            _showLoginScreen();
        }

        private void loginToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            _showLoginScreen();
        }

        private void _showLoginScreen()
        {

            //Showing the login screen in the center of the mdi parent on load
            LoginScreen loginScreen = LoginScreen.Instance;

            loginScreen.MdiParent = this;
            // Set the StartPosition to Manual
            loginScreen.StartPosition = FormStartPosition.Manual;

            // Calculate the center position
            int x = (this.ClientSize.Width - loginScreen.Width) / 2;
            int y = (this.ClientSize.Height - loginScreen.Height) / 2;

            // Set the location of the child form
            loginScreen.Location = new Point(x, y);
            loginScreen.Show();
            loginScreen.BringToFront();
            loginScreen.Focus();

        }



        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manageLotToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            //Showing the managelot screen in the center of the mdi parent on load
            ManageLotScreen manageLotScreen = ManageLotScreen.Instance;
            MainScreen mainScreen = new MainScreen();
            manageLotScreen.MdiParent = this;
            manageLotScreen.Show();
            manageLotScreen.BringToFront();
            manageLotScreen.Focus();


        }

      
    }
}
