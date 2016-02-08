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

namespace Oef3_async_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await updateAsync();
            }
            catch
            {

            }
            
        }

        private async Task updateAsync()
        {
            for (int i = 0; i < 101; i++)
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(100);
                });
                textBlock.Text = i.ToString();
                progressBar.Value = i;
            }
            MessageBox.Show("Called after async process started.", "", MessageBoxButton.OK);
        }
    }
}
