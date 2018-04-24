using System;
namespace TemperatureCalculator
{
    public class calculate
    {
        public calculate()
        {
        }

        private static double fahrenheit, humidity;

        //equation variables
        const double E1 = 35.74, E2 = 0.6215, E3 = 35.75, E4 = 0.4275, E5 = 0.16;

        public static double getTemp(string fDegrees, int windSpeed)
        {
            if (validator(fDegrees))
                return (35.74 + (0.6215 * fahrenheit) - Math.Pow(35.75 * windSpeed, 0.16) 
                        + (0.4275 * fahrenheit) * Math.Pow(windSpeed, 0.16));
            throw new ArgumentException("Not valid input");
        }

        public static double getTemp(string fehrenheit, string humidity, int windSpeed)
        {
            throw new NotImplementedException();
        }


        //making humid null by default because we don't need humidity
        //in order to get the temp....and don't want to be passing null
        //in the params every time
        private static bool validator(string fDegrees, string humid = null) =>
            (humid == null) ? Double.TryParse(fDegrees, out fahrenheit) :
                                    Double.TryParse(fDegrees, out fahrenheit) &&
                                            Double.TryParse(humid, out humidity);
    }
}
