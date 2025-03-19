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
    public partial class ReservationScreen : Form
    {
        private readonly Fidel_Parking_Management_SystemEntities _db;
        private static ReservationScreen _instance;
        public ReservationScreen()
        {
            InitializeComponent();
            _db = new Fidel_Parking_Management_SystemEntities();
        }


        //Singleton form
        public static ReservationScreen Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new ReservationScreen();
                }
                return _instance;
            }
        }

        private void ReservationScreen_Load(object sender, EventArgs e)
        {
            var reservations = _db.VehiclesDetecteds.Select(q => new
            {
               q.TicketNumber,
               q.Operation,
               q.LicensePlateNumber,
               q.Make,
               q.Model,
               q.Color,
               q.EntryDate,
               q.EntryTime,

            }).ToList();
            gvReservations.DataSource = reservations;
            



        }


    }
}
