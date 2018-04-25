using System;
namespace TemperatureCalculator
{
    public class calculate
    {
        public calculate()
        {
        }

        //equation variables
        const double E1 = 35.74, E2 = 0.6215, E3 = 35.75, E4 = 0.4275, E5 = 0.16;

        public static double getTemp(double fDegrees, int windSpeed)
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

        public static double getTemp(double fehrenheit, string humidity, int windSpeed)
        {
            throw new NotImplementedException();
        }
    }
}
