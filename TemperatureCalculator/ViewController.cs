using System;

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
            try
            {
                if (!humid)
                    ResultLabel.Text = String.Format("Result: {0:0.00}", 
                                                     calculate.getTemp(FahrenheitField.Text, (int)WindSlider.Value));
            }
            catch(ArgumentException ex)
            {
                new UIAlertView("Error", ex.Message, null, "Ok", null).Show();
            }

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            HumiditySwitch.ValueChanged += (sender, e) =>
            {
                humid = HumiditySwitch.On;
                HumidityField.Enabled = HumiditySwitch.On;
            };

            FahrenheitField.EditingDidEndOnExit += (sender, e) =>
            {
                compute(sender, e);
                ((UITextField)sender).ResignFirstResponder();
            };
            WindSlider.ValueChanged += compute;

        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
