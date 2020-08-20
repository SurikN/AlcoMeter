using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AlcoMeterv1._0.Calculator;

namespace AlcoMeterv1._0.Helpers
{
    public class AddingDrinkHelper
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Drink> _drinks = new ObservableCollection<Drink>();
        private Drink _selectedDrink;

        public ObservableCollection<Drink> Drinks
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

        public Drink SelectedDrink
        {
            get
            {
                return _selectedDrink;
            }
            set
            {
                _selectedDrink = value;
                OnPropertyChanged();
            }
        }

        public void RemoveDrink(string drink)
        {
            var drinkToRemove = Drinks.FirstOrDefault(d => d.ToString() == drink);
            if(drinkToRemove == null)
            {
                return;
            }
            Drinks.Remove(drinkToRemove);
        }

        public void RemoveDrink(Drink drink)
        {
            if(drink != null)
            {
                Drinks.Remove(drink);
            }
        }

        public double GetAlcohol()
        {
            double alcohol = 0;
            foreach(Drink drink in Drinks)
            {
                alcohol += drink.DrinkAmount * drink.DrinkAlcohol / 100000; //100 for percentage an 1000 for grams => kg
            }
            return alcohol;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

