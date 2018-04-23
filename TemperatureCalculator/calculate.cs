using System;
using Math
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
                return E1 + (E2 * fahrenheit) - Math.Pow(E3 * windSpeed, E5) 
                                                    + (E4 * fahrenheit) * Math.Pow(windSpeed, E5);
            throw new ArgumentException("Not valid input");
        }

        public static double getTemp(string fehrenheit, string humidity, int windSpeed)
        {
            
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
