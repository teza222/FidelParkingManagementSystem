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
    public partial class LoginScreen : Form
    {
        private static LoginScreen _instance;
        public LoginScreen()
        {
            InitializeComponent();
        }

        //Singleton form
        public static LoginScreen Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new LoginScreen();
                }
                return _instance;
            }
        }

        private void _showManageLotScreen()
        {
            this.Hide();

            //Showing the managelot screen in the center of the mdi parent on load
            ManageLotScreen manageLot = ManageLotScreen.Instance;
            MainScreen mainMDIWindow = new MainScreen();
            manageLot.MdiParent = this.MdiParent;
            manageLot.Show();
            manageLot.BringToFront();
            manageLot.Focus();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _showManageLotScreen();
        }
    }
}