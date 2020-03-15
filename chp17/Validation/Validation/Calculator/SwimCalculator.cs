using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Validation.Calculator
{
    public struct SwimCalcResult
    {
        public float Distance;
        public float Calories;
        public float Pace;
    }

    public class SwimCalculator
    {
        private const float metersToMiles = 0.00062137119223733f;
        private const float minsPerHour = 60f;

        public static SwimCalcResult PerformCalculation(int lapsParam, int lengthParam, int minsParam, int calsPerHourParam)
        {
            foreach (int paramValue in new[] { lapsParam, lengthParam, minsParam, calsPerHourParam })
            {
                if (paramValue < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            SwimCalcResult result = new SwimCalcResult();

            result.Distance = (lapsParam * lengthParam) * metersToMiles;
            result.Calories = (minsParam / minsPerHour) * calsPerHourParam;
            result.Pace = (minsParam * minsPerHour) / lapsParam;

            return result;
         }
    }
}