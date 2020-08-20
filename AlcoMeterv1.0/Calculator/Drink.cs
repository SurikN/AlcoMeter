using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlcoMeterv1._0.Calculator
{
    public class Drink
    {
        public string DrinkName { get; set; }
        public int DrinkAmount { get; set; }
        public double DrinkAlcohol { get; set; }

        public Drink(string representation)
        {
            var array = representation.Split('|');
            if(array.Length != 3)
            {
                throw new ApplicationException("Not readable DataBase format!");
            }
            DrinkName = array[0];
            int amount;
            if(!int.TryParse(array[1], out amount))
            {
                throw new ApplicationException("Not readable DataBase format!");
            }
            double alcohol;
            if (!double.TryParse(array[2], out alcohol))
            {
                throw new ApplicationException("Not readable DataBase format!");
            }
            DrinkAmount = amount;
            DrinkAlcohol = alcohol;
        }

        public Drink(string name, int amount, double alcohol)
        {
            DrinkName = name;
            DrinkAmount = amount;
            DrinkAlcohol = alcohol;
        }

        public override string ToString()
        {
            return $"{DrinkName}, {DrinkAmount} ml, {DrinkAlcohol}%";
        }
    }
}
