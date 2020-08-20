using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace AlcoMeterv1._0.Calculator
{
    static class SoberMeter
    {
        public static double GetPromille(double weight, int sex, double alcohol)
        {
            double coef;
            if (sex == 1)
            {
                coef = 1.1;
            }
            else
            {
                coef = 0.9;
            }
            var blood = weight * 0.0085 * coef;
            var promille = alcohol * 100 / blood;
            return promille;
        }

        public static double GetSoberTime(double weight, int calories, int sex, double alcohol)
        {
            double coef = 1;
            if(calories <1000)
            {
                coef = 1.1;
            }
            else if(calories >2000)
            {
                coef = 0.9;
            }

            if (sex == 1)
            {
                return 525000 * alcohol * coef / weight;
            }
            else
            {
                return 630000 * alcohol * coef / weight;
            }
        }
    }
}
