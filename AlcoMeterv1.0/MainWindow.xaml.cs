
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
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AlcoMeterv1._0.Calculator;
using AlcoMeterv1._0.Helpers;

namespace AlcoMeterv1._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AddingDrinkHelper _helper = new AddingDrinkHelper();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _helper;
        }

        private void AddDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            var addDrink = new AddDrink();
            addDrink.ShowDialog(_helper);
        }

        private void RemoveDrinkButton_Click(object sender, RoutedEventArgs e)
        {
            _helper.RemoveDrink(_helper.SelectedDrink);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if(_helper.Drinks.Count <=0)
            {
                MessageBox.Show("Add some drinks", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int sex;
            int calories;
            if(MaleRadioButton.IsChecked == true)
            {
                sex = 1;
            }
            else if (FemaleRadioButton.IsChecked == true)
            {
                sex = 0;
            }
            else
            {
                MessageBox.Show("Enter your sex!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            double weight;
            if(!double.TryParse(WeightTextBox.Text, out weight))
            {
                MessageBox.Show("Enter valid weight!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(!int.TryParse(FoodTextBox.Text, out calories))
            {
                MessageBox.Show("Enter valid calories eaten (zero is valid)!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var promille = SoberMeter.GetPromille(weight, sex, _helper.GetAlcohol())/10;
            var time = SoberMeter.GetSoberTime(weight, calories, sex, _helper.GetAlcohol());
            MessageBox.Show($"{TimeHelper.GetTime(time)}\nPercent of alcohol in blood: {promille}%");
        }
    }
}
