using System;
using System.Drawing;
using System.Windows.Forms;

public class LoadingForm : Form
{
    private PictureBox spinner;

    public LoadingForm()
    {

        // Form Settings
        this.Text = "Loading...";
        this.Size = new Size(150, 150);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.ControlBox = false; // Removes close button

        // Spinning Loader (GIF)
        spinner = new PictureBox
        {
            Size = new Size(50, 50),
            Location = new Point(50, 40), // Centered
            Image = Image.FromFile("dectected_cars/loader.gif"), // Use an actual loading GIF
            SizeMode = PictureBoxSizeMode.StretchImage
        };
        this.Controls.Add(spinner);
    }
}
