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

namespace DemoEx
{
    public partial class AddItemWindow : Window
    {
        public string InputText { get; private set; }

        public AddItemWindow()
        {
            InitializeComponent();
            InputTextBox.Focus();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            InputText = InputTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(InputText))
            {
                MessageBox.Show("Введите непустой текст.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
        }
    }
}
