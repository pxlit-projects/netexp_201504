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

namespace Oef2_ResponsiveUI2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource ts;
        public MainWindow()
        {
            InitializeComponent();
            button1.IsEnabled = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            button.IsEnabled = false;
            button1.IsEnabled = true;

            ts = new CancellationTokenSource();

            CancellationToken ct = ts.Token;
            Task update = Task.Run(() => { //more eff than Task.Factory.StartNew (or new Task() & t.start())
                for (int i = 0; i < 101; i++)
                {
                    if (ct.IsCancellationRequested)
                    {
                        // another thread decided to cancel
                        Console.WriteLine("task canceled");
                        break;
                    }

                    Dispatcher.Invoke(() =>
                    {
                        progressBar.Value = i;
                    });
                    Thread.Sleep(100);
                }
            });
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ts.Cancel();
            button.IsEnabled = true;
            button1.IsEnabled = false;
        }
    }
}
