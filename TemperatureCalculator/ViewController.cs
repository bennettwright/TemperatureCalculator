using System;
using System.Diagnostics;
using UIKit;

namespace TemperatureCalculator
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        private bool humid = false;
        private void compute(object sender, EventArgs args)
        {
            //try
            //{
            if (!humid)
                ResultLabel.Text = String.Format("Result: {0:0.00}F",
                    calculate.getWindChill(Double.Parse(FahrenheitField.Text),
                                      (int)WindSlider.Value));
            else
                ResultLabel.Text = String.Format("Result: {0:0.00}F",
                        calculate.getHeatIndex(Double.Parse(FahrenheitField.Text),
                                               Double.Parse(HumidityField.Text) / 100));
            //}
            //catch(ArgumentException ex)
            //{
            //    new UIAlertView("Error", ex.Message, null, "Ok", null).Show();
            //}

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            HumiditySwitch.ValueChanged += (sender, e) =>
            {
                //action sheet for turning on humidity
                var humidityActionOn = new UIActionSheet("Are you sure you want humidity?", null, "Cancel", null, "Yes");
                //humidityActionOn.AddButton("Yes");
                //humidityActionOn.AddButton("Cancel");
                //humidityActionOn.CancelButtonIndex = 1;

                humidityActionOn.ShowInView(View);

                //if (true)
                humid = HumiditySwitch.On;
                HumidityField.Enabled = HumiditySwitch.On;
                
            };

            //dismiss the keyboard on background touch
            View.AddGestureRecognizer(new UITapGestureRecognizer(() => 
            {
                FahrenheitField.ResignFirstResponder();
                HumidityField.ResignFirstResponder();
            }));

            FahrenheitField.EditingDidEnd += (sender, e) =>
            {
                compute(sender, e);
                WindSlider.Enabled = true;
            };

            //when slider value is changed, update UI
            WindSlider.ValueChanged += (sender, e) =>
            {
                WindSpeedLabel.Text = String.Format("Wind Speed (0-100 mph): {0}",
                                        (int)WindSlider.Value);
                compute(sender, e);
            };

        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
