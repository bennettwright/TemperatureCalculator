using System;
using Math
namespace TemperatureCalculator
{
    public class calculate
    {
        public calculate()
        {
        }

        private static decimal fahrenheit, humidity, windSpeed;

        public static decimal getTemp(string fahrenheit, int windSpeed)
        {
            if (validator(fahrenheit))
                return getWindChill();
            

        }

        public static decimal getTemp(string fehrenheit, string humidity, int windSpeed)
        {
            
        }


        //making humid null by default because we don't need humidity
        //every time in order to get the temp....and don't want to be passing null
        //in the params every time
        private static bool validator(string fDegrees, string humid = null) =>
            (humid == null) ? Decimal.TryParse(fDegrees, out fahrenheit) :
                                    Decimal.TryParse(fDegrees, out fahrenheit) &&
                                            Decimal.TryParse(humid, out humidity);
    }
}
