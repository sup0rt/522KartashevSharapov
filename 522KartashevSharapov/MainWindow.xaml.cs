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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _522KartashevSharapov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Count_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(X.Text) || string.IsNullOrWhiteSpace(Y.Text))
                {
                    MessageBox.Show("Введите значения X и Y.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (double.TryParse(X.Text, out double x) && double.TryParse(Y.Text, out double y))
                {
                    double result = 0;

                    if (doSh.IsChecked == true)
                    {               
                        if (x > 0 && y > 0)
                        {
                            result = Math.Pow(Math.Sinh(x) + y, 2) - Math.Sqrt(Math.Sinh(x) * y);
                        }

                        else if (x < 0 && y < 0)
                        {
                            result = Math.Pow(Math.Sinh(x) + y, 2) + Math.Sqrt(Math.Abs(Math.Sinh(x) * y));
                        }


                        else
                        {
                            result = Math.Pow(Math.Sinh(x) + y, 2) + 1;
                        }
                    }
                    else if (doSqare.IsChecked == true)
                    {
                        if (x > 0 && y > 0)
                        {
                            result = Math.Pow(Math.Pow(x, 2) + y, 2) - Math.Sqrt(Math.Pow(x, 2) * y);
                        }

                        else if (x < 0 && y < 0)
                        {
                            result = Math.Pow(Math.Pow(x, 2) + y, 2) + Math.Sqrt(Math.Abs(Math.Pow(x, 2) * y));
                        }

                        else
                        {
                            result = Math.Pow(Math.Pow(x, 2) + y, 2) + 1;
                        }
                    }
                    else if (doE.IsChecked == true)
                    {
                        if (x > 0 && y > 0)
                        {
                            result = Math.Pow(Math.Exp(x) + y, 2) - Math.Sqrt(Math.Exp(x) * y);
                        }

                        else if (x < 0 && y < 0)
                        {
                            result = Math.Pow(Math.Exp(x) + y, 2) + Math.Sqrt(Math.Abs(Math.Exp(x) * y));
                        }

                        else
                        {
                            result = Math.Pow(Math.Exp(x) + y, 2) + 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите функцию для расчета.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    Answer.Text = result.ToString("F4");
                }
                else
                {
                    MessageBox.Show("Введите корректные числовые значения для X и Y.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            X.Clear();
            Y.Clear();
            Answer.Clear();

            doSh.IsChecked = false;
            doSqare.IsChecked = false;
            doE.IsChecked = false;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            e.Cancel = result != MessageBoxResult.Yes;
        }
    }
}
