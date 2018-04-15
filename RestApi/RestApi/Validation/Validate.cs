using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Validation
{
    public class Validate
    {
        private static double[] values = new double[]{2.0,2.5,3.0,3.5,4.0,4.5,5.0};

        public static bool IsBetween(double value)
        {
            return true;
        }

        public static bool IsCorrect(double value)
        {
            foreach(double v in values)
            {
                if(v == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}