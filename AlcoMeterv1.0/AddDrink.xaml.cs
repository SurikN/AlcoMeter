using AlcoMeterv1._0.Calculator;
using AlcoMeterv1._0.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlcoMeterv1._0
{
    /// <summary>
    /// Логика взаимодействия для AddDrink.xaml
    /// </summary>
    public partial class AddDrink : Window
    {
        private bool _isManual;
        private DrinksDataHelper _data = new DrinksDataHelper();
        private AddingDrinkHelper _helper;

        private string _drinkName;
        private int _drinkAmount;
        private double _drinkAlcohol;

        public AddDrink()
        {
            InitializeComponent();
            DataContext = _data;
            SelectAdding.IsChecked = true;
            SelectGrid.IsEnabled = !_isManual;
            ManualGrid.IsEnabled = _isManual;
        }

        private void SelectAdding_Checked(object sender, RoutedEventArgs e)
        {
            _isManual = false;
            SelectGrid.IsEnabled = true;
            ManualGrid.IsEnabled = false;
        }

        private void ManualAdding_Checked(object sender, RoutedEventArgs e)
        {
            _isManual = true;
            SelectGrid.IsEnabled = false;
            ManualGrid.IsEnabled = true;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if(_isManual)
            {
                if(string.IsNullOrEmpty(ManualDrinkNameBox.Text))
                {
                    MessageBox.Show("Enter valid name of drink!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }    
                _drinkName = ManualDrinkNameBox.Text;
                if (!int.TryParse(ManualAmountTextBox.Text, out _drinkAmount))
                {
                    MessageBox.Show("Enter valid amount of drink!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!double.TryParse(ManualAlcoholTextBox.Text, out _drinkAlcohol))
                {
                    MessageBox.Show("Enter valid amount of alcohol in drink!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                var drink = _data.GetDrink(SelectedDrinkNameBox.Text);
                int quantity;
                if(!int.TryParse(SelectedAmountTextBox.Text, out quantity))
                {
                    MessageBox.Show("Enter valid quantity of drinks!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                //_helper.Drinks.Add(new Drink(drink.DrinkName, drink.DrinkAmount * quantity, drink.DrinkAlcohol));
                _drinkName = drink.DrinkName;
                _drinkAmount = drink.DrinkAmount * quantity;
                _drinkAlcohol = drink.DrinkAlcohol;
            }
            _helper.Drinks.Add(new Calculator.Drink(_drinkName, _drinkAmount, _drinkAlcohol));
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public void ShowDialog(AddingDrinkHelper helper)
        {
            _helper = helper;
            ShowDialog();
        }
    }
}
