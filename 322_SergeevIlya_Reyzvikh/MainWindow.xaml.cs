using System;
using System.Windows;

namespace MathFunctionApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputTextBox.Text) || string.IsNullOrWhiteSpace(InputYTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните оба поля (x и y).", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double x, y;
            if (!double.TryParse(InputTextBox.Text, out x) || !double.TryParse(InputYTextBox.Text, out y))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для x и y.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double f_x = 0;

            // Выбор функции f(x)
            if (RadioButtonSh.IsChecked == true)
            {
                f_x = Math.Sinh(x); // Гиперболический синус
            }
            else if (RadioButtonX2.IsChecked == true)
            {
                f_x = Math.Pow(x, 2); // Квадрат
            }
            else if (RadioButtonEx.IsChecked == true)
            {
                f_x = Math.Exp(x); // Экспонента
            }

            // Вычисление d в зависимости от значений x и y
            double result;
            if (x > y)
            {
                result = Math.Pow(f_x - y, 3) + Math.Atan(f_x);
            }
            else if (y > x)
            {
                result = Math.Pow(y - f_x, 3) + Math.Atan(f_x);
            }
            else // y == x
            {
                result = Math.Pow(y + f_x, 3) + 0.5;
            }

            ResultTextBox.Text = result.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Clear();
            InputYTextBox.Clear();
            ResultTextBox.Clear();
            RadioButtonSh.IsChecked = false;
            RadioButtonX2.IsChecked = false;
            RadioButtonEx.IsChecked = false;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; // Отменяем закрытие окна
            }
        }
    }
}
