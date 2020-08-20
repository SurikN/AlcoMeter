using AlcoMeterv1._0.Calculator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlcoMeterv1._0.Helpers
{
    class DrinksDataHelper
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<Drink> _drinks = new List<Drink>();

        public List<Drink> Drinks
        {
            get
            {
                return _drinks;
            }
            set
            {
                _drinks = value;
                OnPropertyChanged();
            }
        }

        public DrinksDataHelper()
        {
            using (var stream = new StreamReader(new FileStream("./Drinks.dat", FileMode.Open)))
            {
                while(!stream.EndOfStream)
                {
                    Drinks.Add(new Drink(stream.ReadLine()));
                }
            }
        }

        public Drink GetDrink(string toStringValue)
        {
            return Drinks.FirstOrDefault(d => d.ToString() == toStringValue);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
