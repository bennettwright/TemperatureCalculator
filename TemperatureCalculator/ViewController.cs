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
            if (FahrenheitField.Text == String.Empty)
                FahrenheitField.Text = "0";

            if (HumidityField.Text == String.Empty)
                HumidityField.Text = "0";
            

            if (humid)
                ResultLabel.Text = String.Format("Result: {0} F",
                    Math.Round(calculate.getHeatIndex(Double.Parse(FahrenheitField.Text),
                        Double.Parse(HumidityField.Text) / 100)));

            else
                ResultLabel.Text = String.Format("Result: {0} F",
                   Math.Round(calculate.getWindChill(Double.Parse(FahrenheitField.Text),
                       (int)WindSlider.Value)));
        }

        partial void switchActionSheet(UISwitch sender)
        {
            string title = HumiditySwitch.On ? "Turn on Humidity?" : "Turn off Humidity";
            var controller = UIAlertController.Create(title, null, UIAlertControllerStyle.ActionSheet);

            var yesAction = UIAlertAction.Create("Yes, I'm Sure!", UIAlertActionStyle.Default,
                (action) =>
                {
                    humid = HumidityField.Enabled = HumiditySwitch.On = HumiditySwitch.On;
                });


            var noAction = UIAlertAction.Create("No way!", UIAlertActionStyle.Cancel,
                (action) =>
                {
                    humid = HumidityField.Enabled = HumiditySwitch.On = !HumiditySwitch.On;
                });

            controller.AddAction(yesAction);
            controller.AddAction(noAction);
            var ppc = controller.PopoverPresentationController;
            if (ppc != null)
            {
                ppc.SourceView = sender;
                ppc.SourceRect = sender.Bounds;
            }

            PresentViewController(controller, true, null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            //dismiss the keyboard on background touch
            View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                FahrenheitField.ResignFirstResponder();
                HumidityField.ResignFirstResponder();

            }));

            HumidityField.EditingDidEnd += (sender, e) =>
            {
                compute(sender, e);
                HumidityLabel.Text = String.Format("Humidity: {0}%", HumidityField.Text);
            };

            FahrenheitField.EditingDidEnd += (sender, e) =>
            {
                compute(sender, e);
            };

            //when slider value is changed, update UI
            WindSlider.ValueChanged += (sender, e) =>
            {
                WindSpeedLabel.Text = String.Format("Wind Speed (0-100 mph): {0}",
                                        (int)WindSlider.Value);

                //make sure text isnt empty
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
