using System;
namespace TemperatureCalculator
{
    public class calculate
    {
        public calculate()
        {
        }

        public static double getWindChill(double fDegrees, int windSpeed)
        {
            //temperature has to be below 50 degrees fahrenheit and
            //wind speed has to be above 3mph before wind chill can
            //take place
            if (fDegrees < 50 && windSpeed > 3)
                return 35.74 + (0.6215 * fDegrees) - 35.75 * Math.Pow(windSpeed, 0.16)
                 + (0.4275 * fDegrees) * Math.Pow(windSpeed, 0.16);

            else
                return fDegrees;
        }

        public static double getHeatIndex(double fehrenheit, double humidity)
        {
            return    -42.379 + (2.04901523 * fehrenheit) + (10.14333127 * humidity)
                         - (0.22475541 * fehrenheit * humidity) 
                         - (6.83783 * Math.Pow(10, -3) * Math.Pow(fehrenheit, 2))
                         - (5.481717 * Math.Pow(10, -2)  * Math.Pow(humidity, 2))
                         + (1.22874 * Math.Pow(10, -3) * Math.Pow(fehrenheit, 2) * humidity)
                         + (8.5282 * Math.Pow(10, -4) * fehrenheit * Math.Pow(humidity, 2))
                         - (1.99 * Math.Pow(10, -6) * Math.Pow(fehrenheit, 2) * Math.Pow(humidity, 2));
        }
    }
}
