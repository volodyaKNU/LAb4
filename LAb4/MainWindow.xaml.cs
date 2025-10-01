using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using LAb4.mainLogic;

namespace LAb4
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Animal> _animals = new();

        public MainWindow()
        {
            InitializeComponent();
            lbAnimals.ItemsSource = _animals;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            txtOutput.Clear();

            if (!int.TryParse(txtAge.Text, out var age) || age < 0)
            {
                MessageBox.Show("Вік має бути цілим невід’ємним числом.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var type = (cbType.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content?.ToString();

            Animal a = type == "Dog" ? new Dog(age) : new Cat(age);

            var extra = txtExtra.Text?.Trim();
            if (!string.IsNullOrWhiteSpace(extra))
            {
                if (a is Dog)
                    SetPrivateStringProperty(a, "Breed", extra);
                else if (a is Cat)
                    SetPrivateStringProperty(a, "WoolType", extra);
            }

            _animals.Add(a);
            txtExtra.Clear();
        }

        private static void SetPrivateStringProperty(object target, string propertyName, string value)
        {
            var prop = target.GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
            prop?.SetValue(target, value);
        }

        private Animal? SelectedAnimal() => lbAnimals.SelectedItem as Animal;

        private void BtnEat_Click(object sender, RoutedEventArgs e)
        {
            var a = SelectedAnimal();
            if (a == null) { WarnSelect(); return; }
            txtOutput.Text = a.Eat();
        }

        private void BtnSleep_Click(object sender, RoutedEventArgs e)
        {
            var a = SelectedAnimal();
            if (a == null) { WarnSelect(); return; }
            txtOutput.Text = a.Sleep();
        }

        private void BtnId_Click(object sender, RoutedEventArgs e)
        {
            var a = SelectedAnimal();
            if (a == null) { WarnSelect(); return; }
            txtOutput.Text = a.getIDData();
        }

        private void BtnDogInfo_Click(object sender, RoutedEventArgs e)
        {
            var a = SelectedAnimal();
            if (a == null) { WarnSelect(); return; }

            if (a is Dog d)
                txtOutput.Text = d.getAgeData();
            else
                txtOutput.Text = "Оберіть собаку.";
        }

        private void BtnCatCheckup_Click(object sender, RoutedEventArgs e)
        {
            var a = SelectedAnimal();
            if (a == null) { WarnSelect(); return; }

            if (a is Cat c)
                txtOutput.Text = c.GetCheckupResults();
            else
                txtOutput.Text = "Оберіть кішку.";
        }

        private void btnAvg_Click(object sender, RoutedEventArgs e)
        {
            var avg = AnimalAnalysis.getAverage5YearOldAnimal(_animals.ToList());
            txtOutput.Text = $"Середній вік тварин старших 5 років: {avg}";
        }

        private static void WarnSelect()
        {
            MessageBox.Show("Спочатку виберіть тварину зі списку.", "Підказка", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
