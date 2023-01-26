using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncAwaitWpf
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

        private async void StartRnd_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.IsEnabled = false;
            var rnd = new Random();

            while (true)
            {
                var number = await GetRandomizeNumberAsync(rnd);
                _rndNumbers.Items.Add(number);
            }
        }

        private async Task<int> GetRandomizeNumberAsync(Random rnd)
        {
            var task = new Task<int>(GetRandomizeNumber, rnd);
            task.Start();
            return await task;
        }

        private int GetRandomizeNumber(object obj)
        {
            var rnd = (Random)obj;
            Thread.Sleep(200);
            int number = rnd.Next(10000);
            return number;
        }

        private void ClickMe_Click(object sender, RoutedEventArgs e)
        {
            _clickNumbers.Items.Add(_clckTxtBx.Text);
        }
    }
}
