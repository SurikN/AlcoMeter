using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoMeterv1._0.Helpers
{
    public static class TimeHelper
    {
        public static string GetTime(double time)
        {
            int minutes = (int)time;
            var hours = minutes / 60;
            minutes = minutes % 60;
            return $"Time to sober: {hours}h, {minutes}m";
        }
    }
}
