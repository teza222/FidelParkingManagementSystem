using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FidelParkingManagementSystem
{

   

    public partial class ManageLotScreen : Form
    {
        private static ManageLotScreen _instance;
        private readonly Fidel_Parking_Management_SystemEntities _db;
        private string vehicleMake;
        private string vehicleModel;
        private string licensePlate;
        private int ticketNumber;
        private string operation;
        private string entryDate;
        private string entryTime;
        private string exitDate;
        private string exitTime;
        private string color;
        private string duration;
        private int mediaId;
        private string imgUrl;
       
      

        static Random random = new Random();

        List<string> carMake = new List<string>
        {
            "Honda",
            "Toyota",
            "Ford",
            "BMW",
            "Nissan",
            //"Mazda"
        };

        
        //list of car models simulating possible car models that can be detected by the camera
        List<CarMake> carModle = new List<CarMake>
        {
            new CarMake
            {
                Make = "Honda",
                Models = new List<string> { "Civic", "Accord", "CR-V", "HR-V", "Odyssey", "Insight", "Fit" }
            },
            new CarMake
            {
                Make = "Toyota",
                Models = new List<string> { "Camry", "Corolla", "RAV4", "Prius", "Tacoma", "Sienna", "Tundra" }
            },
            new CarMake
            {
                Make = "Ford",
                Models = new List<string> { "F-150", "Mustang", "Explorer", "Escape", "Ranger", "Bronco", "Maverick" }
            },
            new CarMake
            {
                Make = "BMW",
                Models = new List<string> { "3 Series", "5 Series", "7 Series", "X3", "X5", "X7", "i8" }
            },
            new CarMake
            {
            Make = "Nissan",
            Models = new List<string> { "Altima", "Maxima", "Sentra", "Rogue", "Murano", "Pathfinder", "Versa" }
            },
            new CarMake
            {
            Make = "Mazda",
            Models = new List<string> { "Mazda3", "Mazda6", "CX-5", "CX-9", "MX-5 Miata", "CX-30", "MX-30" }
            },
        };

        // Generates a random license plate number simulating scanner reading.
        static string GenerateLicensePlate()
        {
            char[] letters = new char[2];
            char[] digits = new char[4];

            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)('A' + random.Next(0, 26));
            }

            for (int i = 0; i < digits.Length; i++)
            {
                digits[i] = (char)('0' + random.Next(0, 10));
            }

            return new string(digits) +" "+ new string(letters);
        }

        // Generates a random car make and model. simulating a car detected by a Ai camera
        private void GenerateMake()
        {
            Random random = new Random();
            int randomIndex = random.Next(carMake.Count);
            operation = "Entry";
            entryDate = DateTime.Now.ToString("dd/MM/yyyy");
            entryTime = DateTime.Now.ToString("HH:mm:ss");
            exitDate = "N/A";
            exitTime = "N/A";
            ticketNumber = random.Next(1000, 9999);
            color = "Red";
            duration = "N/A";
            imgUrl = "TestImage34.com";

            vehicleMake = carMake[randomIndex];
            vehicleModel = carModle[randomIndex].Models[random.Next(carModle[randomIndex].Models.Count)];
            licensePlate = GenerateLicensePlate();

            // Display the details.
            lbOperation.Text = operation;
            lbEntryTime.Text = entryTime;
            lbExitTime.Text = exitTime;
            lbColor.Text = color;
            lbDuration.Text = duration;
            lbmake.Text = vehicleMake;
            lbModel.Text = vehicleModel;
            lbLicensePlate.Text = licensePlate;
     
        }

        public ManageLotScreen()
        {
            InitializeComponent();
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            _db = new Fidel_Parking_Management_SystemEntities();
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

        private async void btEntryGate_Click(object sender, EventArgs e)
        {
            GenerateMake();

            try
            {
                //demo detected car image simulating a car detected by the camera
                
                string imagePath = $"dectected_cars/{vehicleModel}.png";
                Image image = Image.FromFile(imagePath);
                imgCarImage.Image = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //saving vehicle so-called url to the database
            var vehiclePhoto = new Medium();
            vehiclePhoto.url = "vehicleModel";
            _db.Media.Add(vehiclePhoto);
            _db.SaveChanges();

            //get vehicle photo id after saving to the database
            int vehiclePhotoID = vehiclePhoto.id;

            //save the vehicle details to the database
            var vehicleDetected = new VehiclesDetected();
            vehicleDetected.Operation = operation;
            vehicleDetected.EntryDate = entryDate;
            vehicleDetected.EntryTime = entryTime;
            vehicleDetected.ExitDate = exitDate;
            vehicleDetected.ExitTime = exitTime;
            vehicleDetected.LicensePlateNumber = licensePlate;
            vehicleDetected.Make = vehicleMake;
            vehicleDetected.Model = vehicleModel;
            vehicleDetected.Color = "Red";
            vehicleDetected.Duration = duration;
            vehicleDetected.MediaId = vehiclePhotoID;

            _db.VehiclesDetecteds.Add(vehicleDetected);
            _db.SaveChanges();

            lbTicket.Text = vehicleDetected.TicketNumber.ToString();
        }

    }
}
// Class to hold a car make and its models.
public class CarMake
{
    public string Make { get; set; }
    public List<string> Models { get; set; }
}

